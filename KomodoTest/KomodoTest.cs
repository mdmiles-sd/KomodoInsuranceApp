using KomodoInsuranceApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoTest
{
    [TestClass]
    public class KomodoTest
    {
        [TestMethod]
        public void SetID_Test()
        {
            Developer list = new Developer();

            list.ID = 123456;

            int expected = 123456;
            int actual = list.ID;

            Assert.AreEqual(expected, actual);
        }
    }
}
