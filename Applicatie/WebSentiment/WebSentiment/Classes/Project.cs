using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    class Project
    {
        //VARIABLES
        public int projectID { get; set; }
        public string projectName { get; set; }
        public byte[] projectImageOne { get; set; }
        public byte[] projectImageTwo { get; set; }
        public byte[] projectImageThree { get; set; }

        //CONSTRUCTOR
        public Project()
        {

        }

        public Project(int projectID, string projectName, byte[] projectImageOne, byte[] projectImageTwo, byte[] projectImageThree)
        {
            this.projectID = projectID;
            this.projectName = projectName;
            this.projectImageOne = projectImageOne;
            this.projectImageTwo = projectImageTwo;
            this.projectImageThree = projectImageThree;
        }

        public void InsertProjects(SQLiteConnection con)
        {
            byte[] imgEmpty = new byte[] { };
            con.Insert(new Project(1, "Merlijn", imgEmpty, imgEmpty, imgEmpty));
            con.Insert(new Project(2, "Het houtse meer", imgEmpty, imgEmpty, imgEmpty));
            con.Insert(new Project(3, "TRA", imgEmpty, imgEmpty, imgEmpty));
        }
    }
}
