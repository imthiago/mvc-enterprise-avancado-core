﻿using DomainValidation.Validation;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Specifications.Clientes;

namespace EP.CursoMvc.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);
            var clienteEndereco = new ClienteDeveTerUmEnderecoSpecification();

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado! Esqueceu sua senha?"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "E-mail já cadastrado, esqueceu sua senha?"));
            base.Add("clienteEndereco", new Rule<Cliente>(clienteEndereco, "Cliente não informou endereço"));
        }
    }
}