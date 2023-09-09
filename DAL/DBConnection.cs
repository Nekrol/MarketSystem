using Microsoft.Data.Sqlite;

namespace ProductSite.DAL
{
    public class DBConnection
    {
        public string DbPath;

        private string _dbAddress;
        public  SqliteConnection CreateConnection()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "shop.sqlite");
            _dbAddress = "Data Source=" + DbPath;
            return new SqliteConnection(_dbAddress);
        }
    }
}
