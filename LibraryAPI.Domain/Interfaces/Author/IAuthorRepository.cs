using LibraryApi.Domain.Entities;

namespace LibraryApi.Domain.Interfaces;
    public interface IAuthorRepository
    {
        Task <Author> CreateAuthor(Author author);
        Task <List<Author>> GetAllAuthors();
        Task <Author?> GetAuthorById(string id);
        Task <bool> UpdateAuthor(Author author);
        Task <bool> DeleteAuthor(string id);
    }
