// See https://aka.ms/new-console-template for more information
using LibraryProject.Business.Abstracts;
using LibraryProject.Business.Exceptions;
using LibraryProject.Business.Implementations;
using LibraryProject.Core.Entities;
using System.Linq;
Console.WriteLine("Library Project Is Started : ");
GenreService genreService = new();
AuthorService authorService = new();
LoanedBooksService loanedBooksService = new();
BookService bookService = new(authorService, genreService);
LibraryService library = new();
bool continueProgram = true;
while (continueProgram)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\nPlease choose an option:");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("1. Create Author");
    Console.WriteLine("2. Update Author");
    Console.WriteLine("3. Delete Author");
    Console.WriteLine("4. Show All Authors");
    Console.WriteLine("5. Create Genre");
    Console.WriteLine("6. Update Genre");
    Console.WriteLine("7. Delete Genre");
    Console.WriteLine("8. Show All Genres");
    Console.WriteLine("9. Create Book");
    Console.WriteLine("10. Update Book");
    Console.WriteLine("11. Delete Book");
    Console.WriteLine("12. Show All Books");
    Console.WriteLine("13. Show Books by Author");
    Console.WriteLine("14. Loan Book");
    Console.WriteLine("15. Return Book");
    Console.WriteLine("16. Show Loaned Books");
    Console.WriteLine("17. Show Overdue Loans");
    Console.WriteLine("18. Show Books by Genre");
    Console.WriteLine("0. Exit");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Yellow;
    int choice;
    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid Input... Please Try To Use a Valid Number");
        Console.ResetColor();
        continue;
    }
    Console.ResetColor();

    try
    {
        switch (choice)
        {
            case 1:
                Console.Write("Enter Author Name : ");
                string authorName = Console.ReadLine();
                authorService.Create(authorName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author created successfully.");
                break;

            case 2:
                Console.Write("Enter Author ID: ");
                int authorId = int.Parse(Console.ReadLine());
                Console.Write("Enter new Author name: ");
                authorName = Console.ReadLine();
                authorService.Update(authorId, authorName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author updated successfully.");
                break;

            case 3:
                Console.Write("Enter Author ID: ");
                authorId = int.Parse(Console.ReadLine());
                authorService.Delete(authorId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author deleted successfully.");
                break;

            case 4:
                Console.WriteLine("All Authors:");
                var authors = authorService.GetAll();
                foreach (var author in authors)
                {
                    Console.WriteLine($"ID: {author.Id}, Name: {author.Name}");
                }
                break;

            case 5:
                Console.Write("Enter Genre name: ");
                string genreName = Console.ReadLine();
                genreService.Create(genreName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Genre created successfully.");
                break;

            case 6:
                Console.Write("Enter Genre ID: ");
                int genreId = int.Parse(Console.ReadLine());
                Console.Write("Enter new Genre name: ");
                genreName = Console.ReadLine();
                genreService.Update(genreId, genreName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Genre updated successfully.");
                break;

            case 7:
                Console.Write("Enter Genre ID: ");
                genreId = int.Parse(Console.ReadLine());
                genreService.Delete(genreId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Genre deleted successfully.");
                break;

            case 8:
                Console.WriteLine("All Genres:");
                var genres = genreService.GetAll();
                foreach (var genre in genres)
                {
                    Console.WriteLine($"ID: {genre.Id}, Name: {genre.Name}");
                }
                break;

            case 9:
                int author_count = authorService.GetAll().Count;
                if (author_count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("First you have to create Author");
                    Console.ResetColor();
                    goto case 1;
                }
                int genre_count = genreService.GetAll().Count;
                if (genre_count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("First you have to create Genre");
                    Console.ResetColor();
                    goto case 5;
                }
                Console.Write("Enter Book name: ");
                string bookName = Console.ReadLine();
                Console.Write("Enter Book Publication Date: ");
                int publicationDate = int.Parse(Console.ReadLine());
                Console.Write("Enter Book Count: ");
                int bookCount = int.Parse(Console.ReadLine());
                Console.Write("Enter Genre ID: ");
                genreId = int.Parse(Console.ReadLine());
                Console.Write("Enter Author ID: ");
                authorId = int.Parse(Console.ReadLine());
                bookService.Create(bookName, publicationDate, bookCount, genreId, authorId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book created successfully.");
                break;

            case 10:
                Console.Write("Enter Book ID: ");
                int bookId = int.Parse(Console.ReadLine());
                Console.Write("Enter new Book name: ");
                bookName = Console.ReadLine();
                Console.Write("Enter new Book Publication Date: ");
                publicationDate = int.Parse(Console.ReadLine());
                Console.Write("Enter new Book Count: ");
                bookCount = int.Parse(Console.ReadLine());
                Console.Write("Enter new Genre ID: ");
                genreId = int.Parse(Console.ReadLine());
                Console.Write("Enter new Author ID: ");
                authorId = int.Parse(Console.ReadLine());
                var updatingBook = new Book(bookName, publicationDate, bookCount, genreId, authorId);
                bookService.Update(bookId, updatingBook);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book updated successfully.");
                break;

            case 11:
                Console.Write("Enter Book ID: ");
                bookId = int.Parse(Console.ReadLine());
                bookService.Delete(bookId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book deleted successfully.");
                break;

            case 12:
                Console.WriteLine("All Books:");
                var books = bookService.GetAll();
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Publication Date: {book.PublicationDate}, GenreID: {book.GenreId}, AuthorID: {book.AuthorId}, BookCount: {book.Count}");
                }
                break;

            case 13:
                Console.Write("Enter Author ID: ");
                authorId = int.Parse(Console.ReadLine());
                var booksByAuthor = bookService.GetByAuthor(authorId);
                Console.WriteLine($"Books in Author ID {authorId}:");
                foreach (var book in booksByAuthor)
                {
                    Console.WriteLine($"ID: {book.Id}, Name: {book.Name}");
                }
                break;

            case 14:
                Console.Write("Enter Genre ID: ");
                genreId = int.Parse(Console.ReadLine());
                var booksByGenre = bookService.GetByGenre(genreId);
                Console.WriteLine($"Books with Genre ID {genreId}:");
                foreach (var book in booksByGenre)
                {
                    Console.WriteLine($"ID: {book.Id}, Name: {book.Name}");
                }
                break;

            case 15:
                LoanBook();
                break;

            case 16:
                ReturnBook();
                break;


            case 17:
                ViewLoanedBooks();
                break;

            case 18:
                ViewOverdueLoans();
                break;
            case 0:
                continueProgram = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Exiting the program...");
                break;
        }
    }
    catch (NotFoundException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (AlreadyExistsException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
    finally
    {
        Console.ResetColor();
    }
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}

void ViewOverdueLoans()
{
    try
    {
        library.ViewOverdueLoans();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"An error occurred while viewing overdue loans: {ex.Message}");
        Console.ResetColor();
    }
}

void ReturnBook()
{
    Console.Write("Enter the ID of the book to return: ");
    int bookId;
    while (!int.TryParse(Console.ReadLine(), out bookId))
    {
        Console.Write("Invalid ID. Please enter a valid book ID: ");
    }

    try
    {
        library.ReturnBook(bookId);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Book returned successfully.");
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"An error occurred while returning the book: {ex.Message}");
        Console.ResetColor();
    }
}

void LoanBook()
{
    Console.Write("Enter the ID of the book to loan: ");
    int bookId;
    while (!int.TryParse(Console.ReadLine(), out bookId))
    {
        Console.Write("Invalid ID. Please enter a valid book ID: ");
    }

    Console.Write("Enter the loan date (yyyy-MM-dd): ");
    DateTime loanDate;
    while (!DateTime.TryParse(Console.ReadLine(), out loanDate))
    {
        Console.Write("Invalid date. Please enter a valid date (yyyy-MM-dd): ");
    }

    try
    {
        library.LoanBook(bookId, loanDate);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Book loaned successfully.");
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"An error occurred while loaning the book: {ex.Message}");
        Console.ResetColor();
    }
}

void ViewLoanedBooks()
{
    try
    {
        var loanedBooks = library.GetLoanedBooks();
        if (loanedBooks.Any())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Currently loaned books:");
            foreach (var loan in loanedBooks)
            {
                var book = DataAccess.DataContext.Books.FirstOrDefault(b => b.Id == loan.Id);
                if (book != null)
                {
                    Console.WriteLine($"Book ID: {book.Id}, Title: {book.Name}, Loan Date: {loan.LoanDate}, Due Date: {loan.DueDate}");
                }
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No books are currently loaned.");
        }
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"An error occurred while viewing loaned books: {ex.Message}");
        Console.ResetColor();
    }
}