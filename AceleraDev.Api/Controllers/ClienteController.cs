using AceleraDev.Api.Controllers.Base;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.CrossCutting.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AceleraDev.Api.Controllers
{
    /// <summary>
    /// Endpoint de Cliente
    /// </summary>
    [Authorize]
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        /// <summary>
        /// Busca todos os clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ClienteViewModel>> Get()
        {
            try
            {
                if (TemPerfilAdmin)
                {
                    var usuario = UsuarioLogado();
                }

                var clientes = _clienteAppService.GetAll();
                return Ok(clientes);
            }
            catch
            {
                return BadRequest(new { Messagem = "Ocorreu um erro ao buscar os clientes." });
            }
        }

        /// <summary>
        /// Busca um cLiente por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ClienteViewModel</returns>
        [HttpGet("{id}")]
        public ActionResult<ClienteViewModel> GetById(Guid id)
        {
            try
            {
                var cliente = _clienteAppService.GetById(id);
                
                if(cliente != null)
                    return Ok(cliente);
                
                return NoContent();
            }
            catch 
            {
                return BadRequest(new { Messagem = $"Ocorreu um erro ao buscar o cliente: {id}" });
            }
        }

        [HttpGet("{id}/enderecos")]
        public ActionResult GetEnderecosCliente(Guid id)
        {
            try
            {
                var cliente = _clienteAppService.GetById(id);

                if (cliente != null)
                    return Ok(cliente.Enderecos);

                return NoContent();
            }
            catch
            {
                return BadRequest(new { Messagem = $"Ocorreu um erro ao buscar os endereços do cliente: {id}" });
            }
        }

        [HttpPost]
        public ActionResult Post([FromHeader][Required(ErrorMessage = "Precisa da Empresa no Header.")] string empresa,
            [FromBody]ClienteViewModel cliente)
        {
            cliente = _clienteAppService.Add(cliente);
            return Created($"{Request.Path.Value}/{cliente.Id}", cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromQuery]Guid id, [FromBody]ClienteViewModel cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            _clienteAppService.Update(cliente);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = PerfilUsuario.ADMIN)]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _clienteAppService.Remove(id);
                return Ok();
            }
            catch
            {
                return BadRequest("Ocorreu um erro ao deletar o cliente, tente novamente mais tarde.");
            }
        }
    }
}