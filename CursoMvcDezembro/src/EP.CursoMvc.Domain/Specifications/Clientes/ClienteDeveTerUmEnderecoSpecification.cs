using System.Linq;
using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveTerUmEnderecoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return entity.Enderecos.Any();
        }
    }
}