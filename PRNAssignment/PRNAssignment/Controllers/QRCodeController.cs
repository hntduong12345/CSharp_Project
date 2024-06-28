using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRNAssignment.Models;
using PRNAssignment.Services.QRCodeService;
using System.Drawing;

namespace PRNAssignment.Controllers
{
    [Route("api/qrcode")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        private readonly IQRCodeService _qrCodeService;
        public QRCodeController(IQRCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpPost]
        public IActionResult Index(string lockerId)
        {
            byte[] QRCodeAsByte = _qrCodeService.generateQRCode(lockerId);
            string QRCodeAsImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCodeAsByte)}";

            return Ok(_qrCodeService.GetImg(QRCodeAsByte));
        }
    }
}
