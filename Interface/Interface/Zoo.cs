using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Zoo
    {
        public List<Animal> animals = new();
        public List<ZooWorker> zooWorkers = new();
        public List<VideoCamera> videoCameras = new();
        

        public Zoo()
        {
        }
    }
}
