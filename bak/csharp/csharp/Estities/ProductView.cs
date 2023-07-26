namespace csharp.Estities
{
    public class ProductView
    {
        public int TotalProducts { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiffCostPrice { get; set; }
        public decimal TotalPercDiffCostPrice { get; set; }
        public List<ProductItem> Itens { get; set; }
    }
}
