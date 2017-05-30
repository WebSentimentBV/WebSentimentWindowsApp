using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    public class Project
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

        public void GetProject()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var projectQuery = "SELECT * FROM Project WHERE projectID = " + projectID.ToString() + ";";
            List<Project> selectedProject = con.Query<Project>(projectQuery);
            if (selectedProject.Count > 0)
            {
                this.projectID = selectedProject[0].projectID;
                this.projectName = selectedProject[0].projectName;
                this.projectImageOne = selectedProject[0].projectImageOne;
                this.projectImageTwo = selectedProject[0].projectImageTwo;
                this.projectImageThree = selectedProject[0].projectImageThree;
            }
        }
    }
}
