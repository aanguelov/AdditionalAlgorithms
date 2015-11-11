namespace _01.FractionalKnapsackProblem
{
    using System;

    internal class Item : IComparable<Item>
    {
        public Item(double weight, double price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public double Weight { get; set; }

        public double Price { get; set; }

        public int CompareTo(Item other)
        {
            int result = (other.Price / other.Weight).CompareTo(this.Price / this.Weight);

            return result;
        }
    }
}