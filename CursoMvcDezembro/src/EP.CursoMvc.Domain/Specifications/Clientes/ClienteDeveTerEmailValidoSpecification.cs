using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Validations.Documentos;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return EmailValidation.Validar(entity.Email);
        }
    }
}