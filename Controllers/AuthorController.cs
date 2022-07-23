using AuthorsAndBooksAPI.Entities;
using AuthorsAndBooksAPI.Models;
using AuthorsAndBooksAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsAndBooksAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorApiServices _service;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorApiServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authors = _service.GetAuthors();
            var list = new List<AuthorDto>();

            foreach (var author in authors)
            {
                list.Add(new AuthorDto()
                {
                    Id = author.Id,
                    Name = $"{author.FirstName} {author.LastName}",
                    Age = author.Age,
                    Email = author.Email
                });
            }
            return Ok(list);
        }

        [HttpGet("{authorId}")]
        public ActionResult<Author> GetAuthor(int authorId)
        {
            var authorExist = _service.AuthorExists(authorId);
            if (!authorExist)
                return NotFound();

            var author = _service.GetAuthor(authorId);

            var authorDto = new AuthorDto()
            {
                Id = author.Id,
                Name = $"{author.FirstName} {author.LastName}",
                Age = author.Age,
                Email = author.Email
            };

            return Ok(authorDto);
        }

        [HttpPost]
        public ActionResult CreateAuthor(CreateAuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = _mapper.Map<Author>(authorDto);
            _service.CreateAuthor(author);

            return NoContent();
        }

        [HttpPost("{authorId}")]
        public ActionResult DeleteAuthor(int authorId)
        {
            var authorExist = _service.AuthorExists(authorId);
            if (!authorExist)
                return NotFound();

            _service.DeleteAuthor(authorId);

            return Ok();
        }

        [HttpPut("{authorId}")]
        public ActionResult UpdateAuthor(int authorId, UpdateAuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authorExist = _service.AuthorExists(authorId);
            if (!authorExist)
                return NotFound();


            _service.UpdateAuthor(authorId, authorDto);

            return NoContent();
        }

        [HttpPatch("{authorId}")]
        public ActionResult PartialUpdateAuthor(int authorId,
            JsonPatchDocument<UpdateAuthorDto> patchDocument)
        {
            var authorExist = _service.AuthorExists(authorId);
            if (!authorExist)
                return NotFound();

            var author = _service.GetAuthor(authorId);
            var authorToPatch = _mapper.Map<UpdateAuthorDto>(author);

            patchDocument.ApplyTo(authorToPatch);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!TryValidateModel(authorToPatch))
                return BadRequest(ModelState);

            _mapper.Map(authorToPatch, author);

            _service.PartialUpdateAuthor(author);

            return NoContent();
        }
    }
}
