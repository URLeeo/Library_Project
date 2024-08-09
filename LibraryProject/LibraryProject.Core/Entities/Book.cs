using LibraryProject.Core.Interfaces;

namespace LibraryProject.Core.Entities;

public class Book : IEntity<int>
{
    public int Id { get; set; }
    private static int _id;
    public string Name { get; set; } = null!;
    public int? PublicationDate { get; set; }
    public int Count { get; set; }
    public int? AuthorId { get; set; }
    public int? GenreId { get; set; }

    public Book(string name, int count, int genreId, int authorId, int? publicationdate = null)
    {
        Name = name;
        PublicationDate = publicationdate;
        Count = count;
        AuthorId = authorId;
        GenreId = genreId;
        Id = _id++;
    }
    public override string ToString()
    {
        return $"Id {Id} | BookTitle {Name} | Genre {GenreId} | PublicationDate{PublicationDate}";
    }
}


