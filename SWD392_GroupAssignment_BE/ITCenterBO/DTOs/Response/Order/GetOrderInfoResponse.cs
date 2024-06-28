using ITCenterBO.DTOs.Response.OrderDetail;
using ITCenterBO.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterBO.DTOs.Response.Order
{
    public class GetOrderInfoResponse
    {
        public GetOrderResponse order {  get; set; }
        public IPaginate<GetOrderDetailResponse> OrderDetails { get; set; }
    }
}
