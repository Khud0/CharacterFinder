using NUnit.Framework;
using CharacterSearch;

namespace CharacterFinderTests
{
    public class FirstNonRepeatingCharacterTests
    {
        private string firstLetterString = "aakmhaamqmqahwwbbbboqcmcochkhhkdoqmdwmdwehwokehoewawqqkmbahbwmkabeckhoodmwfmdcokhdcwahowmqmdhkce";
        private char firstLetterAnswer = 'f';

        private string firstNumberString = "gaksjgaksjqwqwqwqwabababbbbbaakkksssgggjjsk1sjsju2uqwqw1";
        private char firstNumberAnswer = '2';

        
        [Test]
        public void Test01_SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void Test02_TwoPointers_FirstLetter()
        {
            char methodAnswer = FirstNonRepeatingCharacter.TwoPointersSearch(firstLetterString);
            Assert.AreEqual(firstLetterAnswer, methodAnswer);
        }

        [Test]
        public void Test03_TwoPointers_FirstNumber()
        {
            char methodAnswer = FirstNonRepeatingCharacter.TwoPointersSearch(firstNumberString);
            Assert.AreEqual(firstNumberAnswer, methodAnswer);
        }

        [Test]
        public void Test04_Dictionary_FirstLetter()
        {
            char methodAnswer = FirstNonRepeatingCharacter.DictionarySearch(firstLetterString);
            Assert.AreEqual(firstLetterAnswer, methodAnswer);
        }

        [Test]
        public void Test05_Dictionary_FirstNumber()
        {
            char methodAnswer = FirstNonRepeatingCharacter.DictionarySearch(firstNumberString);
            Assert.AreEqual(firstNumberAnswer, methodAnswer);
        }

        [Test]
        public void Test06_CountEachCharacter_FirstLetter()
        {
            char methodAnswer = FirstNonRepeatingCharacter.CountEachCharacterSearch(firstLetterString);
            Assert.AreEqual(firstLetterAnswer, methodAnswer);
        }

        [Test]
        public void Test07_CountEachCharacter_FirstNumber()
        {
            char methodAnswer = FirstNonRepeatingCharacter.CountEachCharacterSearch(firstNumberString);
            Assert.AreEqual(firstNumberAnswer, methodAnswer);
        }
    }
}