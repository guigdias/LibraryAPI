using LibraryApi.Domain.Entities;
namespace LibraryAPI.Domain.Interfaces;
public interface IBookRepository
{
    Task CreateBook(Book book);
    Task <List<Book>> GetAllBooks();
    Task<Book?> GetBookById(string id);
    Task <bool> UpdateBook(string id, Book book);
    Task <bool> DeleteBook(string id);
}