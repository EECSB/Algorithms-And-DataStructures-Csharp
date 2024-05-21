namespace AlgorithmsAndDataStructures.DS.Tests
{
    [TestClass()]
    public class MyListTests
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            MyList<int> list = new MyList<int>();

            //Act
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Assert
            Assert.AreEqual(1, list.Get(0));
            Assert.AreEqual(2, list.Get(1));
            Assert.AreEqual(3, list.Get(2));
        }

        [TestMethod]
        public void RemoveTest()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            var nodeToRemove = list.GetNode(2);
            list.Remove(nodeToRemove);

            //Assert
            Assert.AreEqual(1, list.Get(0));
            Assert.AreEqual(3, list.Get(1));
        }

        [TestMethod]
        public void RemoveAtTest_OutOfRange()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(10));
        }

        [TestMethod]
        public void RemoveAtTest_0()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            list.RemoveAt(0);

            //Assert
            Assert.AreEqual(2, list.Get(0));
            Assert.AreEqual(3, list.Get(1));
        }

        [TestMethod]
        public void RemoveAtTest_1()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            list.RemoveAt(1);

            //Assert
            Assert.AreEqual(1, list.Get(0));
            Assert.AreEqual(3, list.Get(1));
        }

        [TestMethod]
        public void GetTest()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act, Assert
            Assert.AreEqual(1, list.Get(0));
            Assert.AreEqual(2, list.Get(1));
            Assert.AreEqual(3, list.Get(2));

            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Get(-1));
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.Get(3));
        }

        [TestMethod]
        public void GetNodeTest()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            var node = list.GetNode(2);

            //Assert
            Assert.IsNotNull(node);
            Assert.AreEqual(2, node.Value);
            Assert.IsNull(list.GetNode(5));
        }
    }
}