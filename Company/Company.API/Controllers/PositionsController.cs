using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IDbService _db;
        public PositionsController(IDbService db)
        {
            _db = db;
        }


        // GET-ALL (READ)
        [HttpGet]
        public async Task<IResult> Get()
        {
            return await _db.HttpGetAsync<Position, PositionDTO>();
        }

        // GET (READ) api/<PositionsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            return await _db.HttpGetAsync<Position, PositionDTO>(id);
        }

        // POST (CREATE)
        [HttpPost]
        public async Task<IResult> Post(PositionDTO dto)
        {
            return await _db.HttpPostAsync<Position, PositionDTO>(dto);
        }

        // PUT (UPDATE) api/<PositionsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, PositionDTO dto)
        {
            return await _db.HttpPutAsync<Position, PositionDTO>(id, dto);
        }



        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            return await _db.HttpDeleteAsync<Position>(id);
        }
    }
}
