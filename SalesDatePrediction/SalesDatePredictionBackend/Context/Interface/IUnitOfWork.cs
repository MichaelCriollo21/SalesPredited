using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context.Class;
using Context.Context;

namespace Context.Interface
{
    public interface IUnitOfWork
    {
        void SaveChanges();

        Repository<T> Repository<T>() where T : class;

        SalesPredictionContext GetContext();
    }
}
