﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_3.Models
{
    public interface IQueue
    {
        void Add(String item);

        String Remove();

        void Clear();

        Boolean IsEmpty { get; }
        Int32 Count { get; }
    }
}
