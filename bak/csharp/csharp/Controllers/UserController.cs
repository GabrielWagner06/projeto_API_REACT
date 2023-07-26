using csharp.Estities;
using csharp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly object entity;

        [HttpGet]
        public ActionResult<string> Get(int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    UserEntity result = new UserRepository().GetById(id);
                    return result != null ? Ok(result) : StatusCode(404, "nenhu esultado encontrador");
                }
                else
                {
                    
                    if (User.IsInRole("Admin"))
                    {
                        List<UserEntity> result = new UserRepository().All;
                        return result != null ? Ok(result) : StatusCode(404, "Nenhum resultado encontreado");
                    }

                    return Forbid();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, @$"Erro {ex}");
            }
        }
       

        [HttpPost]
        // cada metodo que vc queiser booquer se nao for adm ou chef faça isso, esse comando a seguir celesiona os que podem asseçar esse comando
        [Authorize(Roles = "Admin")]
        public ActionResult Save([FromBody] UserEntity body)
        {
            try
            {
                new UserRepository().Save(body);
                return Ok("salvo com sucesso!!!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500,@$"Erro {ex}");
            }
        }



        [HttpPut]
        public ActionResult Update([FromBody] UserEntity body)
        {
            try
            {
                new UserRepository().Update(body);


                return Ok("alteraçao concluida com suceso");
                
            }
            catch (Exception ex)
            {
                return BadRequest(@$"Erro {ex}");
            }
        }


        [HttpDelete]
        public ActionResult Delete([FromBody] UserEntity body)
        {
            try
            {
                new UserRepository().Delete(body);
                return Ok("delete");
            }
            catch (Exception ex)
            {
                return BadRequest(@$"Erro {ex}");
            }
        }
        [HttpGet("all")]
        public ActionResult<List<UserEntity>> GetAll()
        {
            try
            {
                List<UserEntity> result = new UserRepository().GetLoog();
                return Ok(result);
            
            }
            catch (Exception ex)
            {
                return BadRequest(@$"Erro {ex}");
            }
        }
        /*[HttpPost("loogin")]
        
        public ActionResult<string> GetLoog([FromBody]string st_login, string st_password)
        {
            try
            {
                UserEntity result = new UserRepository().PostLoog(st_login, st_password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(@$"Erro {ex}");
            }
        }*/
    }
}
