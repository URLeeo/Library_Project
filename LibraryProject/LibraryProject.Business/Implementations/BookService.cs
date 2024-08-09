using LibraryProject.Business.Abstracts;
using LibraryProject.Business.Exceptions;
using LibraryProject.Core.Entities;

namespace LibraryProject.Business.Implementations;

public class BookService : IBookService
{
    List<Book> _books;
    private AuthorService _authorService;
    private GenreService _genreService;
    public BookService(AuthorService authorService, GenreService genreService)
    {
        _books = new List<Book>();
        _authorService = authorService;
        _genreService = genreService;
    }
    public void Create(string name, int publicationdate, int count,int genreId, int authorId)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Name can't be null");
        }
        _authorService.GetById(authorId);
        _genreService.GetById(genreId);
        Book book = new(name,count,genreId,authorId,publicationdate);
        _books.Add(book);
    }

    public void Delete(int id)
    {
        var book = _books.Find(b => b.Id == id);
        if (book is null)
        {
            throw new NotFoundException("This book doesn't exist");
        }
        _books.Remove(book);
    }

    public List<Book> GetAll()
    {
        return _books;
    }

    public List<Book> GetByAuthor(int authorId)
    {
        _authorService.GetById(authorId);
        return _books.FindAll(b => b.AuthorId == authorId);
    }

    public List<Book> GetByGenre(int genreId)
    {
        _genreService.GetById(genreId);
        return _books.FindAll(b => b.GenreId == genreId);
    }

    public Book GetById(int id)
    {
        var book = _books.Find(b =>b.Id == id);
        if (book is null)
        {
            throw new NotFoundException("This book doesn't exist");
        }
        return book;
    }

    public List<Book> SearchByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Thing that you are looking for cannot be empty");
        }
        return _books.FindAll(b =>b.Name == name);
    }

    public void Update(int id, Book updatingBook)
    {
        Book book = _books.Find(b => b.Id == id);
        if(book is null)
        {
            throw new Exception("Thing that you are looking for doesn't exist");
        }
        book.Name = updatingBook.Name;
        book.AuthorId = updatingBook.AuthorId;
        book.GenreId = updatingBook.GenreId;
        book.PublicationDate = updatingBook.PublicationDate;
    }
}
