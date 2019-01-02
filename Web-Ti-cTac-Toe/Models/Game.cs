using System.ComponentModel.DataAnnotations;

namespace Web_Tic_Tac_Toe.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public bool YouWin { get; set; }
        [MaxLength(1000)]
        [Required]
        public string MoveGame { get; set; }       
    }
}