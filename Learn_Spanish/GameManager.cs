using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Learn_Spanish {
    public class GameManager {
        private static Random random = new Random();

        // Function which set up the question
        public static void SetupQuestion(string wordType, string translationType) {
            while (true) {
                Program.Header();

                // Get all data from JSON file and put in array
                List<Word> wordList = LoadDaysDirectory(wordType);
                Word[] words = wordList.ToArray();

                // Get random number to define word
                int randomNumber = random.Next(1, words.Length + 1);

                // Execute the question
                ExecuteQuestion(wordType, translationType, randomNumber, words);
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
        public static void ExecuteQuestion(string wordType, string translationType, int randomNumber, Word[] wordsData) {
            string outcomeLanguage;
            string questionWord;
            string correctAnswer;

            // Check what translation type the user chose
            if (translationType == "DS") {
                // Dutch to Spanish
                outcomeLanguage = "Spaans";
                questionWord = wordsData[randomNumber - 1].Dutch;
                correctAnswer = wordsData[randomNumber - 1].Spanish;
            } else if (translationType == "SD") {
                // Spanish to Dutch
                outcomeLanguage = "Nederlands";
                questionWord = wordsData[randomNumber - 1].Spanish;
                correctAnswer = wordsData[randomNumber - 1].Dutch;
            } else {
                // Wrong translation type
                outcomeLanguage = "Error, no translation type given";
                questionWord = "Error, no translation type given";
                correctAnswer = "Error, no translation type given";
            }

            while (true) {
                // Ask question to the user and get given input
                if (wordType == "numbers" && translationType == "SD")
                    Console.WriteLine($"Wat is > {questionWord} < in nummers?");
                else
                    Console.WriteLine($"Wat is > {questionWord} < in het {outcomeLanguage}?");
                string userAnswer = Console.ReadLine();

                // Check if input equals the correct answer
                if (userAnswer == correctAnswer) {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nGoed!");
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\nFout! Het juiste antwoord is:\n{correctAnswer}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // Ask to user if he/she wants to continue with answering questions
                UserCheck(wordType, translationType);
                break;
            }
        }

        // Function which asks the user if he/she wants to continue or quit
        public static void UserCheck(string wordType, string translationType) {
            while (true) {
                Console.WriteLine("\nWil je nog een woord om te oefenen? (J/N)");
                string answer = Console.ReadLine();
                if (answer.ToUpper() == "J") {
                    SetupQuestion(wordType, translationType);
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
