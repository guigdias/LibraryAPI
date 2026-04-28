namespace LibraryAPI.Api.DTOs;

public class BookRequest
{
    public string? Title { get; set; }
    public string? AuthorID { get; set; }
    public int CopiesAvailable { get; set; }
}
