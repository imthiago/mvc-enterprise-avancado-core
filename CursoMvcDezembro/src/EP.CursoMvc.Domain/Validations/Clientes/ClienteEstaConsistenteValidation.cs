using DomainValidation.Interfaces.Validation;
using DomainValidation.Validation;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Specifications.Clientes;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {

        public ClienteEstaConsistenteValidation()
        {
            var cpfCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaiorIdade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("cpfCliente", new Rule<Cliente>(cpfCliente, "Cliente informou um CPF inválido"));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido"));
            base.Add("clienteMaiorIdade", new Rule<Cliente>(clienteMaiorIdade, "Cliente não tem maioridade para cadastro"));
        }

        
    }
}