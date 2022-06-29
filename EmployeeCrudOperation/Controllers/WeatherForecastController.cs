using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeCrudOperation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();

        #region 24-06 hansOn
        [HttpPost]
        public ActionResult AddAEmployee(int EmpId, string EmployeeName, int EmployeeAge, string EmployeeAddres)
        {
            employeeList.Add(new EmployeeDetails { EmpId = EmpId, EmployeeName = EmployeeName, EmployeeAge = EmployeeAge, EmployeeAddress = EmployeeAddres });
            int i = employeeList.Count();
            return Ok("New Employeed Added!!");
        }

        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            return Ok(employeeList);

        }

        [HttpPut]
        public ActionResult UpdateAEmployeeDetails(int EmpId, string empName, int EmpAge, string Address)
        {
            var editEmployee = employeeList.Where(obj => obj.EmpId == EmpId).FirstOrDefault();
            if (editEmployee != null)
            {
                editEmployee.EmployeeName = empName;
                editEmployee.EmployeeAge = EmpAge;
                editEmployee.EmployeeAddress = Address;

                return Ok($"EmpId: {EmpId} details updated.");
            }
            else
            {
                return Ok($"EmpId: {EmpId} not found");
            }

        }

        [HttpDelete]
        public ActionResult RemoveEmployee(int EmpId)
        {
            var editEmployee = employeeList.Where(obj => obj.EmpId == EmpId).FirstOrDefault();
            if (editEmployee != null)
            {
                employeeList.Remove(editEmployee);

                return Ok($"EmpId: {EmpId} removed from employee list.");
            }
            else
            {
                return Ok($"EmpId: {EmpId} not found");
            }
        }
        #endregion

    }
}