using System.ComponentModel.DataAnnotations;

namespace AtpApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int TurnedPro { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Height { get; set; }

        public string CoachName { get; set; }

        [Required]
        public int NoOfTitles { get; set; }

        
        public int CountryId { get; set; }
        public Country country { get; set; }
    }
}
