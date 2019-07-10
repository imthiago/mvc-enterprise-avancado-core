using AutoMapper;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Cliente>();
            CreateMap<ClienteEnderecoViewModel, Endereco>();
            CreateMap<EnderecoViewModel, Endereco>();
        }
    }
}