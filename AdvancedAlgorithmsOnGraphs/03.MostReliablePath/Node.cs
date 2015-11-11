namespace _03.MostReliablePath
{
    using System;

    internal class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public double Reliability { get; set; }

        public Node PreviousNode { get; set; }

        public int CompareTo(object other)
        {
            return this.Reliability.CompareTo((other as Node).Reliability);
        }
    }
}