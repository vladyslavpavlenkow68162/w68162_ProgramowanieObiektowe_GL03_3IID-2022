using System;
using System.Collections.Generic;

public interface IEntity
{
    int ID { get; set; }
    string Date { get; set; }
}

public class BookEntity : IEntity
{
    public int ID { get; set; }
    public string Date { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
}

public class PersonEntity : IEntity
{
    public int ID { get; set; }
    public string Date { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public List<string> Books { get; set; }
}

public interface IBaseRepository<T, TEntity> where T : IEntity
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void Delete(int id);
}

public interface IBookRepository<T, TEntity> : IBaseRepository<T, TEntity> where T : IEntity
{
    void BookMethod();
}

public interface IPersonRepository<T, TEntity> : IBaseRepository<T, TEntity> where T : IEntity
{
    void PersonMethod();
}

public class BookRepository : IBookRepository<BookEntity, BookEntity>
{
    public void BookMethod()
    {
        Console.WriteLine("Book-specific method executed.");
    }

    public void Create(BookEntity entity)
    {
        
    }

    public void Update(BookEntity entity)
    {
       
    }

    public IEnumerable<BookEntity> GetAll()
    {
        
        return new List<BookEntity>();
    }

    public BookEntity Get(int id)
    {
        
        return new BookEntity();
    }

    public void Delete(int id)
    {
        
    }
}

public class PersonRepository : IPersonRepository<PersonEntity, PersonEntity>
{
    public void PersonMethod()
    {
        Console.WriteLine("Person-specific method executed.");
    }

    public void Create(PersonEntity entity)
    {
        
    }

    public void Update(PersonEntity entity)
    {
        
    }

    public IEnumerable<PersonEntity> GetAll()
    {
        
        return new List<PersonEntity>();
    }

    public PersonEntity Get(int id)
    {
        
        return new PersonEntity();
    }

    public void Delete(int id)
    {
        
    }
}

class Program
{
    static void Main(string[] args)
    {
        IBookRepository<BookEntity, BookEntity> bookRepository = new BookRepository();
        IPersonRepository<PersonEntity, PersonEntity> personRepository = new PersonRepository();

        BookEntity newBook = new BookEntity { ID = 1, Title = "Sample Book" };
        bookRepository.Create(newBook);

        IEnumerable<BookEntity> allBooks = bookRepository.GetAll();
        foreach (var book in allBooks)
        {
            Console.WriteLine($"Book ID: {book.ID}, Title: {book.Title}");
        }

        bookRepository.BookMethod();

        PersonEntity newPerson = new PersonEntity { ID = 1, Name = "John Doe" };
        personRepository.Create(newPerson);

        PersonEntity retrievedPerson = personRepository.Get(1);
        Console.WriteLine($"Retrieved Person: ID - {retrievedPerson.ID}, Name - {retrievedPerson.Name}");

        personRepository.PersonMethod();

        Console.ReadLine();
    }
}
