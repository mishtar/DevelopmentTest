using System;
using AutoMapper;
using DevelopmentTest.Model.DTO;
using DevelopmentTest.Model.Enumerations;
using DevelopmentTest.Model.Model;

namespace DevelopmentTest.Model.Factory
{
    public class Factory : IFactory
    {
        public EmployeeDto MapEmployee(Employee employee, IMapper mapper)
        {
            var contractType = (ContractType)Enum.Parse(typeof(ContractType), employee.ContractTypeName);

            switch (contractType)
            {
                case ContractType.HourlySalaryEmployee:
                    return mapper.Map<Employee, HourlyEmployeeDto>(employee);
                case ContractType.MonthlySalaryEmployee:
                    return mapper.Map<Employee, MonthlyEmployeeDto>(employee);
            }

            return null;
        }
    }
}
