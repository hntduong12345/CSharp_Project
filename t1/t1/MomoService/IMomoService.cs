using ProGCoder_MomoAPI.Models.Momo;
using ProGCoder_MomoAPI.Models.Order;

namespace t1.MomoService
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderInfoModel model);
        MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
    }
}
