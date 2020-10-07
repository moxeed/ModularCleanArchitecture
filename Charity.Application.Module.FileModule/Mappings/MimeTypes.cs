using System.IO;

namespace Charity.Application.FileModule.Mappings
{
    public static class MimeTypes { 

        public static string GetContentType(string filename)
        {
            var extension = Path.GetExtension(filename);
            return extension switch
            {
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".png" => "image/png",
                ".jpg" => "image/jpg",
                ".pdf" => "	application/pdf",
                _ => string.Empty
            };
        }
    }
}
