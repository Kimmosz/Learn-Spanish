using System;

namespace Learn_Spanish {
    public class Program {
        static void Main(string[] args) {
            MainMenu();
        }

        // Function that shows header 
        public static void Header() {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * *");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* * * * * * * *  SPAANS LEREN   * * * * * * * *");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Function that asks for user input and pause the loop
        public static void PressEnter() {
            Console.WriteLine("Druk op enter om door te gaan...");
            Console.ReadLine();
        }

        // Function that shows main menu 
        public static void MainMenu() {
            while (true) {
                Header();
                Console.WriteLine("¡Hola! ¿Qué tal?\n\nIn deze applicatie kan je Spaanse woorden oefenen!\n");
                Console.WriteLine("Kies een optie:\n" +
                                  "1) Dagen oefenen (Nederlands > Spaans)\n" +
                                  "2) Dagen oefenen (Spaans > Nederlands)\n" +
                                  "3) Maanden oefenen (Nederlands > Spaans)\n" +
                                  "4) Maanden oefenen (Spaans > Nederlands)\n" +
                                  "5) Sluit applicatie af");
                
                // Get choice of the user
                string userInput = Console.ReadLine();
                int choice;

                // User input options
                if (int.TryParse(userInput, out choice)) {
                    if (choice == 1) {
                        // Days words from Dutch to Spanish
                        GameManager.SetupQuestion("days", "DS");
                        break;
                    } else if (choice == 2) {
                        // Days words from Spanish to Dutch
                        GameManager.SetupQuestion("days", "SD");
                        break;
                    } else if (choice == 3) {
                        // Months words from Dutch to Spanish
                        GameManager.SetupQuestion("months", "DS");
                        break;
                    } else if (choice == 4) {
                        // Months words from Spanish to Dutch
                        GameManager.SetupQuestion("months", "SD");
                        break;
                    } else if (choice == 5) {
                        break;
                    } else {
                        // Requires the user to choose one of the given option
                        Console.WriteLine("Kies één van de bovenstaande opties.");
                        PressEnter();
                    }
                } else {
                    // Requires the user to enter a number
                    Console.WriteLine("Kies een nummer.");
                    PressEnter();
                }
            }
        }
    }
}
