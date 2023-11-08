using ProductSite.Models;
using Dapper;
using Humanizer.Bytes;

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
            using (var connection = _connection.CreateConnection())
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
        public void RateProduct(int rate, int productId)
        {
            using (var connection = _connection.CreateConnection())
            {
                connection.Query("INSERT INTO Rating ( Rate, ProductId ) VALUES ( @Rate, @ProductId );", new
                {
                    Rate = rate,
                    ProductId = productId,
                }
                    );
            }
        }
        public float GetAverageRating(int id)
        {
            using (var connection = _connection.CreateConnection())
            {
                return connection.Query<float>("SELECT AVG(Rate) FROM Rating WHERE ProductId=@Id;", new
                {
                    Id = id,
                }
                    ).FirstOrDefault();

            }
        }
    }
    }
