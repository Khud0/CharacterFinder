using System;


namespace CharacterSearch
{
    
    class ConsoleMenu
    {
        // Correct answer for test string: 'f' - FirstNonrepeatingCharacter
        //                                 "HHEELLOO" - Upper Case String
        private static string testString = "aakmhaamqmqa1hwwbbbboqcm1cochkhhk4HdoHqmdHwmdw1e2hwokehoEewEawqEqkmbLahbLw1mkabeckhoodLmwfmdcOokhd2cwaOhowmqm4Odhkce";
        private static bool caseSensitiveSearch = true;

        public static void Main(string[] args)
        {
            if (!caseSensitiveSearch) testString = testString.ToLower();

            RunSearcher<FirstNonRepeatingCharacter>();
            RunSearcher<UpperCaseCharacters>();
            RunSearcher<SortedString>();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        
        private static void RunSearcher<T>() where T : CharacterSearcher, new()
        {
            T searcher = new T();
            searcher.Test(testString);
        }
    }
}
