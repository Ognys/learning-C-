namespace Task1_RegistrationWithNotifications;

public interface IMessageBuilder
{
    public string BuildWelcomeMessage(User user);
}

public class MessageBuilder : IMessageBuilder
{
    public string BuildWelcomeMessage(User user)
    {
        return $"Привет, {user.Name}, спасибо за регистрацию";
    }
}