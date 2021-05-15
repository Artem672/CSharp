using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilder
{

    class Program
    {

        static void Main(string[] args)
        {
            House house = new House();

            house.DrawBasement();
            house.DrawDoor();
            house.DrawWall();
            house.DrawRoof();
            house.DrawWindow();

            Console.ReadKey();
        }
    }
}
