using System.Runtime.Serialization;

namespace DevelopmentTest.Model.DTO
{
    [KnownType(typeof(HourlyEmployeeDto))]
    public class HourlyEmployeeDto : EmployeeDto
    {
        public override decimal AnnualSalary => HourlySalary * 120 * 12;
    }
}
