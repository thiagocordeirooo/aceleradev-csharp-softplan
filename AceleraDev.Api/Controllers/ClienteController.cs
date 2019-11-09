using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: api/cliente
        [HttpGet]
        public IEnumerable<ClienteViewModel> Get()
        {
            //_clienteAppService.Add(new ClienteViewModel { Nome = "TAC" });

            //var data = _clienteAppService.Find(p => p.Nome == "TAC").FirstOrDefault();
            //data.Nome = "Atualziado";

            //_clienteAppService.Update(data);

            return _clienteAppService.BuscarTop10();
        }

    }
}