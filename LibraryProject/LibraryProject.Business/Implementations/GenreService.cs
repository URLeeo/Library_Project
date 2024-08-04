using LibraryProject.Business.Abstracts;
using LibraryProject.Business.Exceptions;
using LibraryProject.Core.Entities;

namespace LibraryProject.Business.Implementations;

public class GenreService : IGenreService
{
    private List<Genre> _genres;
    public GenreService()
    {
        _genres = new List<Genre>();
    }
    public void Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Name can't be empty");
        }
        bool check_genre = _genres.Any(g => g.Name == name);
        if (check_genre)
        {
            throw new AlreadyExistsException("Genre with this name is already exist");
        }
        Genre genre = new Genre(name);
        _genres.Add(genre);
    }

    public void Delete(int id)
    {
        var genre = _genres.Find(g => g.Id == id);
        if (genre is null)
        {
            throw new NotFoundException("There is no any genre with this Name or Id");
        }
        _genres.Remove(genre);
    }

    public List<Genre> GetAll()
    {
        return _genres;
    }

    public Genre GetById(int id)
    {
        var genre = _genres.Find(g => g.Id == id);
        if (genre is null)
        {
            throw new NotFoundException("There is no any genre with this Name or Id");
        }
        return genre;
    }

    public List<Genre> SearchByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        return _genres.FindAll(g => g.Name.Contains(name.Trim()));
    }

    public void Update(int id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var genre = _genres.Find(g => g.Id == id);
        if (genre is null)
        {
            throw new NotFoundException("There is no any genre with this Name or Id");
        }
        var check_genre = _genres.Find(g => g.Name == name);
        if (check_genre is not null)
        {
            throw new AlreadyExistsException("Genre with this name is already exist");
        }
        genre.Name = name;
    }
}
