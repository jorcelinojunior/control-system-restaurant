using Cedro.RestauranteGranville.Dominio.Contratos;
using Cedro.RestauranteGranville.Dominio.Entidades;
using Cedro.RestauranteGranville.Repositorio.Contexto;

namespace Cedro.RestauranteGranville.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(GranvilleContexto granvilleContexto) : base(granvilleContexto)
        {
        }
    }
}
