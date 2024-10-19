using System;

public interface IPrinter
{
    void Print(string content);
}

public interface IScanner
{
    void Scan(string content);
}

public interface IFax
{
    void Fax(string content);
}

public class AllInOnePrinter : IPrinter, IScanner, IFax
{
    public void Print(string content)
    {
        Console.WriteLine("Печать: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Сканирование: " + content);
    }

    public void Fax(string content)
    {
        Console.WriteLine("Факс: " + content);
    }
}

public class BasicPrinter : IPrinter
{
    public void Print(string content)
    {
        Console.WriteLine("Печать: " + content);
    }
}

public class Scanner : IScanner
{
    public void Scan(string content)
    {
        Console.WriteLine("Сканирование: " + content);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IPrinter basicPrinter = new BasicPrinter();
        basicPrinter.Print("Документ для печати.");

        AllInOnePrinter allInOnePrinter = new AllInOnePrinter();
        allInOnePrinter.Print("Документ для печати.");
        allInOnePrinter.Scan("Документ для сканирования.");
        allInOnePrinter.Fax("Документ для факса.");

        Scanner scanner = new Scanner();
        scanner.Scan("Документ для сканирования.");
    }
}
