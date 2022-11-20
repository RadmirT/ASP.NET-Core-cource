using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.Model;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages.RowCount
{
    public class SingletonModel : PageModel
    {
        private readonly static List<RowCountViewModel.Count> _previousCounts = new();
        public RowCountViewModel RowCounts { get; set; }

        private readonly SingletonRepository _singletonRepo;
        private readonly SingletonDataContext _singletonDataContext;

        public SingletonModel(
            SingletonRepository singletonRepo,
            SingletonDataContext singletonDataContext
            )
        {
            this._singletonRepo = singletonRepo;
            this._singletonDataContext = singletonDataContext;
        }

        public void OnGet()
        {
            var count = new RowCountViewModel.Count
            {
                DataContext = this._singletonDataContext.RowCount,
                Repository = this._singletonRepo.RowCount,
            };
            _previousCounts.Insert(0, count);
            this.RowCounts = new RowCountViewModel
            {
                Current = count,
                Previous = _previousCounts,
            };
        }
    }
}
