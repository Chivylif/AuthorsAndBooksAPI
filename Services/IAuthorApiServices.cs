using AuthorsAndBooksAPI.Entities;
using AuthorsAndBooksAPI.Models;

namespace AuthorsAndBooksAPI.Services
{
    public interface IAuthorApiServices
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthor(int authorId);

        bool AuthorExists(int authorId);
        IEnumerable<Book> GetAuthorBooks(int authorId);
        Book GetASingleBookForAuthor(int authorId, int bookId);
        void CreateAuthor(Author author);
        bool DeleteAuthor(int authorId);
        bool UpdateAuthor(int authorId, UpdateAuthorDto author);
        void PartialUpdateAuthor(Author author);
    }
}
