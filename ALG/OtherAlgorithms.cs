namespace AlgorithmsAndDataStructures
{
    public static class OtherAlgorithms
    {
        #region Searching Algorithms

        /// <summary>
        ///     Linear search algorithm or naive search algorithm is the simplest search algorithm out there.
        ///     It simply performs a single iteration over the array and checks if the current element is the element we are looking for.
        ///     Time complexity: O(n) Space complexity: O(1)
        /// </summary>
        /// <param name="find"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int LinearSearch(int find, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == find)
                    return i;
            }

            //If the element is not found return -1.
            return -1;
        }



        /// <summary>
        ///     If the array is sorted, we can use the binary search algorithm to find the element.
        ///     Binary search algorithm or divide and conquer is a much faster algorithm than linear search on a sorted array. 
        ///     It works by:
        ///         1. Finding the middle of the array and checking if the element we are looking for is larger or smaller than the middle element.
        ///         2. If the element is smaller than the middle element, the algorithm searches(same as step 1.) the left half of the array, otherwise it searches(same as step 1.) the right half.
        ///     Time complexity: O(log(n)) Space complexity: O(1)
        /// </summary>
        /// <param name="find"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int BinarySearch(int find, int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;

            //While the left index is less than or equal to the right index.
            while (left <= right)
            {
                //Calculate the middle index.
                int middle = left + (right - left) / 2;

                //If the element is found return the index.
                if (arr[middle] == find)
                    return middle;


                if (arr[middle] < find) //If the element is smaller than the middle element, search the left half ...
                    left = middle + 1;
                else //... otherwise search the right half.
                    right = middle - 1;
            }

            //If the element is not found return -1.
            return -1;
        }

        #endregion



        #region Other Algorithms

        /// <summary>
        ///     The maximum sum subarray problem is where you are given an array of integers and you have to find the subarray(of specified size) that has the largest sum.
        ///     We'll use the sliding window algorithm technique to solve this problem.
        ///     It works by maintaining a "window" of the specified size and sliding it over the array while calculating the sum of all the items within the said "window".
        ///     Time complexity: O(n) Space complexity: O(1)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="subArraySize"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int MaxSumSubarray(int[] numbers, int subArraySize)
        {
            int n = numbers.Length;

            //Validate input. The array size must be greater than or equal to the window size and the window size must be positive.
            if (n < subArraySize || subArraySize <= 0)
                throw new ArgumentException("Invalid input: Array size is smaller than window size or window size is not positive.");

            //Calculate the sum of the initial window.
            int windowSum = 0;
            for (int i = 0; i < subArraySize; i++)
                windowSum += numbers[i];

            //Set the initial maximum sum to the sum of the initial window.
            int maxSum = windowSum;

            //Now let's slide the window from left to right and update the maximum sum.
            for (int i = subArraySize; i < n; i++)
            {
                //Slide the window by adding the next element(to the right) and removing the first(leftmost) element.
                windowSum += numbers[i] - numbers[i - subArraySize]; 

                //Update maxSum if the current window's sum is larger.
                if(maxSum < windowSum)
                    maxSum = windowSum;
            }

            return maxSum;
        }



        /// <summary>
        ///     The "two sum" problem is where you are given an array(of sorted integers) and you have to find two elements within it that will add up to a specific value.
        ///     We will solve this problem by using the two-pointer technique. One pointer will point to the beginning of the array while the other pointer will point to the end.
        ///     We'll move the pointers towards each other until the sum of the elements at the pointers is equal to the target value.
        ///     Time complexity: O(n log n) Space complexity: O(1)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="targetValue"></param>
        /// <returns></returns>
        public static (int?, int?) TwoSum(int[] numbers, int targetValue)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                //Calculate the sum of the two elements at the pointers.
                int sum = numbers[left] + numbers[right];

                if (sum == targetValue) //If the sum is equal to the target value, return the numbers.
                    return (numbers[left], numbers[right]);
                else if (sum < targetValue) //If the sum is less than the target value, move the left pointer to the right.
                    left++;
                else //If the sum is greater than the target value, move the right pointer to the left.
                    right--;
            }

            //If no pair is found.
            return (null, null);
        }



        /// <summary>
        ///     Cycle detection using Floyds algorithm. is a technique used to detect cycles in a linked list.
        ///     It works by using two pointers, one slow and one fast, that traverse the linked list at different speeds.
        ///     If there is a cycle in the linked list, the two pointers will eventually meet at the same node.
        ///     Time complexity: O(n) Space complexity: O(1)     
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rootNode"></param>
        /// <returns></returns>
        public static bool HasCycle<T>(MyList<T>.Node<T> rootNode)
        {
            if (rootNode == null || rootNode.Next == null)
                return false;

            //Initialize the two pointers.
            MyList<T>.Node<T> slow = rootNode;
            MyList<T>.Node<T> fast = rootNode.Next;

            //Iterate over the linked list until the fast pointer reaches the end of the list.
            while (fast != null && fast.Next != null)
            {
                //If the two pointers meet at some point it means that there is a cycle in the linked list.
                if (slow == fast)
                    return true;

                //Move the slow pointer one step and the fast pointer two steps forward.
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            //No cycle found.
            return false;
        }

        #endregion



        #region Path Finding Algorithms

        //A* algorithm is a pathfinding algorithm that is used to find the shortest path between two points on a grid.
        //Here's a great video explaining the A* algorithm: https://www.youtube.com/watch?v=-L-WgKMFuhE&ab_channel=SebastianLague
        //To implement the A* algorithm you can either convert the 2D array grid into a graph node list and 
        //or iterate through the grid and generate the neighboring nodes on the fly.
        public static class AStar
        {  
            public class Node //The Node will represent a cell in the grid.
            {
                public Node(int row, int col)
                {
                    Parent = null;
                    
                    Row = row;
                    Col = col;

                    G_Cost = 0;
                    H_Cost = 0;
                    F_Cost = 0;
                }

                public Node Parent { get; set; }
                
                public int Row { get; set; }
                public int Col { get; set; }

                public int G_Cost { get; set; } //Distance from starting node.
                public int H_Cost { get; set; } //Distance from end node.
                public int F_Cost { get; set; } //F_Cost = G_Cost + H_Cost
            }


            /// <summary>
            ///    Finds the shortest path between two points on a grid using the A* algorithm.
            /// </summary>
            /// <param name="grid"></param>
            /// <param name="start"></param>
            /// <param name="finish"></param>
            /// <returns></returns>
            public static List<Node> FindPath(int[,] grid, Node start, Node finish)
            {
                //Make a HashSet to store visited nodes.
                HashSet<Node> visitedNodes = new HashSet<Node>(comparer: new NodeEqualityComparer());
                //The SortedSet will store the open nodes. It's similar to a HashSet but it maintains the order of the items.
                HashSet<Node> openNodesSet = new HashSet<Node>(comparer: new NodeEqualityComparer());
                //Add the start node to the open nodes set.
                openNodesSet.Add(start);

                //Iterate until the open nodes set is empty
                while (openNodesSet.Count > 0)
                {
                    //Get the node with the lowest F value from the open set.
                    Node current = GetLowestFCostNode(openNodesSet);

                    //Check if the current node is the goal. If so reconstruct and return the path.
                    if (current.Row == finish.Row && current.Col == finish.Col)
                        return ReconstructPath(current);

                    //Add the current node to the list of already visited nodes.
                    visitedNodes.Add(current);
                    openNodesSet.Remove(current);

                    //Generate the neighbouring nodes of the current node from the grid.
                    Node[] neighbors = GetNeighbors(grid, current);

                    //Iterate through each neighbor.
                    foreach (Node neighbor in neighbors)
                    {
                        if (neighbor == null)
                            continue;

                        //Check if the neighbor has already visited ...
                        if (visitedNodes.Contains(neighbor))
                            continue; // ... if so skip it.

                        //Calculate the summed G_Cost so far.
                        //Here each step has a cost of 1. It's however possible to assign different costs to different steps.
                        //For example, you could imagine the cost as the Z axis and assign a cost of 1 to a flat area and a cost of 2 or more to a slope.
                        int summedG_cost = current.G_Cost + 1;

                        //If the neighbor is not in the open set, add it.
                        if (!openNodesSet.Contains(neighbor))
                            openNodesSet.Add(neighbor);
                        else if (summedG_cost >= neighbor.G_Cost) //If the new G_Cost is higher than the old one ...
                            continue; //... this is not a better path so skip this neighbor.

                        //Update the neighbor.
                        neighbor.Parent = current;
                        neighbor.G_Cost = summedG_cost;
                        neighbor.H_Cost = CalcDistance(neighbor, finish);
                        neighbor.F_Cost = neighbor.G_Cost + neighbor.H_Cost;
                    }
                }

                //No path found.
                return null;
            }

            //Get the node with the lowest F value from the open set.
            private static Node GetLowestFCostNode(HashSet<Node> openSet)
            {
                Node lowestNode = null;
                int lowestFCost = int.MaxValue;

                foreach (Node node in openSet)
                {
                    if (node.F_Cost < lowestFCost)
                    {
                        lowestFCost = node.F_Cost;
                        lowestNode = node;
                    }
                }

                return lowestNode;
            }

            //Get the neighbors of a node from the grid.
            private static Node[] GetNeighbors(int[,] grid, Node node)
            {
                Node[] neighbors = new Node[4];

                //Get the dimensions(height/width) of the grid.
                int numRows = grid.GetLength(0);
                int numCols = grid.GetLength(1);

                //Define the 4 possible directions within the arrays.
                //Then access them during the iteration. This way we can reduce the amount of code.
                int[] xDir = { -1, 0, 1, 0 };
                int[] yDir = { 0, -1, 0, 1 };

                //Iterate through the 4 possible directions.
                for (int i = 0; i < 4; i++)
                {
                    //Calculate the new position by adding/subtracting 1 from the current node position.
                    int newRow = node.Row + xDir[i];
                    int newCol = node.Col + yDir[i];

                    //Check if the new position is within the grid and not blocked, else skip this neighbor.
                    bool isXWithinGrid = newCol >= 0 && newCol < numCols; //min. and max. check for col/x-axis.
                    if(!isXWithinGrid)
                        continue;

                    bool isYWithinGrid = newRow >= 0 && newRow < numRows; //min. and max. check for row/y-axis.
                    if (!isYWithinGrid)
                        continue;
                    
                    bool blocked = grid[newRow, newCol] == 1; //Check if blocked.
                    if (blocked)
                        continue;

                    //If the neighbor is valid, create a new node and add it to the neighbors array.
                    neighbors[i] = new Node(newRow, newCol);
                }

                return neighbors;
            }

            //Reconstruct the path from the finish node to the start node.
            private static List<Node> ReconstructPath(Node currentNode)
            {
                List<Node> path = new List<Node>();
                while (currentNode != null) //Iterate until we reach the node without a parent(start node).
                {
                    //Save the current node to the path list ...
                    path.Add(currentNode);
                    //... and set the current node to its parent.
                    currentNode = currentNode.Parent;
                }

                //Reverse the path to get the correct order.
                path.Reverse();

                return path;
            }

            //Calculate the shortest path between two points/nodes.
            private static int CalcDistance(Node current, Node finish)
            {
                //Manhattan distance(straight line) is used to calculate the distance between two points on a grid.
                return Math.Abs(current.Row - finish.Row) + Math.Abs(current.Col - finish.Col);
            }

            //Custom comparer for nodes.
            class NodeComparer : IComparer<Node>
            {
                public int Compare(Node x, Node y)
                {
                    if (x.F_Cost == y.F_Cost)
                        return 0;

                    if (x.F_Cost < y.F_Cost)
                        return -1;

                    return 1;
                }
            }

            class NodeEqualityComparer : IEqualityComparer<Node>
            {
                public bool Equals(Node x, Node y)
                {
                    return x.Row == y.Row && x.Col == y.Col;
                }

                public int GetHashCode(Node obj)
                {
                    return obj.Row.GetHashCode() ^ obj.Col.GetHashCode();
                }
            }
        }

        



        //Dijkstra's algorithm is a pathfinding algorithm that is used to find the shortest path between two points in a graph.
        //Here's a great video explaining Dijkstra's algorithm: https://www.youtube.com/watch?v=EFg3u_E6eHU&ab_channel=SpanningTree
        public class DijkstraExample_Graph
        {
            //The graph is represented as a dictionary where the key is the node and the value is a dictionary of the neighbors and their weights.
            private Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();



            /// <summary>
            /// Add an edge to the graph. An edge is a connection between two nodes with a specified weight.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="destination"></param>
            /// <param name="weight"></param>
            public void AddEdge(int source, int destination, int weight)
            {
                if (!graph.ContainsKey(source))
                    graph[source] = new Dictionary<int, int>();

                graph[source][destination] = weight;

                if(!graph.ContainsKey(destination))
                    graph[destination] = new Dictionary<int, int>();

                graph[destination][source] = weight;
            }



            /// <summary>
            /// Remove an edge from the graph. An edge is a connection between two nodes with a specified weight.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="destination"></param>
            /// <exception cref="ArgumentException"></exception>
            public void RemoveEdge(int source, int destination)
            {
                if (!graph.ContainsKey(source) || !graph[source].ContainsKey(destination))
                    throw new ArgumentException("Edge does not exist.");

                graph[source].Remove(destination);
                graph[destination].Remove(source);
            }



            /// <summary>
            /// Check if an edge exists between two nodes. An edge is a connection between two nodes with a specified weight.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="destination"></param>
            /// <returns></returns>
            public bool ContainsEdge(int source, int destination)
            {
                return graph.ContainsKey(source) && graph[source].ContainsKey(destination);
            }



            /// <summary>
            /// Find the shortest path between two nodes using Dijkstra's algorithm.
            /// </summary>
            /// <param name="start"></param>
            /// <returns></returns>
            public (Dictionary<int, int> distances, Dictionary<int, int> paths) FindPathDijkstra(int start)
            {
                #region Declare Variables

                Dictionary<int, int> prevNodePointers = new Dictionary<int, int>();
                Dictionary<int, int> distances = new Dictionary<int, int>();
                HashSet<int> visitedNodes = new HashSet<int>();
                //A sorted set is very similar to a hashset but it maintains the order of the items.
                //For this reason we can use it for implementing a priority queue.
                //A priority queue is very similar to a queue(FIFO) with the exception that the items will be sorted according to their priority.
                SortedSet<(int, int)> priorityQueue = new SortedSet<(int, int)>();

                #endregion


                #region Initialize Variables

                foreach (var vertex in graph.Keys)
                {
                    //Initialize all distances to infinity/max value.
                    distances[vertex] = int.MaxValue;
                    //Initialize all prevNodePointers to -1;
                    prevNodePointers[vertex] = -1; 
                }

                //Set the distance of the start node to 0.
                distances[start] = 0;
                //Add the start node to the priority queue with a distance of 0.
                priorityQueue.Add((0, start));

                #endregion


                #region Dijkstra's Algorithm

                //Iterate until the priority queue is empty.
                while (priorityQueue.Count > 0)
                {
                    //Get the node with the smallest value/priority/distance from the priority queue.
                    var (dist, node) = priorityQueue.Min;
                    //Remove the current node from the priority queue.
                    priorityQueue.Remove(priorityQueue.Min);

                    //If the node was already visited skip it. Else add it to the list of visited nodes.
                    if (visitedNodes.Contains(node))
                        continue;
                    else
                        visitedNodes.Add(node);

                    //Iterate through all the neighbors of the current node.
                    foreach (var neighbor in graph[node])
                    {
                        //Calculate the new distance.
                        var newDist = distances[node] + neighbor.Value;

                        //If the new distance is smaller than the current distance ...
                        if (newDist < distances[neighbor.Key])
                        {
                            //... update the distance ...
                            distances[neighbor.Key] = newDist;
                            //... add the neighbor to the priority queue ...
                            priorityQueue.Add((newDist, neighbor.Key));
                            //... and finally update the pointer to the previous node so we can reconstruct the path later.
                            prevNodePointers[neighbor.Key] = node;
                        }
                    }
                }

                #endregion

                return (distances, prevNodePointers);
            }



            /// <summary>
            /// Print the shortest distances from a specified start node to all other nodes in the graph.
            /// </summary>
            /// <param name="startNode"></param>
            /// <param name="distances"></param>
            public void PrintDistances(int startNode, Dictionary<int, int> distances)
            {
                Console.WriteLine($"Shortest distances from node {startNode}:");

                foreach (var node in distances)
                    Console.WriteLine($"To node {node.Key}: {node.Value}");
            }



            /// <summary>
            /// Prints the shortest path from a specified start node to a specified finish node.
            /// </summary>
            /// <param name="start"></param>
            /// <param name="finish"></param>
            /// <param name="prevNodePointers"></param>
            public void PrintPath(int start, int finish, Dictionary<int, int> prevNodePointers)
            {
                List<int> path = new List<int>();
                int current = finish;

                //Iterate through the prevNodePointers to reconstruct the path until we reach the start node.
                while (current != start && prevNodePointers.ContainsKey(current) && prevNodePointers[current] != -1)
                {
                    path.Add(current);
                    current = prevNodePointers[current];
                }

                if (current == start)
                {
                    path.Add(start);
                    path.Reverse();
                    Console.WriteLine($"Shortest path from {start} to {finish}: {string.Join(" -> ", path)}");
                }
                else
                {
                    Console.WriteLine($"No path found from {start} to {finish}");
                }
            }
        }

        #endregion
    }
}
