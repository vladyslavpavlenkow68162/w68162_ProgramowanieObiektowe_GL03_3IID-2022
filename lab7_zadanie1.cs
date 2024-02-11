using Microsoft.AspNetCore.Mvc;
using lab5_zadanie3;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public Book Get(int id)
        {
            return _bookRepository.Get(id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }


        [HttpGet]
        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        [HttpPost]
        public void Create(Book input)
        {
            _bookRepository.Create(input);
        }

        [HttpPut]
        public void Update(Book input)
        {
            _bookRepository.Update(input);
        }

        [HttpGet]
        public List<Book> GetBooksByAuthor(string autor)
        {
            return _bookRepository.GetBooksByAuthor(autor);
        }

        [HttpGet]
        public List<Book> GetBooksByYear(int year)
        {
            return _bookRepository.GetBooksByYear(year);
        }

    }

[ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        [HttpPost]
        public void BorrowBook( int id, int bookId)
        {
            _personRepository.BorrowBook(id, bookId);
        }

        [HttpGet]
        public List<Book> GetBorrowedBook(int id)
        {
            return _personRepository.GetBorrowedBooks(id);
        }

        [HttpGet]
        public Person Get(int id)
        {
            return _personRepository.Get(id);
        }

        [HttpPost]
        public void Create(Person person)
        {
            _personRepository.Create(person);
        }

        [HttpPut]
        public void Update(Person person)
        {
            _personRepository.Update(person);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }
    }

     public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }


    class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

        }
    }