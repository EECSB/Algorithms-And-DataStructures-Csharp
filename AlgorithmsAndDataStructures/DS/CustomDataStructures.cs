namespace AlgorithmsAndDataStructures
{
    internal class CustomDataStructures
    {
        public static void RunCustomDataStructures()
        {
            //A list is a collection of values stored in memory(different parts of memory).
            //The elements in the list store the value itself and a pointer to the location of the next element.
            //This makes a list slower than arrays for lookups, O(n) time complexity.
            //But they are much more flexible when it comes to adding/removing elements.
            //Unlike arrays they don't have to be resized if the number of elements exceeds the originally allocated size.
            MyList<int> list = new MyList<int>();
            list.Add(8);
            list.Add(7);
            list.RemoveAt(0);



            //A queue contains elements in a FIFO(first in first out) order.
            //You can only add elements to the back of the queue(using Enqueue()) and remove elements from the front of the queue(using Dequeue()).
            //A queue is really just a list with some restrictions on how you can interact with it.
            //The restriction is that you can only add elements to the front of the list and remove them from the back.
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Enqueue(3);
            int queueItem = queue.Dequeue();



            //A stack contains elements in a LIFO(last in first out) order.
            //You can only add elements to the top of the stack(using Push()) and remove elements from the top of the stack(using Pop()).
            //A stack is also really just a list with some restrictions on how you can interact with it.
            //The restriction is that you can only add elements to the front of the list and also only remove them from the front. (you could also do the opposite and only add/remove elements from the back)
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(5);
            stack.Push(3);
            int stackItem = stack.Pop();



            //A hash set is a collection of unique values with very fast lookup times for stored values.
            //This is because it uses a hash function to map the value to a location in memory(just like an array). We'll see how it works when we implement our own later on.
            //A typical use case for a hashset would be iterating over a data structure and using the hash set to check if you have already visited a node.
            //So every time you visit a node you add it to the hash set, then before you visit the next node you check if it's in the hashset.
            //A dictionary is a collection of key-value pairs.
            //It's almost the same as a hashset with the addition of a value stored "behind" the key which can be used to look up the value said value.
            MyHashtable<string, string> dictionary = new MyHashtable<string, string>();
            dictionary.Add("id1", "some value");
            dictionary.Add("id2", "some other value");
            dictionary.Add("id3", "another value");

            if (dictionary.Contains("id2"))
            {
                //Get value by key ...
                string value = dictionary.Get("id2");

                //... do something ... 

                //... and remove element.
                dictionary.Remove("id2");
            }



            //A tree is a data structure that is composed of nodes.
            //Each node has a value and a list of child nodes(references pointing to child nodes).
            //A node can only have one parent node.
            //And it can't have any connections to its peers(nodes that are on the same level in the tree).

            //Declare/instantiate a tree ...
            Tree<int> tree = new Tree<int>();

            //... and add nodes to it.
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

            tree.BFS(Console.WriteLine);
            tree.DFS(Console.WriteLine);



            //A graph is a data structure composed of nodes and edges.
            //An edge is a connection between two nodes.
            //Each node has a value and a list of edges(references pointing to other nodes).
            //A graph can be directed or undirected. The blockhain for example, is a DAG(directed acyclic graph) where nodes can only be added in one direction.
            //In an undirected graph the edges don't have a direction and can point to any other node in the graph.

            //Declare/instantiate a graph ...
            Graph<int> graph = new Graph<int>();

            //... and add nodes and edges to it.
            graph.AddNode(0);
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);

            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 4, 1);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(1, 3, 1);
            graph.AddEdge(1, 4, 1);
            graph.AddEdge(2, 3, 1);
            graph.AddEdge(3, 4, 1);

            Console.WriteLine("BFS traversal:");
            graph.TraverseBFS(0, Console.WriteLine);

            Console.WriteLine("DFS traversal:");
            graph.TraverseDFS(0, Console.WriteLine);
        }
    }
}
