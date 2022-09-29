
using DEVinCar.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public  class BaseRepositorio<TEntity, Tkey> where TEntity : class
    {
        protected readonly DevInCarDbContext _contexto;

        public BaseRepositorio(DevInCarDbContext contexto)
        {
            _contexto = contexto;
        }
        public virtual void Inserir(TEntity entity)
        {
            _contexto.Set<TEntity>().Add(entity);
            _contexto.SaveChanges();
        }

        public virtual void Atualizar(TEntity entity)
        {
            _contexto.Set<TEntity>().Update(entity);
            _contexto.SaveChanges();
        }

        public virtual  TEntity ObterPorId(Tkey id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public virtual IList<TEntity> ObterTodos( )
        {
            return _contexto.Set<TEntity>()
                            .ToList();
        }
        public virtual void Excluir(TEntity entity)
        {
            _contexto.Set<TEntity>().Remove(entity);
        }
    }
}
