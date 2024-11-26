using Microsoft.EntityFrameworkCore;
using Web_API_Jueves.DAL;
using Web_API_Jueves.DAL.Entities;
using Web_API_Jueves.Domain.Interfaces;

namespace Web_API_Jueves.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
            
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            //var countries = await _context.Countries.ToListAsync();
            //return countries;

            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
           var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            var country1 = await _context.Countries.FindAsync(id);
            var country2 = await _context.Countries.FirstAsync(c => c.Id == id);

            return country;
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);
                if (country == null) {
                    return null;
                }
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
