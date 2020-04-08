using System;
using System.Text;
using Khud0.Utility;

namespace StringPlay
{
    public class SortedString : IStringModifier
    {            
        public void Test(string stringToSearchIn)
        {
            MethodTester<string>.TestAllMethods( stringToSearchIn, "sorted string", 
                                                 new Func<string, bool, string>(BubbleSort), 
                                                 new Func<string, bool, string>(CharArraySort),
                                                 new Func<string, bool, string>(GnomeSort) );
        }

        #region Search Methods

        /// <summary>
        /// Compares pairs of values and swaps them if 
        /// </summary>
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
                        StringBuilderModifier.SwapCharacters(stringBuilder, i, i+1);
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

        // (From https://www.geeksforgeeks.org/gnome-sort-a-stupid-one/)
        /// <summary>
        /// Garden Gnome looks at the flower pot next to him and the previous one.
        /// If they are in the right order he steps one pot forward, otherwise he swaps them and steps one pot backwards.
        /// </summary>
        /// <returns></returns>
        public static string GnomeSort(string stringToSort, bool ascending)
        {
            StringBuilder stringBuilder = new StringBuilder(stringToSort);
            int currentIndex = 1; // Important! Start from 1 to avoid checking array[-1];
            int stringLength = stringToSort.Length;

            while (currentIndex < stringLength)
            {
                // Check if the value at the current index is lower (higher) than value at the previous index;
                // If it is - swap them and take a step back (check the newly created pair);
                int currentCharCode = (int) stringBuilder[currentIndex];
                int previousCharCode = (int) stringBuilder[currentIndex-1];
                bool shouldSwap = (ascending) ? (currentCharCode < previousCharCode) : (currentCharCode > previousCharCode);
                if (shouldSwap)
                {
                    // Perform the swap
                    StringBuilderModifier.SwapCharacters(stringBuilder, currentIndex, currentIndex-1);

                    // Don't go to the index of 0, because there's no other index before it
                    // Increment the current index if you're at the first position, because you've already checked it;
                    if (currentIndex - 1 > 0) currentIndex -= 1; else currentIndex += 1;  
                } else currentIndex += 1;
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sorted array is built one element at a time.
        /// Every previous element is compared to key and if it is higher (lower) -> it gets moved forwards.
        /// The key is then put into the place of the last moved element (if any).
        /// </summary>
        /// <returns></returns>
        public static string InsertionSort(string stringToSort, bool ascending) 
        { 
            int stringLength = stringToSort.Length; 
            StringBuilder stringBuilder = new StringBuilder();

            int[] charCodeArray = new int[stringLength];
            // Convert string into chars (char ASCII codes, actually)
            for (int i=0; i<stringLength; i++)
            {
                charCodeArray[i] = (int) stringToSort[i];
            }

            // i=1, because there's no previous index to 0
            for (int i=1; i<stringLength; i++) 
            { 
                int key = charCodeArray[i]; 
                int j = i - 1; 

                // Check previous element and move it forward if it is higher than key
                // If no such element is found, place the key in the currently empty space
                // (the one that you've moved the element forwards from, if any)
                
                while (j >= 0) 
                { 
                    bool shouldMoveForwards = (ascending) ? (charCodeArray[j] > key) : (charCodeArray[j] < key);
                    if (!shouldMoveForwards) break;

                    charCodeArray[j+1] = charCodeArray[j]; 
                    j = j - 1; // Check if the newly placed element is in its place
                } 
                charCodeArray[j + 1] = key; 
            } 
            
            for(int i=0; i<stringLength; i++)
            {
                stringBuilder.Append((char)charCodeArray[i]);
            }

            return stringBuilder.ToString();
    } 

        #endregion
    }
}
