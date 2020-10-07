using System.Net.NetworkInformation;

namespace Charity.Application.FileModule.DTOs
{
    public class DownloadFileResponse
    {
        public string Name { get; set; }
        public string MimeType { get;set; }
        public byte[] Bytes { get; set; } 
    }
}