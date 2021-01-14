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
                                  "2) Dagen oefenen (Spaans > Nederlands)\n\n" +
                                  "3) Maanden oefenen (Nederlands > Spaans)\n" +
                                  "4) Maanden oefenen (Spaans > Nederlands)\n\n" +
                                  "5) Nummers oefenen [0-100] (Nederlands > Spaans)\n" +
                                  "6) Nummers oefenen [0-100] (Spaans > Nederlands)\n\n" +
                                  "7) Kleuren oefenen (Nederlands > Spaans)\n" +
                                  "8) Kleuren oefenen (Spaans > Nederlands)\n\n" + 
                                  "9) Relaties oefenen (Nederlands > Spaans)\n" +
                                  "10) Relaties oefenen (Spaans > Nederlands)\n\n" + 
                                  "11) Dieren oefenen (Nederlands > Spaans)\n" + 
                                  "12) Dieren oefenen (Spaans > Nederlands)\n\n" +
                                  "13) Sluit applicatie af");
                
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
                        // Numbers from Dutch to Spanish
                        GameManager.SetupQuestion("numbers", "DS");
                        break;
                    } else if (choice == 6) {
                        // Numbers from Spanish to Dutch
                        GameManager.SetupQuestion("numbers", "SD");
                        break;
                    } else if (choice == 7) {
                        // Colors from Dutch to Spanish
                        GameManager.SetupQuestion("colors", "DS");
                        break;
                    } else if (choice == 8) {
                        // Colors from Spanish to Dutch
                        GameManager.SetupQuestion("colors", "SD");
                        break;
                    } else if (choice == 9) {
                        // Relation words from Dutch to Spanish
                        GameManager.SetupQuestion("relations", "DS");
                        break;
                    } else if (choice == 10) {
                        // Relation words from Spanish to Dutch
                        GameManager.SetupQuestion("relations", "SD");
                        break;
                    } else if (choice == 11) {
                        // Animals from Dutch to Spanish
                        GameManager.SetupQuestion("animals", "DS");
                        break;
                    } else if (choice == 12) {
                        // Animals from Spanish to Dutch
                        GameManager.SetupQuestion("animals", "SD");
                        break;
                    } else if (choice == 13) {
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
