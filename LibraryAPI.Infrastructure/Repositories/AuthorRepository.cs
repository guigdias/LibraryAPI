using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Infrastructure.Configurations;
using MongoDB.Driver;

namespace LibraryAPI.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly IMongoCollection<Author> _collection;
    public AuthorRepository(MongoDbContext context)
    {
        _collection = context.Database.GetCollection<Author>("Auhtors");
    }

    public async Task CreateAuthor(Author author)
    {
        await _collection.InsertOneAsync(author);
    }
    public async Task<List<Author>> GetAllAuthors()
    {
        return await _collection.Find(a => a.AuthorID != null)
       .ToListAsync();
    }

    public async Task<Author?> GetAuthorById(string id)
    {
        return await _collection.Find(author => author.AuthorID == id).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        var result = await _collection.ReplaceOneAsync(a => a.AuthorID == author.AuthorID, author);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAuthor(string id)
    {
        var result = await _collection.DeleteOneAsync(author => author.AuthorID == id);
        return result.DeletedCount > 0;
    }
}