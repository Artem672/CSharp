using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Racing
{
    class Game 
    {
        public delegate void AllStart(int CoordX,int CoordY);
        public AllStart allStart;
        public delegate void AllMove();
        public AllMove allMove;
        public List<Car> Cars = new()
        {
            new SportCar(27,"Lens Stroll"),
            new BusCar(56,"Maks Ferstapen"),
            new PassengerCar(11,"Sebastian Fettel"),
            new TruckCar(28,"Luiz Hemilton"),
            new SportCar(39,"Pier Hasli"),
            new PassengerCar(73,"Robert Kubitsa")
        };
        public List<Car> SortedList = null;

        public bool GameEnd { get; set; } = false;

        public Game()
        {
            foreach(Car car in Cars)
            {
                car.Finish += this.ShowWinner;                
                allStart += car.SetCarStartPos;
                allMove += car.OneMove;
            }
        }

        public void ShowWinner(Car car)
        {
            if(!GameEnd)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(30, 5);
                Console.WriteLine($"{car.DriverNickName} won the championship!!!");
                Console.SetCursorPosition(25, 10);
                Console.WriteLine($"Winner stats:  {car.Image}  {car.DriverNickName} {car.GetType().Name}#{car.CarNumber} max speed: {car.MaxSpeed}");
                Console.ReadKey();
                Console.Clear();
                this.GameEnd = true;
            }
           
        }
        public bool MoveCar()
        {
            allMove.Invoke();
            return GameEnd;
        }
        public void Start(int CoordX,int CoordY)
        {
            foreach (var start in allStart.GetInvocationList())
                start.DynamicInvoke(CoordY, CoordX += 2);
        }
        public void RacerList()
        {
            Console.SetCursorPosition(0, 0);
            SortedList = Cars;
            
            for(int i = 0; i < SortedList.Count - 1;i++)
            {
                for(int j = 0; j < SortedList.Count - i - 1;j++)
                { 
                    if(SortedList[j].TrackPath < SortedList[j + 1].TrackPath)
                    {
                        var item = SortedList[j];
                        SortedList[j] = SortedList[j + 1];
                        SortedList[j + 1] = item;
                    }
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"1.  {SortedList[0]}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"2.  {SortedList[1]}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"3.  {SortedList[2]}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"4.  {SortedList[3]}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"5.  {SortedList[4]}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"6.  {SortedList[5]}");
        }

        #region SaveData
        public void SaveData()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));

            using (FileStream fs = new FileStream("RacersInfo.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Cars);
            }
        }
        public async Task GetData()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));

            using (FileStream fs = new FileStream("RacersInfo.xml", FileMode.OpenOrCreate))
            {
                Cars = (List<Car>)formatter.Deserialize(fs);
            }
        }


        #endregion
    }
}
