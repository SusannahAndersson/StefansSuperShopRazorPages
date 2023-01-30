using StefansSuperShop.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace StefansSuperShop.Interfaces
{
    public interface IMailService //TODO: move to new interface folder?
    {
        Task<bool> SendAsync(MailData mailData, CancellationToken ct);
        public Task<bool> SendContactUsAsync(MailData mailData);

    }
}
