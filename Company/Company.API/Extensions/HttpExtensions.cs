using System.ComponentModel;

namespace Company.API.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
            where TEntity : class, IEntity
            where TDto : class
        {
            List<TDto> dtos = await db.GetAllFromDb<TEntity, TDto>();
            return Results.Ok(dtos);
        }

        public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db, int id)
            where TEntity : class, IEntity
            where TDto : class
        {
            try
            {
            TDto dto = await db.GetFromDb<TEntity, TDto>(e => e.Id == id);
            if (dto == null) return Results.BadRequest("Bad request... ");
            return Results.Ok(dto);
            }
            catch
            {
                return Results.BadRequest("Bad request... ");
            }
        }

        public static async Task<IResult> HttpPostAsync<TEntity, TDto>(this IDbService db, TDto dto)
            where TEntity : class
            where TDto : class
        {
            try
            {
                TEntity entity = await db.AddToDb<TEntity, TDto>(dto);
                if (await db.SaveChangesAsync())
                    return Results.Created("Created: ", entity);
            }
            catch { return Results.BadRequest("Bad request. "); }

            return Results.BadRequest("Bad request. ");
        }

        public static async Task<IResult> HttpPutAsync<TEntity, TDto>(this IDbService db, int id, TDto dto)
            where TEntity : class, IEntity
            where TDto : class
        {
            try
            {
                if (!await db.AnyAsync<TEntity>(e => e.Id == id))
                    return Results.NotFound("Not found. ");
                db.UpdateToDb<TEntity, TDto>(id, dto);

                if (await db.SaveChangesAsync())
                    return Results.NoContent();
            }
            catch 
            { 
                return Results.BadRequest("Bad request. "); 
            }
            return Results.BadRequest("Bad request. ");
        }

        public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id)
            where TEntity : class, IEntity
        {
            try
            {
            if (!await db.Delete<TEntity>(id))
                return Results.NotFound("Not found. ");

            if (await db.SaveChangesAsync())
                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest("Bad request... ");
            }
            return Results.BadRequest("Bad request... ");
        }

        public static async Task<IResult> HttpDeleteAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto)
            where TReferenceEntity : class
            where TDto : class
        {
            try
            {
                if (!db.Delete<TReferenceEntity, TDto>(dto))
                    return Results.NotFound("Not found. ");

                if (await db.SaveChangesAsync())
                    return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest("Bad request... ");
            }
            return Results.BadRequest("Bad request... ");
        }


    }
}
