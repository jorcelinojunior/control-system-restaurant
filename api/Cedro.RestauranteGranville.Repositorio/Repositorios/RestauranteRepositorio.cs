using Cedro.RestauranteGranville.Dominio.Contratos;
using Cedro.RestauranteGranville.Dominio.Entidades;
using Cedro.RestauranteGranville.Repositorio.Contexto;

namespace Cedro.RestauranteGranville.Repositorio.Repositorios
{
    public class RestauranteRepositorio : BaseRepositorio<Restaurante>, IRestauranteRepositorio
    {
        public RestauranteRepositorio(GranvilleContexto granvilleContexto) : base(granvilleContexto)
        {
        }
    }
}
