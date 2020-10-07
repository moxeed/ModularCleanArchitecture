using System.Collections.Generic;

namespace Charity.Domain.Settings
{
    public class UploadSettings
    {
        public long MaxFileSize { get; set; }        
        public string FileUploadPath { get; set; }
        public IEnumerable<string> AllowedExtensions { get; set; }
    }
}