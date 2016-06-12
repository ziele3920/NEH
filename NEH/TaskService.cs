
using System;
using System.Collections;

namespace NEH
{
    public class Task
    {
        public int[] times;
        public int totalTime;

        public Task(int[] time)
        {
            times = time;
            int sum = 0;
            foreach (int t in times)
                sum += t;
            totalTime = sum;
        }
    };

    class TaskService
    {

        public Task[] ReadData(string filename)
        {
            string directory = System.IO.Directory.GetCurrentDirectory();
            string[] lines = System.IO.File.ReadAllLines(directory + "\\" + filename);
            string[] firstLine = lines[0].Split(' ');
            int machinesCount = int.Parse(firstLine[1]);
            Task[] data = new Task[int.Parse(firstLine[0])];

            for (int i = 1; i < lines.Length; ++i)
            {
                if (lines[i] == "" || lines[i] == null)
                    continue;
                int[] currentTimes = new int[machinesCount];
                string[] line = lines[i].Split(' ');
                for (int j = 0; j < machinesCount; ++j)
                    currentTimes[j] = int.Parse(line[j]);
                Task currentTask = new Task(currentTimes);
                data[i - 1] = currentTask;
            }
            return data;
        }
    }

    public class myReverserComparer : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Task t1 = x as Task;
            Task t2 = y as Task;
            return (t2.totalTime - t1.totalTime);
        }

    }
}
