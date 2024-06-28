﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.Course
{
    public class CreateCourseRequest
    {
        public IFormFile file { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [DefaultValue(true)]
        public bool IsAvailable { get; set; }
        public double Price { get; set; }
    }
}
