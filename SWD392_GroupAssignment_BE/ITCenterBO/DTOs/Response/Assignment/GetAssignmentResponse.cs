using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Response.Assignment
{
    public class GetAssignmentResponse 
    {
        public int AssignmentId { get; set; }
        public string AssignmentTitle { get; set; }
        public string Question { get; set; }
        public double Deadline { get; set; }
        public string Type { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime AssignmentDuration { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
    }
}
