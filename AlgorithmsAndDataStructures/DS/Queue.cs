namespace AlgorithmsAndDataStructures
{
    public class MyQueue<T>
    {
        //////////////////////// Queue properties ///////////////////////

        internal Node<T> rootNode = null; //Reference to the first node.
        internal Node<T> currentNode = null; //Refference to the last added node.

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


        ///////////////// Queue Manipulation Methods ///////////////////

        public void Enqueue(T data)
        {
            //Create a new node with the provided data.
            Node<T> newNode = new Node<T>(data);

            if (rootNode is null) //... set the root node to the new node if the queue is empty. 
            {
                rootNode = newNode;
                currentNode = newNode;
            }
            else //... add the new node to the end of the queue.
            {
                //Set the next node reference of the current node to the newly created node.
                currentNode.Next = newNode; 

                //Update the current node of the list to the new node.
                currentNode = newNode; 
            }
        }

        public T? Dequeue() //the ? is used to allow the return of null for type T.
        {
            if (rootNode is null)
                return default(T); //Return the default value of type T if the queue is empty.

            //Get the value of the first node in the queue.
            T value = rootNode.Value;

            //Set the root node to the next node in the queue.
            rootNode = rootNode.Next;

            return value;
        }

        ////////////////////////////////////////////////////////////////
    }
}
