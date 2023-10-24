using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;
        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Employee employee = _dataRepository.Get(id);

            if (employee == null) return NotFound("The Employee record could not be found.");

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Employee is null.");

            _dataRepository.Add(employee);

            return CreatedAtAction(nameof(Get), new {Id = employee.EmployeeId},employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]Employee employee)
        {
            if (employee == null) return BadRequest("Employee is null.");

            Employee employeeToUpdate = _dataRepository.Get(id);

            if (employeeToUpdate == null) return NotFound("The Employee record could not be found.");

            _dataRepository.Update(employeeToUpdate, employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = _dataRepository.Get(id);

            if (employee == null) return NotFound("The Employee record could not be found.");

            _dataRepository.Delete(employee);

            return NoContent();
        }
    }
}
