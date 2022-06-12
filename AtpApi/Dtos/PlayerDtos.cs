using AtpApi.Models;
using System.ComponentModel.DataAnnotations;

namespace AtpApi.Dtos
{
    public class PlayerDtos
    {
        [Required]
        [StringLength(50,ErrorMessage ="Max 50 letters")]
        public string Name { get; set; }
        [Required]
        [Range(15,60)]
        public int Age { get; set; }
        [Required]
        [RangeUntilCurrentYear(1990, ErrorMessage = "Please enter a valid year")]
        public int TurnedPro { get; set; }
        [Required]
        [Range(40,100)]
        public int Weight { get; set; }
        [Required]
        [Range(140, 220)]
        public int Height { get; set; }
        [StringLength(50, ErrorMessage = "Max 50 letters")]

        public string CoachName { get; set; }

        [Required]
        public int NoOfTitles { get; set; }


        public int CountryId { get; set; }

        public Country country { get; set; }
    }
}
