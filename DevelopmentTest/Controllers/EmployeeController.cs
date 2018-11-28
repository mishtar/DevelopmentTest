using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DevelopmentTest.Business.Services.Interface;
using Swashbuckle.Swagger.Annotations;

namespace DevelopmentTest.Controllers
{
    /// <summary>
    /// Retrieve employee related data
    /// </summary>
    [RoutePrefix("api/v1/Employees")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Return a list of employees
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation("Employees/GetEmployees")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [HttpGet]
        [Route("GetEmployees")]
        // GET: api/v1/Employees/GetEmployees
        public async Task<IHttpActionResult> Get([FromUri] int id = 0)
        {
            var result = await _employeeService.GetEmployeesAsync(id);
            return Ok(result);
        }
    }
}