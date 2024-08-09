using LibraryProject.Business.Abstracts;
using LibraryProject.Business.Exceptions;
using LibraryProject.Core.Entities;
namespace LibraryProject.Business.Implementations;

public class LibraryService : ILibraryManagementService
{
    private List<Loan> Loans;
    private List<Book> Books;
    public void LoanBook(int id, DateTime loanDate)
    {
        if (DataAccess.DataContext.Books == null)
        {
            throw new InvalidOperationException("Books collection is not initialized.");
        }

        Book book = DataAccess.DataContext.Books.Find(b => b.Id == id);
        if (book == null)
        {
            throw new NotFoundException($"Book with ID {id} not found.");
        }

        if (book.Count <= 0)
        {
            throw new Exception("Book is out of stock.");
        }

        var loan = new Loan(id, "defaultUser", loanDate, loanDate.AddDays(7));

        if (DataAccess.DataContext.Loans == null)
        {
            throw new InvalidOperationException("Loans collection is not initialized.");
        }

        DataAccess.DataContext.Loans.Add(loan);

        book.Count--;

        Console.WriteLine($"Book loaned. Return date: {loanDate.AddDays(7).ToShortDateString()}");
    }

    public void ReturnBook(int id)
    {
        var loan = DataAccess.DataContext.Loans.FirstOrDefault(l => l.Id == id && l.ReturnDate == null);
        if (loan == null)
        {
            throw new NotFoundException("Loan not found.");
        }

        loan.ReturnDate = DateTime.Now;
        var book = DataAccess.DataContext.Books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            book.Count++;
        }
        Console.WriteLine("Book returned.");
    }

    public IEnumerable<Loan> GetOverdueLoans()
    {
        return DataAccess.DataContext.Loans.Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now);
    }

    public void DisplayLoanDetails()
    {
        foreach (var loan in DataAccess.DataContext.Loans)
        {
            Console.WriteLine($"Book ID: {loan.Id}, User ID: {loan.UserId}, Loan Date: {loan.LoanDate}, Due Date: {loan.DueDate}, Return Date: {loan.ReturnDate}");
        }
    }

    public void ViewOverdueLoans()
    {
        var overdueLoans = GetOverdueLoans();
        if (overdueLoans.Any())
        {
            foreach (var loan in overdueLoans)
            {
                Console.WriteLine($"Book ID: {loan.Id}, User ID: {loan.UserId}, Loan Date: {loan.LoanDate}, Due Date: {loan.DueDate}");
            }
        }
        else
        {
            Console.WriteLine("No overdue loans.");
        }
    }
    public IEnumerable<Loan> GetLoanedBooks()
    {
        // Return loans where the book is still on loan (i.e., return date is null)
        return DataAccess.DataContext.Loans.Where(l => l.ReturnDate == null);
    }
}
