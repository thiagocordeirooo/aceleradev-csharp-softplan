using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Services.Base;

namespace AceleraDev.Domain.Services
{
    public class UsuarioService: ServiceBase<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository): base(usuarioRepository)
        {
        }
    }
}
