﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.OrderDetail
{
    public class AddCourseToCarteRequest
    {
        public int OrderId { get; set; }
        public int CourseId { get; set; }
    }
}
