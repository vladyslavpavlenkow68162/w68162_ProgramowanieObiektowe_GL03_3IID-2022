public interface IPersonRepository<T, TEntity> : IBaseRepository<T, TEntity> where T : IEntity
{
    void PersonMethod();
    IEnumerable<BookEntity> GetBooksByPerson(int personId);
    void AddBookToPerson(int personId, BookEntity book);
}

public interface IBookRepository<T, TEntity> : IBaseRepository<T, TEntity> where T : IEntity
{
    void BookMethod();
    IEnumerable<BookEntity> GetBooksByAuthor(string author);
    IEnumerable<BookEntity> GetBooksPublishedInYear(int year);
}

public class PersonRepository : IPersonRepository<PersonEntity, PersonEntity>
{
    private readonly List<PersonEntity> _persons = new List<PersonEntity>();

    public void Create(PersonEntity entity)
    {
        _persons.Add(entity);
    }


    public IEnumerable<BookEntity> GetBooksByPerson(int personId)
    {
        var person = _persons.Find(p => p.ID == personId);
        return person?.Books.Select(bookTitle => new BookEntity { Title = bookTitle }).ToList() ?? new List<BookEntity>();
    }

    public void AddBookToPerson(int personId, BookEntity book)
    {
        var person = _persons.Find(p => p.ID == personId);
        if (person != null)
        {
            if (person.Books == null)
                person.Books = new List<string>();
            person.Books.Add(book.Title);
        }
    }

    public void PersonMethod()
    {
        Console.WriteLine("Person-specific method executed.");
    }
}

public class BookRepository : IBookRepository<BookEntity, BookEntity>
{
    private readonly List<BookEntity> _books = new List<BookEntity>();

    public void Create(BookEntity entity)
    {
        _books.Add(entity);
    }


    public IEnumerable<BookEntity> GetBooksByAuthor(string author)
    {
        return _books.Where(book => book.Author == author).ToList();
    }

    public IEnumerable<BookEntity> GetBooksPublishedInYear(int year)
    {
        return _books.Where(book => book.Year == year).ToList();
    }

    public void BookMethod()
    {
        Console.WriteLine("Book-specific method executed.");
    }
}
