namespace _04.BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;

    internal class BestLecturesSchedule
    {
        private static void Main()
        {
            int lecturesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            List<Lecture> lectures = new List<Lecture>();

            for (int i = 0; i < lecturesCount; i++)
            {
                string[] data = Console.ReadLine().Split(new[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                lectures.Add(new Lecture(data[0], int.Parse(data[1]), int.Parse(data[2])));
            }

            lectures.Sort();
            List<Lecture> lecturesToVisit = new List<Lecture>();

            var last = lectures[0];
            lecturesToVisit.Add(last);
            foreach (var lecture in lectures)
            {
                if (lecture.StartTime >= last.EndTime)
                {
                    lecturesToVisit.Add(lecture);
                    last = lecture;
                }
            }

            Console.WriteLine("Lectures ({0}):", lecturesToVisit.Count);
            foreach (var lecture in lecturesToVisit)
            {
                Console.WriteLine(lecture);
            }
        }
    }
}