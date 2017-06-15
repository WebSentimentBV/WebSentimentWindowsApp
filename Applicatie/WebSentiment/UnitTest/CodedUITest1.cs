using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Linq;

namespace UnitTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            string lblTextbox;
            bool bLabels = true;
            bool bTextBoxes = false;
            {
                if (bLabels)
                {
                    lblTextbox = "";
                    lblTextbox = "";
                    lblTextbox = "";
                }
                if (bTextBoxes)
                {
                    lblTextbox = "";
                    lblTextbox = "";
                    lblTextbox = "";
                    lblTextbox = "";
                }

            }
        }

        [TestMethod]
        public bool TestCode(string name)
        {
            name = "dsfsdaf";
            string error;
            string nameInput = name;

            if (nameInput.Any(char.IsDigit))
            {
                error = "Uw naam kan alleen bestaan uit letters.";
                return false;
            }
            if (nameInput.Count() < 2 || nameInput.Count() > 25)
            {
                error = "Uw naam moet 2-25 letters bevatten.";
                return false;
            }

            return true;
        }
    

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
