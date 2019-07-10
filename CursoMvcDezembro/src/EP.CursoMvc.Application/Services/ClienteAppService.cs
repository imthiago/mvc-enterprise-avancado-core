using System;
using System.Collections.Generic;
using AutoMapper;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Interfaces.Services;
using EP.CursoMvc.Infra.Data.Interfaces;

namespace EP.CursoMvc.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow, IMapper mapper)
        {
            _clienteService = clienteService;
            _uow = uow;
            _mapper = mapper;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteViewModel);
            var endereco = _mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteViewModel);

            _uow.BeginTransaction();

            var clienteReturn = _clienteService.Adicionar(cliente);

            // necessário para repassaras mensagens de erro para o viewmodel
            clienteViewModel = _mapper.Map<Cliente, ClienteEnderecoViewModel>(clienteReturn);

            if (clienteReturn.ValidationResult.IsValid)
                _uow.Commit();

            return clienteViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            _clienteService.Atualizar(_mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));
            return clienteViewModel;
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return _mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return _mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}