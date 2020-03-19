using System;
using System.Diagnostics;

namespace FirstNonRepeatingCharacter
{
    class CharacterSearcher
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            string testString = "aabbccdddeff";

            PointerSearch pointerSearch = new PointerSearch();
            pointerSearch.FindFirstNonRepeatingCharacter(testString);
            ResetStopwatch(ref stopwatch);
        }

        public static void DisplaySearchResult(string className, char foundCharacter)
        {
            if (foundCharacter == default)
            {
                Console.WriteLine("{0} found no nonrepeating characters.", className);
            } else 
            {
                Console.WriteLine("The first nonrepeating character found by {0} is {1}.", className, foundCharacter);
            }
        }

        public static void ResetStopwatch(ref Stopwatch activeStopwatch)
        {
            activeStopwatch.Stop();
            Console.WriteLine("Elapsed time: {0}.", 
                              activeStopwatch.Elapsed);
            activeStopwatch.Restart();                  
        }
    }
}
