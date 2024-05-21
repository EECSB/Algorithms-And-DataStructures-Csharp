namespace AlgorithmsAndDataStructures
{
    public class MyList<T>
    {
        //////////////////////// List properties ////////////////////////

        public Node<T> rootNode { get; set; } = null; //Reference to the first node.
        public Node<T> currentNode { get; set; } = null; //Refference to the last added node.

        ////////////////////////////////////////////////////////////////


        ////////////////////// Node class model ////////////////////////
        
        public class Node<T>
        {
            public Node(T data)
            {
                Value = data;
                Next = null;
            }

            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }

        ////////////////////////////////////////////////////////////////


        ////////////////// List Manipulation Methods ////////////////////
        
        public void Add(T data)
        {
            //Create a new node with the provided data.
            Node<T> newNode = new Node<T>(data);

            //Set the root node to the new node if the list is empty.
            if(rootNode is null)
                rootNode = newNode;

            //Set the next node reference of the current node to the newly created node.
            if(currentNode is not null)
                currentNode.Next = newNode;
            
            //Update the current node of the list to the new node.
            currentNode = newNode;
        }

        public void Remove(Node<T> removeNode) 
        {
            if (removeNode is null)
                return;

            Node<T> current = rootNode;
            Node<T> prev = null;

            //Find the node to be removed.
            while (current is not null && current != removeNode)
            {
                prev = current;
                current = current.Next;
            }

            //"Bypass" the current node. After there is no reference is left to it, it will be removed by the garbage collector.
            prev.Next = current.Next;

            //Set the current node of the list to the last node.
            if (current.Next is null)
                currentNode = prev;
        }

        public void RemoveAt(int removeAtIndex)
        {
            if (removeAtIndex < 0)
                throw new IndexOutOfRangeException("Index out of range.");

            //Start at the beginning of the list and iterate over the list till we get to the index.
            Node<T> current = rootNode;
            Node<T> prev = null;
            for (int i = 0; i < removeAtIndex; i++)
            {
                prev = current;
                current = current.Next;

                if (current is null)
                    throw new IndexOutOfRangeException("Index out of range.");
            }
            
            if (prev is null) //If removing first element.
            {
                rootNode = current.Next;
                currentNode = rootNode;
            }
            else if (current.Next is null) //If removing last element.
            {
                currentNode = prev;
                currentNode.Next = null;
            }
            else //If removing element in the middle.
            {
                //"Bypass" the current node. After there is no reference left to it, it will be removed by the garbage collector.
                prev.Next = current.Next;
            }
        }

        public T Get(int index)
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Index out of range.");

            //Iterate over list to find the node.
            Node<T> current = rootNode;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;

                if (current == null)
                    throw new IndexOutOfRangeException("Index out of range.");
            }

            return current.Value;
        }

        public Node<T> GetNode(T value)
        {
            //Iterate over list to find the node.
            Node<T> current = rootNode;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                    return current;

                current = current.Next;
            }

            return null;
        }

        //Additionally we could implement an indexer allows us to use [] to access elements in the list.
        //More about indexers here: https://eecs.blog/c-indexers/

        ////////////////////////////////////////////////////////////////
    }
}
