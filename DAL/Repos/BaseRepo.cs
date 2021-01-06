﻿using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repos
{
    public class BaseRepo<T> : IRepository<T> where T: class
    {
        private readonly AppDbContext db;

        public BaseRepo(AppDbContext db)
        {
            this.db = db;
        }
        public bool Add(T data)
        {
            try
            {
                db.Set<T>().Add(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T data)
        {
            try
            {
                db.Set<T>().Remove(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<T> Get()
        {
           return db.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }

        public bool Update(T data)
        {
            try
            {
                db.Set<T>().Update(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}