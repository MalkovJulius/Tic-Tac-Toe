using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Tic_Tac_Toe.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int SchoreWin { get; set; }
        public int SchoreLose { get; set; }

        public virtual ICollection<Game> Games { get; set; } //test this solution        
    }
}