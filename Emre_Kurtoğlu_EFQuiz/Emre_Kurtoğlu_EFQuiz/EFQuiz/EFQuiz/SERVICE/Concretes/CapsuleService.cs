using EFQuiz.CORE.Enums;
using EFQuiz.CORE.Helpers;
using EFQuiz.CORE.Models;
using EFQuiz.REPO.UnitOfWorks;
using EFQuiz.SERVICE.Contracts;
using EFQuiz.SERVICE.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.Concretes
{
    public class CapsuleService : ICapsuleService
    {
        private readonly IManagerRepo _manager;

        public CapsuleService(IManagerRepo manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Yeni bir kapsül oluşturur.
        /// </summary>
        public void CreateCapsule(string title, DateTime openDate)
        {
            var capsule = new Capsule
            {
                Title = title,
                OpenDate = Guard.SetDate(openDate),
                Contents = new List<CapsuleDetail>()
            };

            _manager.Capsules.Create(capsule);
            _manager.Save();
        }

        /// <summary>
        /// Belirtilen kapsüle içerik ekler.
        /// </summary>
        public void AddContentToCapsule(int capsuleId, string text, ContentType contentType)
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
        /// Sistemdeki tüm kapsülleri getirir.
        /// </summary>
        public List<Capsule> GetAllCapsules()
        {
            return _manager.Capsules.GetAll().ToList();
        }

        /// <summary>
        /// Açılma tarihi bugüne veya geçmişe denk gelen kapsülleri getirir.
        /// </summary>
        public List<Capsule> GetOpenedCapsules()
        {
            return _manager.Capsules
                .GetAll()
                .Where(c => c.OpenDate <= DateTime.Now)
                .ToList();
        }

        /// <summary>
        /// Belirli bir kapsülün detaylarını getirir.
        /// </summary>
        public Capsule? GetCapsuleDetails(int capsuleId)
        {
            return _manager.Capsules
                .GetAll()
                .FirstOrDefault(c => c.Id == capsuleId);
        }

        /// <summary>
        /// İçerik sayısına göre en çok içeriğe sahip ilk N kapsülü getirir.
        /// </summary>
        public List<Capsule> GetTopCapsulesByContentCount(int topCount)
        {
            return _manager.Capsules
                .GetAll()
                .OrderByDescending(c => c.Contents.Count)
                .Take(topCount)
                .ToList();
        }

        /// <summary>
        /// Sistem genelinde en çok kullanılan içerik tipini getirir.
        /// </summary>
        public ContentType GetMostUsedContentType()
        {
            return _manager.CapsuleDetails
                .GetAll()
                .ToList()
                .GroupBy(cd => cd.ContentType)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()
                .Key;
        }
    }
}
