using AceleraDev.Application.ViewModels;
using AceleraDev.CrossCutting.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;

namespace AceleraDev.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected UsuarioViewModel UsuarioLogado()
        {
            ClaimsPrincipal currentUser = User;

            var usuario = currentUser.Claims.Where(c => c.Type == "usuario").Select(c => c.Value).SingleOrDefault();
            return JsonConvert.DeserializeObject<UsuarioViewModel>(usuario);
        }

        protected bool TemPerfilAdmin => UsuarioLogado().Perfil == PerfilUsuario.ADMIN;
        protected bool TemPerfilVendedor => UsuarioLogado().Perfil == PerfilUsuario.VENDEDOR;
    }
}