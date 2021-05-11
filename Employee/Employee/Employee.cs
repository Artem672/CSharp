using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Employee
{
    public class Employee : ICloneable
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public ushort Salary { get; set; }
        public double ContractNumber { get; set; }
        public Employee() { }
        public Employee(Employee Clone)
        {
            this.FirstName = Clone.FirstName;
            this.SecondName = Clone.SecondName;
            this.Position = Clone.Position;
            this.Salary = Clone.Salary;
        }

        public void InputName()
        {
            string FirstName = "", SecondName = "";

            do
            {
                Console.Write("Input first name:  ");
                FirstName = Console.ReadLine();
                Console.Write("Input second name:  ");
                SecondName = Console.ReadLine();
            } while (!CheckOnlyLetters(FirstName) && !CheckOnlyLetters(SecondName));

            this.FirstName = FirstName;
            this.SecondName = SecondName;
            
        }

        public void AddSalary(ushort add)
        {
            try
            {
                this.Salary += checked(add);              
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private bool CheckOnlyLetters(string Example)
        {
            char[] ExampleArray = Example.ToCharArray();
            for (int i = 0; i < ExampleArray.Length; i++) 
            {
                if(!Char.IsLetter(ExampleArray[i]))
                {                   
                    return false;
                }
            }
            return true;
        }
        public object Clone()
        {
            return new Employee(this);
        }
        public override string ToString()
        {
            return ($"Name:  {this.FirstName} {this.SecondName}\nPosition:  {this.Position}\nSalary:  {this.Salary}\nContract number:  {this.ContractNumber}");
        }
    }
}
