using LibraryProject.Core.Entities;

namespace LibraryProject.Business.Abstracts;

public interface IAuthorService
{
    void Create(string name);
    void Update(int id, string name);
    void Delete(int id);
    List<Author> GetAll();
    Author GetById(int id);
    List<Author> SearchByName(string name);
}
