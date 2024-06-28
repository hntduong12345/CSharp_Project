using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseExelFolder
{
    internal class StudentCourse
    {
        public string CourseName { get; set; }
        public string StudentID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return $"{CourseName}|{StudentID}|{Email}|{FullName}";
        }
    }
}
