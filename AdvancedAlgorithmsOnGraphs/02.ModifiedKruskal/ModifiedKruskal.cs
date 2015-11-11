namespace _02.ModifiedKruskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ExtendCableNetwork;

    internal class ModifiedKruskal
    {
        private static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            var graphEdges = new List<Edge>();

            FillEdges(edgesCount, graphEdges);

            var minimumSpanningForest = Kruskal(nodesCount, graphEdges);

            Console.WriteLine("Minimum spanning forest weight: " + minimumSpanningForest.Sum(e => e.Weight));
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static void FillEdges(int edgesCount, List<Edge> graphEdges)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                string[] inputLine = Console.ReadLine().Split(' ');
                int startNode = int.Parse(inputLine[0]);
                int endNode = int.Parse(inputLine[1]);
                int weight = int.Parse(inputLine[2]);

                graphEdges.Add(new Edge(startNode, endNode, weight));
            }
        }

        private static List<Edge> Kruskal(int n, List<Edge> edges)
        {
            edges.Sort();

            // Initialize parents
            var parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }

            // Kruskal's algorithm
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    // Union (merge) the trees
                    parent[rootStartNode] = rootEndNode;
                }
            }

            return spanningTree;
        }

        private static int FindRoot(int node, int[] parent)
        {
            // Find the root parent for the node
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            // Optimize (compress) the path from node to root
            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
}