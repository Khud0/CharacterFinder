using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSearch
{
    public class SortedString : CharacterSearcher
    {            
        List<Func<string, bool, string>> allMethods = new List<Func<string, bool, string>>()
        {
            new Func<string, bool, string>(BubbleSort),
            new Func<string, bool, string>(CharArraySort)
        };

        public override void Test(string stringToSearchIn)
        {
            TestAllMethods<string>(stringToSearchIn, "sorted string", allMethods);
        }

        #region Search Methods
            
        public static string BubbleSort(string stringToSort, bool ascending)
        {
            int stringLength = stringToSort.Length;
            StringBuilder stringBuilder = new StringBuilder(stringToSort);
                
            int changesMade = 0;
            do // Run the code block at least once in any case
            {
                changesMade = 0;

                // Compare character of current index to the next one in the string
                // Use their ASCII codes. For example, let's say that (int) 'c' = 3; (int) 'a' = 1.
                // If current code is higher than next one, swap the corresonding characters' places.
                for (int i=0; i<stringLength-1; i++)
                {
                    int charCurrentCode = (int) stringBuilder[i];
                    int charCompareToCode = (int) stringBuilder[i+1];
                    bool shouldSwapCharacters = ascending ? (charCurrentCode > charCompareToCode) : (charCurrentCode < charCompareToCode);

                    if (shouldSwapCharacters)
                    {
                        char tempChar = stringBuilder[i];
                        stringBuilder[i] = stringBuilder[i+1];
                        stringBuilder[i+1] = tempChar;
                        changesMade++;
                    }
                }
            } while (changesMade != 0);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Use the Array namespace functions to sort the string and reverse it, if needed
        /// </summary>
        public static string CharArraySort(string stringToSort, bool ascending)
        {
            char[] charArray = stringToSort.ToCharArray();
            Array.Sort(charArray);
            if (!ascending) Array.Reverse(charArray);
            return String.Join("", charArray);
        }

        /// <summary>
        /// Convets a string into an array of integer char codes and sorts them with a Selection method (finds minimum in current array).
        /// Finally, it converts the integers back into characters.
        /// </summary>
        public static string ToIntSelectionSort(string stringToSort, bool ascending)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int stringLength = stringToSort.Length;
            int[] charCodeArray = new int[stringLength];
            
            // Convert string into chars (char ASCII codes, actually)
            for (int i=0; i<stringLength; i++)
            {
                charCodeArray[i] = (int) stringToSort[i];
            }

            // Find minimum in a part of the array and put it into the first place
            // You could use stringLength-1 Because last entry is already sorted, but I want to Append to stringBuilder inside of the loop
            for (int i=0; i<stringLength; i++)
            {
                int minIndex = i;
                for (int ii=i+1; ii<stringLength; ii++)
                {
                    bool shouldSwapValues = ascending ? (charCodeArray[ii] < charCodeArray[minIndex]) : (charCodeArray[ii] > charCodeArray[minIndex]);
                    if (shouldSwapValues)
                    {
                        minIndex = ii; // If descending, maxIndex
                    }
                }

                // Swap new minimum with current value at current position
                // If you don't swap - the minimum will just depend on "i" position, this way you "remove it" from the array that is currently being checked
                int temp = charCodeArray[minIndex];
                charCodeArray[minIndex] = charCodeArray[i];
                charCodeArray[i] = temp;
                stringBuilder.Append((char) temp);
            }

            Console.WriteLine();
            return stringBuilder.ToString();
        }

        #endregion
    }
}
