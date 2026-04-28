namespace LibraryAPI.Domain.Entities;

public class Book
{
    public string? BookID { get; set; }
    public string? Title { get; set; }
    public string? AuthorID { get; set; }
    public int CopiesAvailable { get; set; }
    public int LoanCount { get; set; }

    public Book(string? title, string? authorID, int copiesAvailable)
    {
        Title = title;
        AuthorID = authorID;
        CopiesAvailable = copiesAvailable;
        LoanCount = 0;
    }

    public static Book CreateBook(string? title, string? authorID, int copiesAvailable)
    {
        return new Book(title, authorID, copiesAvailable);
    }
}