using AutoMapper;
using EC.Console.Client.Calculator.Services.Processors.Additions.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Divisions;
using EC.Console.Client.Calculator.Services.Processors.Divisions.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Journals;
using EC.Console.Client.Calculator.Services.Processors.Journals.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Multiplications;
using EC.Console.Client.Calculator.Services.Processors.Multiplications.Dtos;
using EC.Console.Client.Calculator.Services.Processors.SquareRoots;
using EC.Console.Client.Calculator.Services.Processors.SquareRoots.Dtos;
using EC.Console.Client.Calculator.Services.Processors.Subtractions;
using EC.Console.Client.Calculator.Services.Processors.Subtractions.Dtos;

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
