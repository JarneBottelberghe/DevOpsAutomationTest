namespace Domain;
public class Item
{
    public string ItemId { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }

    public Product Product { get; set; }

    public Item(string itemId, int quantity, double totalPrice, Product product)
    {
        ItemId = itemId;
        Quantity = quantity;
        TotalPrice = totalPrice;
        Product = product;
    }
}