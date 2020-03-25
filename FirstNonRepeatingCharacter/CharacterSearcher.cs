using System;
using System.Collections.Generic;


namespace CharacterSearch
{
    public class CharacterSearcher
    {
        public virtual void TestAllMethods(string stringToSearchIn)
        {
            Console.WriteLine("Error: Default TestAllMethods method used!");
        }

        /// <param name="searchFor">What do you expect to find using this method</param>
        protected virtual void DisplaySearchResult(string methodName, string searchFor, object searchResult)
        {
            Console.WriteLine(); 
            if (searchResult == default) Console.WriteLine("Method \"{0}\" didn't find any \"{1}\"", methodName, searchFor);
            else                         Console.WriteLine("Method \"{0}\" found \"{1}\": {2}", methodName, searchFor, searchResult);  
        }
    }
}
