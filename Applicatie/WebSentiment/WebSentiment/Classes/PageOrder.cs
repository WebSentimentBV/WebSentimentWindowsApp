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

        }

        public void InsertPageOrders(SQLiteConnection con)
        {

        }

        public void GetPageOrder()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var pageOrderQuery = "SELECT * FROM PageOrders WHERE pageOrderID = " + pageOrderID.ToString() + ";";
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
