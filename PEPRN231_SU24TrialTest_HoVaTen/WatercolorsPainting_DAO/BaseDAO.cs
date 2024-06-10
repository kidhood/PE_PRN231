﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WatercolorsPainting_BO;

namespace WatercolorsPainting_DAO
{
    public class BaseDAO<T> where T : class
    {
        private readonly WatercolorsPainting2024DBContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseDAO()
        {
            _context = new WatercolorsPainting2024DBContext();
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }
        public bool Remove(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }


        public IQueryable<T> Get()
        {
            return this._dbSet.AsQueryable();
        }

    }
}
