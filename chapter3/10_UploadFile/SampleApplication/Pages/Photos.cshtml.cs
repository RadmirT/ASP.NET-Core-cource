using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApplication.Pages
{
    [IgnoreAntiforgeryToken]
    public class PhotosModel : PageModel
    {
        public void OnPost(
          [FromHeader] string userId,  //UserId будет привязан к HTTP-заголовку в запросе
           [FromBody] List<Photo> photos)  //Список объектов photo будет привязан к телу запроса, обычно в формате JSON

        {
            /* Реализация метода */
        }
    }

    public class Photo
    {
        public string Name { get; set; }
        public string Tags { get; set; }
    }
}

