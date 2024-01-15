using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VisaApplicationSystem.Data;
using VisaApplicationSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VisaApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaApplicationsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VisaApplicationsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<VisaApplicationsController>
        [HttpGet]
        //public IEnumerable<VisaApplications> Get(int id)
        public IEnumerable<TableJoinResult> Get(int id) 
        {

            var applicationslist = (from i1 in dbContext.VisaApplications
                                    join j1 in dbContext.VisaTypes on i1.VisaType equals j1.Id
                                    where i1.CreatedBy.Equals(id)
                                    select new TableJoinResult { Table1 = i1, Table2 = j1 }).ToList();


            //var applicationslist = dbContext.VisaApplications.Where(b => b.CreatedBy == id)
            //        .ToList();

           
            foreach (var pair in applicationslist)
            {
                string photo = GetImage(applicationslist[0].Table1.Photo);
                applicationslist[0].Table1.Photo = photo;
            }
           
            return applicationslist;
            
        }
        public string GetImage(string image)
        {
            return "data:image/png;base64," + image;
        }

        
        // POST api/<VisaApplicationsController>
        [HttpPost]
        public void Post(VisaApplications visaApplication)
        {
            dbContext.VisaApplications.Add(visaApplication);

            dbContext.SaveChanges();
        }

        
    }
}
