using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;

namespace LibraryAPI.Domain.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<Book> CreateBook(string title, string authorID, int copiesAvailable)
    {
        var book = Book.CreateBook(title, authorID, copiesAvailable);
        await _bookRepository.CreateBook(book);
        return book;
    }
    public async Task GetAllBooks() => await _bookRepository.GetAllBooks();
}
