using LibraryProject.Business.Abstracts;
using LibraryProject.Business.Exceptions;
using LibraryProject.Core.Entities;
using Microsoft.VisualBasic;

namespace LibraryProject.Business.Implementations;

public class AuthorService : IAuthorService
{
    private List<Author> _authors;
    public AuthorService()
    {
        _authors = new List<Author>();
    }
    public void Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name can't be empty");
        }
        var check_author = _authors.Find(a => a.Name == name);
        if (check_author is not null)
        {
            throw new AlreadyExistsException("Author with this name is already exist");
        }
        Author author = new Author(name);
        _authors.Add(author);
    }

    public void Delete(int id)
    {
        var author = _authors.Find(a => a.Id == id);
        if (author is null)
        {
            throw new NotFoundException("There is no any author with this Name or Id");
        }
        _authors.Remove(author);
    }

    public List<Author> GetAll()
    {
        return _authors;
    }

    public Author GetById(int id)
    {
        var author = _authors.Find(d => d.Id == id);
        if (author is null)
        {
            throw new NotFoundException("There is no any author with this Name or Id");
        }
        return author;
    }

    public List<Author> SearchByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        return _authors.FindAll(a => a.Name.Contains(name.Trim()));
    }

    public void Update(int id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var author = _authors.Find(a => a.Id == id);
        if (author is null)
        {
            throw new NotFoundException("There is no any author with this Name or Id");
        }
        var check_author = _authors.Find(a => a.Name == name);
        if (check_author is not null)
        {
            throw new AlreadyExistsException("Author with this name is already exist");
        }
        author.Name = name;
    }
}
