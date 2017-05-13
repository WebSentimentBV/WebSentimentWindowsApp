using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    public class PageOrder
    {
        //VARIABLES
        public int pageOrderID { get; set; }
        public int pageID { get; set; }
        public int parentID { get; set; }
        public string pageTitle { get; set; }

        //CONSTRUCTOR

        public PageOrder()
        {

        }

        public PageOrder(int pageOrderID, int pageID, int parentID, string pageTitle)
        {
            this.pageOrderID = pageOrderID;
            this.pageID = pageID;
            this.parentID = parentID;
            this.pageTitle = pageTitle;
        }

        public void InsertPageOrders(SQLiteConnection con)
        {
            con.Insert(new PageOrder(1, 1, 0, "Home"));
            con.Insert(new PageOrder(2, 2, 1, "Diensten"));
            con.Insert(new PageOrder(3, 3, 1, "Projecten"));
            con.Insert(new PageOrder(4, 4, 1, "Over ons"));
            con.Insert(new PageOrder(5, 5, 1, "Cliënten"));
            con.Insert(new PageOrder(6, 6, 1, "Contact"));
            con.Insert(new PageOrder(7, 7, 2, "Website"));
            con.Insert(new PageOrder(8, 8, 2, "E-commerce"));
            con.Insert(new PageOrder(9, 9, 2, "Applicaties op maat"));
        }

        public void GetPageOrder()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var pageOrderQuery = "SELECT * FROM PageOrder WHERE pageOrderID = " + pageOrderID.ToString() + ";";
            List<PageOrder> selectedPageOrder = con.Query<PageOrder>(pageOrderQuery);
            if (selectedPageOrder.Count > 0)
            {
                this.pageOrderID = selectedPageOrder[0].pageOrderID;
                this.pageID = selectedPageOrder[0].pageID;
                this.parentID = selectedPageOrder[0].parentID;
                this.pageTitle = selectedPageOrder[0].pageTitle;
            }
        }

        public List<PageOrder> GetSubPageOrders()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var subPageOrdersQuery = "SELECT * FROM PageOrder WHERE parentID = " + pageOrderID.ToString() + ";";
            List<PageOrder> subPageOrders = con.Query<PageOrder>(subPageOrdersQuery);
            return subPageOrders;
        }
    }
}
