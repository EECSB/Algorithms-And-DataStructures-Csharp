namespace AlgorithmsAndDataStructures
{
    public class MyStack<T>
    {
        /////////////////////// Stack properties ///////////////////////

        internal Node<T> currentNode = null; //Reference to the last added node.

        ////////////////////////////////////////////////////////////////


        ////////////////////// Node class model ////////////////////////

        public class Node<T>
        {
            public Node(T data)
            {
                Value = data;
                Previous = null;
            }

            public T Value { get; set; }
            public Node<T> Previous { get; set; }
        }

        ////////////////////////////////////////////////////////////////


        ///////////////// Stack Manipulation Methods ///////////////////

        public void Push(T data)
        {
            //Create a new node with the provided data.
            Node<T> newNode = new Node<T>(data);

            if (currentNode is null)
            {
                //Set the root node to the new node if the list is empty.
                currentNode = newNode;
            }
            else 
            {
                //Set the previous node reference of the new node to the current node.
                newNode.Previous = currentNode;
                //Update the current node of the list to the new node.
                currentNode = newNode;
            }
        }

        public T? Pop() //the ? is used to allow the return of null for type T.
        {
            if (currentNode is null)
                return default(T); //Return the default value of type T if the queue is empty.

            //Get the value of the last node on the stack.
            T value = currentNode.Value;

            //Set the current node to the node previous node of the last node in the stack.
            currentNode = currentNode.Previous;

            return value;
        }

        public T? Peek() //the ? is used to allow the return of null for type T.
        {
            if (currentNode is null)
                return default(T); //Return the default value of type T if the queue is empty.

            //Get the value of the last node on the stack and return it without removing the current node.
            return currentNode.Value;
        }

        ////////////////////////////////////////////////////////////////
    }
}
