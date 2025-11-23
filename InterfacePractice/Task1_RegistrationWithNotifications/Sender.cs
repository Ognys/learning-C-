namespace Task1_RegistrationWithNotifications;

public interface INotificationSender
{
    public void SendMessage(User user, string message);
}

public class SendEmail : INotificationSender
{
    public void SendMessage(User user, string message)
    {
        System.Console.WriteLine($"Сообщение: \"{message}\" было отправлено на\n" +
        $"Email: {user.Email}\nПользователю: {user.Name}");
    }
}

public class SendSms : INotificationSender
{
    public void SendMessage(User user, string message)
    {
        System.Console.WriteLine($"Сообщение: \"{message}\" было отправлено на\n" +
        $"Phone: {user.Phone}\nПользователю: {user.Name}");
    }
}