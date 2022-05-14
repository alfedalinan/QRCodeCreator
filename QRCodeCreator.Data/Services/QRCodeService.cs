using QRCodeCreator.Business.Entities;
using QRCodeCreator.Business.Models;
using QRCodeCreator.Data.Interfaces;
using QRCoder;
using System;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace QRCodeCreator.Data.Services
{
    public class QRCodeService : IQRCodeService
    {
        public QRCodeInfo Create(QRCodeFormData qRCodeFormData)
        {
            QRCodeGenerator generator = new QRCodeGenerator();

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo propertyInfo in qRCodeFormData.GetType().GetProperties())
            {
                var propertyValue = propertyInfo.GetValue(qRCodeFormData);
                var propertyName = propertyInfo.Name.Replace("Name", " Name");
                sb.Append($"{propertyName}: {propertyValue}\n");
            }

            QRCodeData data = generator.CreateQrCode(sb.ToString(), QRCodeGenerator.ECCLevel.H);
            QRCode code = new QRCode(data);
            Bitmap image = code.GetGraphic(20);

            ImageConverter imageConverter = new ImageConverter();
            byte[] imageBytes = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));

            QRCodeInfo qrCodeInfo = new QRCodeInfo()
            {
                Base64Image = Convert.ToBase64String(imageBytes)
            };

            return qrCodeInfo;
        }
    }
}
