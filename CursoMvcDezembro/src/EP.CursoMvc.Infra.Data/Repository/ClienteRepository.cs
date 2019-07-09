using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EP.CursoMvc.Domain.Entities;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EP.CursoMvc.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CursoMvcContext context) : base(context)
        {
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.GetDbConnection();
            const string sql = @"SELECT * FROM Clientes";

            return cn.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.GetDbConnection();
            var sql = @"SELECT * FROM Cliente c " +
                "LEFT JOIN Enderecos e " +
                "on c.ClienteId = e.ClienteId " +
                "WHERE c.ClienteId = @sid";

            var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            return cliente.FirstOrDefault();
        }
    }
}