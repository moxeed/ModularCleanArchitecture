using System.Threading.Tasks;
using Charity.Application.Module.DTOs.Email;

namespace Charity.Application.Module.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
