
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public bool TestMethod1(string name)
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


    }
}
