namespace BSD.Business.Interfaces
{
    public interface ICrudHandler<TDbContext, TEntity, TDto>
    {
        bool CanCreate(TDbContext db, TEntity entity); 
        bool CanDelete(TDbContext db, TEntity entity);
        bool CanList(TDbContext db);
        bool CanRead(TDbContext db, TEntity entity);
        bool CanUpdate(TDbContext db, TEntity entity);

        TEntity? FindById(TDbContext db, long id);
        TEntity? FindByMatch(TDbContext db, TDto dto);
        IQueryable<TEntity> ListAll(TDbContext db);

        bool AttachToState(TDbContext db, TEntity entity);
        bool UpdateToState(TDbContext db, TEntity entity, TDto dto);
        bool DeleteFromState(TDbContext db, TEntity entity);
    }
}