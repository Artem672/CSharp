using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class SportCar : Car
    {
        Random random = new();
        public override string Image => $"O[{CarNumber}]O>";
        public override double MaxSpeed => random.Next(180, 320);
        public override double Acceleration => 1;

        public override double MinAcceleration => 0.8;
        public SportCar()
        {

        }
        public SportCar(int CarNumber, string DriverNickName) : base(CarNumber, DriverNickName)
        {
        }

        public override string ToString()
        {
            return $"Name:  {this.DriverNickName} Car number:  {this.CarNumber} Track progress:  {Math.Round(this.TrackPath, 1)} / 100";
        }
    }

    public class PassengerCar : Car
    {
        Random random = new();
        public override string Image => $"O[{CarNumber}]O}}";
        public override double MaxSpeed => random.Next(180,320);
        public override double Acceleration => 0.9;
        public override double MinAcceleration => 0.7;
        public PassengerCar()
        {

        }
        public PassengerCar(int CarNumber, string DriverNickName) : base(CarNumber, DriverNickName)
        {           
        }

        public override string ToString()
        {
            return $"Name:  {this.DriverNickName} Car number:  {this.CarNumber} Track progress:  {Math.Round(this.TrackPath, 1)} / 100";
        }
    }

    public class BusCar : Car
    {
        Random random = new();
        public override string Image => $"O[{CarNumber}]O";
        public override double MaxSpeed => random.Next(120, 280);
        public override double Acceleration => 0.8;
        public override double MinAcceleration => 0.6;
        public BusCar()
        {

        }
        public BusCar(int CarNumber, string DriverNickName) : base(CarNumber, DriverNickName)
        {
        }
        public override string ToString()
        {
            return $"Name:  {this.DriverNickName} Car number:  {this.CarNumber} Track progress:  {Math.Round(this.TrackPath, 1)} / 100";
        }
    }

    public class TruckCar : Car
    {
        Random random = new();
        public override string Image => $"O[{CarNumber}]O";
        public override double MaxSpeed => random.Next(140, 280);
        public override double Acceleration => 0.7;
        public override double MinAcceleration => 0.5;
        public TruckCar()
        {

        }
        public TruckCar(int CarNumber, string DriverNickName) : base(CarNumber, DriverNickName)
        {
        }
        public override string ToString()
        {
            return $"Name:  {this.DriverNickName} Car number:  {this.CarNumber} Track progress:  {Math.Round(this.TrackPath, 1)} / 100";
        }
    }
}
