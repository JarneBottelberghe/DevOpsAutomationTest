// See https://aka.ms/new-console-template for more information
using Domain;

Console.WriteLine("WIJZIG STATUS BESTELLING");
Console.WriteLine("Geef nummer bestelling: ");

string bestelNr = Console.ReadLine();
Console.WriteLine();

//TODO Juiste order ophalen DB indien order bestaat
Order order = new Order();
int status = 0;
do
{
    Console.WriteLine($"Wijzig status voor bestelling: {bestelNr}");
    Console.WriteLine("CREATED = 1");
    Console.WriteLine("PROCCESSED = 2");
    Console.WriteLine("SHIPPED = 3");
    Console.WriteLine("DELIVERED = 4");
    Console.WriteLine("Geef nummer: ");

    try
    {
        status = int.Parse(Console.ReadLine());
    } catch {
        Console.WriteLine("Geef een getal tussen 1 en 4 in ");
    }

} while (status < 1 || status > 4);

switch (status)
{
    case 1:
        order.ChangeStatus(OrderStatus.CREATED); break;
    case 2:
        order.ChangeStatus(OrderStatus.PROCCESSED); break;
    case 3:
        order.ChangeStatus(OrderStatus.SHIPPED); break;
    case 4:
        order.ChangeStatus(OrderStatus.DELIVERED); break;
    default: break;
}

//TODO STATUS WIJZIGEN IN DB
Console.WriteLine();
Console.WriteLine($"STATUS GEWIJZIGD NAAR {order._orderStatus}");

order._notfications.ForEach(noti => Console.WriteLine(noti.Message));
