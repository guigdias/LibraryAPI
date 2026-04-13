namespace LibraryAPI.Domain.Entities;

public class Book
{
    public string? BookID { get; set; }
    public string? Title { get; set; }
    public string? AuthorID { get; set; }
    public int CopiesAvailable { get; set; }
    public int LoanCount { get; set; } = 0;
}