using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Data.Common;
using Company.API.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporationsController : ControllerBase
    {
        private readonly IDbService _db;
        public CorporationsController(IDbService db)
        {
            _db = db;
        }


        // GET-ALL (READ)
        [HttpGet]
        public async Task<IResult> Get()
        {
            return await _db.HttpGetAsync<Corporation, CorporationDTO>();
        }

        // GET (READ) api/<CorporationsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            return await _db.HttpGetAsync<Corporation, CorporationDTO>(id);
        }

        // POST (CREATE)
        [HttpPost]
        public async Task<IResult> Post(CorporationDTO dto)
        {
            return await _db.HttpPostAsync<Corporation, CorporationDTO>(dto);
        }

        // PUT (UPDATE) api/<CorporationsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, CorporationDTO dto)
        {
            return await _db.HttpPutAsync<Corporation, CorporationDTO>(id, dto);
        }



        // DELETE api/<CorporationsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            return await _db.HttpDeleteAsync<Corporation>(id);
        }
    }
}
