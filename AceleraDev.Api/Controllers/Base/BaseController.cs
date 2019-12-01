using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.CrossCutting.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;

namespace AceleraDev.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public BaseController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        protected UsuarioViewModel UsuarioLogado()
        {
            ClaimsPrincipal currentUser = User;
            var idUsuario = currentUser.Claims.Where(c => c.Type == "id").Select(c => c.Value).SingleOrDefault();

            return _usuarioAppService.GetById(new Guid(idUsuario));
        }

        protected bool UsuarioTemPerfilAdmin => GetRoleFromJWT() == Constants.PERFIL_ADMIN;

        protected bool UsuarioTemPerfilVendedor => GetRoleFromJWT() == Constants.PERFIL_VENDEDOR;

        private string GetRoleFromJWT()
        {
            return User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
        }
    }
}
