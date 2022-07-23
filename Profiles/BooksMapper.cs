using AutoMapper;

namespace AuthorsAndBooksAPI.Profiles
{
    public class BooksMapper : Profile
    {
        public BooksMapper()
        {
            CreateMap<Entities.Book, Models.BookDto>();
        }
    }
}
