namespace Task1_RegistrationWithNotifications;

public class RegistrationService
{
    private readonly INotificationSender _notificationSender;
    private readonly IMessageBuilder _messageBuilder;
    public RegistrationService(INotificationSender notificationSender, IMessageBuilder messageBuilder)
    {
        _notificationSender = notificationSender;
        _messageBuilder = messageBuilder;
    }

    public void Register(User user)
    {
        System.Console.WriteLine($"Пользователь {user.Name} зарегистрирован");
        string HelloMessage = _messageBuilder.BuildWelcomeMessage(user);
        _notificationSender.SendMessage(user,HelloMessage);
    }
}