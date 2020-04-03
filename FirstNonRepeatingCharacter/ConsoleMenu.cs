using System;
using System.Collections.Generic;


namespace CharacterSearch
{
    
    class ConsoleMenu
    {
        // Correct answer for test string: 'f' - FirstNonrepeatingCharacter
        //                                 "HHEELLOO" - Upper Case String
        private static string defaultString = "aakmhaamqmqa1hwwbbbboqcm1cochkhhk4HdoHqmdHwmdw1e2hwokehoEewEawqEqkmbLahbLw1mkabeckhoodLmwfmdcOokhd2cwaOhowmqm4Odhkce";
        private static string inputString = "/default";
        private static bool caseSensitiveSearch = true;

        private static Dictionary<string, string> commands = new Dictionary<string, string>()
        {
            { "/all", "Tests all the methods in the program" },

            { "/nonrepeating", "Finds the first non repeating character" },
            { "/uppercase", "Finds all UPPER CASE characters" },
            { "/sort", "Sorts characters" },

            { "/exit", "Closes the console" }
        };

        public static void Main(string[] args)
        {
            if (!caseSensitiveSearch) defaultString = defaultString.ToLower();

            while (true)
            {
                Console.Clear();

                // Display all command options with their descriptions
                Console.WriteLine("Which method would you like to test?");
                foreach (string commandName in commands.Keys)
                {
                    Console.WriteLine($"{commandName} - {commands[commandName]}");
                }
                Console.WriteLine();

                // Check user's input before running any further code
                string inputCommand = Console.ReadLine();
                if (!CommandIsCorrect(inputCommand))
                {
                    Console.WriteLine("\n-- This command is not supported. Press any key to try again. --\n");
                    Console.ReadKey();
                    continue;
                }

                // Read input string from the user so that you can use it to run the selected method(s)
                Console.WriteLine("\nWhich string would you like to test?\n" +
                             "Type \"/default\" to use the default test string\n" +
                             "Type \"/previous\" to use the default test string\n");
                string readLine = Console.ReadLine();
                if (readLine == "/default") inputString = defaultString;
                else if (readLine != "/previous") inputString = readLine;

                Console.WriteLine($"\n-- Your input: {inputString} --");

                TestMethod(inputCommand);

                Console.WriteLine("\n-- Press any key to restart the program. --");
                Console.ReadKey();
            }
        }

        private static bool CommandIsCorrect(string inputCommand)
        {
            if (inputCommand == "/exit") 
            {                
                Environment.Exit(0);
                return false;
            }
            else return commands.ContainsKey(inputCommand);
        }

        private static void TestMethod(string inputCommand)
        {     
            // Don't forget to add new commands to this switch statement
            switch (inputCommand)
            {
                case "/all": RunAllSearchers(); break;
                case "/nonrepeating": RunSearcher<FirstNonRepeatingCharacter, char>(); break;
                case "/uppercase": RunSearcher<UpperCaseCharacters, string>(); break;
                case "/sort": RunSearcher<SortedString, string>(); break;
            }
        }

        private static void RunAllSearchers()
        {
            foreach (string commandName in commands.Keys)
            {
                if (commandName != "/all" && commandName != "/exit") TestMethod(commandName);
            }
        }

        private static void RunSearcher<TSearcher, TOutput>() where TSearcher : CharacterSearcher<TOutput>, new()
                                                              where TOutput : IComparable
        {
            TSearcher searcher = new TSearcher();
            searcher.Test(inputString);
        }
    }
}
