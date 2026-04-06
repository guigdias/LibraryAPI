namespace LibraryApi.Domain.Entities;

public class Author
{
    public string? AuthorID { get; set; }
    public string? Name { get; set; }
    public string? Biography { get; set; }
    public int BooksWritten { get; set; }
}