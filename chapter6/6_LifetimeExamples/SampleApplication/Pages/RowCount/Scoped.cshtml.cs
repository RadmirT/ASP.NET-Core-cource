using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.Model;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages.RowCount
{
    public class ScopedModel : PageModel
    {
        private readonly static List<RowCountViewModel.Count> _previousCounts = new(); // c#9 feature - target typing
        public RowCountViewModel RowCounts { get; set; }

        private readonly ScopedRepository _scopedRepo;
        private readonly ScopedDataContext _scopedDataContext;

        public ScopedModel(
            ScopedRepository scopedRepo,
            ScopedDataContext scopedDataContext
            )
        {
            this._scopedRepo = scopedRepo;
            this._scopedDataContext = scopedDataContext;
        }

        public void OnGet()
        {
            var count = new RowCountViewModel.Count
            {
                DataContext = this._scopedDataContext.RowCount,
                Repository = this._scopedRepo.RowCount,
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
