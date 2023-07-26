using csharp.Estities;
using csharp.Services.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : UserEntity
    {
        [HttpPost]

        public ActionResult Login(string login, string password)
        {
            try
            {
                UserEntity user = new LoginRepository().Login(login, password);

                if (user != null)
                {
                    return Ok(new
                    {
                        UserData = user,
                        Token = TokenService.GenerateToken(user)
                    });
                }
                return StatusCode(404, $@"usuario nao encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode($@"Erro {ex}");

            }
        }

        private ActionResult StatusCode(string v)
        {
            throw new NotImplementedException();
        }

        private ActionResult StatusCode(int v1, string v)
        {
            throw new NotImplementedException();
        }

        private ActionResult Ok(object value)
        {
            throw new NotImplementedException();
        }
    }
}
