using Dapper;
using ProductSystem.Models;

namespace ProductSystem
{
    internal class Query
    {
        public static IEnumerable<Product> GetAllProducts()
        {
            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<Product>("Select * from Product");
            }
        }

        public static IEnumerable<Vendor> GetAllVendors()
        {
            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<Vendor>("Select * from Vendor");
            }
        }

        public static void CreateProduct(Product product)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query<Product>("INSERT INTO Product (Name, Price, Amount, VendorId, Description ) VALUES (@name, @price, @amount, @vendorId, @description );", new
                {
                    name = product.Name,
                    price = product.Price,
                    amount = product.Amount,
                    vendorId = product.VendorId,
                    description = product.Description
                });
            }
        }
        public static void CreateVendor(Vendor vendor)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query<Vendor>("INSERT INTO Vendor (Name, Address ) VALUES (@name, @address );", new
                {
                    name = vendor.Name,
                    address = vendor.Address
                });
            }
        }
        public static void EditProduct(Product product, int id)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query<Product>("UPDATE Product SET Name = @name, Price = @price, Amount = @amount, VendorId = @vendorId,  Description = @description WHERE Id = @Id;", new
                {
                    Id = id,
                    name = product.Name,
                    price = product.Price,
                    amount = product.Amount,
                    vendorId = product.VendorId,
                    description = product.Description,
                });
            }
        }
        public static Product ChoiceProduct(int id) 
        {
            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<Product>("SELECT * FROM Product where Id = @Id;", new
                {
                    Id = id,
                }).FirstOrDefault();
            }
        }

        public static Vendor ChoiceVendor(int id)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<Vendor>("SELECT * FROM Vendor where Id = @Id;", new
                {
                    Id = id,
                }).FirstOrDefault();
            }
        }
        public static void DeleteProduct(int id)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query("DELETE FROM Product WHERE Id = @Id;", new
                {
                    Id = id,
                }).FirstOrDefault();

            }
        }

        public static void DeleteVendor(int id2)
        {
            using (var connection = DBConnection.CreateConnection())
            {
                connection.Query("DELETE FROM Vendor WHERE Id = @Id;", new
                {
                    Id = id2,
                }).FirstOrDefault();

            }
        }
        public static int GetHighId()
        {

            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<int>("SELECT Id FROM Product order by 1 desc limit 1 ;")
                .FirstOrDefault();
            }
        }
        public static int GetHighIdVendor()
        {

            using (var connection = DBConnection.CreateConnection())
            {
                return connection.Query<int>("SELECT Id FROM Vendor order by 1 desc limit 1 ;")
                .FirstOrDefault();
            }
        }
    }
}
