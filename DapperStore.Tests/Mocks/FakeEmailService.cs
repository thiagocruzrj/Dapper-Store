using DapperStore.Domain.StoreContext.Services;

namespace DapperStore.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}