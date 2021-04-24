using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new();
            string[] NameArray = new string[] { "Alex", "Artem", "Nazar", "Fedor", "Oleg" };
            Random zooWorkers = new();
            for (int i = 0; i < zooWorkers.Next(1,4);i++)
            {
                Random names = new();
                ZooWorker zooWorker = new(NameArray[names.Next(0, NameArray.Length)]);
                zoo.zooWorkers.Add(zooWorker);
            }
            Random video = new();
            for(int i = 0; i < video.Next(1,5);i++)
            {
                VideoCamera videoCamera = new(i);
                zoo.videoCameras.Add(videoCamera);
            }
            Bear bear = new("Fedor", 10, "Meat", 60);
            Wolf wolf = new("Vasyl", 20, "Pelmeni", 40);
            zoo.animals.Add(bear);
            zoo.animals.Add(wolf);
            /*
            for(int i = 0; i < zoo.videoCameras.Count; i++)
            {
                zoo.videoCameras[i].Watching();
                zoo.zooWorkers[i].Watching();
            }
            */
            ShowAnimal(zoo);
            ShowVideoCamera(zoo);
        }

        static Random random = new();
        static void ShowAnimal(Zoo zoo)
        {
            Animal animal = zoo.animals[random.Next(0, zoo.animals.Count)];

            int function = random.Next(0, 3);

            if (function == 1)
            {
                animal.AnimalEating();
            }
            else if (function == 2) 
            {
                animal.AnimalWalking();
            }
            else
            {
                animal.AnimalSleeping();
            }
        }
        static void ShowVideoCamera(Zoo zoo)
        {
            VideoCamera videoCamera = zoo.videoCameras[random.Next(0, zoo.videoCameras.Count)];

            videoCamera.Watching(zoo);
        }
    }

    
}
