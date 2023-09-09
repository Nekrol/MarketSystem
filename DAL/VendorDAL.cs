using ProductSite.Models;
using Dapper;

namespace ProductSite.DAL
{
    public class VendorDAL
    {
        private DBConnection _connection;
        public IEnumerable<Vendor> GetAllVendors()
        {
            using (var connection = _connection.CreateConnection())
            {
                return connection.Query<Vendor>("Select * FROM Vendor;");
            }
        }

        public Vendor ChoiceVendor(int id)
        {
            using (var connection = _connection.CreateConnection())
            {
                return connection.Query<Vendor>("SELECT * FROM Product where Id = @Id;", new
                {
                    Id = id,
                }).FirstOrDefault();
            }
        }
    }
}
