namespace AlgorithmsAndDataStructures
{
    public class DotnetDataStructures
    {
        public static void RunDotnetDataStructures()
        {
            //Data structures part of .NET

            //This is just a regular variable. A single value stored at a memory location.
            int variable = 10;

    

            //An array is a collection of values stored in a contiguous(values stored one after the other in memory) chunk of memory.
            //In the example below the "array" variable contains the memory location of the first element of the array.
            //When you use the index like so "[1]" it's added to the memory location stored in the "array" variable.
            //The resulting value is the memory location of where the requested the element is located.
            //This makes array lookups very fast, O(1) time complexity.
            int[] array = new int[3];
            array[0] = 2;
            array[1] = 5;



            //A list is a collection of values stored in memory(different parts of memory).
            //The elements in the list store the value itself and a pointer to the location of the next element.
            //This makes a list slower than arrays for lookups, O(n) time complexity.
            //But they are much more flexible when it comes to adding/removing elements.
            //Unlike arrays they don't have to be resized if the number of elements exceeds the originally allocated size.
            List<int> list = new List<int>();
            list.Add(8);
            list.Add(7);
            list.RemoveAt(0);


            //A queue contains elements in a FIFO(first in first out) order.
            //You can only add elements to the back of the queue(using Enqueue()) and remove elements from the front of the queue(using Dequeue()).
            //A queue is really just a list with some restrictions on how you can interact with it.
            //The restriction is that you can only add elements to the front of the list and remove them from the back.
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Enqueue(3);
            int queueItem = queue.Dequeue();



            //A stack contains elements in a LIFO(last in first out) order.
            //You can only add elements to the top of the stack(using Push()) and remove elements from the top of the stack(using Pop()).
            //A stack is also really just a list with some restrictions on how you can interact with it.
            //The restriction is that you can only add elements to the front of the list and also only remove them from the front. (you could also do the opposite and only add/remove elements from the back)
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(5);
            stack.Push(3);
            int stackItem = stack.Pop();



            //A hash set is a collection of unique values with very fast lookup times for stored values.
            //This is because it uses a hash function to map the value to a location in memory(just like an array). We'll see how it works when we implement our own later on.
            //A typical use case for a hashset would be iterating over a data structure and using the hash set to check if you have already visited a node.
            //So every time you visit a node you add it to the hash set, then before you visit the next node you check if it's in the hashset.
            HashSet<string> hashset = new HashSet<string>();
            hashset.Add("hello");
            hashset.Add("world");
            hashset.Add("!");

            if (hashset.Contains("world"))
            {
                //Do something ...
            }


            //A dictionary is a collection of key-value pairs.
            //It's almost the same as a hashset with the addition of a value stored "behind" the key which can be used to look up the value said value.
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("id1", "some value");
            dictionary.Add("id2", "some other value");
            dictionary.Add("id3", "another value");

            string value = dictionary["id2"];
        }
    }
}
