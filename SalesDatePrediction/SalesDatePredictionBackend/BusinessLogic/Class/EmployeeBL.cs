using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using Context.Class;
using Context.Interface;
using Entities.Entities.HR;
using Entities.Entities.Sales.Sales;

namespace BusinessLogic.Class
{
    public class EmployeeBL : IEmployee, IDisposable
    {
        private readonly IUnitOfWork UnitOfWork;
        private Repository<Employee> EmployeeRepository;

        public EmployeeBL(IUnitOfWork UoW)
        {
            this.UnitOfWork = UoW;
            EmployeeRepository = UnitOfWork.Repository<Employee>();
        }

        public IEnumerable<Employee> FindAll()
        {
            return EmployeeRepository.FindAll();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
