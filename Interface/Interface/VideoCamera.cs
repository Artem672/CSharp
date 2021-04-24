using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class VideoCamera : IWatch
    {
        public int CameraNumber { get; set; }
        public void Watching(Zoo zoo)
        {
            Random rnd = new();
            Console.WriteLine($"{this.GetType().Name} №{CameraNumber} is watching on: {zoo.animals[rnd.Next(0, zoo.animals.Count)].AnimalName}");
        }

        public VideoCamera(int CameraNumber)
        {
            this.CameraNumber = CameraNumber;
        }
    }
}
