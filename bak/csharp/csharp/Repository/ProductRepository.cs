using csharp.Estities;
using System.Data;

namespace csharp.Repository
{
    public class ProductRepository : BaseRepository
    {


        public ProductEntity GetProductsView()
        {
            try
            {
                string query = $@"SELECT A.ProductID, A.Name AS Product, A.ProductNumber,
                                   A.StandardCost, A.ListPrice,
                                   B.Name AS Subcategory,
                                   C.Name AS Category,
                                   D.Name AS Model
                            FROM AdventureWorks2019.Production.Product AS A
                            INNER JOIN AdventureWorks2019.Production.ProductSubcategory AS B ON B.ProductSubcategoryID = A.ProductSubcategoryID 
                            INNER JOIN AdventureWorks2019.Production.ProductCategory AS C ON C.ProductCategoryID = B.ProductCategoryID
                            INNER JOIN AdventureWorks2019.Production.ProductModel AS D ON D.ProductModelID = A.ProductModelID";


                List<ProductItem> itens = new List<ProductItem>();
                DataTable result = ExecQuery(query);

                if (result.Rows.Count == 0)
                {
                    return null;
                }

                foreach (DataRow dr in result.Rows)
                {
                    var item = new ProductItem
                    {

                        ProductID = Convert.ToInt32(dr["ProductID"]),
                        Name = Convert.ToString(dr["Product"]),
                        ProductNumber = Convert.ToString(dr["ProductNumber"]),
                        StandardCost = Math.Round(Convert.ToDecimal(dr["StandardCost"]), 2),
                        ListPrice = Math.Round(Convert.ToDecimal(dr["ListPrice"]), 2),
                        Subcategory = Convert.ToString(dr["Subcategory"]),
                        Category = Convert.ToString(dr["Category"]),
                        Model = Convert.ToString(dr["Model"])

                    };
                    var differenceCosPrice = Math.Round(item.ListPrice - item.StandardCost, 2);
                    var percDiffCosPrice = Math.Round((item.ListPrice - item.StandardCost) / item.ListPrice * 100, 2);
                    itens.Add(item);
                }
                var newList = itens.Where(x => x.ProductID > 800)
                    .Select(x => new { Produto = x.ProductID, Valor = $"R${x.ListPrice}", Ordem = x.ListPrice })
                    .OrderByDescending(x => x.Ordem)
                    .FirstOrDefault();
                decimal totalCost = Math.Round(itens.Sum(x => x.StandardCost), 2);
                decimal totalprice = Math.Round(itens.Sum(x => x.ListPrice), 2);
                return new ProductEntity
                {
                    TotalProducts = itens.Count,
                    TotalCost = totalCost,
                    TotalPrice = totalprice,
                    TotalDiffCostPrice = totalprice - totalCost,
                    TotalPercDiffCostPrice = Math.Round((totalprice - totalCost) / totalprice * 100, 2),
                    Itens = itens
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class ProductEntity
        {
            public int TotalProducts { get; set; }
            public decimal TotalCost { get; set; }
            public decimal TotalPrice { get; set; }
            public decimal TotalDiffCostPrice { get; set; }
            public decimal TotalPercDiffCostPrice { get; set; }
            public List<ProductItem> Itens { get; set; }
        }
    }
}


