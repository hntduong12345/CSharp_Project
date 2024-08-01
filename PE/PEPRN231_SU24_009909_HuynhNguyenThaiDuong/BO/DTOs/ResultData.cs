using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTOs
{
    public class ResultData
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ResultData()
        {
            StatusCode = 1;
            Message = "Action Success";
        }
    }
}
