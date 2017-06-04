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


        public List<Client> GetClients()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var clientsQuery = "SELECT * FROM Tbl_Clients;";
            List<Client> listOfClients = con.Query<Client>(clientsQuery);
            return listOfClients;
        }
    }
}
