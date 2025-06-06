﻿using EFQuiz.CORE.Models;
using EFQuiz.REPO.Contexts;
using EFQuiz.REPO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.REPO.Concretes
{
    public class CapsuleRepo : BaseRepo<Capsule>, ICapsuleRepo
    {
        public CapsuleRepo(TimeCapDbContext context) : base(context)
        {
        }
    }
}
