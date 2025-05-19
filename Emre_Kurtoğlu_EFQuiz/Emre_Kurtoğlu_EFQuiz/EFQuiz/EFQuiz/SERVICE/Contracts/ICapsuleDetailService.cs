using EFQuiz.CORE.Enums;
using EFQuiz.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.Contracts
{
    public interface ICapsuleDetailService
    {
        void AddDetail(int capsuleId, string text, ContentType contentType);
        List<CapsuleDetail> GetAll();
        List<CapsuleDetail> GetByCapsuleId(int capsuleId);
    }
}
