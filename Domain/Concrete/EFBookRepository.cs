using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books
        {
            get { return context.Books; }
        }

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
                context.Books.Add(book);
            else
            {
                Book db = context.Books.Find(book.BookId);
                if (db != null)
                {
                    db.Author = book.Author;
                    db.Description = book.Description;
                    db.Genre = db.Genre;
                    db.Name = db.Name;
                    db.Price = db.Price;
                }
            }
            context.SaveChanges();
        }
    }
}
