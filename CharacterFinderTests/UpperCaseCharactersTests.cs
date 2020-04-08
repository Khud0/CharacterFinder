using NUnit.Framework;
using StringPlay;

namespace CharacterFinderTests
{
    class UpperCaseCharactersTests
    {
        string uppercaseString = "jqkwjekwqtHweqwrktuaselgEdjhjasLLiqoqwieOqlwkwrq";

        [Test]
        public void Test01_SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void Test02_StringBuilderRemove()
        {
            string methodAnswer = UpperCaseCharacters.StringBuilderRemove(uppercaseString);
            string correctAnswer = "HELLO";
            Assert.AreEqual(correctAnswer, methodAnswer);
        }

        [Test]
        public void Test03_StringBuilderAdd()
        {
            string methodAnswer = UpperCaseCharacters.StringBuilderRemove(uppercaseString);
            string correctAnswer = "HELLO";
            Assert.AreEqual(correctAnswer, methodAnswer);
        }

        [Test]
        public void Test04_UpperCaseNoDuplicate()
        {
            string testString = "qweklqwlHHIIHIHIHIHIHHHHIIqwrtlkq;HIHIHIHIHHHHHHHHHHHIIIIIIIHIHIHIHIHIHIHqwekIq";
            string methodAnswer = UpperCaseCharacters.UpperCaseNoDuplicate(testString);
            string correctAnswer = "HI";
            Assert.AreEqual(correctAnswer, methodAnswer);
        }
    }
}
