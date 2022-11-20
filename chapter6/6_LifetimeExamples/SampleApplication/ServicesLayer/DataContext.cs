namespace SampleApplication.ServicesLayer
{
    public class DataContext
    {
        static readonly Random _rand = new Random();
        public DataContext()
        {
            this.RowCount = _rand.Next(1, 1_000_000_000);
        }

        public int RowCount { get; }
    }

    public class TransientDataContext : DataContext { }
    public class ScopedDataContext : DataContext { }
    public class SingletonDataContext : DataContext { }

}
