using DataAccess.Contexts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OtoMuhasebe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
            using (var context = new OtoMuhasebeContext())
            {
                // Veritabanında kullanıcı yoksa varsayılan admin kullanıcısını oluştur
                if (!context.Users.Any())
                {
                    context.Users.Add(new User { Username = "admin", Password = "123" });
                    context.SaveChanges();
                }

                var user = context.Users.FirstOrDefault(x => x.Username == loginUser.Username && x.Password == loginUser.Password);
                if (user != null)
                {
                    return Ok(new { token = "fake-jwt-token-for-demo", user = user.Username });
                }
                return Unauthorized();
            }
        }
    }
}
