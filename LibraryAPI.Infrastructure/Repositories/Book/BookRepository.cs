using LibraryApi.Domain.Entities;
using LibraryApi.Domain.Interfaces;
using MongoDB.Driver;


namespace LibraryAPI.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book>? _books;

    public async Task CreateBook(Book book)
    {
        await _books.InsertOneAsync(book);
    }
    public async Task<List<Book>> GetAllBooks()
    {
        return await _books.Find(book => true).ToListAsync();
    }

    public async Task<Book?> GetBookById(string id)
    {
        return await _books.Find(book => book.BookID == id).FirstOrDefaultAsync();
    }
    
    public async Task UpdateBook(string id, Book book)
    {
        await _books.ReplaceOneAsync(b => b.BookID == id, book);
    }

    public async Task DeleteBook(string id)
    {
        await _books.DeleteOneAsync(book => book.BookID == id);
    }

    Task<bool> IBookRepository.UpdateBook(string id, Book book)
    {
        throw new NotImplementedException();
    }

    Task<bool> IBookRepository.DeleteBook(string id)
    {
        throw new NotImplementedException();
    }
}