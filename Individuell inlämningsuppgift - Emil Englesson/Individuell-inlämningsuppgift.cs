namespace Individuell_inlämningsuppgift___Emil_Englesson;

class Program
{
    static void Main(string[] args)
    {
        bool result = false;
        bool userInput = false;

        Console.WriteLine("Miniräknare");
        Console.WriteLine("--------------------------");
        Console.WriteLine("");
        Console.WriteLine("Välkommen till denna miniräknare gjord av Emil Englesson.");
        
        while(result == false)
        {
            string userInput1 = " ";
            string userInputOperator = " ";
            string userInput2 = " ";
            int userResult = 0;
            bool operatorInput = false;

            do
            {
                Console.WriteLine("Skriv in ditt första tal:");
                userInput1 = (Console.ReadLine());

                if (userInput1 == "" || !int.TryParse(userInput1, out int notValid1)){ 
                    Console.WriteLine("Du behöver skriva in ett tal för att starta, försök igen.");
                    userInput = false; 
                } 
                else
                {
                    userInput = true;
                }
            //Kontrollerar att det första talet är ett nummer

                if (userInput1 != null){
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("Skriv in tecknet för vilket alternativ du vill använda:");
                    Console.WriteLine("+  Addera");
                    Console.WriteLine("-  Subtrahera");
                    Console.WriteLine("*  Multiplicera");
                    Console.WriteLine("/  Dividera");
                
                    userInputOperator = Console.ReadLine();

                    if (userInputOperator == "+" || userInputOperator == "-" || userInputOperator == "*" || userInputOperator == "/") // fungerar inte
                    {
                        operatorInput = true;
                        userInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Inmatningen var inte ett tecken, försök igen.");
                    }
                } while (operatorInput == false);
                //Kontrollerar att ett tecken skrivs in
                
                do
                {
                    Console.WriteLine("Skriv in ditt andra tal:");
                    userInput2 = (Console.ReadLine());

                    if (userInput2 == "" || !int.TryParse(userInput2, out int notValid2)){ 
                        Console.WriteLine("Du behöver skriva in ett tal för att fortsätta, försök igen."); 
                        userInput = false;
                    } 
                    if (userInputOperator == "/")
                    {
                        if (int.TryParse(userInput2, out int divideZero))
                        {
                            if (divideZero == 0)
                            {
                                userInput = false;
                                Console.WriteLine("");
                                Console.WriteLine("Ogiltig inmatning! Skriv in ett annat värde");
                                //Ifall andra talet är lika med 0
                            }
                            else
                            {
                                userInput = true;
                            }
                        }
                    }
                    else
                    {
                        userInput = true;
                    }

                int inputNumber1 = int.Parse(userInput1);
                int inputNumber2 = int.Parse(userInput2);
                //Omvandlar userInput från string till int för matematiska beräkningar

                
                if (userInputOperator == "+")
                {
                    userResult = inputNumber1 + inputNumber2;
                }
                else if (userInputOperator == "-")  
                {
                    userResult = inputNumber1 - inputNumber2;
                }
                else if (userInputOperator == "*")  
                {
                    userResult = inputNumber1 * inputNumber2;
                }
                else if (userInputOperator == "/")  
                {
                    userResult = inputNumber1 / inputNumber2;
                    
                }

                Console.WriteLine("");
                Console.WriteLine("Svar:");
                Console.WriteLine($"{inputNumber1} {userInputOperator} {inputNumber2} = {userResult}");
                Console.WriteLine("");

                } while(userInput == false);
                }
                 
            
                Console.WriteLine("Skriv \"s\" för att starta om, eller \"a\" för att avsluta.");
                string endChoice = Console.ReadLine();
                Console.WriteLine("");

                if (endChoice == "a" || endChoice == "A")
                {
                    result = true; // Avslutar programmet
                }
                else if (endChoice == "s" || endChoice == "S")
                {
                    result = false; // Startar om programmet
                }
            }while(userInput == false);
        }
    }
}

// Välkomnande meddelande - klar
// Användaren matar in tal och matematiska operation - klar
// OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet! - klar
// Ifall användaren skulle dela med 0 visa Ogiltig inmatning! - klar
// Fråga användaren om den vill avsluta eller fortsätta. - klar
// En lista för att spara historik för räkningar
// Lägga resultat till listan
// Visa resultat
// Fråga användaren om den vill visa tidigare resultat.
// Visa tidigare resultat
