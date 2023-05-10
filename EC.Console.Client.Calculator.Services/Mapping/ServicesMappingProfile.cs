using AutoMapper;
using EC.Console.Client.Calculator.Services.Resolvers.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions;
using EC.Console.Client.Calculator.Services.Resolvers.Divisions.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Journals;
using EC.Console.Client.Calculator.Services.Resolvers.Journals.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications;
using EC.Console.Client.Calculator.Services.Resolvers.Multiplications.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots;
using EC.Console.Client.Calculator.Services.Resolvers.SquareRoots.Dtos;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions;
using EC.Console.Client.Calculator.Services.Resolvers.Subtractions.Dtos;

namespace EC.Api.Calculator.Presentation.WebApi.Mapping
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<AdditionResponseDto, AdditionResponse>();
            CreateMap<DivisionResponseDto, DivisionResponse>();
            CreateMap<MultiplicationResponseDto, MultiplicationResponse>();
            CreateMap<SquareRootResponseDto, SquareRootResponse>();
            CreateMap<SubtractionResponseDto, SubtractionResponse>();
            CreateMap<JournalQueryOperationDto, JournalQueryOperation>();
            CreateMap<JournalResponseDto, JournalResponse>();

        }
    }
}
