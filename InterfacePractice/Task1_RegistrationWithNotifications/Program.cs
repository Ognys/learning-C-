using Task1_RegistrationWithNotifications;

User Yaroslav = new User("Ярослав", "YaroslavZaharov@mail.ru", "84329978125");

System.Console.WriteLine("Как вы хотите отправить сообщение:\n1. Email\n2.Sms");
int userChoice;
while (true)
{
    if(int.TryParse(Console.ReadLine(),out userChoice) && userChoice < 3 && userChoice > 0)
        break;
    System.Console.WriteLine("Введено неверное значение. Повторите попытку");
}


INotificationSender notificationSender;
IMessageBuilder messageBuilder = new MessageBuilder();

switch (userChoice)
{
    case 1:
    notificationSender = new SendEmail();
        break;
    case 2:
    notificationSender = new SendSms();
        break;
    default:
    System.Console.WriteLine("Выбрано неверное значение. Повторите попытку");
    return;
}


RegistrationService registrationService = new RegistrationService(notificationSender,messageBuilder);
registrationService.Register(Yaroslav);
