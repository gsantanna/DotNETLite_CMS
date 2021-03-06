﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.Infra.Repository
{

    public abstract class Repository<T> : IRepository<T> where T : class, new()
    {
        public Repository()
        {
            this.Context = Activator.CreateInstance<TDLCDataContext>();
            this.Model = this.Context.Set<T>();
        }
        public Repository(DbContext Context)
        {
            this.Context = Context;
            this.Model = this.Context.Set<T>();
        }



        public virtual IQueryable<T> All
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T
                                          , object>>[] includeProperties)
        {
            IQueryable<T> query = All;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            //string sql = query.ToString();
            return query;
        }














        public T Insert(T model)
        {
            this.Model.Add(model);
            this.Save();
            return model;
        }
        public bool Edit(T model)
        {
            bool status = false;
            this.Context.Entry<T>(model).State = EntityState.Modified;
            if (this.Save() > 0)
            {
                status = true;
            }
            return status;
        }
        public virtual bool Delete(T model)
        {
            bool status = false;
            this.Context.Entry<T>(model).State = EntityState.Deleted;
            if (this.Save() > 0)
            {
                status = true;
            }
            return status;
        }
        public bool Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            bool status = false;
            T model = this.Model.Where<T>(where).FirstOrDefault<T>();
            if (model != null)
            {
                status = Delete(model);
            }
            return status;
        }
        public bool Delete(params object[] Keys)
        {
            bool status = false;
            T model = this.Model.Find(Keys);
            if (model != null)
            {
                status = Delete(model);
            }
            return status;
        }
        public T Find(params object[] Keys)
        {
            return this.Model.Find(Keys);
        }
        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return this.Model.Where<T>(where).FirstOrDefault<T>();
        }
        public IQueryable<T> Query()
        {
            return this.Model;
        }
        public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> Set = this.Query();
            foreach (var include in includes)
            {
                Set = Set.Include(include);
            }
            return Set;
        }





        public IQueryable<T> QueryFast()
        {
            return this.Model.AsNoTracking<T>();
        }
        public IQueryable<T> QueryFast(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> Set = this.QueryFast();
            foreach (var include in includes)
            {
                Set = Set.Include(include);
            }
            return Set.AsNoTracking();

        }
        public T Create()
        {
            return this.Model.Create();
        }
        public DbSet<E> Create<E>()
            where E : class, new()
        {
            return this.Context.Set<E>();
        }
        public System.Data.Entity.DbContext Context
        {
            get;
            private set;
        }
        public System.Data.Entity.DbSet<T> Model
        {
            get;
            private set;
        }
        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        public int Save()
        {
            return this.Context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this.Context.SaveChangesAsync();
        }
    }

    



}
