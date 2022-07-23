using AuthorsAndBooksAPI.Models;
using AuthorsAndBooksAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsAndBooksAPI.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IAuthorApiServices _service;
        private readonly IMapper _mapper;

        public BooksController(IAuthorApiServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAuthorBooks(int authorId)
        {
            if (!_service.AuthorExists(authorId))
                return NotFound();

            var books = _service.GetAuthorBooks(authorId);
            if (books == null)
                return NotFound();

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksDto);
        }

        [HttpPost("{bookId}")]
        public ActionResult<BookDto> GetASingleBookForAuthor(int authorId, int bookId)
        {
            var authorExists = _service.AuthorExists(authorId);
            if (!authorExists)
            {
                return NotFound();
            }

            var book = _service.GetASingleBookForAuthor(authorId, bookId);
            if (book == null)
                return NotFound();

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }
    }
}
