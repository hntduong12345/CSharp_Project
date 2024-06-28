using QRCoder;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;

namespace PRNAssignment.Services.QRCodeService
{
    public class QRCodeService : IQRCodeService
    {

        public byte[]  generateQRCode(string lockerId)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(lockerId, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrBitmap = qrCode.GetGraphic(40);

            return BitmapToByteArray(qrBitmap);
        }

        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image GetImg(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                Image img = Image.FromStream(ms);
                return img;
            }
        }
    }
}
