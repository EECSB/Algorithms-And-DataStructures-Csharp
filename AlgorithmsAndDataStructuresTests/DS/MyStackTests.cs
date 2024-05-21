namespace AlgorithmsAndDataStructures.DS.Tests
{
    [TestClass()]
    public class MyStackTests
    {
        [TestMethod]
        public void PushTest()
        {
            //Arrange
            MyStack<int> stack = new MyStack<int>();

            //Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Assert
            Assert.AreEqual(3, stack.currentNode.Value);
            Assert.AreEqual(2, stack.currentNode.Previous.Value);
            Assert.AreEqual(1, stack.currentNode.Previous.Previous.Value);
        }

        [TestMethod()]
        public void PopTest()
        {
            //Arrange
            MyStack<int> stack = new MyStack<int>();

            //Assert
            Assert.AreEqual(default(int), stack.Pop()); //If the stack is empty expect default(int).
        
            //Act   
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Assert
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        [TestMethod()]
        public void PeekTest()
        {
            //Arrange
            MyStack<int> stack = new MyStack<int>();

            //Assert
            Assert.AreEqual(default(int), stack.Peek()); //If the stack is empty expect default(int).

            //Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Assert
            Assert.AreEqual(3, stack.Peek());
        }
    }
}