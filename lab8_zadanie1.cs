using System.Text.Json;
using lab5_zadanie3;

    public class FileBookRepository : IBookRepository
    {
        private readonly string filePath;
        private List<Book> books;

        public FileBookRepository(string filePath)
        {
            this.filePath = filePath;
            books = LoadDataFromJson();
        }

        public void Create(Book item)
        {
            books.Add(item);
            SaveDataToJson();
        }

        public void Update(Book item)
        {
            var existingBook = books.Find(book => book.Id == item.Id);

            if (existingBook != null)
            {
                existingBook.Tytuł = item.Tytuł;
                existingBook.Autor = item.Autor;
                existingBook.Rok = item.Rok;
                SaveDataToJson();
            }
        }

        public void Delete(int id)
        {
            var bookToRemove = books.Find(book => book.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                SaveDataToJson();
            }
        }

        public Book Get(int id)
        {
            return books.Find(book => book.Id == id);
        }

        public List<Book> GetAll()
        {
            return books;
        }

        private void SaveDataToJson()
        {
            string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private List<Book> LoadDataFromJson()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Book>>(json);
            }
            else
            {
                return new List<Book>();
            }
        }

        public List<Book> GetBooksByAuthor(string autor)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooksByYear(int rok)
        {
            throw new NotImplementedException();
        }
    }


    class Program
    {
        static void Main()
        {
            string filePath = "/Users/zhnk/repos/w67968_ProgramowanieObiektowe_GL01_3IID-2023-/labs/lab_8/books.json";
            var bookRepository = new FileBookRepository(filePath);

            
            bookRepository.Create(new Book { Id = 1, Tytuł = "Pride and Prejudice", Autor = "Jane Austen", Rok = 1813 });

            
            if (File.Exists(filePath))
            {
                string zawartosc = File.ReadAllText(filePath);
                Console.WriteLine("Zawartość pliku: " + zawartosc);
            }
            else
            {
                Console.WriteLine("Plik nie istnieje.");
            }

            
            var existingBook = bookRepository.Get(1);
            if (existingBook != null)
            {
                existingBook.Tytuł = "Nowa nazwa książki";
                bookRepository.Update(existingBook);
            }

           

            
            var allBooks = bookRepository.GetAll();
            foreach (var book in allBooks)
            {
                Console.WriteLine($"Title: {book.Tytuł}, Author: {book.Autor}, Year: {book.Rok}");
            }
        }
    }
