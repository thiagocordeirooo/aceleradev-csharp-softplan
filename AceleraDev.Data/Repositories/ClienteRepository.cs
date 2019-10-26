using AceleraDev.Data.Repositories.Base;
using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Models;
using System.Collections.Generic;

namespace AceleraDev.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository()
        {
            base._mock = new List<Cliente> {
                new Cliente
                {
                    Nome = "Thiago",
                    Sobrenome = "Cordeiro",
                    Cpf = "070.044.555.77"
                }
            };
        }

        public List<Cliente> BuscarTop10()
        {
            throw new System.NotImplementedException();
        }
    }
}
