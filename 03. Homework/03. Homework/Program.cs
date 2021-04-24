using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool Menu = true;
            char MenuChoice;
            List<Client> clients = new List<Client>();
            EventService @event = new EventService();

            while (Menu)
            {
                Console.Clear();
                Console.WriteLine("0. Вихід");
                Console.WriteLine("1. Додати клієнта");
                Console.WriteLine("2. Переглянути список клієнтів");
                Console.WriteLine("3. Додати захід");
                Console.WriteLine("4. Переглянути список заходів");
                Console.Write("Ваш вибір -> ");
                MenuChoice = Convert.ToChar(Console.ReadLine());

                switch (MenuChoice)
                {
                    case '0':
                        Menu = false;
                        break;
                    case '1':
                        Console.Clear();
                        bool CorrectPhoneNumber = false;
                        Console.Write("Введіть ім'я: ");
                        string Name = Console.ReadLine();
                        string PhoneNumber = default;
                        do
                        {
                            bool OnlyDigit = true;
                            Console.Write("Введіть номер телефону (починаючи з 380): ");
                            PhoneNumber = Console.ReadLine();

                            char[] phoneN = PhoneNumber.ToCharArray();
                            for (int i = 0; i < phoneN.Length; i++)
                            {
                                if (!Char.IsDigit(phoneN[i]))
                                {
                                    OnlyDigit = false;
                                }
                            }

                            if (PhoneNumber.Length == 12 && (PhoneNumber[0] == '3' && PhoneNumber[1] == '8' && PhoneNumber[2] == '0') && OnlyDigit == true)
                            {
                                CorrectPhoneNumber = true;
                            }
                        } while (CorrectPhoneNumber != true);
                        Client Person = new Client(Name, PhoneNumber);
                        clients.Add(Person);
                        break;
                    case '2':
                        Console.Clear();
                        if (clients.Count != 0)
                        {
                            foreach (Client item in clients)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        break;
                    case '3':
                        Console.Clear();
                        @event.AddEvent();
                        break;
                    case '4':
                        Console.Clear();
                        if(@event.Events.Count != 0)
                        {
                            foreach (Event item in @event.Events)
                            {
                                Console.WriteLine(item.ToString());
                                Console.WriteLine();
                            }
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неправильне значення!");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
