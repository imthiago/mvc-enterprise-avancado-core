using AutoMapper;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Cliente, ClienteEnderecoViewModel>();
            CreateMap<Endereco, ClienteEnderecoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}