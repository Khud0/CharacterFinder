using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CharacterSearch
{
    class ConsoleMenu
    {
        private static Stopwatch stopwatch = default;
        // Correct answer: '1' - FirstNonrepeatingCharacter
        // Correct answer: '1', 'e', 'p' - AllNonRepeatingCharacters
        private static string testString = "aabbccdddgggggwwwwxzxzklqklqttttttyyyyyy1uiuiuiuiooooeffqqqvvvbnbnbnmmkkpkqtydf";
        private static bool caseSensitiveSearch = true;

        public static void Main(string[] args)
        {
            if (!caseSensitiveSearch) testString = testString.ToLower();

            RunSearcher<FirstNonRepeatingCharacter>();

            Console.ReadKey();
        }

        
        private static void RunSearcher<T>() where T : CharacterSearcher, new()
        {
            StartStowpatch(ref stopwatch);
            T searcher = new T();
            searcher.Find(testString);
            StopStopwatch(ref stopwatch);
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
