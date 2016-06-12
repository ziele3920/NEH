using System;

namespace NEH
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskService TS = new TaskService();
            NEHAlg NEH = new NEHAlg();
            Task[] tasks;

            Console.WriteLine("Podaj nazwę pliku");
            string fileName = Console.ReadLine();
            tasks = TS.ReadData(fileName);
            Console.WriteLine("Result: " +  NEH.DoNEHAlg(tasks));
            Console.ReadKey();
        }
    }
}
