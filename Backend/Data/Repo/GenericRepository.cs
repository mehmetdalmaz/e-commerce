using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Context;

namespace Data.Repo
{
    public class GenericRepository<T>: IGenericDal<T> where T :class
    {
         private readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            throw new Exception("Entity not found");

            return entity;
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
    }
