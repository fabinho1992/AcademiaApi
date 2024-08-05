﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces
{
    public interface IUnitofWork
    {
        IAlunoService AlunoService { get; }
        Task Commit();
    }
}