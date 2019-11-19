using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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

            //var end = new EnderecoViewModel
            //{
            //    Cep = "88115234",
            //    Rua = "Rua Estranha",
            //    Numero = 10
            //};

            //var endDois = new EnderecoViewModel
            //{
            //    Cep = "88115234",
            //    Rua = "Rua Estranha II",
            //    Numero = 100
            //};

            var clienteUm = new ClienteViewModel
            {
                Nome = "Max IV",
                Cpf = "98435877078",
                DataNascimento = new DateTime(1989, 12, 24),
            };

            _clienteAppService.Add(clienteUm);

            return _clienteAppService.BuscarTop10();
        }

    }
}