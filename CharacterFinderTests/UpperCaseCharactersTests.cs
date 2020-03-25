using NUnit.Framework;
using CharacterSearch;

namespace CharacterFinderTests
{
    class UpperCaseCharactersTests
    {
        string uppercaseString = "jqkwjekwqtHweqwrktuaselgEdjhjasLLiqoqwieOqlwkwrq";

        [Test]
        public void Test1_SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2_StringBuilderRemove()
        {
            string methodAnswer = UpperCaseCharacters.StringBuilderRemove(uppercaseString);
            string correctAnswer = "HELLO";
            Assert.AreEqual(correctAnswer, methodAnswer);
        }

        [Test]
        public void Test3_StringBuilderAdd()
        {
            string methodAnswer = UpperCaseCharacters.StringBuilderRemove(uppercaseString);
            string correctAnswer = "HELLO";
            Assert.AreEqual(correctAnswer, methodAnswer);
        }

        [Test]
        public void Test4_UpperCaseNoDuplicate()
        {
            string testString = "qweklqwlHHIIHIHIHIHIHHHHIIqwrtlkq;HIHIHIHIHHHHHHHHHHHIIIIIIIHIHIHIHIHIHIHqwekIq";
            string methodAnswer = UpperCaseCharacters.UpperCaseNoDuplicate(testString);
            string correctAnswer = "HI";
            Assert.AreEqual(correctAnswer, methodAnswer);
        }
    }
}
