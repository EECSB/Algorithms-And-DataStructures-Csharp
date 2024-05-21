using AlgorithmsAndDataStructures;

namespace OtherAlgorithmsAndDataStructures.Tests
{
    [TestClass]
    public class OtherOtherAlgorithmsTests
    {
        [TestMethod]
        public void LinearSearchFoundTest()
        {
            //Arrange
            int[] arr = { 4, 6, 2, 8, 5 };
            int find = 2;
            int expectedIndex = 2;

            //Act
            int result = OtherAlgorithms.LinearSearch(find, arr);

            //Assert
            Assert.AreEqual(expectedIndex, result);
        }

        [TestMethod]
        public void LinearSearchNotFoundTest()
        {
            //Arrange
            int[] arr = { 4, 6, 2, 8, 5 };
            int find = 9;

            //Act
            int result = OtherAlgorithms.LinearSearch(find, arr);

            //Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void BinarySearchFoundTest()
        {
            //Arrange
            int[] arr = { 2, 4, 5, 6, 8 };
            int find = 5;
            int expectedIndex = 2;

            //Act
            int result = OtherAlgorithms.BinarySearch(find, arr);

            //Assert
            Assert.AreEqual(expectedIndex, result);
        }

        [TestMethod]
        public void BinarySearchNotFoundTest()
        {
            //Arrange
            int[] arr = { 2, 4, 5, 6, 8 };
            int find = 9;

            //Act
            int result = OtherAlgorithms.BinarySearch(find, arr);

            //Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void MaxSumSubarrayTest()
        {
            //Arrange
            int[] numbers = { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
            int subArraySize = 4;
            int expectedMaxSum = 24;

            //Act
            int result = OtherAlgorithms.MaxSumSubarray(numbers, subArraySize);

            //Assert
            Assert.AreEqual(expectedMaxSum, result);
        }

        [TestMethod]
        public void TwoSumFoundTest()
        {
            //Arrange
            int[] numbers = { 2, 4, 7, 11, 15 };
            int targetValue = 9;
            int expectedNum1 = 2;
            int expectedNum2 = 7;

            //Act
            var result = OtherAlgorithms.TwoSum(numbers, targetValue);

            //Assert
            Assert.AreEqual(expectedNum1, result.Item1);
            Assert.AreEqual(expectedNum2, result.Item2);
        }

        [TestMethod]
        public void TwoSumNotFoundTest()
        {
            //Arrange
            int[] numbers = { 2, 4, 7, 11, 15 };
            int targetValue = 20;

            //Act
            var result = OtherAlgorithms.TwoSum(numbers, targetValue);

            //Assert
            Assert.IsNull(result.Item1);
            Assert.IsNull(result.Item2);
        }

        [TestMethod]
        public void HasCycleTrueTest()
        {
            //Arrange
            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.currentNode.Next = myList.rootNode; //Add cycle.

            //Act
            bool result = OtherAlgorithms.HasCycle(myList.rootNode);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasCycleFalseTest()
        {
            //Arrange
            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            //Act
            bool result = OtherAlgorithms.HasCycle(myList.rootNode);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindPathPathFoundTest()
        {
            //Arrange
            int[,] grid = new int[,]
            {
                { 0, 0, 0, 0 },
                { 1, 1, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 0, 0, 0 }
            };
            var start = new OtherAlgorithms.AStar.Node(0, 0);
            var finish = new OtherAlgorithms.AStar.Node(2, 2);

            //Act
            List<OtherAlgorithms.AStar.Node> path = OtherAlgorithms.AStar.FindPath(grid, start, finish);

            //Assert
            Assert.IsNotNull(path);
            Assert.IsTrue(path.Count > 0);

            //First node should be at the same position as the start node.
            Assert.AreEqual(start.Col, path.First().Col);
            Assert.AreEqual(start.Row, path.First().Row);

            //Last node should be at the same position as the finish node.
            Assert.AreEqual(finish.Col, path.Last().Col);
            Assert.AreEqual(finish.Row, path.Last().Row);
        }

        [TestMethod]
        public void FindPathPathFound2Test()
        {
            //Arrange
            int[,] grid = {
                { 0, 0, 0, 0, 0, 0, 1 },
                { 0, 1, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };
            var start = new OtherAlgorithms.AStar.Node(0, 0);
            var finish = new OtherAlgorithms.AStar.Node(2, 6);

            //Act
            List<OtherAlgorithms.AStar.Node> path = OtherAlgorithms.AStar.FindPath(grid, start, finish);

            //Assert
            Assert.IsNotNull(path);
            Assert.IsTrue(path.Count > 0);

            //First node should be at the same position as the start node.
            Assert.AreEqual(start.Col, path.First().Col);
            Assert.AreEqual(start.Row, path.First().Row);

            //Last node should be at the same position as the finish node.
            Assert.AreEqual(finish.Col, path.Last().Col);
            Assert.AreEqual(finish.Row, path.Last().Row);
        }

        [TestMethod]
        public void FindPathPathFound3Test()
        {
            //Arrange
            int[,] grid = {
                { 0, 0, 0, 0, 0, 0, 1 },
                { 0, 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };
            var start = new OtherAlgorithms.AStar.Node(0, 0);
            var finish = new OtherAlgorithms.AStar.Node(4, 5);

            //Act
            List<OtherAlgorithms.AStar.Node> path = OtherAlgorithms.AStar.FindPath(grid, start, finish);

            //Assert
            Assert.IsNotNull(path);
            Assert.IsTrue(path.Count > 0);

            //First node should be at the same position as the start node.
            Assert.AreEqual(start.Col, path.First().Col);
            Assert.AreEqual(start.Row, path.First().Row);

            //Last node should be at the same position as the finish node.
            Assert.AreEqual(finish.Col, path.Last().Col);
            Assert.AreEqual(finish.Row, path.Last().Row);
        }

        [TestMethod]
        public void FindPathNoPathTest()
        {
            //Arrange
            int[,] grid = new int[,]
            {
                { 0, 0, 0, 0 },
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
            var start = new OtherAlgorithms.AStar.Node(0, 0);
            var finish = new OtherAlgorithms.AStar.Node(3, 3);

            //Act
            List<OtherAlgorithms.AStar.Node> path = OtherAlgorithms.AStar.FindPath(grid, start, finish);

            //Assert
            Assert.IsNull(path);
        }

        [TestMethod]
        public void AddEdgeAddEdgeBetweenNodesTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();

            //Act
            graph.AddEdge(0, 1, 3);
            graph.AddEdge(1, 2, 2);

            //Assert
            Assert.IsTrue(graph.ContainsEdge(0, 1));
            Assert.IsTrue(graph.ContainsEdge(1, 0)); //Bidirectional edge
            Assert.IsTrue(graph.ContainsEdge(1, 2));
            Assert.IsTrue(graph.ContainsEdge(2, 1)); //Bidirectional edge
        }

        [TestMethod]
        public void RemoveEdgeRemoveEdgeBetweenNodesTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();
            graph.AddEdge(0, 1, 3);
            graph.AddEdge(1, 2, 2);

            //Act
            graph.RemoveEdge(0, 1);

            //Assert
            Assert.IsFalse(graph.ContainsEdge(0, 1));
            Assert.IsFalse(graph.ContainsEdge(1, 0)); //Bidirectional edge removed
            Assert.IsTrue(graph.ContainsEdge(1, 2));
            Assert.IsTrue(graph.ContainsEdge(2, 1)); //Bidirectional edge still exists
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveEdgeThrowExceptionWhenEdgeDoesNotExistTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();

            //Act
            graph.RemoveEdge(0, 1); 
            
            //Assert
            //Should throw exception.
        }

        [TestMethod]
        public void ContainsEdgeReturnTrueIfEdgeExists()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();
            graph.AddEdge(0, 1, 3);

            //Assert
            Assert.IsTrue(graph.ContainsEdge(0, 1));
        }

        [TestMethod]
        public void ContainsEdgeFalseIfEdgeDoesNotExistTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();

            //Assert
            Assert.IsFalse(graph.ContainsEdge(0, 1));
        }

        [TestMethod]
        public void RemoveEdgeRemovesEdgeCorrectlyTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();
            graph.AddEdge(0, 1, 4);

            //Act
            graph.RemoveEdge(0, 1);

            //Assert
            Assert.IsFalse(graph.ContainsEdge(0, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveEdgeThrowsExceptionWhenEdgeDoesNotExistTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();

            //Act
            graph.RemoveEdge(0, 1);

            //Assert
            //Exception is expected.
        }

        [TestMethod]
        public void FindPathDijkstraTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();
            graph.AddEdge(0, 1, 3);
            graph.AddEdge(0, 2, 2);
            graph.AddEdge(1, 2, 2);
            graph.AddEdge(1, 3, 1);
            graph.AddEdge(2, 3, 3);
            graph.AddEdge(1, 4, 4);
            graph.AddEdge(4, 5, 1);
            graph.AddEdge(3, 5, 2);
            graph.AddEdge(2, 5, 6);
            graph.AddEdge(2, 6, 5);
            graph.AddEdge(6, 5, 2);

            //Act
            var (distances, paths) = graph.FindPathDijkstra(0);

            //Assert distances
            Assert.AreEqual(0, distances[0]);
            Assert.AreEqual(3, distances[1]);
            Assert.AreEqual(2, distances[2]);
            Assert.AreEqual(4, distances[3]);
            Assert.AreEqual(7, distances[4]);
            Assert.AreEqual(6, distances[5]);
            Assert.AreEqual(7, distances[6]);

            //Assert paths
            Assert.AreEqual(-1, paths[0]); // No previous node for start node
            Assert.AreEqual(0, paths[1]);
            Assert.AreEqual(0, paths[2]);
            Assert.AreEqual(1, paths[3]);
            Assert.AreEqual(1, paths[4]);
            Assert.AreEqual(3, paths[5]);
            Assert.AreEqual(2, paths[6]);
        }

        [TestMethod]
        public void FindPathDijkstraDisconnectedGraphTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();
            graph.AddEdge(0, 1, 3);
            graph.AddEdge(0, 2, 2);
            graph.AddEdge(1, 2, 2);
            //Disconnected from part above.
            graph.AddEdge(3, 4, 1); 

            //Act
            var (distances, paths) = graph.FindPathDijkstra(0);

            //Assert distances
            Assert.AreEqual(0, distances[0]);
            Assert.AreEqual(3, distances[1]);
            Assert.AreEqual(2, distances[2]);
            Assert.AreEqual(int.MaxValue, distances[3]); //Node 3 not reachable from node 0.
            Assert.AreEqual(int.MaxValue, distances[4]); //Node 4 not reachable from node 0.

            //Assert paths
            Assert.AreEqual(-1, paths[0]); //No path found.
            Assert.AreEqual(0, paths[1]);
            Assert.AreEqual(0, paths[2]);
            Assert.AreEqual(-1, paths[3]); //No path found.
            Assert.AreEqual(-1, paths[4]); //No path found.
        }

        [TestMethod]
        public void FindPathDijkstraSingleNodeGraphTest()
        {
            //Arrange
            var graph = new OtherAlgorithms.DijkstraExample_Graph();
            graph.AddEdge(0, 0, 0);

            //Act
            var (distances, paths) = graph.FindPathDijkstra(0);

            //Assert distances
            Assert.AreEqual(0, distances[0]); //Distance to itself should be 0.

            //Assert paths
            Assert.AreEqual(-1, paths[0]); //-1 Indicates no paths found.
        }
    }
}