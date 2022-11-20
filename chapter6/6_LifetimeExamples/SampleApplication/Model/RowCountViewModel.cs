namespace SampleApplication.Model
{
    public class RowCountViewModel
    {
        public Count Current { get; set; }
        public List<Count> Previous { get; set; }

        public class Count
        {
            public int DataContext { get; set; }
            public int Repository { get; set; }
        }
    }
}
