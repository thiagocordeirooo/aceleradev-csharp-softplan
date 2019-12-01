using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AceleraDev.Application.ApplicationServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IServiceBase<Usuario> _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IServiceBase<Usuario> usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public UsuarioViewModel Add(UsuarioViewModel obj)
        {
            throw new NotImplementedException();
        }

        public IList<UsuarioViewModel> Find(Func<Usuario, bool> predicate)
        {
            var models = _usuarioService.Find(predicate);
            return _mapper.Map<List<UsuarioViewModel>>(models);
        }

        public IList<UsuarioViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel GetById(Guid id)
        {
            var model = _usuarioService.GetById(id);
            return _mapper.Map<UsuarioViewModel>(model);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioViewModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
