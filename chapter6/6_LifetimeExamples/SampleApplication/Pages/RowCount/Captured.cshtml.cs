using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.Model;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages.RowCount
{
    public class CapturedModel : PageModel
    {
        private readonly static List<RowCountViewModel.Count> _previousCounts = new();
        public RowCountViewModel RowCounts { get; set; }

        private readonly CapturingRepository _capturingRepo;
        private readonly ScopedDataContext _scopedDataContext;

        public CapturedModel(
            CapturingRepository capturingRepo,
            ScopedDataContext scopedDataContext
            )
        {
            this._capturingRepo = capturingRepo;
            this._scopedDataContext = scopedDataContext;
        }

        public void OnGet()
        {
            var count = new RowCountViewModel.Count
            {
                DataContext = this._scopedDataContext.RowCount,
                Repository = this._capturingRepo.RowCount,
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
