using LibraryProject.Core.Interfaces;

namespace LibraryProject.Core.Entities;

public class Genre : IEntity<int>
{
    public int Id { get; }
    public string Name { get; set; } = null!;
    private static int _id;
    public Genre(string name)
    {
        Id = _id++;
        Name = name;
    }
    public override string ToString()
    {
        return $"Id {Id} | Name {Name}";
    }
}