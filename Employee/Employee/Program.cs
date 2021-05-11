using System;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Menu = true;
            Department department = new Department();
            while(Menu)
            {
                Console.Write(
                    "0.Exit\n" +
                    "1.Add employee\n" +
                    "2.Delete employee by name\n" +
                    "3.Delete employee by number\n" +
                    "4.All employee info\n" +
                    "5.Add salary\n" +
                    "6.Enumerator\n" +
                    "7.Revers enumerator\n" +
                    "8.Salart enumerator\n" +
                    "Your choice:  ");
                int Choice = int.Parse(Console.ReadLine());

                switch(Choice)
                {
                    case 0:
                        {
                            Console.Clear();
                            Menu = false;
                            Console.WriteLine("Goodbye!");
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            department.AddEmployee();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            department.DeleteEmployeeByName();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            department.DeleteEmployeeByContract();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            department.OutputEmployeeInfo();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            department.AddSalary();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            foreach (Employee employee in department)
                            {
                                Console.WriteLine(employee);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            foreach (Employee employee in department.GetReverseEnumerator())
                            {
                                Console.WriteLine(employee);
                            }
                            
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            foreach (Employee employee in department.GetSalaryEnumerator())
                            {
                                Console.WriteLine(employee);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }
            }
        }
    }
}
