namespace _02.ProcessorScheduling
{
    internal class Task
    {
        public Task(int value, int deadLine)
        {
            this.Value = value;
            this.DeadLine = deadLine;
        }

        public int Value { get; set; }

        public int DeadLine { get; set; }
    }
}