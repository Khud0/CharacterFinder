using NUnit.Framework;
using StringPlay;

namespace CharacterFinderTests
{
    class FormattedStringTests
    {
        [Test]
        public void Test01_SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void Test02_Ladder()
        {
            string stringToConvert = "aaaa1 41RIDDLE";
            string methodAnswer = FormattedString.Ladder(stringToConvert);      
            string correctAnswer = "AaAa1 41RiDdLe";
            Assert.AreEqual(correctAnswer, methodAnswer);
        }

    }
}
