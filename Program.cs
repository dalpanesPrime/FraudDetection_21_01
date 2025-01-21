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

        //Check for same Deal and address
        List<Order> idOrdersFraudulentDealAddress = orders.Where(o => 
        (o.DealId == orders[0].DealId && o.Email.ToLower() == orders[0].Email.ToLower()) 
        ||
        (o.DealId == orders[0].DealId && o.Address.ToLower() == orders[0].Address.ToLower() && o.City.ToLower() == orders[0].City.ToLower() && o.State.ToLower() == orders[0].State.ToLower() && o.Zip == orders[0].Zip )
        ).ToList();

    

foreach (Order order in idOrdersFraudulentDealAddress) {
    Console.WriteLine(order.Id);
}
Console.ReadLine();


