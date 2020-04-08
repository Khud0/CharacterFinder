using NUnit.Framework;
using StringPlay;

namespace CharacterFinderTests
{
    class SortedStringTests
    {
        private string stringToSort = "ewqwkqjkqwjrkqwjkasdsufgisddkdkdkskkakasjqwkqqlxzxcvbbn";
        private string correctAnswerAscending = "aaabbcdddddefgijjjjkkkkkkkkkkklnqqqqqqqrsssssuvwwwwwxxz";
        private string correctAnswerDescending = "zxxwwwwwvusssssrqqqqqqqnlkkkkkkkkkkkjjjjigfedddddcbbaaa";

        [Test]
        public void Test01_SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void Test02_BubbleSort_Ascending()
        {
            string methodAnswer = SortedString.BubbleSort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test03_BubbleSort_Descending()
        {
            string methodAnswer = SortedString.BubbleSort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }

        [Test]
        public void Test04_CharArraySort_Ascending()
        {
            string methodAnswer = SortedString.CharArraySort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test05_CharArraySort_Descending()
        {
            string methodAnswer = SortedString.CharArraySort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }

        [Test]
        public void Test06_ToIntSelectionSort_Ascending()
        {
            string methodAnswer = SortedString.ToIntSelectionSort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test07_ToIntSelectionSort_Descending()
        {
            string methodAnswer = SortedString.ToIntSelectionSort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }

        [Test]
        public void Test08_ToIntSelectionSort_Descending2()
        {
            string testStringEasy = "abcdefg";
            string methodAnswer = SortedString.ToIntSelectionSort(testStringEasy, false);     
            Assert.AreEqual("gfedcba", methodAnswer);
        }

        [Test]
        public void Test09_GnomeSort_Ascending()
        {
            string methodAnswer = SortedString.GnomeSort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test10_GnomeSort_Descending()
        {
            string methodAnswer = SortedString.GnomeSort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }

        [Test]
        public void Test11_InsertionSort_Ascending()
        {
            string methodAnswer = SortedString.InsertionSort(stringToSort, true);          
            Assert.AreEqual(correctAnswerAscending, methodAnswer);
        }

        [Test]
        public void Test12_InsertionSort_Descending()
        {
            string methodAnswer = SortedString.InsertionSort(stringToSort, false);     
            Assert.AreEqual(correctAnswerDescending, methodAnswer);
        }
    }
}
