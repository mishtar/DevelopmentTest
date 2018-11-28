using System.Runtime.Serialization;

namespace DevelopmentTest.Model.DTO
{
    [KnownType(typeof(MonthlyEmployeeDto))]
    public class MonthlyEmployeeDto : EmployeeDto
    {
        public override decimal AnnualSalary => base.MonthlySalary * 12;
    }
}
