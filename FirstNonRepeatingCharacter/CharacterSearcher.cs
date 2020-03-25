using System;


namespace CharacterSearch
{
    public abstract class CharacterSearcher
    {
        public abstract void Find(string stringToSearchIn);
        protected abstract void DisplaySearchResult(string methodName, char foundCharacter);
    }
}
