using DapperStore.Domain.StoreContext.Services;

namespace DapperStore.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            // TODO: Implement
        }
    }
}