using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleApplication.Model;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Pages.RowCount
{
    public class TransientModel : PageModel
    {
        private readonly static List<RowCountViewModel.Count> _previousCounts = new();
        public RowCountViewModel RowCounts { get; set; }

        private readonly TransientRepository _transientRepo;
        private readonly TransientDataContext _transientDataContext;

        public TransientModel(
            TransientRepository transientRepo,
            TransientDataContext transientDataContext
            )
        {
            this._transientRepo = transientRepo;
            this._transientDataContext = transientDataContext;
        }

        public void OnGet()
        {
            var count = new RowCountViewModel.Count
            {
                DataContext = this._transientDataContext.RowCount,
                Repository = this._transientRepo.RowCount,
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
