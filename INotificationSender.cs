using System;

public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("Email отправлен: " + message);
    }
}

public class SmsSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("SMS отправлено: " + message);
    }
}

public class NotificationService
{
    private readonly INotificationSender _notificationSender;
    public NotificationService(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }

    public void SendNotification(string message)
    {
        _notificationSender.Send(message);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        INotificationSender emailSender = new EmailSender();
        NotificationService emailService = new NotificationService(emailSender);
        emailService.SendNotification("Привет! Это тестовое уведомление через Email.");

        INotificationSender smsSender = new SmsSender();
        NotificationService smsService = new NotificationService(smsSender);
        smsService.SendNotification("Привет! Это тестовое уведомление через SMS.");
    }
}
