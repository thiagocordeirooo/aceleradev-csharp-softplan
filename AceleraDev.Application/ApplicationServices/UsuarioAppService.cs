using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Application.ViewModels.Seguranca;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace AceleraDev.Application.ApplicationServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public UsuarioViewModel Add(UsuarioViewModel obj)
        {
            var model = _mapper.Map<Usuario>(obj);
            model = _usuarioService.Add(model);

            return _mapper.Map<UsuarioViewModel>(model);
        }

        public IList<UsuarioViewModel> Find(Func<Usuario, bool> predicate)
        {
            var model = _usuarioService.Find(predicate);
            return _mapper.Map<List<UsuarioViewModel>>(model);
        }

        public IList<UsuarioViewModel> GetAll()
        {
            var model = _usuarioService.GetAll();
            return _mapper.Map<List<UsuarioViewModel>>(model);
        }

        public UsuarioViewModel GetById(Guid id)
        {
            var model = _usuarioService.GetById(id);
            return _mapper.Map<UsuarioViewModel>(model);
        }

        public void Remove(Guid id)
        {
            _usuarioService.Remove(id);
        }

        public void Update(UsuarioViewModel obj)
        {
            var model = _mapper.Map<Usuario>(obj);
            _usuarioService.Update(model);
        }
    }
}
