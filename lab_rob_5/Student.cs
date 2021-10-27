using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_rob_5
{
    class Student
    {
        public int ID { get; private set; }
        public string First_Name { get; private set; }
        public string Last_Name { get; private set; }
        public string Phone_Number { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }

        public string Name { get; private set; }

        public Student(int id, string first_name, string last_name, string phone = null, string email = null, int age = 0)
        {
            ID = id;
            First_Name = first_name;
            Last_Name = last_name;
            Phone_Number = phone;
            Email = email;
            Age = age;

            Name = first_name + " " + last_name;
        }
    }
}
