namespace AlgorithmsAndDataStructures
{
    public class MyHashtable<K, V>
    {
        ///////////////////////// Constructors /////////////////////////
        
        public MyHashtable(int size = 100)
        {
            this.size = size;
            hashtable = new LinkedList<KeyValuePair<K, V>>[size];
        }

        ////////////////////////////////////////////////////////////////


        //////////////////// Hash Table properties /////////////////////

        private int size;
        private LinkedList<KeyValuePair<K, V>>[] hashtable;

        ////////////////////////////////////////////////////////////////


        /////////////////////// Hash Table Methods /////////////////////

        public void Add(K key, V value)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null.");

            //Calculate the index for the given key and the size of the table.
            //Because the key can be any type we need to use the GetHashCode() method to get a unique integer for the key.
            //We then use the modulo operator to get a number between 0 and the size of the hashtable.
            int index = calculateIndex(key);

            if (hashtable[index] == null)
                hashtable[index] = new LinkedList<KeyValuePair<K, V>>();

            //Add the key value pair to the linked list at the calculated index.
            //Using a list to store the values at a certain index instead of storing them directly in the hashtable array gives us
            //the ability to deal with hash(key) collisions by simply adding the key value pair with the same key to the end of the list.
            hashtable[index].AddLast(new KeyValuePair<K, V>(key, value));
        }

        public V? Get(K key)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null.");

            //Calculate the index for the given key and the size of the table.
            int index = calculateIndex(key);
            
            //If the index is empty, the key is not in the hashtable.
            if (hashtable[index] == null)
                throw new KeyNotFoundException("Key not found.");

            //Iterate through the linked list of the calculated index and return the value if the key is found.
            foreach (var item in hashtable[index])
            {
                if (item.Key.GetHashCode() == key.GetHashCode())
                    return item.Value;
            }

            throw new KeyNotFoundException("Key not found.");
        }

        public bool TryGet(K key, out V value)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null.");

            //Calculate the index for the given key and the size of the table.
            int index = calculateIndex(key);

            //If the index is empty return false and set the out value to the default value of the type V.
            if (hashtable[index] == null)
            {
                value = default(V);
                return false;
            }

            //Iterate through the linked list of the calculated index and return the value if the key is found.
            foreach (var item in hashtable[index])
            {
                if (item.Key.GetHashCode() == key.GetHashCode())
                {
                    value = item.Value;
                    return true;
                }
            }

            value = default(V);
            return false;
        }

        public bool Contains(K key)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null.");

            //Calculate the index for the given key and the size of the table.
            int index = calculateIndex(key);

            //If the index is empty return false.
            if (hashtable[index] == null)
                return false;

            //Iterate through the linked list of the calculated index and return true if the key is found.
            foreach (var item in hashtable[index])
            {
                if (item.Key.GetHashCode() == key.GetHashCode())
                    return true;
            }

            return false;
        }

        public void Remove(K key)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null.");

            //Calculate the index for the given key and the size of the table.
            int index = calculateIndex(key);

            //If the index is empty return.
            if (hashtable[index] == null)
                return;

            KeyValuePair<K, V> itemToRemove = default(KeyValuePair<K, V>);
            //Iterate through the linked list of the calculated index and get the key value pair to be removed if the key is found.
            foreach (var item in hashtable[index])
            {
                if (item.Key.GetHashCode() == key.GetHashCode())
                {
                    itemToRemove = item;
                    break;
                }
            }

            //Remove the key value pair from the linked list.
            hashtable[index].Remove(itemToRemove);
        }

        private int calculateIndex(K key)
        {
            //Calculate the index for the given key by hashing its value first.
            //The GetHashCode() method returns a unique integer for the key. It's present in the System.Object(the data type all other data types inherit from) class.
            //We could restrict the key to an integer and directly use it in the hash calculation below.
            //However using a generic type and calling GetHashCode() enables us to use any type as the key.
            int hashCode = key.GetHashCode();

            //Calculate the index by taking the modulo of the hash code and the size of the hashtable.
            int index = hashCode % hashtable.Length;

            //Get the absolute value of the index to avoid negative indexes.
            index = Math.Abs(index);
            
            return index;
        }

        ///////////////////////////////////////////////////////////////
    }
}
