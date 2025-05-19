using EFQuiz.REPO.Contracts;
using EFQuiz.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.IUnitOfWorks
{
    public interface IUnitOfWorks
    {
        ICapsuleDetailService CapsuleDetailService { get; }
        ICapsuleService CapsuleService { get; }
    }
}
