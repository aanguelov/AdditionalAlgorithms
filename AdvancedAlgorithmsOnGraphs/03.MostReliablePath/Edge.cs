namespace _03.MostReliablePath
{
    internal class Edge
    {
        public Edge(Node node, double percentage)
        {
            this.Percentage = percentage;
            this.Node = node;
        }

        public Node Node { get; set; }

        public double Percentage { get; set; }
    }
}