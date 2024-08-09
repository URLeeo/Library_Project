using LibraryProject.Core.Interfaces;

namespace LibraryProject.Core.Entities;

public class Loan : IEntity<int>
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Loan(int id, string userId, DateTime loanDate, DateTime dueDate)
    {
        Id = id;
        UserId = userId;
        LoanDate = loanDate;
        DueDate = dueDate;
        ReturnDate = null;
    }
}
