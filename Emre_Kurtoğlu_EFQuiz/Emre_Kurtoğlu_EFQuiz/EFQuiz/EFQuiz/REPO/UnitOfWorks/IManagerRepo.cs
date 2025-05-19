using EFQuiz.REPO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.REPO.UnitOfWorks
{
    public interface IManagerRepo
    {
        ICapsuleRepo Capsules { get; }
        ICapsuleDetailRepo CapsuleDetails { get; }

        public bool Save();
    }
}
