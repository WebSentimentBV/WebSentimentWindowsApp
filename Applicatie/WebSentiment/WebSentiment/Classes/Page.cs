using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    public class Page
    {
        //VARIABLES
        public int pageID { get; set; }
        public string pageType { get; set; }
        public string pageTitle { get; set; }
        public byte[] pageImage { get; set; }
        public string pageTextOne { get; set; }
        public string pageTextTwo { get; set; }

        //CONSTRUCTOR
        public Page()
        {

        }

        public Page(int pageID, string pageType, string pageTitle, byte[] pageImage, string pageTextOne, string pageTextTwo)
        {
            this.pageID = pageID;
            this.pageType = pageType;
            this.pageTitle = pageTitle;
            this.pageImage = pageImage;
            this.pageTextOne = pageTextOne;
            this.pageTextTwo = pageTextTwo;
        }

        public void InsertPages(SQLiteConnection con)
        {
            byte[] imgEmpty = new byte[] { };
            con.Insert(new Page(1, "Menu", "Home", imgEmpty, "", ""));
            con.Insert(new Page(2, "Menu", "Diensten", imgEmpty, "", ""));
            con.Insert(new Page(3, "SliderProjects", "Projecten", imgEmpty, "", ""));
            con.Insert(new Page(4, "Text", "Over ons", imgEmpty, "", ""));
            con.Insert(new Page(5, "Slider", "Cliënten", imgEmpty, "", ""));
            con.Insert(new Page(6, "Contact", "Contact", imgEmpty, "", ""));
            con.Insert(new Page(7, "ImageText", "Website", imgEmpty, "", ""));
            con.Insert(new Page(8, "ImageText", "E-commerce", imgEmpty, "", ""));
            con.Insert(new Page(9, "ImageText", "Applicaties op maat", imgEmpty, "", ""));
        }

        public void GetPage()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var pageQuery = "SELECT * FROM Page WHERE pageID = " + pageID.ToString() + ";";
            List<Page> selectedPage = con.Query<Page>(pageQuery);
            if (selectedPage.Count > 0)
            {
                this.pageID = selectedPage[0].pageID;
                this.pageType = selectedPage[0].pageType;
                this.pageTitle = selectedPage[0].pageTitle;
                this.pageImage = selectedPage[0].pageImage;
                this.pageTextOne = selectedPage[0].pageTextOne;
                this.pageTextTwo = selectedPage[0].pageTextTwo;
            }
        }
    }
}
