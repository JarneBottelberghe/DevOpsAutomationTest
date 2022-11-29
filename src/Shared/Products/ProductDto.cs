namespace Shared.Products

{
    public static class ProductDto
    {
        public class Index
        {
            public string ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double UnitPrice { get; set; }
            public int LeftInStock { get; set; }
            public double Height { get; set; }
            public double Width { get; set; }
            public double Depth { get; set; }

        }
        public class Detail
        {
            public string ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double UnitPrice { get; set; }
            public string SupplierId { get; set; }
            public int ProductCategoryId { get; set;}   

        }

        public class Mutate
        {
            public string ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double UnitPrice { get; set; }
            public int LeftInStock { get; set; }
            public double height { get; set; }
            public double width { get; set; }
            public double depth { get; set; }
            public string SupplierId { get; set; }
            public int ProductCategoryId { get; set; }
        }
    }
}
