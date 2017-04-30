using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    class Page
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

        public void InsertPages(SQLiteConnection con)
        {

        }
    }
}
