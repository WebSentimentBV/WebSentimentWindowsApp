using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    public class Client
    {
        //VARIABLES
        public int clientID { get; set; }
        public string clientName { get; set; }
        public byte[] clientImage { get; set; }

        //CONSTRUCTOR
        public Client()
        {

        }

        public Client(int clientID, string clientName, byte[] clientImage)
        {
            this.clientID = clientID;
            this.clientName = clientName;
            this.clientImage = clientImage;
        }

        public void InsertClients(SQLiteConnection con)
        {
            byte[] imgEmpty = new byte[] { };
            con.Insert(new Client(1, "Naam", clientImage));
            con.Insert(new Client(2, "Naam", clientImage));
            con.Insert(new Client(3, "Naam", clientImage));
        }
    }
}
