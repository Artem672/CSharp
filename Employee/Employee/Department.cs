using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class Department :IEnumerable
    {
        private List<Employee> Employees = new();
        public void AddEmployee()
        {
            Employee employee = new();
            employee.InputName();            
            Console.Write("Input position name:  ");
            string Position = Console.ReadLine();
            employee.Position = Position;
            Console.Write("Input contract number:  ");
            int ContractNumber = int.Parse(Console.ReadLine());
            employee.ContractNumber = ContractNumber;
            ushort Salary = 0;
            try
            {
                Console.Write("Input salary:  ");
                Salary = ushort.Parse(Console.ReadLine());                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            employee.Salary = Salary;

            Employees.Add(employee);
        }
        public void OutputEmployeeInfo()
        {
            foreach(var item in Employees)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        public void DeleteEmployeeByContract()
        {
            bool EmployeeDeleted = false;
            Console.Write("Input contract number:  ");
            int ContractNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < Employees.Count; i++) 
            {
                if(Employees[i].ContractNumber == ContractNumber)
                {
                    Employees.RemoveAt(i);
                    Console.WriteLine("Employee was deleted!");
                    break;
                }
            }
        }
        public void DeleteEmployeeByName()
        {
            bool EmployeeDeleted = false;
            Console.Write("Input first name:  ");
            string FirstName = Console.ReadLine();
            Console.Write("Input second name:  ");
            string SecondName = Console.ReadLine();

            for (int i = 0; i < Employees.Count; i++)
            {                
                if (Employees[i].FirstName == FirstName && Employees[i].SecondName == SecondName) 
                {
                    Employees.RemoveAt(i);
                    Console.WriteLine("Employee was deleted!");
                    EmployeeDeleted = true;
                    break;
                }
            }

            if (!EmployeeDeleted)
                Console.WriteLine("Employee wasn't deleted!");
                   
        }
        public IEnumerator GetEnumerator()
        {
            return Employees.GetEnumerator();
        }
        public IEnumerable GetReverseEnumerator()
        {
            for (int i = Employees.Count - 1; i >= 0; i--)
                yield return Employees[i];
        }
        public IEnumerable GetSalaryEnumerator()
        {
            int Average = 0;

            foreach (Employee employee in Employees)
                Average += employee.Salary;
            Average /= Employees.Count;

            foreach(Employee employee in Employees)
            {
                if(employee.Salary < Average)
                {
                    yield return employee;
                }
            }
        }
        public void AddSalary()
        {
            OutputEmployeeInfo();
            Console.Write("Enter contract number:  ");
            double Contract = double.Parse(Console.ReadLine());

            Employee Example = null;
            foreach(Employee item in Employees)
            {
                if(item.ContractNumber == Contract)
                {
                    Example = item;
                }
            }

            if(Example != null)
            {
                Console.WriteLine("Enter sum to add:  ");
                ushort Sum = ushort.Parse(Console.ReadLine());
                Example.AddSalary(Sum);
            }            
        }
    }
}
