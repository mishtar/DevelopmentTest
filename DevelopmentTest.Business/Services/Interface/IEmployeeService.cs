using System.Collections.Generic;
using System.Threading.Tasks;
using DevelopmentTest.Model.DTO;

namespace DevelopmentTest.Business.Services.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int id);
    }
}
