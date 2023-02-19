using WebAppMVS.Models;

namespace WebAppMVS.Interfaces;

public interface IRaceRepository
{
    Task<IEnumerable<Race>> GetAll();

    Task<Race> GetByIdAsync(int id);

    Task<IEnumerable<Race>> GetClubByCity(string city);

    bool Add(Race race);

    bool Update(Race race);

    bool Delete(Race race);

    bool Save();

}