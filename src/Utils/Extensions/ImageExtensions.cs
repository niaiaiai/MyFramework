using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Utils
{
    public static class ImageExtensions
    {
        public static string IFormFileToBase64(IFormFile formFile)
        {
            using (Stream stream = formFile.OpenReadStream())
            {
                return Convert.ToBase64String(stream.GetAllBytes());
            }
        }
    }
}
