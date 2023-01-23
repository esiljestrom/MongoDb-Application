using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Update;
using System.Formats.Asn1;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Company.Data.Services
{
    public class DbService : IDbService
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;
        public DbService(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST method
        public async Task<TEntity> AddToDb<TEntity, TDto>(TDto dto)
            where TEntity : class 
            where TDto : class
        {
            TEntity entity = _mapper.Map<TEntity>(dto); // Mappar om DTO från clienten till en entity
            await _context.Set<TEntity>().AddAsync(entity); // Lägger till entiteten till databasen
            return entity; 
        }

        //GET (all) method
        public async Task<List<TDto>> GetAllFromDb<TEntity, TDto>()
            where TEntity : class, IEntity
            where TDto : class
        {
            List<TEntity> entities = await _context.Set<TEntity>().ToListAsync(); // Hämtar alla entiteter av en viss entitetsklass från databasen
            List<TDto> dtos = _mapper.Map<List<TDto>>(entities); // Mappar om entiteterna till DTOs för att bara skicka med nödvändig data till clienten
            return dtos;
        }

        // GET method
        public async Task<TDto> GetFromDb<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
            where TDto : class
        {
            TEntity entity = await _context.Set<TEntity>().SingleAsync(expression); // expresssion: TEntity.Id = id från controller metoden
            TDto dto = _mapper.Map<TDto>(entity);
            return dto;
        }

        // UPDATE method

        public void UpdateToDb<TEntity, TDto>(int id, TDto dto)
            where TEntity : class, IEntity
            where TDto : class
        {
            TEntity entity = _mapper.Map<TEntity>(dto); 
            entity.Id = id; // Sätter entityns id till parameter-id
            _context.Set<TEntity>().Update(entity);
        }

        // DELETE method
        public async Task<bool> Delete<TEntity>(int id)
            where TEntity : class, IEntity
        {
            try
            {
            TEntity entity = await _context.Set<TEntity>().SingleAsync(e => e.Id == id);
            if (entity == null)
                return false;
            _context.Remove(entity);
            }
            catch { throw; }
            return true;
        }
        public bool Delete<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class
            where TDto : class
        {
            try
            {
                TReferenceEntity entity = _mapper.Map<TReferenceEntity>(dto);
                if (entity == null)
                    return false;
                _context.Remove(entity);
            }
            catch { throw; }
            return true;
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() >= 0;

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity => await _context.Set<TEntity>().AnyAsync(expression);
    }
}
