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

        //CONSTRUCTOR
        public Category()
        {

        }

        public void GetCategoryName()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var categoryQuery = "SELECT categoryTitle FROM tbl_Categories WHERE categoryID = " + categoryID.ToString() + ";";
            List<Category> selectedCategory = con.Query<Category>(categoryQuery);
            if (selectedCategory.Count > 0)
            {
                this.categoryID = selectedCategory[0].categoryID;
                this.categoryTitle = selectedCategory[0].categoryTitle;
            }
        }

        public Object GetSubCategories()
        {
            SQLiteConnection con = new DatabaseManager().GetCon();
            var subCategoriesQuery = "SELECT * FROM tbl_C_Regels INNER JOIN tbl_Categories WHERE categoryID = " + categoryID.ToString() + " WHERE parentID = " + categoryID.ToString() + ";";
            
            var subCategories = con.Query<C_Regel>(subCategoriesQuery);
            return subCategories;
        }
    }
}
