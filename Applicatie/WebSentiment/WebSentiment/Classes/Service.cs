using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    public class Service
    {
        //VARIABLES
        public int serviceID { get; set; }
        public string serviceTitle { get; set; }
        public string serviceText { get; set; }
        public byte[] serviceImage { get; set; }

        //CONSTRUCTOR
        public Service()
        {

        }
        public Service(int serviceID, string serviceTitle, string serviceText, byte[] serviceImage)
        {
            this.serviceID = serviceID;
            this.serviceTitle = serviceTitle;
            this.serviceText = serviceText;
            this.serviceImage = serviceImage;
        }

        public void InsertServices(SQLiteConnection con)
        {
            byte[] imgEmpty = new byte[] { };
            con.Insert(new Service(1, "Website", "Bent u opzoek naar een effectieve website die uw doelgroep volledig informeert en op een positieve manier aantrekt? Of uw website nu uit enkele pagina’s bestaat of complexer van aard is, WebSentiment ontwikkelt graag een succesvolle website voor u.", imgEmpty));
            con.Insert(new Service(2, "E-commerce", "Het aantal online verkopen heeft zich de afgelopen jaren enorm ontwikkeld. Het aantal mobiele internetshoppers zal de komende jaren alleen maar toenemen. WebSentiment ontwikkelt professionele en efficiënte webshops op maat met een doel- en conversiegericht design.", imgEmpty));
            con.Insert(new Service(3, "Applicaties op maat", "Heeft u genoeg van tijdrovende bedrijfsprocessen en wilt u uw productiviteit vergroten? Steeds meer bedrijven maken gebruik van online software op maat. WebSentiment heeft meer dan 15 jaar ervaring in huis als het gaat om het automatiseren van bedrijfsprocessen.", imgEmpty));
        }
    }
}
