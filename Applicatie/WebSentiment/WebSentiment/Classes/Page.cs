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
        }
    }
}
