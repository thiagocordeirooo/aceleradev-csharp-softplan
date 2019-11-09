using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Services.Base;
using System.Collections.Generic;

namespace AceleraDev.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        protected readonly IClienteRepository _clienteRespository;

        public ClienteService(IClienteRepository clienteRespository) : base(clienteRespository)
        {
            _clienteRespository = clienteRespository;
        }

        public List<Cliente> BuscarTop10()
        {
            return _clienteRespository.BuscarTop10();
        }
    }
}
