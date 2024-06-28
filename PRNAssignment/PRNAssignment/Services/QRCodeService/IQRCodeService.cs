using System.Drawing;

namespace PRNAssignment.Services.QRCodeService
{
    public interface IQRCodeService
    {
        byte[] generateQRCode(string lockerId);

        Image GetImg(byte[] data);
    }
}
