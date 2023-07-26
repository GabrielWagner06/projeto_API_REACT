using System.Data;

namespace csharp.Estities
{
    public class ProductItem
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public List<ProductItem> Itens { get; set; }



        internal static void Add(object value)
        {
            throw new NotImplementedException();
        }

        public static implicit operator DataTable(ProductItem v)
        {
            throw new NotImplementedException();
        }
    }
}
