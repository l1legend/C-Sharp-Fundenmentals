using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FunProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person Person1= new Person();
            //Person1.FirstName = "Michael";
            //Person1.LastName="Min";
            //Person1.Age=36;           
            //Console.WriteLine(Person1.FullName());

            var person1 = new Person
            {
                FirstName = "Michael",
                LastName = "Min",
                Age = 36
            };

            //Task Task1 = new Task();
            //Task1.TaskName = "read";
            //Task1.Description ="task1";
            //Task1.Id = 1;
            //Task1.IsDone = true;

            var Task1 = new Task
            {
                TaskName = "read",
                Description = "gain knowledge",
                Id = 1,
                IsDone = true
            };

            var Task2 = new Task
            {
                TaskName = "eat",
                Description = "gain sustenance",
                Id = 2,
                IsDone = false
            };

            person1.TaskList = new List<Task>();
            person1.TaskList.Add(Task1);
            person1.TaskList.Add(Task2);

            Console.WriteLine(person1.FullName() + "\n");
            Console.WriteLine("Current Task:");

            //person1.TaskList.ForEach(x => Console.WriteLine
            //("TaskName:" + " " + x.TaskName + "\n" + "TaskDescription:" + " " + x.Description + "\n"
            // + "Id:" + " " + x.Id + "\n" + "IsDone:" + " " + x.IsDone.ToString().ToLower() + "\n"));
            
            foreach (var t in person1.TaskList)
            {
                foreach (var prop in t.GetType().GetProperties())
                {
                    Console.WriteLine($"{prop.Name}: {prop.GetValue(t, null).ToString()}");
                }
                Console.WriteLine("\n");
            }
            Console.Read();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public int Age { get; set; }
        public List<Task>TaskList { get; set; }
        public string FullName()
        {
            return ($"{FirstName} {LastName}");
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set;}
        public string Description { get; set; }
        public bool ?IsDone { get; set;}
    }
}
