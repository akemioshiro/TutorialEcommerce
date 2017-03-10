using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TutorialEcommerce.Domain.Entities;

namespace TutotrialEcommerce.Repositories
{
    public class Repository<TEntity> where TEntity : EntityBase
    {
        protected readonly EfDbContext Context;

        public Repository(EfDbContext context)
        {
            this.Context = context;
        }

        // para nao repetir toda hora o Context.Set<TEntity>()
        private DbSet<TEntity> Entity
        {
            get { return Context.Set<TEntity>(); }
        }

        void Add(TEntity obj)
        {
            obj.DtInclusao = DateTime.Now;
            Entity.Add(obj);
        }

        void AddAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
            {
                Add(entity);
            }
        }

        void DeleteAll(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
            {
                Delete(entity);
            }
        }

        void Delete(TEntity obj)
        {
            Entity.Remove(obj);
        }

        void Delete(int id)
        {
            Entity.Remove(Get(id));
        }

        TEntity Get(int id)
        {
            Entity.Find(id);
        }

        TEntity First()
        {
            return Entity.FirstOrDefault();
        }

        IQueryable<TEntity> Get()
        {
            return Entity;
        }

        void Update(TEntity obj)
        {
            obj.Alteracao = DateTime.Now;
            Context.Entry(obj).State = EntityState.Modified;
        }

        void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        void AddOrUpdate(TEntity obj)
        {
            if(obj.Id>0)
                Update(obj);
            else
                Add(obj);
        }


    }
}
