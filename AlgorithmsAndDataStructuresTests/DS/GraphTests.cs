namespace AlgorithmsAndDataStructures.Tests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void AddNodeTest()
        {
            //Arrange
            Graph<int> graph = new Graph<int>();

            //Act
            graph.AddNode(1);

            //Assert
            Assert.IsTrue(graph.ContainsNode(1));
        }

        [TestMethod]
        public void AddEdgeTest()
        {
            //Arrange
            Graph<int> graph = new Graph<int>();
            graph.AddNode(1);
            graph.AddNode(2);

            //Act
            graph.AddEdge(1, 2, 1);

            //Assert
            Assert.IsTrue(graph.ContainsEdge(1, 2));
            Assert.IsTrue(graph.ContainsEdge(2, 1));
        }

        [TestMethod]
        public void AddDirectedEdgeTest()
        {
            //Arrange
            Graph<int> graph = new Graph<int>();
            graph.AddNode(1);
            graph.AddNode(2);

            //Act
            graph.AddDirectedEdge(1, 2, 1);

            //Assert
            Assert.IsTrue(graph.ContainsEdge(1, 2));
            Assert.IsFalse(graph.ContainsEdge(2, 1));
        }

        [TestMethod]
        public void RemoveNodeTest()
        {
            //Arrange
            Graph<int> graph = new Graph<int>();
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(1, 3, 1);

            List<int> bfsOrder = new List<int>();
            Action<int> action = (node) => bfsOrder.Add(node);

            //Act
            graph.TraverseBFS(1, action);

            //Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, bfsOrder);
        }

        [TestMethod]
        public void TraverseBFSTest()
        {
            //Arrange
            Graph<int> graph = new Graph<int>();
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddEdge(1, 2, 1);

            //Act
            graph.RemoveNode(1);

            //Assert
            Assert.IsFalse(graph.ContainsNode(1));
            Assert.IsFalse(graph.ContainsEdge(1, 2));
        }

        [TestMethod]
        public void TraverseDFSTest()
        {
            //Arrange
            Graph<int> graph = new Graph<int>();
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(1, 3, 1);

            List<int> dfsOrder = new List<int>();
            Action<int> action = (node) => dfsOrder.Add(node);

            //Act
            graph.TraverseDFS(1, action);

            //Assert
            CollectionAssert.AreEqual(new List<int> { 1, 3, 2 }, dfsOrder);
        }
    }
}