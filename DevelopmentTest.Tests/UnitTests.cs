using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTest.Business.Services.Implementation;
using DevelopmentTest.Model.Automapper;
using DevelopmentTest.Model.Factory;
using DevelopmentTest.Utility.RequestTools.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopmentTest.Tests
{
    [TestClass]
    public class UnitTests
    {
        public readonly IMapper _mapper;
        public UnitTests()
        {
            Mapper.Reset();
            AutoMapperConfiguration.Configure();
            _mapper = Mapper.Instance;
        }

        [TestMethod]
        public async Task GetOneEmployee()
        {
            const int iEmployeeNumber = 1;
            var oEmployeeService = new EmployeeService(new RequestTools(), new Factory(), _mapper);
            var employees = await oEmployeeService.GetEmployeesAsync(iEmployeeNumber);
            Assert.AreEqual(employees.Count(), 1);
        }

        [TestMethod]
        public async Task GetMultipleEmployees()
        {
            const int iEmployeeNumber = 0;
            var oEmployeeService = new EmployeeService(new RequestTools(), new Factory(), _mapper);
            var employees = await oEmployeeService.GetEmployeesAsync(iEmployeeNumber);
            Assert.AreNotEqual(employees.Count(), 1);
        }

        [TestMethod]
        public async Task GetNoneEmployee()
        {
            const int iEmployeeNumber = 10000;
            var oEmployeeService = new EmployeeService(new RequestTools(), new Factory(), _mapper);
            var employees = await oEmployeeService.GetEmployeesAsync(iEmployeeNumber);
            Assert.AreEqual(employees.Count(), 0);
        }
    }
}
