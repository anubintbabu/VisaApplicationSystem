using Microsoft.AspNetCore.Mvc;
using VisaApplicationSystem.Data;
using VisaApplicationSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VisaApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaTypesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VisaTypesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<VisaTypesController>
        [HttpGet]
        public IEnumerable<VisaTypes> Get()
        {
            var visatypes = dbContext.VisaTypes.ToList();
            return visatypes;
        }
    }
}
