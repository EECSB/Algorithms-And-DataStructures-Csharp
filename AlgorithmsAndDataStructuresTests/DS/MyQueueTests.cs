namespace AlgorithmsAndDataStructures.DS.Tests
{
    [TestClass]
    public class MyQueueTests
    {
        [TestMethod]
        public void EnqueueTest()
        {
            //Arrange
            var queue = new MyQueue<int>();

            //Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            //Assert
            Assert.AreEqual(1, queue.rootNode.Value);
            Assert.AreEqual(2, queue.rootNode.Next.Value);
            Assert.AreEqual(3, queue.rootNode.Next.Next.Value);
        }

        [TestMethod]
        public void DequeueTest()
        {
            //Arrange
            var queue = new MyQueue<int>();

            //Act
            //queue.Enqueue(1);
            queue.rootNode = new MyQueue<int>.Node<int>(1);
            queue.currentNode = queue.rootNode;

            //queue.Enqueue(2);
            queue.currentNode.Next = new MyQueue<int>.Node<int>(2);
            queue.currentNode = queue.currentNode.Next;

            //queue.Enqueue(3);
            queue.currentNode.Next = new MyQueue<int>.Node<int>(3);
            queue.currentNode = queue.currentNode.Next;

            //Assert
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(default(int), queue.Dequeue()); //If the queue is empty expect default(int).
        }
    }
}