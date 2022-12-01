namespace SampleApplication.ServicesLayer
{
    public class MapService
    {
        public MapService(IConfiguration configuration)
        {
            ZoomLevel = configuration["MapSettings:DefaultZoomLevel"];
            Latitude = configuration["MapSettings:DefaultLocation:Latitude"];
        }

        public string ZoomLevel { get; private set; }
        public string Latitude { get; private set; }
    }
}
