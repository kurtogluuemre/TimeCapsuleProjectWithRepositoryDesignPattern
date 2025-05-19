using EFQuiz.CORE.Enums;
using EFQuiz.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.Contracts
{
    public interface ICapsuleService
    {
        /// <summary>
        /// Servis işlemlerinde kullanacağım metotlar
        /// </summary>
        void CreateCapsule(string title, DateTime openDate);
        void AddContentToCapsule(int capsuleId, string text, ContentType contentType);
        List<Capsule> GetAllCapsules();
        List<Capsule> GetOpenedCapsules();
        Capsule? GetCapsuleDetails(int capsuleId);
        List<Capsule> GetTopCapsulesByContentCount(int topCount);
        ContentType GetMostUsedContentType();
    }
}
