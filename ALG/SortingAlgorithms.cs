namespace AlgorithmsAndDataStructures.ALG
{
    public static class SortingAlgorithms
    {
        //A very interseting visualisation of sorting algorithms: https://www.youtube.com/watch?v=kPRA0W1kECg&ab_channel=TimoBingmann
        //Here you can find the time and space complexity table for sorting algorithms: https://www.bigocheatsheet.com/

        /// <summary>
        ///     Bubble sort iterates through a list and compares adjacent elements.
        ///     If they are in the wrong order the items will be swaped.
        ///     Time complexity: O(n^2), Space complexity: O(1)
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
           if (arr is null)
                throw new ArgumentNullException();

            if (arr.Length == 0)
                return;

            //Itertate through the array.
            for (int i = 0; i < arr.Length; i++)
            {
                //Iterate through the array and compare each element with the next element.
                for (int j = 0; j < arr.Length - i - 1; j++) //-i because the last i elements are already sorted and -1 to skip the last element.
                {
                    //If current element is greater than next element swap them.
                    if (arr[j] > arr[j + 1])
                    {
                        //Save current element in temp variable.
                        int temp = arr[j];
                        //Assign next element to current element.
                        arr[j] = arr[j + 1];
                        //Assign temp variable to next element.
                        arr[j + 1] = temp;
                    }
                }
            }
        }



        /// <summary>
        ///    Selection sort iterates through a list and selects the minimum element in the unsorted part of the list.
        ///    Then it swaps the minimum element with the first element in the unsorted part of the list.
        ///    Time complexity: O(n^2), Space complexity: O(1)
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            if (arr is null)
                throw new ArgumentNullException();

            if (arr.Length == 0)
                return;

            //Iterate through the array.
            for (int i = 0; i < arr.Length; i++)
            {
                //Find the index of the minimum element in the unsorted portion of the array.
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //If the current element is smaller than the minimum found so far update minIndex.
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap the minimum element with the first element of the unsorted portion.
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }



        /// <summary>
        ///     Insertion sort iterates through a list and moves elements to the right until it finds the correct position for the element.
        ///     Time complexity: O(n^2), Space complexity: O(1)
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            if (arr is null)
                throw new ArgumentNullException();

            if (arr.Length == 0)
                return;

            //Iterate through the array.
            for (int i = 1; i < arr.Length; i++)
            {
                //Store the current element to be inserted.
                int insert = arr[i];
                //Set the index of the last element in the sorted portion.
                int j = i - 1;

                //Move elements that are larger than value to be inserted one position forward.
                while (j >= 0 && arr[j] > insert)
                {
                    arr[j + 1] = arr[j]; //Move the element forward.
                    j--; //Decrement the index to continue checking elements to the left.
                }

                //Insert value into the correct position in the sorted portion.
                arr[j + 1] = insert;
            }
        }

        

        /// <summary>
        ///    Counting sort is a non-comparison sorting algorithm. 
        ///    It sorts elements by counting the number of occurrences of each unique element in the array.
        ///    Time complexity: O(n + k), Space complexity: O(n + k)
        /// </summary>
        /// <param name="arr"></param>
        public static void CountingSort(int[] arr) 
        {
            if(arr is null)            
                throw new ArgumentNullException();            

            if (arr.Length == 0)
                return;

            //Get the maximum element in the array ...
            int max = arr.Max();
            //... and create an array to store the count of each element.
            int[] count = new int[max + 1];
            int[] output = new int[arr.Length];

            //Count the number of occurrences of each element in the array.
            for (int i = 0; i < arr.Length; i++)
            { 
                //Get the value of the current element.
                int value = arr[i];

                //Use it as an index in the count array and increment the count.
                count[value]++;
            }

            //Add the count of the previous element to the current element.
            //This calculates the prefix sum of the elements in the count array.
            //This will give us the position of each element in the output array.
            for (int i = 1; i < count.Length; i++)
                count[i] += count[i - 1];

            //Place the elements in the correct position in the output array.
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                //Get the value of the current element.
                int index = arr[i];

                //Get the position of the element in the output array.
                int outputArrPosition = count[index] - 1;

                //Place the element in the correct position in the output array.
                output[outputArrPosition] = index;

                //Decrement the count of the element.
                count[index]--;
            }

            //Copy the sorted array back to the original array.
            for (int i = 0; i < arr.Length; i++)
                arr[i] = output[i];
        }

        //Note: Radix sort is very similar to counting sort but is more suitable for larger numbers as groups values it by their digits.
        //Here's a great video series on radix sort: https://www.youtube.com/watch?v=_KhZ7F-jOlI&ab_channel=Creel



        /// <summary>
        ///     Mergesort is a divide and conquer algorithm that recursively divides the array into two halves, 
        ///     sorts them and finally then merges them back togeter.
        ///     Time complexity: O(n log n), Space complexity: O(n)
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            if (arr is null)
                throw new ArgumentNullException();

            if (arr.Length == 0)
                return;

            int n = arr.Length;
            if (n <= 1) //If array size is less than or equal to 1 the array is sorted.
                return;

            //Get middle index of the array.
            int middleIndex = n / 2;

            //Create two subarrays, one from start to midpoint and another from midpoint to the end.
            int[] left = new int[middleIndex];
            int[] right = new int[n - middleIndex];

            //Copy elements from the original array to the subarrays.
            //You might want to use Span<T> instead of Array.Copy. More about Span<T> here: https://eecs.blog/c-unsafe-code-pointers-stackalloc-and-spans/
            Array.Copy(arr, 0, left, 0, middleIndex);
            Array.Copy(arr, middleIndex, right, 0, n - middleIndex);

            //Recursive calls to sort the left and right subarrays.
            MergeSort(left);
            MergeSort(right);

            //Merge the sorted left and right subarrays back into the original array.
            Merge(arr, left, right);
        }

        //Helper method for mergeing two sorted subarrays into one sorted array.
        private static void Merge(int[] arr, int[] left, int[] right)
        {
            int nL = left.Length;
            int nR = right.Length;
            int i = 0;
            int j = 0;
            int k = 0;

            //Compare subarrays elements from left and right and merge them.
            while (i < nL && j < nR)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }

                k++;
            }

            //Copy any remaining elements from left subarray.
            while (i < nL)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            //Copy any remaining elements from right subarray.
            while (j < nR)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
