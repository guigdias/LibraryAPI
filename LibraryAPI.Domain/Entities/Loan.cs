namespace LibraryApi.Domain.Entities;

public class Loan
{
    public string? LoanID { get; set; }
    public string? BookID { get; set; }
    public DateTime LoanDate { get; set; }
    public int LoanDurationDays { get; set; }
    public double LoanPrice { get; set; } = 5.00; // Default loan price

    public Loan(string bookID, int loanDurationDays, double loanPrice)
    {
        BookID = bookID;
        LoanDurationDays = loanDurationDays;
        loanPrice = CalculateTotalPrice(loanDurationDays);
        LoanPrice = loanPrice;
        LoanDate = DateTime.Now; // Set loan date to now when creating a new loan
    }

    public double CalculateTotalPrice(int loanDurationDays)
    {
        return LoanPrice * loanDurationDays;
    }   
}