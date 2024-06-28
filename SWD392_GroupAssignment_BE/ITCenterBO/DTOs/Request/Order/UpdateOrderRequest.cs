using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.Order
{
    public class UpdateOrderRequest
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }
    }
}
