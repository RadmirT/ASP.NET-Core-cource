using Microsoft.AspNetCore.Mvc;
using SampleApplication.Model;

namespace SampleApplication.Controllers
{

    [Route("[controller]")]
    public class NoAttributeController : ControllerBase
    {
        List<string> _fruit = new List<string>
        {
            "Pear", "Lemon", "Peach"
        };

        [HttpGet]
        public ActionResult Update()
        {
            return this.Ok(this._fruit);
        }

        [HttpPost]
        public ActionResult Update([FromBody] UpdateModel model) // Атрибут[FromBody] указывает на то, что параметр должен быть привязан к телу запроса 
        {
            if (!this.ModelState.IsValid) //Нужно проверить, была ли валидация модели успешной и вернуть ответ с кодом состояния 400, если она не удалась
            {
                return this.BadRequest(new ValidationProblemDetails(this.ModelState));
            }

            if (model.Id < 0 || model.Id > this._fruit.Count)
            {
                
                return NotFound(new ProblemDetails()  //Если отправленные данные не содержат допустимого идентификатора, вернуть ответ 404 
                {
                    Status = 404,
                    Title = "Not Found",
                    Type = "https://tools.ietf.org/html/rfc7231"
                           + "#section-6.5.4",
                });

            }

            this._fruit[model.Id] = model.Name;

            return this.Ok();
        }
    }
}
