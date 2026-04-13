
namespace LibraryAPI.Domain.Entities;

public class Author
{
    public string? AuthorID { get; set; }
    public string? Name { get; set; }
    public string? Biography { get; set; }
    public int BooksWritten { get; set; }

    public Author(string name, string biography)
    {
        Name = name;
        Biography = biography;
        BooksWritten = 0;
    }

    public static Author CreateAuthor(string name, string biography)
    {
        return new Author(name, biography);
    }
}
