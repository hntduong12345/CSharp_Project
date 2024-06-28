using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Response.LearnerAssignment
{
    public class UpdateLearnerAssignmentResponse
    {
        public int LearnerAssignmentId { get; set; }
        public int AccountId { get; set; }
        public int AssignmentId { get; set; }
        public float Mark { get; set; }
        public DateTime AssignmentTakenDate { get; set; }
        public DateTime TakenDuration { get; set; }
    }
}
