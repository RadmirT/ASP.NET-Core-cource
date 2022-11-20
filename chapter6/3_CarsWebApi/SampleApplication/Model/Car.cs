using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Model
{
    public class Car
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
    }
}
