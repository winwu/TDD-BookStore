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
            var uniqueCollection = new List<List<Book>>();
            
            if (uniqueCollection.Count <= 0)
            {
                List<Book> tmp = new List<Book>();
                uniqueCollection.Add(tmp);
            }

            var book = this._books;

            for(var i = 0; i< book.Count(); i++)
            {
                Console.WriteLine("index is : {0}", i);
                var b = book.ElementAt(i);

                // 有沒有被 append 過
                bool used = false;

                foreach (var currentList in uniqueCollection.ToList())
                {
                    if(!currentList.Any(item => item.Id == b.Id))
                    {
                        // 沒有重複 也沒有用過
                        if (used == false)
                        {
                            Console.WriteLine("never used");
                            currentList.Add(b);
                            used = true;
                            // break;
                        }
                    }
                }

                if (!used)
                {
                    var tmpList = new List<Book>();
                    tmpList.Add(b);
                    uniqueCollection.Add(tmpList);
                }
            }

            // default total
            int total = 0;

            foreach(var currentList in uniqueCollection)
            {
                Console.WriteLine("current list is {0} \t", currentList.Count);

                int currentListTotal = currentList.Sum(item => item.Price);

                if (currentList.Count == 2)
                {
                    // 兩本不同打 5%
                    currentListTotal = Convert.ToInt32(currentListTotal * 0.95);
                }
                else if (currentList.Count == 3)
                {
                    // 三本不同打 10%
                    currentListTotal = Convert.ToInt32(currentListTotal * 0.9);
                }
                else if (currentList.Count == 4)
                {
                    // 四本不同打 20%
                    currentListTotal = Convert.ToInt32(currentListTotal * 0.8);
                }
                else if (currentList.Count == 5)
                {
                    // 五本不同打 25%
                    currentListTotal = Convert.ToInt32(currentListTotal * 0.75);
                }

                Console.WriteLine("this currentlist after discount {0}", currentListTotal);
                total += currentListTotal;

            }

            return total;
        }
    }
}