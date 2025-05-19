using EFQuiz.CORE.Models;
using EFQuiz.REPO.Concretes;
using EFQuiz.REPO.Contexts;
using EFQuiz.REPO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.REPO.UnitOfWorks
{
    /// <summary>
    /// Repository nesnelerine erişimi yöneten ve veri kaydını sağlayan sınıftır.
    /// Unit of Work deseninin repository tarafındaki karşılığıdır.
    /// </summary>
    public class ManagerRepo : IManagerRepo
    {
        private readonly TimeCapDbContext _context;
        private readonly Lazy<ICapsuleRepo> _capsuleRepo;
        private readonly Lazy<ICapsuleDetailRepo> _capsuleDetailRepo;

        public ManagerRepo(TimeCapDbContext context)
        {
            _context = context;
            _capsuleRepo = new Lazy<ICapsuleRepo>(() => new CapsuleRepo(_context));
            _capsuleDetailRepo = new Lazy<ICapsuleDetailRepo>(() => new CapsuleDetailRepo(_context));
        }
        public ICapsuleRepo Capsules => _capsuleRepo.Value;

        public ICapsuleDetailRepo CapsuleDetails => _capsuleDetailRepo.Value;

        public bool Save()
        {
           return _context.SaveChanges() > 0;
        }
    }
}
