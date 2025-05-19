using EFQuiz.CORE.Enums;
using EFQuiz.CORE.Helpers;
using EFQuiz.CORE.Models;
using EFQuiz.REPO.UnitOfWorks;
using EFQuiz.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.Concretes
{
    public class CapsuleDetailService : ICapsuleDetailService
    {
        private readonly IManagerRepo _manager;

        public CapsuleDetailService(IManagerRepo manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Belirli bir kapsüle yeni bir içerik ekler.
        /// </summary>
        public void AddDetail(int capsuleId, string text, ContentType contentType)
        {
            var capsule = _manager.Capsules.GetById(capsuleId);
            if (capsule == null)
                throw new Exception("Kapsül bulunamadı.");

            var detail = new CapsuleDetail
            {
                CapsuleId = capsuleId,
                Text = Guard.SetData(text),
                ContentType = contentType
            };

            _manager.CapsuleDetails.Create(detail);
            _manager.Save();
        }

        /// <summary>
        /// Sistemdeki tüm kapsül içeriklerini getirir.
        /// </summary>
        public List<CapsuleDetail> GetAll()
        {
            return _manager.CapsuleDetails.GetAll().ToList();
        }

        /// <summary>
        /// Belirli bir kapsüle ait içerikleri getirir.
        /// </summary>
        public List<CapsuleDetail> GetByCapsuleId(int capsuleId)
        {
            return _manager.CapsuleDetails
                .GetAll()
                .Where(cd => cd.CapsuleId == capsuleId)
                .ToList();
        }
    }

}
