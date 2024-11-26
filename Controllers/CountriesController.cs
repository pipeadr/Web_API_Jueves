using Microsoft.AspNetCore.Mvc;
using Web_API_Jueves.DAL.Entities;
using Web_API_Jueves.Domain.Interfaces;

namespace Web_API_Jueves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var contries = await _countryService.GetCountriesAsync();
            if (contries == null || !contries.Any())
            {
                return NotFound();
            }
            return Ok(contries);

        }


        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var contry = await _countryService.GetCountryByIdAsync(id);
            if (contry == null)
            {
                return NotFound();
            }
            return Ok(contry);

        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountryawait = await _countryService.CreateCountryAsync(country);
                if (newCountryawait == null) {
                    return NotFound();
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Update")]
        [Route("Update")]
        public async Task<ActionResult<Country>> UpdateCountryAsync(Country country) 
        {
            try
            {
                var updatedCountrt = await _countryService.UpdateCountryAsync(country);
                if (updatedCountrt == null)
                {
                    return NotFound();
                }
                return Ok(updatedCountrt);

            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));

                return Conflict(ex.Message);
            }
        
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            //if (id == null) return BadRequest();
            if (id == Guid.Empty) return BadRequest();
            var deletedCountry = await _countryService.DeleteCountryAsync(id);
            if (deletedCountry == null) return NotFound();
            return Ok("Borrado satisfactoriamente");
        }



    }
}
