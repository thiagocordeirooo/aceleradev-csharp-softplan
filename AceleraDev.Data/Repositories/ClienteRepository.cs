using AceleraDev.Data.Context;
using AceleraDev.Data.Repositories.Base;
using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(AceleraDevContext context): base(context)
        {
        }

        public List<Cliente> BuscarTop10()
        {
            return _context.Clientes.Where(p => p.Ativo).Take(10).ToList();
        }
    }
}
