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
            // 不重複的 Book 組合
            List<Book> uniqueGroup = new List<Book>();
            
            // 重複的 Book 組合
            List<Book> notUniqueGroup = new List<Book>();

            foreach(var b in this._books)
            {
                bool isExists = uniqueGroup.Any(item => item.Id == b.Id);
                if (isExists)
                {
                    notUniqueGroup.Add(b);
                } else
                {
                    uniqueGroup.Add(b);
                }
            }

            int sumOfUnique = 0;
            int sumOfNotUnique = 0;

            sumOfUnique = uniqueGroup.Sum(p => p.Price);
            sumOfNotUnique = notUniqueGroup.Sum(p => p.Price);


            if(uniqueGroup.Count == 2)
            {
                // 兩本不同打 5%
                sumOfUnique = Convert.ToInt32(sumOfUnique * 0.95);
            } else if (uniqueGroup.Count == 3 ) {
                // 三本不同打 10%
                sumOfUnique = Convert.ToInt32(sumOfUnique * 0.9);
            }
            

            return sumOfUnique + sumOfNotUnique;
        }
    }
}