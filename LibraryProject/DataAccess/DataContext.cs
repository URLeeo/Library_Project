using LibraryProject.Core.Entities;

namespace DataAccess;

public static class DataContext
{
    public static List<Author> Authors { get; set; }
    public static List<Book> Books { get; set; }
    public static List<Genre> Genres { get; set; }
    public static List<Loan> Loans { get; set; }

    static DataContext()
    {
        Authors = new List<Author>();
        Books = new List<Book>();
        Genres = new List<Genre>();
        Loans = new List<Loan>();
    }
}