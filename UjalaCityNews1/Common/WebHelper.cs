using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UjalaCityNews1.Common
{
    public static class WebHelper
    {
        public static string SaveFile(HttpPostedFileBase file, string path)
        {
            // Define the folder where the file will be saved
            string uploadFolder = HttpContext.Current.Server.MapPath(path);

            // Ensure the folder exists
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Get the file name and append datetime
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            string dateTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFileName = $"{fileName}_{dateTimeStamp}{fileExtension}";

            // Combine the folder path with the new file name
            string filePath = Path.Combine(uploadFolder, newFileName);

            // Save the file
            file.SaveAs(filePath);

            // Return the relative path to be saved in the database
            return Path.Combine(path, newFileName);
        }
        public static string ConvertSpacesToHyphens(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Replace(' ', '-').Replace('.', '-').Replace(',', '-');
        }

    }
}