using System;
using Khud0.Utility;

namespace StringPlay
{
    public static class MethodTester<TOutput> where TOutput : IComparable
    {
        /// <summary>Displays results according to expected output</summary>
        /// <param name="searchFor">What should the method return? How is it called? Example: "first non repeating character"</param>
        public static void DisplaySearchResult(string methodName, string searchFor, TOutput searchResult)
        {
            Console.WriteLine(); 
            if (searchResult == null || searchResult.Equals(default(TOutput))) 
                    Console.WriteLine($"Method \"{methodName}\" didn't find any \"{searchFor}\"");
            else    Console.WriteLine($"Method \"{methodName}\" found \"{searchFor}\": {searchResult}");  
        }

        /// <summary>
        /// Fires all methods (Func delegates) from searchMethhods list and prints out their outputs, if any.
        /// Displays elapsed time for each method it runs.
        /// </summary>
        /// <typeparam name="TOutput">Return type of methods (Func delegates) in provided List</typeparam>
        /// <param name="expectedOutput">What should the method return? How is it called? Example: "first non repeating character"</param>
        /// <param name="searchMethods">List of Func delegates with all the methods you want to test</param>
        public static void TestAllMethods(string stringToSearchIn, string expectedOutput, params Func<string, TOutput>[] searchMethods) 
        {
            int methodCount = searchMethods.Length;
            for (int methodIndex=0; methodIndex<methodCount; methodIndex++)
            {
                Func<string, TOutput> selectedMethod = searchMethods[methodIndex];

                Stopwatcher.Start();
                DisplaySearchResult(selectedMethod.Method.Name, expectedOutput, selectedMethod.Invoke(stringToSearchIn));
                Stopwatcher.Stop();
            }
        }

        /// <summary>
        /// Fires all methods (Func delegates) from searchMethhods list and prints out their outputs, if any.
        /// Displays elapsed time for each method it runs.
        /// </summary>
        /// <typeparam name="TOutput">Return type of methods (Func delegates) in provided List</typeparam>
        /// <param name="expectedOutput">What should the method return? How is it called? Example: "first non repeating character"</param>
        /// <param name="searchMethods">List of Func delegates with all the methods you want to test</param>
        public static void TestAllMethods(string stringToSearchIn, string expectedOutput, params Func<string, bool, TOutput>[] searchMethods) 
        {
            int methodCount = searchMethods.Length;
            for (int methodIndex=0; methodIndex<methodCount; methodIndex++)
            {
                Func<string, bool, TOutput> selectedMethod = searchMethods[methodIndex];

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
