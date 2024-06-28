using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Request.Order
{
    public class CreateNewOrderRequest
    {
        //Item in order detail
        public List<int> courseIdInOrderDetail {  get; set; }
    }
}
