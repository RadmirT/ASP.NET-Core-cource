using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.shopping.com.Controllers
{
    //[EnableCors] // Использует политику по умолчанию заданную методом UseCors("AllowShoppingApp");
    [EnableCors("AllowShoppingApp")] // Использует конкретную политику.
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // [DisableCors] // Отключает использование CORS
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
               "Aunt Hattie's",
                "Danish",
                "Cobblestone",
                "Dave's Killer Bread",
                "Entenmann's",
                "Famous Amos",
                "Home Pride",
                "Hovis",
                "Keebler Company",
                "Kits",
                "McVitie's",
                "Mother's Pride",
            };
        }
    }
}
