using Web_API_Jueves.DAL.Entities;

namespace Web_API_Jueves.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> UpdateCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);
    }
}
