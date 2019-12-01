using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Models;
using System;
using System.Collections.Generic;

namespace AceleraDev.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel Add(UsuarioViewModel obj);
        void Update(UsuarioViewModel obj);
        void Remove(Guid id);
        UsuarioViewModel GetById(Guid id);
        IList<UsuarioViewModel> GetAll();
        IList<UsuarioViewModel> Find(Func<Usuario, bool> predicate);
    }
}
