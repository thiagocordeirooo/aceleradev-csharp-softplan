using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Models;
using System;
using System.Collections.Generic;

namespace AceleraDev.Application.Interfaces
{
    public interface IClienteAppService
    {
        void Add(ClienteViewModel obj);
        void Update(ClienteViewModel obj);
        void Remove(Guid id);
        ClienteViewModel GetById(Guid id);
        IList<ClienteViewModel> GetAll();
        IList<ClienteViewModel> Find(Func<Cliente, bool> predicate);
        IEnumerable<ClienteViewModel> BuscarTop10();
    }
}
