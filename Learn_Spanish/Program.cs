using System;

namespace Learn_Spanish {
    public class Program {
        static void Main(string[] args) {
            MainMenu();
        }

        // Header
        public static void Header() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * *");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* * * * * * * *  SPAANS LEREN   * * * * * * * *");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Main menu 
        static void MainMenu() {
            Header();
            Console.WriteLine("¡Hola! ¿Qué tal?\n\nIn deze applicatie kan je Spaanse woorden oefenen!\n\nKies een onderdeel:");
        }
    }
}
