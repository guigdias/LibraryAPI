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
}
