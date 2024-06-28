using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.Order
{
    public class CreateOrderRequest
    {
        public int AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(false)]
        public bool Status { get; set; }
    }
}
