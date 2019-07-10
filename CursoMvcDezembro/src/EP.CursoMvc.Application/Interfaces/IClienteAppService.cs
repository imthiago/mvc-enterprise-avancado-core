using System;
using System.Collections.Generic;
using EP.CursoMvc.Application.ViewModels;

namespace EP.CursoMvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteViewModel);
        ClienteViewModel ObterPorId(Guid id);
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void Remover(Guid id);
    }
}