
using System;
using System.Collections.Generic;

namespace NEH
{
    class NEHAlg
    {
        public int DoNEHAlg(Task[] tasks)
        {
            int cMax = int.MaxValue;
            Array.Sort(tasks, new myReverserComparer());
            List<Task> optSequence = new List<Task> { tasks[0] };
            for(int i = 1; i < tasks.Length; ++i)
                cMax = AddToSequence(optSequence, tasks[i]);
            return cMax;
        }

        int AddToSequence(List<Task> sequence, Task newTask)
        {
            int sequenceLengths = sequence.Count;
            int cMax = int.MaxValue, minCMax = int.MaxValue;
            int newTaskOptIndex = 0;
            for(int i = 0; i <= sequenceLengths; ++i)
            {
                sequence.Insert(i, newTask);
                cMax = CountCMax(sequence);
                sequence.Remove(newTask);
                if (cMax < minCMax)
                {
                    newTaskOptIndex = i;
                    minCMax = cMax;
                }
            }
            sequence.Insert(newTaskOptIndex, newTask);
            return minCMax;
        }

        int CountCMax(List<Task> sequence)
        {
            int machinesCount = sequence[0].times.Length;
            int[] machinesTimes = new int[machinesCount];
            int waitForTaskFinishTime = 0;
            foreach (Task currentTask in sequence)
            {
                for(int i = 0; i < machinesCount; ++i)
                {
                    if(i>0)
                    {
                        waitForTaskFinishTime = machinesTimes[i - 1] - machinesTimes[i];
                        machinesTimes[i] += waitForTaskFinishTime > 0 ? waitForTaskFinishTime : 0;
                    }
                    machinesTimes[i] += currentTask.times[i];
                }
            }
            return machinesTimes[machinesCount - 1];
        }
    }
}
