using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models;
using System.Collections.Generic;

namespace AceleraDev.Domain.Interfaces.Services
{
    public interface IClienteService: IServiceBase<Cliente>
    {
        List<Cliente> BuscarTop10();
    }
}
