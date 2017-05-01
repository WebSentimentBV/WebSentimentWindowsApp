using SQLite.Net;
using System.IO;
namespace WebSentiment.Classes
{
    public class DatabaseManager
    {
        private SQLite.Net.SQLiteConnection con;
        private string databaseName;
        private string path;
        public DatabaseManager()
        {
            Init();
        }
        private void Init()
        {
            databaseName = "WebSentimentDB";
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, databaseName);
            con = new SQLite.Net.SQLiteConnection(new
            SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        public SQLiteConnection GetCon()
        {
            return con;
        }
    }
}
