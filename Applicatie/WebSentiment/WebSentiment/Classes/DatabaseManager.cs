using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
namespace E_Divison.Classes
{
    class DatabaseManager
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
            databaseName = "db.sqlite";
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
