// See https://aka.ms/new-console-template for more information
using FraudDetection_21_01.Entities;
using System.Numerics;

Console.Write("Set number of orders to deal with: ");
int n = int.Parse(Console.ReadLine());

List<string> inputs = new List<string>();
for (int i = 0; i < n; i++)
{
    Console.Write($"Order {i + 1}: ");
    string input = Console.ReadLine();
    inputs.Add(input);
}

// Aquí puedes procesar los datos de la lista 'inputs'

List<Order> orders = new List<Order>();
Console.WriteLine("Fraudulent Orders are:");
foreach (string input in inputs)
{
    string[] orderProperties = input.Split(',');
    orders.Add(
        new Order() {
            Id= int.Parse(orderProperties[0]),
            DealId= int.Parse(orderProperties[1]),
            Email= orderProperties[2],
            Address= orderProperties[3],
            City= orderProperties[4],
            State= orderProperties[5],
            Zip = int.Parse(orderProperties[6]),
            CreditCard = BigInteger.Parse(orderProperties[7])
        });    
}

string[] streets = { "St. Example", "Street Example", "Another Street" };
string target = "street";

List<Order> idOrdersFraudulent = null;
foreach (var order in orders)
{
    if (idOrdersFraudulent == null)
    {
        //Check for same Deal and address
        idOrdersFraudulent = orders.Where(o =>
                (o.DealId == order.DealId && o.Email.ToLower() == order.Email.ToLower())
                ||
                (o.DealId == order.DealId && o.Address.ToLower() == order.Address.ToLower() && o.City.ToLower() == order.City.ToLower() && o.State.ToLower() == order.State.ToLower() && o.Zip == order.Zip && o.CreditCard != order.CreditCard)
                ).ToList();
    }
    else if(!idOrdersFraudulent.Contains(order))
    {
        idOrdersFraudulent.AddRange( orders.Where(o =>
                (o.DealId == order.DealId && o.Email.ToLower() == order.Email.ToLower())
                ||
                (o.DealId == order.DealId && o.Address.ToLower() == order.Address.ToLower() && o.City.ToLower() == order.City.ToLower() && o.State.ToLower() == order.State.ToLower() && o.Zip == order.Zip && o.CreditCard != order.CreditCard)
                ).ToList());
    }

}



if (idOrdersFraudulent != null)
{
    foreach (Order order in idOrdersFraudulent)
    {
        Console.WriteLine(order.Id);
    }
}
else {
    Console.WriteLine("There are no fraudulent orders");
}

Console.ReadLine();


