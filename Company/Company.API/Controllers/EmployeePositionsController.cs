using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionsController : ControllerBase
    {
        private readonly IDbService _db;
        public EmployeePositionsController(IDbService db)
        {
            _db = db;
        }

        // POST (CREATE)
        [HttpPost]
        public async Task<IResult> Post(EmployeePositionDTO dto)
        {
            return await _db.HttpPostAsync<EmployeePosition, EmployeePositionDTO>(dto);
        }

        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(EmployeePositionDTO dto)
        {
            return await _db.HttpDeleteAsync<EmployeePosition, EmployeePositionDTO>(dto);
        }
    }
}
