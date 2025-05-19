using EFQuiz.CORE.Abstracts;
using EFQuiz.REPO.Contexts;
using EFQuiz.REPO.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.REPO.Concretes
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        /// <summary>
        /// Veritabanı bağlamını temsil eder.
        /// </summary>
        protected readonly TimeCapDbContext _context;

        /// <summary>
        /// BaseRepo sınıfının yapıcı metodu.
        /// </summary>
        protected BaseRepo(TimeCapDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Veritabanına yeni bir entity ekler.
        /// </summary>
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Veritabanından belirtilen entity'yi siler.
        /// </summary>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Veritabanındaki tüm entity'leri sorgulanabilir şekilde döner.
        /// </summary>
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        /// <summary>
        /// Belirtilen ID'ye sahip entity'yi getirir.
        /// </summary>
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }

}
