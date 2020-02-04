using Cedro.RestauranteGranville.Dominio.Contratos;
using Cedro.RestauranteGranville.Dominio.Entidades;
using Cedro.RestauranteGranville.Repositorio.Contexto;

namespace Cedro.RestauranteGranville.Repositorio.Repositorios
{
    public class PratoRepositorio : BaseRepositorio<Prato>, IPratoRepositorio
    {
        public PratoRepositorio(GranvilleContexto granvilleContexto) : base(granvilleContexto)
        {
        }
    }
}
