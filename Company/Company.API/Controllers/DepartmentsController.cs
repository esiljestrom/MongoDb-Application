using Company.API.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDbService _db;
        public DepartmentsController(IDbService db)
        {
            _db = db;
        }


        // GET-ALL (READ)
        [HttpGet]
        public async Task<IResult> Get()
        {
            return await _db.HttpGetAsync<Department, DepartmentDTO>();
        }

        // GET (READ) api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            return await _db.HttpGetAsync<Department, DepartmentDTO>(id);
        }

        // POST (CREATE)
        [HttpPost]
        public async Task<IResult> Post(DepartmentDTO dto)
        {
            return await _db.HttpPostAsync<Department, DepartmentDTO>(dto);
        }

        // PUT (UPDATE) api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, DepartmentDTO dto)
        {
            return await _db.HttpPutAsync<Department, DepartmentDTO>(id, dto);
        }



        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            return await _db.HttpDeleteAsync<Department>(id);
        }
    }
}
