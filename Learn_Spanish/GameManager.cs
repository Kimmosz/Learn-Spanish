using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Learn_Spanish {
    public class GameManager {
        private static Random random = new Random();

        // Function which set up the question
        public static void SetupQuestion(string wordType, string type) {
            while (true) {
                Program.Header();

                // Get all data from JSON file and put in array
                List<Word> getWordList = LoadDaysDirectory(wordType);
                Word[] words = getWordList.ToArray();

                // Get random number to define word
                int randomNumber = random.Next(1, words.Length + 1);

                // Execute the question
                ExecuteQuestion(wordType, type, randomNumber, words);
                break;
            }
        }

        // Function which gets the data from JSON file
        private static List<Word> LoadDaysDirectory(string wordType) {
            using (StreamReader reader = new StreamReader(@"../../../data/" + wordType + ".json", Encoding.GetEncoding("iso-8859-1"))) {
                string json = reader.ReadToEnd();
                List<Word> words = JsonConvert.DeserializeObject<List<Word>>(json);
                return words;
            }
        }

        // Function which asks the user the question and checks if its correct
        public static void ExecuteQuestion(string wordType, string type, int randomNumber, Word[] wordsData) {
            string language;
            string questionWord;
            string answerWord;

            // Check what translation type the user chose
            if (type == "DS") {
                // Dutch to Spanish
                language = "Spaans";
                questionWord = wordsData[randomNumber - 1].Dutch;
                answerWord = wordsData[randomNumber - 1].Spanish;
            } else if (type == "SD") {
                // Spanish to Dutch
                language = "Nederlands";
                questionWord = wordsData[randomNumber - 1].Spanish;
                answerWord = wordsData[randomNumber - 1].Dutch;
            } else {
                // Wrong translation type
                language = "Error, no translation type given";
                questionWord = "Error, no translation type given";
                answerWord = "Error, no translation type given";
            }

            while (true) {
                // Ask question to the user and get given input
                if (wordType=="numbers" && type=="SD")
                    Console.WriteLine($"Wat is > {questionWord} < in nummers?");
                else 
                    Console.WriteLine($"Wat is > {questionWord} < in het {language}?");
                string answer = Console.ReadLine();

                // Check if input equals the correct answer
                if (answer == answerWord) { 
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nGoed!");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\nFout! Het juiste antwoord is:\n{answerWord}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Ask to user if he/she wants to continue with answering questions
                UserCheck(wordType, type);
                break;
            }
        }

        // Function which asks the user if he/she wants to continue or quit
        public static void UserCheck(string wordType, string type) {
            while (true) {
                Console.WriteLine("\nWil je nog een woord om te oefenen? (J/N)");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "J") {
                    SetupQuestion(wordType, type);
                    break;
                } else if (answer.ToUpper() == "N") {
                    Program.MainMenu();
                    break;
                } else {
                    Console.WriteLine("Kies één van de opties");
                    continue;
                }
            }
        }
    }
}
