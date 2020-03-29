using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSearch
{
    public class UpperCaseCharacters : CharacterSearcher
    {
        List<Func<string, string>> allMethods = new List<Func<string, string>>()
        {
            new Func<string, string>(StringBuilderRemove),
            new Func<string, string>(StringBuilderAdd),
            new Func<string, string>(UpperCaseNoDuplicate)
        };

        public override void Test(string stringToSearchIn)
        {
            TestAllMethods<string>(stringToSearchIn, "upper case letters", allMethods);
        }



        #region Search Methods

        /// <summary>
        /// Creates an initialized StringBuilder and checks every character in a string. If it is an Upper Case character - remove it from the StringBuilder.
        /// </summary>
        public static string StringBuilderRemove(string stringToSearchIn)
        {
            // If the string doesn't have upper case characters - don't check it
            if (stringToSearchIn.ToLower() == stringToSearchIn) return null;

            StringBuilder stringBuilder = new StringBuilder(stringToSearchIn);
            int stringLength = stringToSearchIn.Length;

            // Start from the end so that indexes of removed chars remain the same (StringBuilder will concatenate the rest of a string and all new indexes will be shifted)
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
            // If the string doesn't have upper case characters - don't check it
            if (stringToSearchIn.ToLower() == stringToSearchIn) return null;

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
        public static string UpperCaseNoDuplicate(string stringToSearchIn)
        {
            // If the string doesn't have upper case characters - don't check it
            if (stringToSearchIn.ToLower() == stringToSearchIn) return null;

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

        #endregion
    }
}
