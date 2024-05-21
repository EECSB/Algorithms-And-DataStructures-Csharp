namespace AlgorithmsAndDataStructures.DS.Tests
{
    [TestClass()]
    public class TreeTests
    {
        [TestMethod()]
        public void FindTest()
        {
            //Arrange
            Tree<int> tree = new Tree<int>();

            tree.Root = new Tree<int>.Node<int>(1);

            var node2 = new Tree<int>.Node<int>(2);
            var node3 = new Tree<int>.Node<int>(3);
            tree.Root.AddNode(node2);
            tree.Root.AddNode(node3);

            var node4 = new Tree<int>.Node<int>(4);
            node3.AddNode(node4);

            var node5 = new Tree<int>.Node<int>(5);
            var node6 = new Tree<int>.Node<int>(6);
            node4.AddNode(node5);
            node4.AddNode(node6);

            //Act
            var foundNode = tree.Find(5);

            //Assert
            Assert.IsNotNull(foundNode);
            Assert.AreEqual(5, foundNode.Value);
        }

        [TestMethod()]
        public void BFSTest()
        {
            // Arrange
            Tree<int> tree = new Tree<int>();

            tree.Root = new Tree<int>.Node<int>(1);

            var node2 = new Tree<int>.Node<int>(2);
            var node3 = new Tree<int>.Node<int>(3);
            tree.Root.AddNode(node2);
            tree.Root.AddNode(node3);

            var node4 = new Tree<int>.Node<int>(4);
            node3.AddNode(node4);

            var node5 = new Tree<int>.Node<int>(5);
            var node6 = new Tree<int>.Node<int>(6);
            node4.AddNode(node5);
            node4.AddNode(node6);

            int[] expectedOrder = { 1, 2, 3, 4, 5, 6 };
            int[] actualOrder = new int[expectedOrder.Length];
            int index = 0;

            // Act
            tree.BFS(value => actualOrder[index++] = value);

            // Assert
            CollectionAssert.AreEqual(expectedOrder, actualOrder);
        }

        [TestMethod()]
        public void DFSTest()
        {
            //Arrange
            Tree<int> tree = new Tree<int>();

            tree.Root = new Tree<int>.Node<int>(1);

            var node2 = new Tree<int>.Node<int>(2);
            var node3 = new Tree<int>.Node<int>(3);
            tree.Root.AddNode(node2);
            tree.Root.AddNode(node3);

            var node4 = new Tree<int>.Node<int>(4);
            node3.AddNode(node4);

            var node5 = new Tree<int>.Node<int>(5);
            var node6 = new Tree<int>.Node<int>(6);
            node4.AddNode(node5);
            node4.AddNode(node6);

            int[] expectedOrder = { 1, 2, 3, 4, 5, 6 };
            int[] actualOrder = new int[expectedOrder.Length];
            int index = 0;

            //Act
            tree.DFS(value => actualOrder[index++] = value);

            //Assert
            CollectionAssert.AreEqual(expectedOrder, actualOrder);
        }
    }
}