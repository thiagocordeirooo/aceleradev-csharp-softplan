using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Application.ViewModels.Autenticacao;
using AceleraDev.CrossCutting.Helpers;
using AceleraDev.CrossCutting.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        public ActionResult Post(LoginViewModel loginViewModel)
        {
            var usuario = _usuarioAppService.Find(p => p.Email == loginViewModel.Login).FirstOrDefault();

            if (usuario == null)
                return BadRequest("Usuário não cadastrado.");

            if (usuario.Senha != loginViewModel.Password.ToHashMD5())
                return BadRequest("Senha inválida.");

            if (!usuario.Ativo)
                return BadRequest("Usuário inativo.");

            usuario.AccessToken = GerarJWT(usuario);

            return Ok(usuario);
        }

        private string GerarJWT(UsuarioViewModel usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKeyJWT);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Perfil),
                    new Claim("id", usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
