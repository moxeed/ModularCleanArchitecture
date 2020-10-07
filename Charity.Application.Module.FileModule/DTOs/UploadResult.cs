using System.Collections.Generic;

namespace Charity.Application.FileModule.DTOs
{
    public class UploadResult
    {
        public bool Succeeded { get; }
        public IEnumerable<string> Errors { get; }

        public int? FileId { get; set; }
        public string FilePath { get; }

        private UploadResult(bool succeeded, string path,int? fileId = null, IEnumerable<string> errors = null)
        {
            Succeeded = succeeded;
            Errors = errors;
            FilePath = path;
            FileId = fileId;
        }

        public static UploadResult Succeed(string path, int? fileId)
        {
            return new UploadResult(true, path, fileId);
        }
        
        public static UploadResult Failed(string path, params string[] errors)
        {
            return new UploadResult(true, path,errors: errors);
        }

        public static implicit operator bool(UploadResult result) => result.Succeeded;
    }
}
