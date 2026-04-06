using LibraryApi.Domain.Entities;

namespace LibraryApi.Domain.Interfaces;

public interface ILoanRepository
{
    Task CreateLoan(Loan loan);
    Task<List<Loan>> GetAllLoans();
    Task<Loan?> GetLoanById(string id);
    Task<bool> UpdateLoan(Loan loan);
    Task<bool> DeleteLoan(string id);
}