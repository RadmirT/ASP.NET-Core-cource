using Microsoft.AspNetCore.Mvc;
using SampleApplication.Model;

namespace SampleApplication.Controllers
{
    [ApiController] // При добавлении атрибута [ApiController] применяется несколько соглашений, общих для контроллеров API 
    [Route("[controller]")]
    public class FruitController : ControllerBase
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
        public ActionResult Update(UpdateModel model) //Модель проверяется автоматически и, если она недействительна, то возвращается ответ с кодом состояния 400 
        {
            if (model.Id < 0 || model.Id > this._fruit.Count)
            {
                return this.NotFound(); // Коды состояния ошибки автоматически преобразуются в объект ProblemDetails
            }

            this._fruit[model.Id] = model.Name;
            return this.Ok();
        }
    }
}
