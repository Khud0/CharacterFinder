using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSearch
{
    public class FormattedString : CharacterSearcher<string>
    {
        List<Func<string, string>> allMethods = new List<Func<string, string>>()
        {
            new Func<string, string>(Ladder)
        };

        public override void Test(string stringToSearchIn)
        {
            TestAllMethods(stringToSearchIn, "formatted string", allMethods);
        }

        #region Methods
        
        /// <summary>
        /// Formats your string to a LaDdEr CaSe, spaces and symbols don't count.
        /// </summary>
        /// <param name="inputString">String to convert to LaDdEr</param>
        /// <param name="startWithUpper">Should the 1st character be written in upper case? False -> ladder will start from the 2d. </param>
        public static string Ladder(string inputString)
        {
            bool currentIsUpper = true;
            int stringLength = inputString.Length;
            StringBuilder stringBuilder = new StringBuilder(inputString);

            for(int i=0; i<stringLength; i++)
            {
                char currentChar = stringBuilder[i];
                char currentCharToUpper = Char.ToUpper(currentChar);
                char currentCharToLower = Char.ToLower(currentChar);

                // Characters will be the same if there is no ToLower or ToUpper equivalent for currentChar (they are the same)
                if (currentCharToLower == currentCharToUpper) continue;
                else 
                {
                    stringBuilder[i] = (currentIsUpper) ? currentCharToUpper : currentCharToLower;
                    currentIsUpper = !currentIsUpper;
                }
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
