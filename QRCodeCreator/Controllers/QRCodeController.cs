using Microsoft.AspNetCore.Mvc;
using QRCodeCreator.Business.Entities;
using QRCodeCreator.Business.Models;
using QRCodeCreator.Data.Interfaces;
using QRCodeCreator.ViewModels;

namespace QRCodeCreator.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly IQRCodeService _qrCodeService;
        public QRCodeController(IQRCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;
        }

        [HttpPost]
        public IActionResult Generate([FromForm] QRCodeFormData formData)
        {
            QRCodeInfo qrCodeInfo = _qrCodeService.Create(formData);

            QRCodeViewModel qrCodeVM = new QRCodeViewModel()
            {
                Base64Image = qrCodeInfo.Base64Image
            };

            return PartialView("QRCode/_GeneratePartial", qrCodeVM);
        }
    }
}
