using AutoMapper;
using DevelopmentTest.Model.DTO;
using DevelopmentTest.Model.Model;

namespace DevelopmentTest.Model.Factory
{
    public interface IFactory
    {
        EmployeeDto MapEmployee(Employee employee, IMapper mapper);
    }
}
