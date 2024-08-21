using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.WebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteCommand, CreateNoteDto>()
                .ForMember(dto => dto.Title, opt => opt.MapFrom(cmd => cmd.Title))
                .ForMember(dto => dto.Details, opt => opt.MapFrom(cmd => cmd.Details));
        }
    }
}
