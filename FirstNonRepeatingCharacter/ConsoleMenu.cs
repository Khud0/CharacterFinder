using System;


namespace CharacterSearch
{
    
    class ConsoleMenu
    {
        // Correct answer for test string: 'f' - FirstNonrepeatingCharacter
        private static string testString = "aakmhaamqmqa1hwwbbbboqcm1cochkhhk4doqmdwmdw1e2hwokehoewawqqkmbahbw1mkabeckhoodmwfmdcokhd2cwahowmqm4dhkce";
        private static bool caseSensitiveSearch = true;

        public static void Main(string[] args)
        {
            if (!caseSensitiveSearch) testString = testString.ToLower();

            RunSearcher<FirstNonRepeatingCharacter>();

            Console.ReadKey();
        }

        
        private static void RunSearcher<T>() where T : CharacterSearcher, new()
        {
            T searcher = new T();
            searcher.Find(testString);
        }
    }
}
