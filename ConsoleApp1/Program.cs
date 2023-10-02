// See https://aka.ms/new-console-template for more information
using System;

class Converter
{
    private decimal usdRate;
    private decimal eurRate;

    public Converter(decimal usdRate, decimal eurRate)
    {
        this.usdRate = usdRate;
        this.eurRate = eurRate;
    }

    public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
    {
        if (fromCurrency.Equals("UAH", StringComparison.OrdinalIgnoreCase))
        {
            if (toCurrency.Equals("USD", StringComparison.OrdinalIgnoreCase))
            {
                return amount / usdRate;
            }
            else if (toCurrency.Equals("EUR", StringComparison.OrdinalIgnoreCase))
            {
                return amount / eurRate;
            }
        }
        else if (fromCurrency.Equals("USD", StringComparison.OrdinalIgnoreCase))
        {
            if (toCurrency.Equals("UAH", StringComparison.OrdinalIgnoreCase))
            {
                return amount * usdRate;
            }
        }
        else if (fromCurrency.Equals("EUR", StringComparison.OrdinalIgnoreCase))
        {
            if (toCurrency.Equals("UAH", StringComparison.OrdinalIgnoreCase))
            {
                return amount * eurRate;
            }
        }

        throw new InvalidOperationException("Неправильний обмін валют.");
    }
}

class Program
{
    static void Main(string[] args)
    {
     
        decimal usdRate = 38.4M; // Курс долара до гривні
        decimal eurRate = 39.24M; // Курс євро до гривні

        Converter converter = new Converter(usdRate, eurRate);

        Console.WriteLine("Сurrency conversion.");

        Console.Write("Enter the currency you are converting (UAH, USD, EUR): ");
        string fromCurrency = Console.ReadLine().ToUpper();

        Console.Write("Enter the currency you are converting to (UAH, USD, EUR): ");
        string toCurrency = Console.ReadLine().ToUpper();

        Console.Write("Enter the amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        decimal result = converter.Convert(amount, fromCurrency, toCurrency);

        Console.WriteLine($"{amount} {fromCurrency} = {result} {toCurrency}");

        Console.ReadKey();
    }
}








