using AceleraDev.Data.Context;
using AceleraDev.Data.Repositories.Base;
using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(AceleraDevContext context) : base(context)
        {
        }

        public List<Cliente> BuscarTop10()
        {
            //return _context.Clientes.Where(p => p.Ativo).Take(10).ToList();

            return base.ExecutarConsultaComDapper("select top 10 * from cliente");
            //using (var con = new SqlConnection(_context.GetConnectionString()))
            //{
            //    try
            //    {
            //        var query = @"select * from cliente c
            //                      join endereco e on c.Id = e.ClienteId";

            //        con.Open();

            //        return con.Query<Cliente, Endereco, Cliente>(query,
            //            map:(cli, end) =>
            //            {
            //                cli.Enderecos = new List<Endereco> { end };
            //                return cli;
            //            }).ToList();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Ocorreu um erro ao executar uma pesquisa com Dapper", ex);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}
        }
    }
}
