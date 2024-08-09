using LibraryProject.Core.Entities;

namespace LibraryProject.Business.Abstracts;

public interface ILibraryManagementService
{
    void LoanBook(int id, DateTime loanDate);
    void ReturnBook(int id);
    IEnumerable<Loan> GetOverdueLoans();
    void DisplayLoanDetails();
    IEnumerable<Loan> GetLoanedBooks();
}
