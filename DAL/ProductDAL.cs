using ProductSite.Models;
using Dapper;

namespace ProductSite.DAL
{
    public class ProductDAL
    {
        private DBConnection _connection;
        public ProductDAL()
        {
            _connection = new DBConnection();
        }
        public IEnumerable<Product> GetAllProducts()
        {
            using(var connection = _connection.CreateConnection())
            {
                return connection.Query<Product>("SELECT *  FROM Product;");
            }
        }

        public Product ChoiceProduct(int id)
        {
            using (var connection = _connection.CreateConnection())
            {
                return connection.Query<Product>("SELECT * FROM Product where Id = @Id;", new
                {
                    Id = id,
                }).FirstOrDefault();
            }
        }
    }
}
