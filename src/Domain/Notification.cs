using System.Security.Cryptography.X509Certificates;

namespace Domain;
public class Notification
{
    private string? NotificationId { get; set; }
    private OrderStatus? NotificationType { get; set; }
    public string? Message { get; set; }
    public bool? IsSeen { get; set; }

    private Order ord { get; set; }

    public String ordId { get; set; }

    public Notification(OrderStatus ord1, String ordId1)
    {
        NotificationType = ord1;
        ordId = ordId1;
        IsSeen = false;
        if (NotificationType != null)
        {
            if (NotificationType == OrderStatus.CREATED)
            {
                Message = String.Format("Order " + ordId + " is ontvangen");
            }
            else if (NotificationType == OrderStatus.PROCCESSED)
            {
                Message = String.Format("order " + ordId + " is klaar om verzonden te worden");
            }
            else if (NotificationType == OrderStatus.SHIPPED)
            {
                Message = String.Format("Order " + ordId + " is verzonden");
            }
            else if (NotificationType == OrderStatus.DELIVERED)
            {
                Message = String.Format("Order " + ordId + " is geleverd");
            }
        }

    }
    public void isSeen(bool seen)
    {
        IsSeen = seen;
    }
    //public Notification(Order ord1)
    //{
    //    ord = ord1;
    //    if (ord.OrderId != null)
    //    {
    //        if (ord._orderStatus == OrderStatus.CREATED)
    //        {
    //            Message = String.Format("Order " + ord.OrderId + " is ontvangen");
    //        }
    //        else if (ord._orderStatus == OrderStatus.PROCCESSED)
    //        {
    //            Message = String.Format("order " + ord.OrderId + " is klaar om verzonden te worden");
    //        }
    //        else if (ord._orderStatus == OrderStatus.SHIPPED)
    //        {
    //            Message = String.Format("Order" + ord.OrderId + " is verzonden");
    //        }
    //        else if (ord._orderStatus == OrderStatus.DELIVERED)
    //        {
    //            Message = String.Format("Order " + ord.OrderId + " is geleverd");
    //        }
    //    }
    //}

}
