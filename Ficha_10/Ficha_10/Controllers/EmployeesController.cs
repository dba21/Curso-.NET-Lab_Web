using Ficha_10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ficha_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Employees employees;

        public EmployeesController()
        {
            employees = JsonLoader.loadEmploeesJson();
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees.EmployeesL;
            
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id:int}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetId(int id)
        {
            Employee? emp = employees.EmployeesL.Find(e => e.UserId == id);
            if (emp == null)
            {
                return NotFound($"Id: {id} not Found.");
            }
            else
            {
                return Ok(emp);
            }
        }
        /*
        // POST api/<ValuesController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody] Employee employee)
        {
            if (employees.EmployeesL.Count == 0)
            {
                employee.UserId = 1;
                employees.EmployeesL.Add(employee);
            }
            else
            {
                var lastEmp = employees.EmployeesL[employees.EmployeesL.Count - 1];
                employee.UserId = lastEmp.UserId + 1;
                employees.EmployeesL.Add(employee);
            }
            return ("./JsonFiles/employees.json", employee);
        }
        */
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var emp = employees.EmployeesL.Find(e => e.UserId == id);
            if (emp == null)
            {
                return NotFound($"Id: {id} not found!");
            }
            else
            {
                emp.JobTitle = employee.JobTitle;
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.EmployeeCode = employee.EmployeeCode;
                emp.Region = employee.Region;
                emp.PhoneNumber = employee.PhoneNumber;
                emp.EmailAddress = employee.EmailAddress;
                return Ok(emp);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            int removed = employees.EmployeesL.RemoveAll(e => e.UserId == id);
            if (removed == 0)
            {
                return NotFound(string.Format("Id: {0} not found.", id));
            }
            else
            {
                return Ok(removed);
            }
        }
        /*
        //Download
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Download(int id)
        {
            string json = JsonSerializer.Serialize<Employees>(employees);
            //namespace.class.function
            System.IO.File.WriteAllText("./JsonFiles/employees.json", json);

            try
            {
                byte[] byteArray = System.IO.File.ReadAllBytes("./JsonFiles/employees.json");
                return File(byteArray, null, "./JsonFiles/employees.json");

            }
            catch(FileNotFoundException e)
            {
                return NotFound(e.Message);
            }

            //File um metodo,(FileContentResolt) Assinatura dos metodos é sempre a devolver Nome e Argumentos
        }*/
    }
}
