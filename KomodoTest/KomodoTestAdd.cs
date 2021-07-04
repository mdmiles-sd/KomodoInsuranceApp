using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KomodoInsuranceApp;
using System.Collections.Generic;

namespace KomodoTest
{
    [TestClass]
    public class KomodoTestAdd
    {
            DeveloperRepository _repo = new DeveloperRepository();
        [TestInitialize]
        public void Arrange()
        {

            Developer MikeMiles = new Developer("MikeMiles",123456,true);
            _repo.AddDeveloperToList(MikeMiles);
        }





        [TestMethod]
        public void AddToList_NotNull()
        {
            Developer list = new Developer();
            list.ID = 123456;
            DeveloperRepository repository = new DeveloperRepository();

            repository.AddDeveloperToList(list);
            List<Developer> listFromDirectory = repository.GetDeveloperList();

            Assert.IsNotNull(listFromDirectory);
        }

        [TestMethod]
        public void UpdateEistinglist()
        {
            Developer TerranBeasley = new Developer("TerranBeasley",456789,false);
            bool updateResult = _repo.UpdateExistinglist(123456,TerranBeasley);

            Assert.IsTrue(updateResult == true);
        }

        [TestMethod]
        public void DeleteDevloper()
        {
            
            
            bool deleteResult = _repo.RemoveDeveloperFromList(123456);
            Assert.IsTrue(deleteResult);
        

        }
        
    }

}
