using System.ComponentModel.DataAnnotations;

namespace AtpApi.Dtos
{
    public class CountryDtos
    {
        [Required]
        public string Name { get; set; }
    }
}
