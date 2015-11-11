namespace _01.ExtendCableNetwork
{
    using System;
    using System.Collections.Generic;

    using global::ExtendCableNetwork;

    internal class ExtendACableNetwork
    {
        private static readonly List<Edge> Edges = new List<Edge>();

        private static bool[] connectedNodes;

        private static void Main()
        {
            int budget = int.Parse(Console.ReadLine().Split(' ')[1]);
            int nodes = int.Parse(Console.ReadLine().Split(' ')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            connectedNodes = new bool[nodes];
            FillEdges(edgesCount);

            Edges.Sort();

            int totalWeight = 0;
            foreach (var edge in Edges)
            {
                int currentWeight = edge.Weight;
                if (connectedNodes[edge.StartNode] ^ connectedNodes[edge.EndNode])
                {
                    connectedNodes[edge.StartNode] = true;
                    connectedNodes[edge.EndNode] = true;
                    totalWeight += currentWeight;
                    if (totalWeight > budget)
                    {
                        totalWeight -= currentWeight;
                        break;
                    }

                    Console.WriteLine(edge);
                }
            }

            Console.WriteLine("Budget used: " + totalWeight);
        }

        private static void FillEdges(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                string[] inputLine = Console.ReadLine().Split(' ');
                int startNode = int.Parse(inputLine[0]);
                int endNode = int.Parse(inputLine[1]);
                int weight = int.Parse(inputLine[2]);

                Edges.Add(new Edge(startNode, endNode, weight));

                if (inputLine.Length > 3)
                {
                    connectedNodes[endNode] = true;
                    connectedNodes[startNode] = true;
                }
            }
        }
    }
}
