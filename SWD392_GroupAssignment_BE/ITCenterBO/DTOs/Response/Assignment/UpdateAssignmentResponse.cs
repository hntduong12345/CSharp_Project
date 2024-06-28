using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Response.Assignment
{
    public class UpdateAssignmentResponse
    {
        public int AssignmentId { get; set; }
        public string AssignmentTitle { get; set; }
        public string Question { get; set; }
        public double Deadline { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AssignmentDuration { get; set; }
    }
}
