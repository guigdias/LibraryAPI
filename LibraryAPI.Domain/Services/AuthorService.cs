using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Services;

public class AuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<Author> CreateAuthor(string name, string biography)
    {
        var author = Author.CreateAuthor(name, biography);
        await _authorRepository.CreateAuthor(author);
        return author;
    }
    public async Task GetAllAuthors() => await _authorRepository.GetAllAuthors();

    public async Task<Author> GetAuthorById(string id)
    {
        var author = await _authorRepository.GetAuthorById(id);
        if (author == null)
            throw new Exception("Author not found");

        return author;
    }
    public async Task<Author> UpdateAuthor(string id, string name, string biography)
    {
        var author = await GetAuthorById(id);
        if (author == null)
            throw new Exception("Author not found");

        if (string.IsNullOrEmpty(name))
            throw new Exception("Name cannot be null");

        if (string.IsNullOrEmpty(biography))
            throw new Exception("Biography cannot be null");

        author.UpdateAuthor(name, biography);

        await _authorRepository.UpdateAuthor(author);

        return author;
    }
    public async Task<bool> DeleteAuthor(string id)
    {
        return await _authorRepository.DeleteAuthor(id);
    }
}
