using LibraryProject.Core.Interfaces;

namespace LibraryProject.Core.Entities;

public class Book : IEntity<Guid>
{
    public Guid Id { get; }
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
        Id = new Guid();
    }
    public override string ToString()
    {
        return $"Id {Id} | BookTitle {Name} | Genre {GenreId} | PublicationDate{PublicationDate}";
    }
}


