using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.OwnedCourse
{
    public class CreateOwnedCourseRequest
    {
        public int CourseId { get; set; }
        public int AccountId { get; set; }
        [DefaultValue(true)]
        public bool IsOwned { get; set; }
        [DefaultValue(false)]
        public bool IsFinished { get; set; }
    }
}
