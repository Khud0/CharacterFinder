using NUnit.Framework;
using CharacterSearch;

namespace CharacterFinderTests
{
    public class Tests
    {
        private string firstLetterString = "aakmhaamqmqahwwbbbboqcmcochkhhkdoqmdwmdwehwokehoewawqqkmbahbwmkabeckhoodmwfmdcokhdcwahowmqmdhkce";
        private char firstLetterAnswer = 'f';

        private string firstNumberString = "gaksjgaksjqwqwqwqwabababbbbbaakkksssgggjjsk1sjsju2uqwqw1";
        private char firstNumberAnswer = '2';

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2_TwoPointers_FirstLetter()
        {
            char methodAnswer = FirstNonRepeatingCharacter.TwoPointersSearch(firstLetterString);
            Assert.AreEqual(firstLetterAnswer, methodAnswer);
        }

        [Test]
        public void Test3_TwoPointers_FirstNumber()
        {
            char methodAnswer = FirstNonRepeatingCharacter.TwoPointersSearch(firstNumberString);
            Assert.AreEqual(firstNumberAnswer, methodAnswer);
        }

        [Test]
        public void Test4_Dictionary_FirstLetter()
        {
            char methodAnswer = FirstNonRepeatingCharacter.DictionarySearch(firstLetterString);
            Assert.AreEqual(firstLetterAnswer, methodAnswer);
        }

        [Test]
        public void Test5_Dictionary_FirstNumber()
        {
            char methodAnswer = FirstNonRepeatingCharacter.DictionarySearch(firstNumberString);
            Assert.AreEqual(firstNumberAnswer, methodAnswer);
        }

        [Test]
        public void Test6_CountEachCharacter_FirstLetter()
        {
            char methodAnswer = FirstNonRepeatingCharacter.CountEachCharacterSearch(firstLetterString);
            Assert.AreEqual(firstLetterAnswer, methodAnswer);
        }

        [Test]
        public void Test7_CountEachCharacter_FirstNumber()
        {
            char methodAnswer = FirstNonRepeatingCharacter.CountEachCharacterSearch(firstNumberString);
            Assert.AreEqual(firstNumberAnswer, methodAnswer);
        }
    }
}