using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dtos.CreateLoginDto;
using RealEstateApi.Models.DapperContext;
using RealEstateApi.Tools;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SignIn(LoginDto dto)
        {
            string query = "select * from AppUser where Username=@UserName and Password=@Password";
            var parametres = new DynamicParameters();
            parametres.Add("UserName", dto.UserName);
            parametres.Add("Password", dto.Password);
            using(var connection = _context.CreateConnection())
            {
                var login = connection.QueryFirstOrDefault<LoginResultDto>(query,parametres);
                if (login != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.Id = login.Id;
                    model.UserName = login.UserName;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("başarısız!");

                }
            }
        }
    }
}
