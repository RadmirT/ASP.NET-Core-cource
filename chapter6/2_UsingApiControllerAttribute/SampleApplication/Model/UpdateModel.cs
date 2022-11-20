using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Model
{
    public class UpdateModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
