using Blazor.Dto;
using Blazor.Persistence.Repositories;
using Blazor.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Blazor.Server.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepositoryInterface _employeeRepository;

        public EmployeeController(EmployeeRepositoryInterface employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public ActionResult CreateEmployee(CreationEmployeeDto employeeDTO)
        {
            Employee employee = _employeeRepository.CreateEmployee(employeeDTO.Name, employeeDTO.Age);

            if (employee != null)
            {
                _employeeRepository.Save();
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTournament(Guid id)
        {
            bool employeeRemoved = _employeeRepository.DeleteEmployee(id);

            if (employeeRemoved)
            {
                _employeeRepository.Save();
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(_employeeRepository.GetEmployees());
        }

        [HttpGet("{identifier}")]
        public ActionResult<IEnumerable<Employee>> GetEmployee(string identifier)
        {
            if (Guid.TryParse(identifier, out Guid id))
            {
                return Ok(_employeeRepository.GetEmployee(id));
            }

            return Ok(_employeeRepository.GetEmployee(identifier));
        }
    }
}
