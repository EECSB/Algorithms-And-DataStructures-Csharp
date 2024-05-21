namespace AlgorithmsAndDataStructures.Tests
{
    [TestClass]
    public class MyHashtableTests
    {
        [TestMethod]
        public void AddTest()
        {
            //Arrange
            var hashtable = new MyHashtable<int, string>();

            //Act
            hashtable.Add(1, "One");

            //Assert
            Assert.IsTrue(hashtable.Contains(1));
        }

        [TestMethod]
        public void GetExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<string, int>();
            hashtable.Add("One", 1);

            //Act
            var result = hashtable.Get("One");

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetNonExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<string, int>();

            //Act, Assert
            Assert.ThrowsException<KeyNotFoundException>(() => hashtable.Get("Two"));
        }

        [TestMethod]
        public void TryGetExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<int, string>();
            hashtable.Add(1, "One");

            //Act
            bool result = hashtable.TryGet(1, out string value);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual("One", value);
        }

        [TestMethod]
        public void TryGetNonExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<string, int>();

            //Act
            bool result = hashtable.TryGet("Two", out int value);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(default(int), value);
        }

        [TestMethod]
        public void ContainsExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<int, string>();
            hashtable.Add(1, "One");

            //Act
            bool result = hashtable.Contains(1);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsNonExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<string, int>();

            //Act
            bool result = hashtable.Contains("Two");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<int, string>();
            hashtable.Add(1, "One");

            //Act
            hashtable.Remove(1);

            //Assert
            Assert.IsFalse(hashtable.Contains(1));
        }

        [TestMethod]
        public void RemoveNonExistingKeyTest()
        {
            //Arrange
            var hashtable = new MyHashtable<string, int>();

            //Act
            hashtable.Remove("Two");

            //Assert
            //No exception should be thrown.
        }
    }
}