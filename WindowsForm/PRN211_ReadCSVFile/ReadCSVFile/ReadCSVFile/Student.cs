using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSVFile
{
    internal class Student
    {
        private string id;
        private string name;
        private string email;
        private string courseName;

        public Student(string id, string name, string email, string courseName)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.courseName = courseName;
        }
        
        public string getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getCourseName()
        {
            return this.courseName;
        }

        override
        public string ToString()
        {
            return String.Format("[MSSV: {0,10}| Name: {1,30}| Email: {2,30}| Phone: {3}]"
                ,this.id, this.name, this.email, this.courseName);
        }

        public string getField(string fieldName)
        {
            if (fieldName.Equals("MSSV"))
            {
                return getId();
            }
            else if (fieldName.Equals("Name"))
            {
                return getName();
            }
            else if (fieldName.Equals("Email"))
            {
                return getEmail();
            }
            else if (fieldName.Equals("Phone"))
            {
                return getCourseName();
            }
            else
                return "";
        }
    }
}
