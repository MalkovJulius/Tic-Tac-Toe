using System.ComponentModel.DataAnnotations;

namespace Web_Tic_Tac_Toe.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [MaxLength(50)]
        [Required]
        public string NameOfWinner { get; set; }
        [MaxLength(1000)]        
        public string DescriptionGame { get; set; }       
        public int? PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}