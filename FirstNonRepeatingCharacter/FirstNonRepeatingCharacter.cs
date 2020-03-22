using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSearch
{
    public class FirstNonRepeatingCharacter : CharacterSearcher
    {
        public override void Find(string stringToSearchIn)
        {
            DisplaySearchResult("Two Pointers", TwoPointers(stringToSearchIn));
        }



        protected override void DisplaySearchResult(string methodName, char foundCharacter)
        {
            if (foundCharacter == default)
            {
                Console.WriteLine("Method \"{0}\" didn't find any Non Repeating Charaters.", methodName);
            } 
            else 
            {
                Console.WriteLine("Method \"{0}\" found First Non Repeating Charater: {1}", methodName, foundCharacter);
            }
            
        }



        /// <summary>
        /// The slowest FirstNonRepeatingCharacter method. It uses two loops:
        /// <para>First loop goes through each character.</para>
        /// <para>Second loop compares char from the first one to each other character in the string.</para>
        /// </summary>
        /// <param name="stringToSearchIn">Sir</param>
        /// <returns>First non repeating character in the given string.</returns>
        public char TwoPointers(string stringToSearchIn)
        {
            char foundCharacter = default;
            int stringLength = stringToSearchIn.Length;

            // First loop - go through each single character in a string
            for (int i=0; i<stringLength; i++)
            {
                bool characterRepeats = false;

                // Compare one chosen character to each other character in the string except for itself
                for (int ii=0; ii<stringLength; ii++)
                {
                    if (ii == i) continue; // The character should skip itself (when both pointers are referring to the same position in a string)
                    if (stringToSearchIn[i] == stringToSearchIn[ii])
                    {
                        characterRepeats = true;
                        break; // The character is definitely repeated at least once, there is no need to keep seaching for another duplicate
                    }
                }

                if (!characterRepeats)
                {
                    foundCharacter = stringToSearchIn[i];
                    break;
                }
            }

            return foundCharacter;
        }   
    }
}
