namespace Restaurant.Domain.Interfaces
{
    public interface IEmailDomainService
    {
        void Send(string to, string subject, string message);
    }
}
