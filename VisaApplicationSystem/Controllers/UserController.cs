using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using VisaApplicationSystem.Data;
using VisaApplicationSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VisaApplicationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<UserController>
        public IEnumerable<UserProfiles> Get()
        {
            var userprofile = dbContext.UserProfiles
                            .ToList();
           
            return userprofile;
            
        }

       

        // POST api/<UserController>
        [HttpPost]
        public bool Post(UserProfiles userProfile)
        {
            try
            {
                userProfile.Password = GetHashPassword(userProfile.Password);
                dbContext.UserProfiles.Add(userProfile);

                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public string GetHashPassword(string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Encoding.ASCII.GetBytes("visa"),
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
        // PUT api/<UserController>/5
        [HttpPut]
        public void Put(UserProfiles userprofile)
        {
            var user = dbContext.UserProfiles.FirstOrDefault(item => item.UserId == userprofile.UserId);
            if (user != null)
            {
                user.Name = userprofile.Name;
                user.Email = userprofile.Email;
                user.PhoneNo = userprofile.PhoneNo;
                user.Username = userprofile.Username;
            if(userprofile.Password!= null && userprofile.Password != "")
                {
                    user.Password = GetHashPassword(userprofile.Password);
                }
                dbContext.SaveChanges();
            }
        }
       
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
