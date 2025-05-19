using EFQuiz.REPO.UnitOfWorks;
using EFQuiz.SERVICE.Concretes;
using EFQuiz.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.IUnitOfWorks
{
    /// <summary>
    /// Tüm servis katmanlarının tek bir noktadan yönetilmesini sağlayan Unit of Work sınıfıdır.
    /// Lazy yükleme ile servislerin yalnızca ihtiyaç duyulduğunda oluşturulmasını sağlar.
    /// </summary>
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly Lazy<ICapsuleDetailService> _capsuleDetailService;
        private readonly Lazy<ICapsuleService> _capsuleService;

        public UnitOfWorks(IManagerRepo managerRepo)
        {
            _capsuleDetailService = new Lazy<ICapsuleDetailService>(() => new CapsuleDetailService(managerRepo));
            _capsuleService = new Lazy<ICapsuleService>(() => new CapsuleService(managerRepo));
        }

        public ICapsuleDetailService CapsuleDetailService => _capsuleDetailService.Value;
        public ICapsuleService CapsuleService => _capsuleService.Value;
    }

}
