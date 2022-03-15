using Ficha_12.Models;
using Microsoft.EntityFrameworkCore;

//implementação da interface IBookService, 
namespace Ficha_12.Services
{
    public class BookService : IBookService
    {
        //context é a sessão a base dados
        private readonly LibraryContext context;
        public BookService (LibraryContext context)
        {
            this.context = context;
        }
        //Book referencia para a tabela
        public Book Create(Book newBook)
        {
            Publisher pub = context.Publishers.Find(newBook.Publisher.ID);

            if(pub is null)
            {
                throw new NullReferenceException("Publisher does not exist.");
            }
            else
            {
                newBook.Publisher = pub;
                context.Books.Add(newBook);
                context.SaveChanges();
                return newBook;
            }
        }

        public void DeleteByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public Book Download()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            var books = context.Books.Include(p => p.Publisher);
            return books;

            //return context.Books.Include(p => p.Publisher);
        }

        public void GetByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public Book? GetByISBN(string isbn)
        {
            var book = context.Books.Include(b => b.Publisher).SingleOrDefault(b => b.ISBN == isbn);
            return book;
        }

        
        public void Update(string isbn, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(string isbn, int publisherId)
        {
            throw new NotImplementedException();
        }
    }
}
