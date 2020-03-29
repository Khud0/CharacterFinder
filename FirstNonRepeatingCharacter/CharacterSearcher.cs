using System;
using System.Collections.Generic;


namespace CharacterSearch
{
    public class CharacterSearcher
    {
        public virtual void Test(string stringToSearchIn)
        {
            Console.WriteLine("Error: Default TestAllMethods method used!");
        }

        /// <param name="searchFor">What should the method return? How is it called? Example: "first non repeating character"</param>
        protected virtual void DisplaySearchResult(string methodName, string searchFor, object searchResult)
        {
            Console.WriteLine(); 
            if (searchResult == default) Console.WriteLine("Method \"{0}\" didn't find any \"{1}\"", methodName, searchFor);
            else                         Console.WriteLine("Method \"{0}\" found \"{1}\": {2}", methodName, searchFor, searchResult);  
        }

        /// <summary>
        /// Fires all methods (Func delegates) from searchMethhods list and prints out their outputs, if any.
        /// Displays elapsed time for each method it runs.
        /// </summary>
        /// <typeparam name="T">Return type of methods (Func delegates) in provided List</typeparam>
        /// <param name="expectedOutput">What should the method return? How is it called? Example: "first non repeating character"</param>
        /// <param name="searchMethods">List of Func delegates with all the methods you want to test</param>
        protected void TestAllMethods<T>(string stringToSearchIn, string expectedOutput, List<Func<string, T>> searchMethods) 
        {
            int methodCount = searchMethods.Count;
            for (int methodIndex=0; methodIndex<methodCount; methodIndex++)
            {
                Func<string, T> selectedMethod = searchMethods[methodIndex];

                Stopwatcher.Start();
                DisplaySearchResult(selectedMethod.Method.Name, expectedOutput, selectedMethod.Invoke(stringToSearchIn));
                Stopwatcher.Stop();
            }
        }

        /// <summary>
        /// Tests sort methods which can be ascending and descending
        /// </summary>
        protected void TestAllMethods<T>(string stringToSearchIn, string expectedOutput, List<Func<string, bool, T>> searchMethods) 
        {
            int methodCount = searchMethods.Count;
            for (int methodIndex=0; methodIndex<methodCount; methodIndex++)
            {
                Func<string, bool, T> selectedMethod = searchMethods[methodIndex];

                Stopwatcher.Start();
                DisplaySearchResult(selectedMethod.Method.Name, expectedOutput + " - ascending", selectedMethod.Invoke(stringToSearchIn, true));
                Stopwatcher.Stop();

                Stopwatcher.Start();
                DisplaySearchResult(selectedMethod.Method.Name, expectedOutput + " - descending", selectedMethod.Invoke(stringToSearchIn, false));
                Stopwatcher.Stop();
            }
        }
    }
}
