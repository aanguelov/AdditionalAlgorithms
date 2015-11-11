namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MostReliablePath
    {
        private static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            string[] path = Console.ReadLine().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);           

            Node[] nodes = new Node[nodesCount];
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            var graph = new Dictionary<Node, List<Edge>>();
            for (int i = 0; i < nodesCount; i++)
            {
                nodes[i] = new Node(i);
                graph.Add(nodes[i], new List<Edge>());
            }

            Node sourceNode = nodes.FirstOrDefault(n => n.Id == int.Parse(path[1]));
            Node destinationNode = nodes.FirstOrDefault(n => n.Id == int.Parse(path[2]));

            for (int i = 0; i < edgesCount; i++)
            {
                int[] data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Node first = nodes[data[0]];
                Node second = nodes[data[1]];
                double percentage = (double)data[2];

                graph[first].Add(new Edge(second, percentage));
                graph[second].Add(new Edge(first, percentage));
            }
            

            Dijkstra(sourceNode, graph);
            var mostReliablePath = FindPath(destinationNode);

            Console.WriteLine("Most reliable path reliability: " + destinationNode.Reliability);
            Console.WriteLine(string.Join(" -> ", mostReliablePath));
        }

        private static void Dijkstra(Node source, Dictionary<Node, List<Edge>> graph)
        {
            var queue = new BinaryHeap<Node>();

            foreach (Node node in graph.Keys)
            {
                node.Reliability = double.NegativeInfinity;
            }

            source.Reliability = 100.0;
            queue.Insert(source);

            while (queue.Count != 0)
            {
                Node current = queue.ExtractMax();

                if (double.IsNegativeInfinity(current.Reliability))
                {
                    break;
                }

                foreach (var childEdge in graph[current])
                {
                    var newReliability = (current.Reliability * childEdge.Percentage) / 100;
                    //Node nextNode = graph.Keys.FirstOrDefault(n => n.Id == childEdge.EndNode);
                    if (newReliability > childEdge.Node.Reliability)
                    {
                        childEdge.Node.Reliability = newReliability;
                        childEdge.Node.PreviousNode = current;
                        queue.Insert(childEdge.Node);
                    }
                }
            }
        }

        private static List<int> FindPath(Node node)
        {
            var result = new List<int>();

            while (node != null)
            {
                result.Add(node.Id);
                node = node.PreviousNode;
            }

            result.Reverse();
            return result;
        } 
    }
}