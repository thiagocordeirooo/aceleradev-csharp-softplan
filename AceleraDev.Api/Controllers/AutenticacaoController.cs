using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Application.ViewModels.Seguranca;
using AceleraDev.CrossCutting.Helpers;
using AceleraDev.CrossCutting.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace AceleraDev.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly AppSettings _appSettings;

        public AutenticacaoController(IUsuarioAppService usuarioAppService, IOptions<AppSettings> appSettings)
        {
            _usuarioAppService = usuarioAppService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost()]
        public ActionResult<UsuarioViewModel> Post([FromBody]LoginViewModel loginViewModel)
        {
            var usuario = _usuarioAppService.Find(p => p.Email == loginViewModel.Email).FirstOrDefault();

            if (usuario == null)
                return StatusCode((int)HttpStatusCode.BadRequest, "Usuário não encontrado.");

            if (usuario.Senha != loginViewModel.Senha.ToHashMD5())
                return StatusCode((int)HttpStatusCode.BadRequest, "Senha incorreta.");

            if (!usuario.Ativo)
                return StatusCode((int)HttpStatusCode.BadRequest, "Usuário inativo.");

            usuario.AccessToken =  GerarJWT(usuario);
            usuario.Senha = null;

            return Ok(usuario);
        }

        private string GerarJWT(UsuarioViewModel usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Perfil),
                    new Claim("usuario", JsonConvert.SerializeObject(usuario)),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
