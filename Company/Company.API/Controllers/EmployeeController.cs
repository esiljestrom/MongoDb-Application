using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDbService _db;
        public EmployeeController(IDbService db)
        {
            _db = db;
        }


        // GET-ALL (READ)
        [HttpGet]
        public async Task<IResult> Get()
        {
            return await _db.HttpGetAsync<Employee, EmployeeDTO>();
        }

        // GET (READ) api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            return await _db.HttpGetAsync<Employee, EmployeeDTO>(id);
        }

        // POST (CREATE)
        [HttpPost]
        public async Task<IResult> Post(EmployeeDTO dto)
        {
            return await _db.HttpPostAsync<Employee, EmployeeDTO>(dto);
        }

        // PUT (UPDATE) api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, EmployeeDTO dto)
        {
            return await _db.HttpPutAsync<Employee, EmployeeDTO>(id, dto);
        }



        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            return await _db.HttpDeleteAsync<Employee>(id);
        }
    }
}
