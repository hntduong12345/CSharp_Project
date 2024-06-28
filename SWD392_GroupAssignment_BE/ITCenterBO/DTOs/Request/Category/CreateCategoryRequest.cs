using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.Category
{
    public class CreateCategoryRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
