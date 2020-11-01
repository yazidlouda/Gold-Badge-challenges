using System;
using System.Collections.Generic;
using Cafe.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTest
{
    [TestClass]
    public class CafeTest1
    {
        [TestMethod]
        public void AddOrder_ShouldGetCorrectBoolean()
        {
            Menu order = new Menu();
            MenuRepository repository = new MenuRepository();

            repository.AddOrder(order);

            int expected = 1;
            int actual = repository.ListOrders().Count;

            Assert.AreEqual(expected,actual);


        }
        [TestMethod]
        public void GetdOrderByNumber_ShouldReturnCorrectCollection()
        {
            
            Menu content = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddOrder(content);
          
            List <Menu> contents = repo.ListOrders();
            bool directoryHasContent = contents.Contains(content);
           
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void RemoveOrder_ShouldReturnTrue()
        {
            Menu content = new Menu();
            MenuRepository repo = new MenuRepository();

            repo.AddOrder(content);

            bool wasRemoved = repo.RemoveOrder(content);
            Assert.IsTrue(wasRemoved);
        }
    }
}
