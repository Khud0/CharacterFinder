using System;


namespace CharacterSearch
{
    public abstract class CharacterSearcher
    {
        public abstract void Find(string stringToSearchIn, int searchOptionIndex);
        public abstract int GetSearchOptionsCount();
        protected abstract void DisplaySearchResult(string methodName, char foundCharacter);
    }
}
