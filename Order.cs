
public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

public class PriceCalculator
{
    public double CalculateTotalPrice(Order order)
    {
        return order.Quantity * order.Price * 0.9;
    }
}

public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails)
    {
        Console.WriteLine("Платеж обработан с использованием: " + paymentDetails);
    }
}
public class NotificationService
{
    public void SendConfirmationEmail(string email)
    {
        Console.WriteLine("Подтверждение отправлено на: " + email);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var order = new Order
        {
            ProductName = "Ноутбук",
            Quantity = 2,
            Price = 1000.00
        };

        var priceCalculator = new PriceCalculator();
        var paymentProcessor = new PaymentProcessor();
        var notificationService = new NotificationService();

        double totalPrice = priceCalculator.CalculateTotalPrice(order);
        Console.WriteLine($"Общая стоимость: {totalPrice}");

        paymentProcessor.ProcessPayment("Кредитная карта");

        notificationService.SendConfirmationEmail("user@example.com");
    }
}

