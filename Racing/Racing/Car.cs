using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Racing
{
    public abstract class Car 
    {
        #region Variables
        public abstract string Image { get; }
        public delegate void FinishRacing(Car car);
        public event FinishRacing Finish;
        public abstract double MaxSpeed { get; }

        private double CurrentSpeed = 1;
        public abstract double Acceleration { get; }
        public abstract double MinAcceleration { get; }
        private int coordX = 0;
        private int coordY = 0;
        public int CoordX { get => coordX; set => coordX = value; }
        public int CoordY { get => coordY; set => coordY = value; }
        public double Speed
        {
            get => CurrentSpeed;
            set
            {
                if (value > MaxSpeed)
                    CurrentSpeed = MaxSpeed;
                else
                    CurrentSpeed = value;
            }
        }
        public int CarNumber { get; set; }
        public string DriverNickName { get; set; }
        private double trackPath = 1;
        public double TrackPath 
        {
            get => trackPath;
            set
            {
                if (trackPath > 100)
                    Finish(this);
                else
                    trackPath = value;
            }
        }

        #endregion

        public Car()
        {

        }
        public abstract override string ToString();

        [JsonConstructor]
        public Car(int CarNumber, string DriverNickName)
        {
            this.CarNumber = CarNumber;
            this.DriverNickName = DriverNickName;
        }

        public void OneMove()
        {
            this.CorrectSpeed();

            this.TrackPath += this.Speed / 100;
            this.PrintTrack();
        }
        public void SetCarStartPos(int x,int y)
        {
            this.CoordX = x;
            this.CoordY = y;
            Console.SetCursorPosition(CoordX, CoordY);
            Console.Write(this.Image);
        }

        public void CorrectSpeed()
        {
            Random random = new();
            this.Speed += (this.Speed * this.Acceleration) * 0.4;
            if (this.Speed == this.MaxSpeed)
                this.Speed *= (random.NextDouble() * (this.Acceleration - this.MinAcceleration) + this.MinAcceleration);
        }

        public void PrintTrack()
        {
            try
            {
                Console.SetCursorPosition(this.CoordX, this.CoordY);
                Console.Write($"S|....................................................................................................|F   {Math.Round(this.TrackPath, 1)} / 100");
                
                Console.SetCursorPosition(this.CoordX, this.CoordY - 1);
                Console.Write("                                                                                                        ");
                
                Console.SetCursorPosition(this.CoordX + (int)this.TrackPath - 1, this.CoordY - 1);
                Console.Write($"{Math.Round(Speed, 2)} km/h");

                Console.SetCursorPosition(this.CoordX + (int)this.TrackPath + 1, this.CoordY);
                Console.Write(this.Image);
            }
            catch { }
        }
    }
}
