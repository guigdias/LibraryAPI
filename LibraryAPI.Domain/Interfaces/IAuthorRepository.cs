using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Domain.Interfaces;
    public interface IAuthorRepository
    {
        Task CreateAuthor(Author author);
        Task <List<Author>> GetAllAuthors();
        Task <Author?> GetAuthorById(string id);
        Task <bool> UpdateAuthor(string id, Author author);
        Task <bool> DeleteAuthor(string id);
    }
