using Microsoft.Data.Sqlite;

namespace ProductSystem
{
    public static class DBConnection
    {
        public static string DbPath;
        private static string _dbAddress;
        public static SqliteConnection CreateConnection()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "shop.sqlite");
            _dbAddress = "Data Source=" + DbPath;
            return new SqliteConnection(_dbAddress);
        }
    }
}