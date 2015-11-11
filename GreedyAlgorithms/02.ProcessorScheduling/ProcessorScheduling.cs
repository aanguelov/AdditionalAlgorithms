namespace _02.ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class ProcessorScheduling
    {
        private static void Main()
        {
            int tasksCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            Dictionary<int, Task> tasks = new Dictionary<int, Task>();
            int largestDeadLine = 0;
            for (int i = 0; i < tasksCount; i++)
            {
                string[] line = Regex.Split(Console.ReadLine(), "[^\\d]+");
                tasks.Add(i + 1, new Task(int.Parse(line[0]), int.Parse(line[1])));
                if (int.Parse(line[1]) > largestDeadLine)
                {
                    largestDeadLine = int.Parse(line[1]);
                }
            }

            var orderedTasks = tasks
                .OrderByDescending(t => t.Value.Value)
                .Take(largestDeadLine)
                .OrderBy(t => t.Value.DeadLine)
                .ToDictionary(t => t.Key, t => t.Value);

            int[] taskNumbers = orderedTasks.Keys.ToArray();
            

            Console.WriteLine("Optimal schedule: " + string.Join(" -> ", taskNumbers));
            Console.WriteLine("Total value: " + orderedTasks.Values.Sum(v => v.Value));
        }
    }
}