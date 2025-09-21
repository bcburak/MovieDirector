using MovieDirectorApp.Domain.Entities;

namespace MovieDirectorApp.Domain.Interfaces
{
    public interface IDirectorRepository //: IGenericRepository<Entities.Director>
    {
        Task AddAsync(Director entity);
        Task DeleteAsync(string id);
    }
}
