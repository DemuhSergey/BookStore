using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> listcollection = new List<CartLine>();

        public void AddItem(Book book, int quntity)
        {
            CartLine line = listcollection
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line != null)
            {
                line.Quntity += quntity;
            }
            else
            {
                listcollection.Add(new CartLine
                {
                    Quntity =quntity,
                    Book = book
                });
            }
        }

        public void RemoveLine(Book book)
        {
            listcollection.RemoveAll(a=>a.Book.BookId == book.BookId);
        }

        public decimal ComputeTotalValue()
        {
            return listcollection.Sum(c => c.Book.Price * c.Quntity);
        }

        public void Clear()
        {
            listcollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return listcollection; }
        }
    }

    public class CartLine
    {
        public Book Book { get; set; }
        public int Quntity { get; set; }
    }


}
