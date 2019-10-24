using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Repositories;
using AceleraDev.Domain.Services.Base;
using System;
using System.Collections.Generic;

namespace AceleraDev.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        public ClienteService()
        {
            base._repositoryBase = new ClienteRepository();
        }

        public List<Cliente> BuscarTop10()
        {
            throw new NotImplementedException();
        }
    }
}
