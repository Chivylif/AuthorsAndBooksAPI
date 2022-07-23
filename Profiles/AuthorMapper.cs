using AutoMapper;

namespace AuthorsAndBooksAPI.Profiles
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Models.CreateAuthorDto, Entities.Author>();
            CreateMap<Models.UpdateAuthorDto, Entities.Author>();
            CreateMap<Entities.Author, Models.UpdateAuthorDto>();
        }
    }
}
