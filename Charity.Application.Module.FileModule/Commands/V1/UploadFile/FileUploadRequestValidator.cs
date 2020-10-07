﻿using System.IO;
using System.Linq;
using Charity.Application.FileModule.Commands.V1.UploadProjectFile;
using Charity.Application.Module.Common;
using Charity.Domain.Settings;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Charity.Application.FileModule.Commands.V1.UploadFile
{
    public class FileUploadRequestValidator : AbstractValidator<FileUploadRequest>
    {
        public FileUploadRequestValidator(IOptions<UploadSettings> options)
        {
            RuleFor(x => x.File).NotNull().WithMessage(PersianErrorMessages.EmptyError);
            RuleFor(x => x.File).Must(c =>
            {
                var extension = Path.GetExtension(c.FileName);
                return options.Value.AllowedExtensions.Contains(extension);
            }).WithMessage("فرمت مجاز نیست");
            RuleFor(x => x.File).Must(c => 
                options.Value.MaxFileSize > c.Length).WithMessage("حجم فایل بیش از حد مجاز است");
        }
    }
}