using NUnit.Framework;
using CharacterSearch;

namespace CharacterFinderTests
{
    class SortedStringTests
    {
        private string stringToSort = "ewqwkqjkqwjrkqwjkasdsufgisddkdkdkskkakasjqwkqqlxzxcvbbn";
        private string correctAnswerAscending = "aaabbcdddddefgijjjjkkkkkkkkkkklnqqqqqqqrsssssuvwwwwwxxz";
        private string correctAnswerDescending = "zxxwwwwwvusssssrqqqqqqqnlkkkkkkkkkkkjjjjigfedddddcbbaaa";

        [Test]
        public void Test1_SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2_BubbleSort_Ascending()
        {
            string methodAnswer = SortedString.BubbleSort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test3_BubbleSort_Descending()
        {
            string methodAnswer = SortedString.BubbleSort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }

        [Test]
        public void Test4_CharArraySort_Ascending()
        {
            string methodAnswer = SortedString.CharArraySort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test5_CharArraySort_Descending()
        {
            string methodAnswer = SortedString.CharArraySort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }

        [Test]
        public void Test6_ToIntSelectionSort_Ascending()
        {
            string methodAnswer = SortedString.ToIntSelectionSort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test7_ToIntSelectionSort_Descending()
        {
            string methodAnswer = SortedString.ToIntSelectionSort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }

        [Test]
        public void Test8_ToIntSelectionSort_Descending2()
        {
            string testStringEasy = "abcdefg";
            string methodAnswer = SortedString.ToIntSelectionSort(testStringEasy, false);     
            Assert.AreEqual("gfedcba", methodAnswer);
        }
    }
}
