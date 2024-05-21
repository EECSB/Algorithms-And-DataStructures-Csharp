namespace AlgorithmsAndDataStructures.ALG.Tests
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        [TestMethod]
        public void BubbleSortTest()
        {
            testSort(SortingAlgorithms.BubbleSort);
        }

        [TestMethod]
        public void SelectionSortTest()
        {
            testSort(SortingAlgorithms.SelectionSort);
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            testSort(SortingAlgorithms.InsertionSort);
        }

        [TestMethod]
        public void CountingSortTest()
        {
            testSort(SortingAlgorithms.CountingSort);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            testSort(SortingAlgorithms.MergeSort);
        }


        private void testSort(Action<int[]> action)
        {
            //Arrange
            int[] arr = { 5, 3, 2, 4, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            //Act
            action(arr);

            //Assert
            CollectionAssert.AreEqual(expected, arr);
            Assert.ThrowsException<ArgumentNullException>(() => action(null));
        }
    }
}