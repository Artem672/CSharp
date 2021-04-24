using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Homework
{
    class EventService
    {
        public List<Event> Events = new List<Event>();

        public void AddEvent()
        {
            Console.Write("Введіть назву події: ");
            string EventName = Console.ReadLine();
            Console.Write("Введіть місце події: ");
            string Place = Console.ReadLine();
            Console.Write("Введіть кількість клієнтів: ");
            uint MaxPersons = Convert.ToUInt32(Console.ReadLine());
            DateTime Date;
            do
            {
                Console.Write("Введіть введіть день: ");
                int Day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введіть введіть місяць: ");
                int Month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введіть введіть рік: ");
                int Year = Convert.ToInt32(Console.ReadLine());
                Date = new DateTime(Year, Month, Day);
            } while (Date < DateTime.Now);
            Event @event = new Event(EventName, Place, MaxPersons, Date);
            Events.Add(@event);
        }
    }
}
