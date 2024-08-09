using LibraryProject.Core.Entities;

namespace LibraryProject.Business.Abstracts;

public interface IBookService
{
    void Create(string name, int publicationdate, int count, int genreId, int authorId);
    void Update(int id, Book updatingBook);
    void Delete(int id);
    List<Book> GetAll();
    Book GetById(int id);
    List<Book> GetByGenre(int genreId);
    List<Book> GetByAuthor(int authorId);
    List<Book> SearchByName(string name);
}
