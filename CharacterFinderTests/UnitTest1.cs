using NUnit.Framework;
using CharacterSearch;

namespace CharacterFinderTests
{
    public class Tests
    {
        FirstNonRepeatingCharacter firstNonRepatingCharacter = new FirstNonRepeatingCharacter();

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
        public void Test2_FirstLetterTwoPointers()
        {
            string testString = "aaaaabbbbcccdddeeeabababecdfdcdcadce";
            char correctAnswer = 'f';
            char methodAnswer = firstNonRepatingCharacter.TwoPointers(testString);

            Assert.AreEqual(correctAnswer, methodAnswer);
        }

        [Test]
        public void Test3_FirstNumberTwoPointers()
        {
            string testString = "aaaaarbbbbcccdrgddeeeabarbabegcdfdcdc1fedfdrrgradcre";
            char correctAnswer = '1';
            char methodAnswer = firstNonRepatingCharacter.TwoPointers(testString);

            Assert.AreEqual(correctAnswer, methodAnswer);
        }
    }
}