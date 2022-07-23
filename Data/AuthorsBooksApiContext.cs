using AuthorsAndBooksAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorsAndBooksAPI.Data
{
    public class AuthorsBooksApiContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public AuthorsBooksApiContext(DbContextOptions<AuthorsBooksApiContext> options)
            : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=AuthorBookDb.db");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasData(
                new Author()
                {
                    Id = 1,
                    FirstName = "Ikenna",
                    LastName = "Ogbonna",
                    Age = "33",
                    Email = "ikenna@gmail.com"
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Nelson",
                    LastName = "Okoro",
                    Age = "29",
                    Email = "nelson@yahoo.com"
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "Dozie",
                    LastName = "Osigwe",
                    Age = "32",
                    Email = "osigwe@gmail.com"
                },
                new Author()
                {
                    Id = 4,
                    FirstName = "Akinkumi",
                    LastName = "Ogbonna",
                    Age = "23",
                    Email = "akinkumi@gmail.com"
                }
                );
            modelBuilder.Entity<Book>()
                .HasData(
                new Book()
                {
                    Id = 1,
                    Title = "Things Fall Apart",
                    Description = " The depth of our expertise is defined by a carefully selected pool of consultants who ensure that we continue to be the firm of choice to our growing list of discerning clienteles.",
                    ProductionYear = "1990",
                    AuthorId = 1
                },
                new Book()
                {
                    Id = 2,
                    Title = "The beautiful ones are yet to be born",
                    Description = "Jobrole Consulting Limited is a Talent Management Company that offers innovative talent and business solutions to drive performance and acceleration. Our focus is to develop and implement new ideas and strategies for Organizations to enhance their business processes and growth.",
                    ProductionYear = "1993",
                    AuthorId = 2
                },
                new Book()
                {
                    Id = 3,
                    Title = "The burning man",
                    Description = "Our focus is to develop and implement new ideas and strategies for Organizations to enhance their business processes and growth.",
                    ProductionYear = "2000",
                    AuthorId = 3
                },
                new Book()
                { 
                    Id = 4,
                    Title = "The man from another planet",
                    Description = "The man from another planet is a book written by Akinkumi a renowned writter is about a man that came from another planet, exploits on earth and his love life.",
                    ProductionYear = "2001",
                    AuthorId = 4
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
