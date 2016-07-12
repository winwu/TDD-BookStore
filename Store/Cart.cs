using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class Cart
    {
        private List<Book> books;

        public Cart(List<Book> books)
        {
            this.books = books;
        }

        public object GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}