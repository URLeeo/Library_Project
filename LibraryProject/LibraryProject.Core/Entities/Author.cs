using LibraryProject.Core.Interfaces;

namespace LibraryProject.Core.Entities;

public class Author : IEntity<int>
{
    public int Id { get; }
    public string Name { get; set; } = null!;

    private static int _id;
    public Author(string name)
    {
        Id = _id++;
        Name = name;
    }
    public override string ToString()
    {
        return $"Id {Id} | Name {Name}";
    }
}
