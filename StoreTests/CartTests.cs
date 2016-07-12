using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void Get_Total_Price_buy_book_id_1()
        {
            //  第一集買了一本，價格應為100*1=100
            // arrange
            var books = new List<Book>
            {
                new Book()
                {
                    Id = "1",
                    Name = "《哈利波特-神祕的魔法石》",
                    Price = 100
                }
            };

            var target = new Cart(books);
            int expected = 100;

            // act
            var actual = target.GetTotalPrice();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Get_Total_Price_buy_book_id_1_and_2()
        {
            //  第一集買了一本，第二集也買了一本 價格應為 100*2*0.95 = 190
            // arrange
            var books = new List<Book>
            {
                new Book() { Id = "1", Name = "《哈利波特-神祕的魔法石》", Price = 100 },
                new Book() { Id = "2", Name = "《哈利波特-消失的密室》", Price = 100 }
            };

            var target = new Cart(books);
            int expected = 190;

            // act
            var actual = target.GetTotalPrice();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}