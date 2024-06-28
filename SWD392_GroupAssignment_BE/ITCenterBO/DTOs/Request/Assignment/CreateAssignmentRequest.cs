using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.Assignment
{
    public class CreateAssignmentRequest
    {
        public string AssignmentTitle { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AssignmentDuration { get; set; }
    }
}
