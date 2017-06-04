using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSentiment.Classes
{
    public class Category
    {
        //VARIABLES
        public int categoryID { get; set; }
        public string categoryTitle { get; set; }
        public int pageID { get; set; }
        public int parentID { get; set; }


        //CONSTRUCTOR
        public Category()
        {
        }

        public void GetCategory()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var categoryQuery = "SELECT * FROM Tbl_Categories INNER JOIN Tbl_P_Regels ON Tbl_Categories.CategoryID = Tbl_P_Regels.CategoryID WHERE Tbl_Categories.categoryID = " + categoryID.ToString() + ";";
            List<Category> selectedCategory = con.Query<Category>(categoryQuery);
            if (selectedCategory.Count > 0)
            {
                this.pageID = selectedCategory[0].pageID;
                this.categoryTitle = selectedCategory[0].categoryTitle;
            }
        }

        public List<Category> GetSubCategories()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var subCategoriesQuery = "SELECT * FROM tbl_C_Regels INNER JOIN tbl_Categories ON tbl_C_Regels.categoryID = tbl_Categories.categoryID  WHERE parentID = " + categoryID.ToString() + "; ";
            List<Category> subCategories = con.Query<Category>(subCategoriesQuery);
            return subCategories;
        }
    }
}
