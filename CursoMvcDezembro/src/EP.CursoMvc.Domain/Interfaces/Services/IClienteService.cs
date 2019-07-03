﻿using System;
using System.Collections.Generic;
using EP.CursoMvc.Domain.Entities;

namespace EP.CursoMvc.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(Guid id);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterTodos();
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
    }
}