namespace Individuell_inlämningsuppgift___Emil_Englesson;

class Program
{
    static List<string> history = new List<string>(); //Lista för resultaten i historiken

    static void Main(string[] args)
    {
        string? userInput1 = " ";
        string? userInput2 = " ";
        string? userInputOperator = " ";
        double result = 0;
        bool startCalc = false;
        bool restart = false;

        Console.WriteLine("Miniräknare");
        Console.WriteLine("--------------------------");
        Console.WriteLine("");
        Console.WriteLine("Välkommen till denna miniräknare gjord av Emil Englesson.");

        do
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Skriv 's' för att starta, 'h' för historiken, eller 'a' för att avsluta programmet");
                string? startInput = Console.ReadLine();

            if (startInput?.ToLower() == "h")
            {
                ShowHistory();
            }
            else if (startInput?.ToLower() == "s")
            {
                startCalc = true;
            }
            else if (startInput?.ToLower() == "a")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Inte ett giltigt val, vänligen försök igen.");
                Console.WriteLine("");
            }

            } while (startCalc == false);
                    
            do
            {
                Console.WriteLine("Skriv in ditt första tal, och tryck ENTER:");
                userInput1 = Console.ReadLine();

            } while (UserInputs(userInput1) == false);

            UserInputs(userInput1);

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Skriv in tecknet för vilket alternativ du vill använda, och tryck ENTER:");
                Console.WriteLine("+  Addera");
                Console.WriteLine("-  Subtrahera");
                Console.WriteLine("*  Multiplicera");
                Console.WriteLine("/  Dividera");
                userInputOperator = Console.ReadLine();

            } while (UserInputOperator(userInputOperator) == false);

            UserInputOperator(userInputOperator);
            
            do
            {
                do
                {
                    Console.WriteLine("Skriv in ditt andra tal, och tryck ENTER:");
                    userInput2 = Console.ReadLine();
                } while (UserInputs(userInput2) == false);
                
                UserInputs(userInput2); //Kontrollerar först att det är ett tal
                
            } while (DivideByZero(userInputOperator, userInput2) == false); //Kontrollerar ifall "0" blivit inskrivet och "/" valdes i föregående steg

            

            double inputNumber1 = Convert.ToDouble(userInput1);
            double inputNumber2 = Convert.ToDouble(userInput2);

            result = InputCalculations(inputNumber1, userInputOperator, inputNumber2);
            

            string endResult = $"{userInput1} {userInputOperator} {userInput2} = " + result;
            Console.WriteLine($"{endResult}");
            Console.WriteLine("");
            history.Add(endResult); //Lägger till i historiken ifall miniräknaren börjar om

            do
            {
            Console.WriteLine("Välj ett av valen:\n 1. Meny(ny uträkning, se historik)\n 2. Avsluta miniräknaren");
            string? endQuestion = Console.ReadLine();

            if (endQuestion == "1")
            {
                startCalc = false;
                restart = true;
            }
            else if (endQuestion == "2")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Inget val gjort");
            }
            } while (restart == false);

        } while (startCalc == false);
    }

    static bool UserInputs(string? UserInput)
    {
        bool userInput = false;
        do
        {
        
        if (UserInput == "" || !int.TryParse(UserInput, out int notValid1)){ 
            Console.WriteLine("Du behöver skriva in ett tal för att starta, försök igen.");
            return false;
        } 
        else
        {
            userInput = true;
            return true;
        }
        } while (userInput == false);          
    } //Kontrollerar att det första talet är ett nummer  

    static bool DivideByZero(string? divide, string? zero)
    {
    if (divide == "/" && zero == "0")
        {
            Console.WriteLine("");
            Console.WriteLine("Ogiltig inmatning! Skriv in ett annat värde");
            Console.WriteLine("");
            return false;
        }
        else{
            return true;
        }
    } //Kontrollerar så att det inte går att dividera med 0

    static bool UserInputOperator(string? userInputOperator)
    {
        bool operatorInput = false;
        do
        {

        if (userInputOperator == "+" || userInputOperator == "-" || userInputOperator == "*" || userInputOperator == "/") 
            {
                operatorInput = true;
                return true;
            }
            else
            {
                Console.WriteLine("Inmatningen var inte ett tecken, försök igen.");
                return false;
            }
        } while (operatorInput == false);        
    } //Kontrollerar så att ett av de giltiga tecknen skrivs in

    static double InputCalculations(double firstInput, string? Operator, double secondInput)
    {
        double result = 0;

        if (Operator == "+")
        {
            result = firstInput + secondInput;
            return result;
            
        }
        else if (Operator == "-")  
        {
            result = firstInput - secondInput;
            return result;
        }
        else if (Operator == "*")  
        {
            result = firstInput * secondInput;
            return result;
        }
        else if (Operator == "/")  
        {
            result = firstInput / secondInput;
            return result;
        }
        else
        {
            return 0;
        }
    } //Utför de matematiska operationerna


    static void ShowHistory()
    {
        if (history.Count > 0)
        {
            Console.WriteLine("Historik:");
            foreach (string prevCalculations in history)
            {
                Console.WriteLine(prevCalculations);
            }
        } //Skriver ut uträkningarna ifall där finns några, annas visas texten nedan
        else
        {
            Console.WriteLine("Inga uträkningar gjorda");
        }
    } 
}