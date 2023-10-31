using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCSharpDemo
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id; ",
            new { id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name," +
                " Price = @price," +
                " CategoryID = @categoryID," +
                " OnSale = @onsale," +
                " StockLevel = @stockLevel" +
                " WHERE ProductId = @id;",
                new
                {
                    name = product.Name,
                    price = product.Price,
                    categoryID = product.CategoryID,
                    OnSale = product.OnSale,
                    stockLevel = product.StockLevel,
                    id = product.ProductID
                });
        }

        public void InsertProduct(string name, double price, int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}
