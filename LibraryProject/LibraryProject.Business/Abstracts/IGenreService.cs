using LibraryProject.Core.Entities;

namespace LibraryProject.Business.Abstracts;

public interface IGenreService
{
    void Create(string name);
    void Update(int id, string name);
    void Delete(int id);
    List<Genre> GetAll();
    Genre GetById(int id);
    List<Genre> SearchByName(string name);
}
