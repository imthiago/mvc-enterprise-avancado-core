using System;
using DomainValidation.Interfaces.Specification;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente entity)
        {
            return DateTime.Now.Year - entity.DataNascimento.Year >= 18;
        }
    }
}