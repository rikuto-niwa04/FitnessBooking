namespace FitnessBooking.Services;

public interface IMailService
{
    Task SendAsync(string to, string subject, string body);
}

public class FakeMailService : IMailService
{
    public Task SendAsync(string to, string subject, string body)
    {
        Console.WriteLine($"[MAIL] to={to} subject={subject} body={body}");
        return Task.CompletedTask;
    }
}
