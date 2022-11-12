using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApplication.Pages
{
    [IgnoreAntiforgeryToken]
    public class PhotosModel : PageModel
    {
        public void OnPost(
          [FromHeader] string userId,  //UserId ����� �������� � HTTP-��������� � �������
           [FromBody] List<Photo> photos)  //������ �������� photo ����� �������� � ���� �������, ������ � ������� JSON

        {
            /* ���������� ������ */
        }
    }

    public class Photo
    {
        public string Name { get; set; }
        public string Tags { get; set; }
    }
}

