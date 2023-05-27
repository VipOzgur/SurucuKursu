﻿using System.Web;
using System.IO;
using System.Drawing;
using SurucuKursu.Models;

namespace SurucuKursu
{
    public class PublicClass
    {
        public string ImgToBase64(IFormFile img)
        {
            using (var ms = new MemoryStream())
            {
                img.CopyTo(ms);
               
                var imageBytes = ms.ToArray();

                // Base64'e dönüştürün
                var base64String = Convert.ToBase64String(imageBytes);

                // Veritabanına kaydedin veya başka bir işlem yapın
                return base64String;
            }
        }
    }
}
