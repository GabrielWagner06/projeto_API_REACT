using csharp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
       [HttpGet]
        [Route("ProductsView")]
        //[Authorize(Roles = "Admin")]
        public ActionResult GetProductsView()
        {
            try
            {
                var result = new ProductRepository().GetProductsView();
                return result != null ? Ok(result) : StatusCode(404, "Nenhum resultado encontrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex}");
            }
        }
     
     

    }
}
