using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;

namespace Company.Data.Interfaces
{
    public interface IDbService
    {
        //Task<List<TDto>> GetAll<TEntity, TDto>()
        //    where TEntity : class, IEntity // TEntity måste vara en klass och implementera IEntity
        //    where TDto : class; //TDto måste vara en klass

        //Task<List<TDto>> GetAll<TEntity, TDto>(TEntity entity)
        //    where TEntity : class, IEntity;

        Task<List<TDto>> GetAllFromDb<TEntity, TDto>()
            where TEntity : class, IEntity
            where TDto : class;



        Task<TEntity> AddToDb<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class;

        Task<TDto> GetFromDb<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity
            where TDto : class;

        void UpdateToDb<TEntity, TDto>(int id, TDto dtdo)
            where TEntity : class, IEntity
            where TDto : class;

        Task<bool> Delete<TEntity>(int id)
            where TEntity : class, IEntity;

        bool Delete<TReferenceEntity, TDto>(TDto dto)
            where TReferenceEntity : class
            where TDto : class;

        Task<bool> SaveChangesAsync();

        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
            where TEntity : class, IEntity;


        //Task<TDto> GetFromDb<TEntity, TDto>(int id)
        //    where TEntity : class, IEntity
        //    where TDto : class;
    }
}
