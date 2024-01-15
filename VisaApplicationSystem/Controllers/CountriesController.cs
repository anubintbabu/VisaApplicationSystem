using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using VisaApplicationSystem.Data;
using VisaApplicationSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VisaApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CountriesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<Countries> Get()
        {
            var countries = dbContext.Countries.ToList();
            return countries;
        }
       
        
    }
}
