using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ITCenterBO.DTOs.Response.Order
{
    public class UpdateOrderResponse
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(false)]
        public bool Status { get; set; }
    }
}
