namespace AlgorithmsAndDataStructures
{
    public class Tree<T>
    {
        ///////////////////////// Constructors /////////////////////////
        
        public Tree(Node<T> rootNode = null)
        {
            Root = rootNode;
        }
        
        ////////////////////////////////////////////////////////////////


        //////////////////////// Queue properties ///////////////////////

        public Node<T> Root { get; set; }

        ////////////////////////////////////////////////////////////////


        ////////////////////// Node class model ////////////////////////

        public class Node<T>
        {
            public Node(T value)
            {
                Value = value;
                Children = new List<Node<T>>();
            }


            public T Value { get; set; }
            public List<Node<T>> Children { get; set; }


            public void AddNode(T value)
            {
                Children.Add(new Node<T>(value));
            }

            public void AddNode(Node<T> node)
            {
                Children.Add(node);
            }

            public void RemoveNode(Node<T> node)
            {
                Children.Remove(node);
            }
        }

        ////////////////////////////////////////////////////////////////


        ////////////////// Tree Manipulation Methods ///////////////////

        public Node<T> Find(T value)
        {
            return FindNodeWithValue(Root, value);
        }

        private Node<T> FindNodeWithValue(Node<T> node, T value)
        {
            if (node == null)
                return null;

            if (EqualityComparer<T>.Default.Equals(node.Value, value))
                return node;

            //Recursively iterate the children and look for the value.
            foreach (var child in node.Children)
            {
                var result = FindNodeWithValue(child, value);
                if (result != null)
                    return result;
            }

            return null;
        }

        //Breadth First Search - Done non-recursively using a queue.
        public void BFS(Action<T> action)
        {
            if (Root == null)
                return;

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(Root);

            //Iterate through the queue and process each node until the queue is empty.
            while (queue.Count > 0)
            {
                //Get the current node from the queue.
                Node<T> node = queue.Dequeue();

                //Process the current node with the function passed in via the action parameter.
                action(node.Value);

                //Add the children of the current node to the queue.
                foreach (var child in node.Children)
                    queue.Enqueue(child);
            }
        }

        //Depth First Search - Done non-recursively using a stack.
        public void DFS(Action<T> action)
        {
            if (Root == null)
                return;

            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(Root);

            //Iterate through the stack and process each node until the stack is empty.
            while (stack.Count > 0)
            {
                //Get the current node from the stack.
                Node<T> node = stack.Pop();

                //Process the current node with the function passed in via the action parameter.
                action(node.Value);

                //Add the children of the current node to the stack in reverse order.
                for (int i = node.Children.Count - 1; i >= 0; i--)
                    stack.Push(node.Children[i]);
            }
        }


        ////////////////////////////////////////////////////////////////
    }
}
