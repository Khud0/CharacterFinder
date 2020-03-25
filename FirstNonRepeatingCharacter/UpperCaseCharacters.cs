using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSearch
{
    public delegate string PerformStringSearch(string stringToSearchIn);

    public class UpperCaseCharacters : CharacterSearcher
    {
        private List<PerformStringSearch> searchOptions = new List<PerformStringSearch>()
        {
            new PerformStringSearch(StringBuilderRemove),
            new PerformStringSearch(StringBuilderAdd),
            new PerformStringSearch(RemoveDuplicateUpperCase)
        };



        // Fires all method from searchOptions list and prints out FirstNonRepeatingCharacter, if any
        // Displayes elapsed time for each method it runs
        public override void TestAllMethods(string stringToSearchIn)
        {
            int methodCount = searchOptions.Count;
            for (int methodIndex=0; methodIndex<methodCount; methodIndex++)
            {
                Stopwatcher.Start();
                PerformStringSearch selectedMethod = searchOptions[methodIndex];
                DisplaySearchResult(selectedMethod.Method.Name, "upper case characters", selectedMethod(stringToSearchIn));
                Stopwatcher.Stop();
            }
        }



        /// <summary>
        /// Creates an initialized StringBuilder and checks every character in a string. If it is an Upper Case character - remove it from the StringBuilder.
        /// </summary>
        public static string StringBuilderRemove(string stringToSearchIn)
        {
            StringBuilder stringBuilder = new StringBuilder(stringToSearchIn);
            int stringLength = stringToSearchIn.Length;

            for(int i=stringLength-1; i>=0; i--)
            {
                if (!char.IsUpper(stringToSearchIn[i]))
                {
                    stringBuilder.Remove(i, 1);
                }
            }

            return (stringBuilder.Length == 0) ? null : stringBuilder.ToString();
        }

        /// <summary>
        /// Creates an empty StringBuilder and fills it in if the character is an Upper Case character.
        /// </summary>
        public static string StringBuilderAdd(string stringToSearchIn)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int stringLength = stringToSearchIn.Length;

            for (int i=0; i<stringLength; i++)
            {
                char currentChar = stringToSearchIn[i];
                if (char.IsUpper(currentChar))
                {
                    stringBuilder.Append(currentChar);
                }
            }

            return (stringBuilder.Length == 0) ? null : stringBuilder.ToString();
        }

        /// <summary>
        /// Returns ONLY upper case characters without duplicates. The same character isn't checked more than once thanks to a list of seen characters.
        /// </summary>
        public static string RemoveDuplicateUpperCase(string stringToSearchIn)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<char> seenUpperCaseCharacters = new List<char>();
            int stringLength = stringToSearchIn.Length;

            for (int i=0; i<stringLength; i++)
            {
                char currentChar = stringToSearchIn[i];
                if (char.IsUpper(currentChar) && !seenUpperCaseCharacters.Contains(currentChar))
                {
                    stringBuilder.Append(currentChar);
                    seenUpperCaseCharacters.Add(currentChar);
                }
            }

            return (stringBuilder.Length == 0) ? null : stringBuilder.ToString();
        }
    }
}
