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
        private IEnumerable<Book> _books;

        public Cart(IEnumerable<Book> books)
        {
            this._books = books;
        }

        public int GetTotalPrice()
        {
            List<int> priceList = new List<int>();
            var sum = 0;

            foreach(var b in this._books)
            {
                priceList.Add(b.Price);
            }

            sum = priceList.Sum();
            Console.WriteLine("Price Sum {0}", sum);

            return sum;
        }
    }
}