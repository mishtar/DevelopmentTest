using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTest.Business.Services.Interface;
using DevelopmentTest.Model.DTO;
using DevelopmentTest.Model.Factory;
using DevelopmentTest.Model.Model;
using DevelopmentTest.Utility;
using DevelopmentTest.Utility.RequestTools.Interface;

namespace DevelopmentTest.Business.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRequestTools _requestTools;
        private readonly IFactory _factory;
        private readonly IMapper _mapper; 

        public EmployeeService(IRequestTools requestTools, IFactory factory, IMapper mapper)
        {
            _requestTools = requestTools;
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int id)
        {
            var response = await _requestTools.Invoke<IEnumerable<Employee>>(HttpMethod.Get, ConfigurationUtility.GetConfigValue<string>("MasGlobalTestApiEmployeesUrl"));

            if (response == null)
                return null;

            var list = response.Select(employee => _factory.MapEmployee(employee, _mapper));

            return id > 0 ? list.Where(r => r.Id == id) : list;
        }
    }
}
