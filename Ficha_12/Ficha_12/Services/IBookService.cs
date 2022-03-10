using Ficha_12.Models;

namespace Ficha_12.Services
{
    public interface IBookService
    {
        public abstract IEnumerable<Book> GetAll();
        public abstract Book GetByISBN(string isbn);
        public abstract Book Create(Book newBook);
        public abstract void DeleteByISBN(string isbn);
        public abstract void Update(string isbn, Book book);
        public abstract void GetByAuthor(string author);
        public abstract Book Download();
        public abstract void UpdatePublisher(string isbn, int publisherId);
    }
}
