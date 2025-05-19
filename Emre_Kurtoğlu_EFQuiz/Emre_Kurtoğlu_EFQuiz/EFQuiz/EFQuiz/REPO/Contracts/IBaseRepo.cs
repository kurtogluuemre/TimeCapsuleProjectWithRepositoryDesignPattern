using EFQuiz.CORE.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.REPO.Contracts
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        /// <summary>
        /// CRUD işlemleri
        /// </summary>
        IQueryable<T> GetAll();
        T? GetById(int id);
        void Create(T entity);
        void Delete(T entity);
    }
}
