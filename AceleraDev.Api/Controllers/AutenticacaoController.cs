using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Application.ViewModels.Autenticacao;
using AceleraDev.CrossCutting.Helpers;
using AceleraDev.CrossCutting.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    /// <summary>
    /// Login do usuário.
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Login do usuário ctor.
        /// </summary>
        /// <param name="usuarioAppService"></param>
        /// <param name="appSettings"></param>
        public AutenticacaoController(IUsuarioAppService usuarioAppService, IOptions<AppSettings> appSettings)
        {
            _usuarioAppService = usuarioAppService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Endpoint para login do usuário.
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        /// <response code="200">Retorna o usuário e o token</response>
        /// <response code="400">Se ocorrer algum erro na autenticação</response>  
        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
