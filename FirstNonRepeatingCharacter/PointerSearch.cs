using System;
using System.Collections.Generic;
using System.Text;

namespace FirstNonRepeatingCharacter
{
    class PointerSearch : ISearchNonRepeatingCharacter
    {
        public override string ToString()
        {
            return "PointerSearch";
        }

        public char FindFirstNonRepeatingCharacter(string stringToSearchIn)
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

            CharacterSearcher.DisplaySearchResult(this.ToString(), foundCharacter);

            return foundCharacter;
        }
    }
}
