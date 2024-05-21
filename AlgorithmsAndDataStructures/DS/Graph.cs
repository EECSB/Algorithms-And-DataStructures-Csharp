namespace AlgorithmsAndDataStructures
{
    //A graph data structure can either be represented using an adjacency list or an adjacency matrix.
    //We'll use an adjacency list to represent the graph in this example.
    //Adjacency list vs matrix: https://en.wikipedia.org/wiki/Adjacency_list#:~:text=of%20the%20degree.-,Trade%2Doffs,-%5Bedit%5D

    public class Graph<T>
    {
        ///////////////////////// Constructors /////////////////////////

        public Graph()
        {
            nodes = new Dictionary<T, Node<T>>();
        }

        ////////////////////////////////////////////////////////////////


        /////////////////////// Graph properties ///////////////////////

        private Dictionary<T, Node<T>> nodes;

        ////////////////////////////////////////////////////////////////


        ////////////////// Node - Edge class models ////////////////////

        public class Node<T>
        {
            public Node(T value)
            {
                Value = value;
                Edges = new List<Edge>();
            }

            public T Value { get; set; }
            public List<Edge> Edges { get; }
        }

        public class Edge
        {
            public Node<T> Target { get; set; }
            public int Weight { get; set; }

            public Edge(Node<T> target, int weight)
            {
                Target = target;
                Weight = weight;
            }
        }

        ///////////////////////////////////////////////////////////////


        ////////////////// Graph Manipulation Methods /////////////////

        public void AddNode(T value)
        {
            if (!nodes.ContainsKey(value))
                nodes[value] = new Node<T>(value);
        }

        public void AddEdge(T source, T target, int weight)
        {
            if (!nodes.ContainsKey(source) || !nodes.ContainsKey(target))
                throw new ArgumentException("Source or target node doesn't exist.");

            Node<T> sourceNode = nodes[source];
            Node<T> targetNode = nodes[target];

            sourceNode.Edges.Add(new Edge(targetNode, weight));
            targetNode.Edges.Add(new Edge(sourceNode, weight));
        }

        public void AddDirectedEdge(T source, T target, int weight)
        {
            if (!nodes.ContainsKey(source) || !nodes.ContainsKey(target))
                throw new ArgumentException("Source or target node doesn't exist.");

            Node<T> sourceNode = nodes[source];
            Node<T> targetNode = nodes[target];

            sourceNode.Edges.Add(new Edge(targetNode, weight));
        }

        public void RemoveNode(T value)
        {
            if (!nodes.ContainsKey(value))
                throw new ArgumentException("Node doesn't exist.");

            //Remove the node from the dictionary.
            Node<T> nodeToRemove = nodes[value];
            nodes.Remove(value);

            //Remove edges pointing to the removed node.
            foreach (var node in nodes.Values)
                node.Edges.RemoveAll(edge => edge.Target == nodeToRemove);
        }

        public bool ContainsNode(T value)
        {
            return nodes.ContainsKey(value);
        }

        public bool ContainsEdge(T source, T target)
        {
            if (!nodes.ContainsKey(source) || !nodes.ContainsKey(target))
                return false;

            Node<T> sourceNode = nodes[source];

            return sourceNode.Edges.Any(edge => edge.Target.Value.Equals(target));
        }

        public void TraverseBFS(T start, Action<T> action)
        {
            //Use hashset to keep track of visited nodes.
            HashSet<T> visited = new HashSet<T>();
            Queue<Node<T>> queue = new Queue<Node<T>>();

            Node<T> startNode = nodes[start];
            queue.Enqueue(startNode);
            visited.Add(startNode.Value);

            //Iterate through the queue and process each node until the queue is empty.
            while (queue.Count > 0)
            {
                //Get the current node from the queue.
                Node<T> currentNode = queue.Dequeue();

                //Process the current node with the function passed in via the action parameter.
                action(currentNode.Value);

                //Add the children of the current node to the queue.
                foreach (Edge edge in currentNode.Edges)
                {
                    if (!visited.Contains(edge.Target.Value))
                    {
                        queue.Enqueue(edge.Target);
                        visited.Add(edge.Target.Value);
                    }
                }
            }
        }

        public void TraverseDFS(T start, Action<T> action)
        {
            //Use hashset to keep track of visited nodes.
            HashSet<T> visited = new HashSet<T>();
            Stack<Node<T>> stack = new Stack<Node<T>>();

            Node<T> startNode = nodes[start];
            stack.Push(startNode);

            //Iterate through the stack and process each node until the stack is empty.
            while (stack.Count > 0)
            {
                //Get the current node from the stack.
                Node<T> currentNode = stack.Pop();

                //If the node hasn't been visited, process it and add its children to the stack.
                if (!visited.Contains(currentNode.Value))
                {
                    //Process the current node with the function passed in via the action parameter.
                    action(currentNode.Value);

                    //Mark the current node as visited.
                    visited.Add(currentNode.Value);

                    //Add the children of the current node to the stack.
                    foreach (Edge edge in currentNode.Edges)
                    {
                        if (!visited.Contains(edge.Target.Value))
                            stack.Push(edge.Target);
                    }
                }
            }
        }

        ///////////////////////////////////////////////////////////////
    }
}
