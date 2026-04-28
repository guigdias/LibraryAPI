using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Infrastructure.Configurations;
using MongoDB.Driver;


namespace LibraryAPI.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _collection;

    public BookRepository(MongoDbContext context)
    {
        _collection = context.Database.GetCollection<Book>("Books");
    }
    public async Task CreateBook(Book book)
    {
        await _collection.InsertOneAsync(book);
    }
    public async Task<List<Book>> GetAllBooks()
    {
        return await _collection.Find(book => true).ToListAsync();
    }

    public async Task<Book?> GetBookById(string id)
    {
        return await _collection.Find(book => book.BookID == id).FirstOrDefaultAsync();
    }
    
    public async Task<bool> UpdateBook(Book book)
    {
        var result = await _collection.ReplaceOneAsync(b => b.BookID == book.BookID, book);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteBook(string id)
    {
       var result = await _collection.DeleteOneAsync(book => book.BookID == id);
       return result.DeletedCount > 0;
    }
}