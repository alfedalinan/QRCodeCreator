using QRCodeCreator.Business.Entities;
using QRCodeCreator.Business.Models;

namespace QRCodeCreator.Data.Interfaces
{
    public interface IQRCodeService
    {
        QRCodeInfo Create(QRCodeFormData qRCodeFormData);
    }
}
