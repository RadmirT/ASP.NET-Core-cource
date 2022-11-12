using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoList.Pages
{
    public class CurrencyModel : PageModel
    {
        /// <summary>
        /// ��������, �������������� ��������� [BindProperty], ��������� ������� � �������� ������
        /// �������� �� ����� ��������� � ������ ��� GET-��������, ���� �� �� ����������� �������� SupportsGet
        /// </summary>
        
        //[BindProperty(SupportsGet = true)]
        public string Code { get; set; }
        public void OnGet(string code)
        {
            this.Code = code;
        }
    }
}
