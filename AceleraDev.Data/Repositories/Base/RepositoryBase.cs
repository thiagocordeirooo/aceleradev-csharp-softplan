using AceleraDev.Data.Auditoria;
using AceleraDev.Data.Context;
using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models.Base;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceleraDev.Data.Repositories.Base
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
    {
        protected readonly AceleraDevContext _context;
        protected readonly MongoDbContext _mongoDbContext;

        public RepositoryBase(AceleraDevContext context)
        {
            _context = context;
            _mongoDbContext = new MongoDbContext();
        }

        public void Add(TModel obj)
        {
            obj.Id = Guid.NewGuid();
            obj.CriadoEm = obj.AtualizadoEm = DateTime.Now;
            obj.Ativo = true;

            _context.Set<TModel>().Add(obj);
            _context.SaveChanges();

            InserirAuditoria("Add", obj.Id.Value);
        }

        public IList<TModel> Find(Func<TModel, bool> predicate)
        {
            return _context.Set<TModel>().Where(predicate).ToList();
        }

        public IList<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
        }

        public TModel GetById(Guid id)
        {
            return _context.Set<TModel>().FirstOrDefault(p => p.Id == id);
        }

        public void Remove(Guid id)
        {
            _context.Set<TModel>().Remove(this.GetById(id));
            _context.SaveChanges();

            InserirAuditoria("Remove", id);
        }

        public void Update(TModel obj)
        {
            _context.Update(obj);
            _context.SaveChanges();

            InserirAuditoria("Update", (Guid)obj.Id);
        }

        public List<TModel> ExecutarConsultaComDapper(string query, object param = null)
        {
            using (var con = new SqlConnection(_context.GetConnectionString()))
            {
                try
                {
                    con.Open();
                    return con.Query<TModel>(query, param).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao executar uma pesquisa com Dapper", ex);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void InserirAuditoria(string operacao, Guid entidadeId)
        {
            Task.Run(() =>
            {
                var auditoria = new AuditoriaModel
                {
                    UsuarioId = "502FB637-9F6B-4B53-90F1-743F27411BAE",
                    Data = DateTime.UtcNow,
                    Entidade = typeof(TModel).Name,
                    Operacao = operacao,
                    EntidadeId = entidadeId.ToString()
                };

                _mongoDbContext.Auditorias.InsertOne(auditoria);
            });
        }
    }
}
