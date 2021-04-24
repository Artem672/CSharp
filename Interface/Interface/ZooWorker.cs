using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class ZooWorker : IWatch
    {
        public string WorkerName { get; set; }
        public void Watching(Zoo zoo)
        {
            Random rnd = new();
            Console.WriteLine($"{this.GetType().Name}: {WorkerName} is watching on: {zoo.animals[rnd.Next(0, zoo.animals.Count)]}");
        }

        public ZooWorker(string WorkerName)
        {
            this.WorkerName = WorkerName;
        }
    }
}
