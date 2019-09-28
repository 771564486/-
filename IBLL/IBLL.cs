﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBLL<T> where T:class
    {
         int Insert(T t);
         int Update(T t);
         int Delete(T t);
         List<T> SelectAll();
    }
}
