namespace Shared.Orders;
public static class PackageDto
{
    public class Create
    {
        public string? PackageId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Dept { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

    }


}
