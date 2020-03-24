using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CharacterSearch
{
    
    class ConsoleMenu
    {
        
        private static Stopwatch stopwatch = default;
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
            int methodCount = searcher.GetSearchOptionsCount();
            for (int methodIndex=0; methodIndex<methodCount; methodIndex++)
            {
                StartStowpatch(ref stopwatch);
                searcher.Find(testString, methodIndex);
                StopStopwatch(ref stopwatch);
            }
        }
        private static void StartStowpatch(ref Stopwatch activeStopwatch)
        {
            if (activeStopwatch == default) 
            {
                activeStopwatch = Stopwatch.StartNew();
            } else activeStopwatch.Restart();
        }
        private static void StopStopwatch(ref Stopwatch activeStopwatch)
        {
            if (activeStopwatch == default) { Console.WriteLine("Stopwatch hadn't been started before you tried to stop it"); return; }
            
            activeStopwatch.Stop();
            Console.WriteLine("Elapsed time: {0}.", activeStopwatch.Elapsed);                      
        }
    }
}
