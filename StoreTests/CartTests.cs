﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod()]
        public void Get_Total_Price_buy_book_id_1_and_2_and_3()
        {
            //  第一二三集各買一本  價格應為 100*3*0.9 = 270
            // arrange
            var books = new List<Book>
            {
                new Book() { Id = "1", Name = "《哈利波特-神祕的魔法石》", Price = 100 },
                new Book() { Id = "2", Name = "《哈利波特-消失的密室》", Price = 100 },
                new Book() { Id = "3", Name = "《哈利波特-阿茲卡班的逃犯》", Price = 100 }
            };

            var target = new Cart(books);
            int expected = 270;

            // act
            var actual = target.GetTotalPrice();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Get_Total_Price_buy_book_id_1_and_2_and_3_and_4()
        {
            //  第一二三四集各買一本  價格應為 100*4*0.8 = 320
            // arrange
            var books = new List<Book>
            {
                new Book() { Id = "1", Name = "《哈利波特-神祕的魔法石》", Price = 100 },
                new Book() { Id = "2", Name = "《哈利波特-消失的密室》", Price = 100 },
                new Book() { Id = "3", Name = "《哈利波特-阿茲卡班的逃犯》", Price = 100 },
                new Book() { Id = "4", Name = "《哈利波特-火盃的考驗》", Price = 100 }
            };

            var target = new Cart(books);
            int expected = 320;

            // act
            var actual = target.GetTotalPrice();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Get_Total_Price_buy_book_id_1_to_5()
        {
            //  第一二三四五集各買一本  價格應為 100*5*0.75 = 375
            // arrange
            var books = new List<Book>
            {
                new Book() { Id = "1", Name = "《哈利波特-神祕的魔法石》", Price = 100 },
                new Book() { Id = "2", Name = "《哈利波特-消失的密室》", Price = 100 },
                new Book() { Id = "3", Name = "《哈利波特-阿茲卡班的逃犯》", Price = 100 },
                new Book() { Id = "4", Name = "《哈利波特-火盃的考驗》", Price = 100 },
                new Book() { Id = "5", Name = "《哈利波特-鳳凰會的密令》", Price = 100 }
            };

            var target = new Cart(books);
            int expected = 375;

            // act
            var actual = target.GetTotalPrice();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Get_Total_Price_buy_book_id_1_and_2_and_3_and_3()
        {
            //  一二 各買一本  第三買兩本 價格應為 100*3*0.9 + 100 = 370
            // arrange
            var books = new List<Book>
            {
                new Book() { Id = "1", Name = "《哈利波特-神祕的魔法石》", Price = 100 },
                new Book() { Id = "2", Name = "《哈利波特-消失的密室》", Price = 100 },
                new Book() { Id = "3", Name = "《哈利波特-阿茲卡班的逃犯》", Price = 100 },
                new Book() { Id = "3", Name = "《哈利波特-阿茲卡班的逃犯》", Price = 100 }
            };

            var target = new Cart(books);
            int expected = 370;

            // act
            var actual = target.GetTotalPrice();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Get_Total_Price_buy_book_id_1_and_2x2_and_3x2()
        {
            //  第一集買一本 第二三集各買兩本 價格應為 100*3*0.9 + 100*2*0.95 = 460
            // arrange
            var books = new List<Book>
            {
                new Book() { Id = "1", Name = "《哈利波特-神祕的魔法石》", Price = 100 },
                new Book() { Id = "2", Name = "《哈利波特-消失的密室》", Price = 100 },
                new Book() { Id = "2", Name = "《哈利波特-消失的密室》", Price = 100 },
                new Book() { Id = "3", Name = "《哈利波特-阿茲卡班的逃犯》", Price = 100 },
                new Book() { Id = "3", Name = "《哈利波特-阿茲卡班的逃犯》", Price = 100 }
            };

            var target = new Cart(books);
            int expected = 460;

            // act
            var actual = target.GetTotalPrice();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}