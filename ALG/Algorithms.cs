namespace AlgorithmsAndDataStructures
{
    public static class Algorithms
    {
        public static void RunAlgorithms()
        {
            //Max sum of a subarray problem. 
            int[] numbers = { 4, 2, 1, 7, 8, 1, 2, 8, 1, 0 };
            int k = 3;
            int maxSum = OtherAlgorithms.MaxSumSubarray(numbers, k);
            Console.WriteLine($"Maximum sum of a subarray of size {k}: {maxSum}");





            //Two sum problem.
            int[] numbers2 = { 1, 3, 5, 7, 9, 11 };
            int target = 12;

            (int?, int?) result = OtherAlgorithms.TwoSum(numbers2, target);

            if (result.Item1 is not null && result.Item2 is not null)
                Console.WriteLine($"Pair found: {result.Item1} + {result.Item2} = {target}");
            else
                Console.WriteLine("No pair found.");





            //Cycle detection in a linked list using Floyd's cycle detection algorithm.
            MyList<int> list = new MyList<int>();
            list.Add(5);
            list.Add(2);
            list.Add(8);
            list.Add(7);

            bool hasCycle = OtherAlgorithms.HasCycle(list.rootNode);
            Console.WriteLine("Has cycle: " + hasCycle);





            //Find path between two points in a grid using A* algorithm.
            int[,] grid = {
                { 0, 0, 0, 0, 0, 0, 1 },
                { 0, 1, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };

            var start = new OtherAlgorithms.AStar.Node(0, 0);
            var finish = new OtherAlgorithms.AStar.Node(2, 6);

            List<OtherAlgorithms.AStar.Node> path = OtherAlgorithms.AStar.FindPath(grid, start, finish);

            if (path is null)
            {
                Console.WriteLine("No path found.");
            }
            else
            { 
                Console.WriteLine("Path:");
                foreach (var node in path)
                    Console.WriteLine($"({node.Row}, {node.Col})");
            }





            //Find shortest path between two points in a graph using Dijkstra's algorithm.
            var graph = new OtherAlgorithms.DijkstraExample_Graph();
            graph.AddEdge(0, 1, 3);
            graph.AddEdge(0, 2, 2);
            graph.AddEdge(1, 2, 2);
            graph.AddEdge(1, 3, 1);
            graph.AddEdge(2, 3, 3);
            graph.AddEdge(1, 4, 4);
            graph.AddEdge(4, 5, 1);
            graph.AddEdge(3, 5, 2);
            graph.AddEdge(2, 5, 6);
            graph.AddEdge(2, 6, 5);
            graph.AddEdge(6, 5, 2);

            int startNode = 0;
            var (distances, paths) = graph.FindPathDijkstra(startNode);

            graph.PrintDistances(startNode, distances);
            graph.PrintPath(0, 5, paths);





            Console.ReadLine();
        }
    }
}
