using AuthorsAndBooksAPI.Data;
using AuthorsAndBooksAPI.Entities;
using AuthorsAndBooksAPI.Models;
using AutoMapper;

namespace AuthorsAndBooksAPI.Services
{
    public class AuthorApiServices : IAuthorApiServices
    {
        private readonly AuthorsBooksApiContext _context;
        private readonly IMapper _mapper;

        public AuthorApiServices(AuthorsBooksApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Author GetAuthor(int authorId)
        {
            var author = _context.Authors.Where(x => x.Id == authorId).FirstOrDefault();

            return author;
        }

        public bool AuthorExists(int authorId)
        {
            return _context.Authors.Any(a => a.Id == authorId);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList<Author>();
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAuthorBooks(int authorId)
        {
            var books = _context.Books.Where(x => x.AuthorId == authorId).ToList<Book>();
            return books;
        }

        public Book GetASingleBookForAuthor(int authorId, int bookId)
        {
            var books = _context.Books.Where(x => x.AuthorId == authorId).ToList();
            var book = books.Where(x => x.Id == bookId).FirstOrDefault();

            return book;

        }

        public void CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public bool DeleteAuthor(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (author == null)
                return false;

            _context.Authors.Remove(author);
            _context.SaveChanges();

            var authorAfterDeletion = _context.Authors.Where(X => X.Id == author.Id).FirstOrDefault();
            if (authorAfterDeletion == null)
                return false;

            return true;
        }

        public bool UpdateAuthor(int authorId, UpdateAuthorDto author)
        {
            var authorFromDb = _context.Authors.FirstOrDefault(x => x.Id == authorId);
            if (authorFromDb == null)
                return false;

            _mapper.Map(author, authorFromDb);

            _context.Authors.Update(authorFromDb);
            _context.SaveChanges();

            return true;
        }

        public void PartialUpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
