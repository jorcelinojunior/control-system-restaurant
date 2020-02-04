using Cedro.RestauranteGranville.Dominio.Contratos;
using Cedro.RestauranteGranville.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cedro.RestauranteGranville.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly GranvilleContexto GranvilleContexto;
        public BaseRepositorio(GranvilleContexto granvilleContexto)
        {
            GranvilleContexto = granvilleContexto;
        }

        public void Adicionar(TEntity entity)
        {
            GranvilleContexto.Set<TEntity>().Add(entity);
            GranvilleContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            GranvilleContexto.Set<TEntity>().Update(entity);
            GranvilleContexto.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return GranvilleContexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return GranvilleContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            GranvilleContexto.Remove(entity);
            GranvilleContexto.SaveChanges();
        }
        public void Dispose()
        {
            GranvilleContexto.Dispose();
        }
    }
}
