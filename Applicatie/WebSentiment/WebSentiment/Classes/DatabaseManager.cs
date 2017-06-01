using SQLite.Net;
using System.IO;
namespace WebSentiment.Classes
{
    public class DatabaseManager
    {
        private SQLite.Net.SQLiteConnection con;
        const string databaseName = "WebSentimentDB.sqlite";
        private string path;
        public DatabaseManager()
        {
            Init();
        }
        private void Init()
        {
            path = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Data", databaseName);
            con = new SQLite.Net.SQLiteConnection(new
            SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        public SQLiteConnection GetCon()
        {
            return con;
        }
    }
}
