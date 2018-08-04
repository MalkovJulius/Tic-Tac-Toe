using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Tic_Tac_Toe.Models
{
    public class Game
    {
        [Key]
        public uint GameId { get; set; }
        public bool YouWin { get; set; }
        [MaxLength(1000)]
        [Required]
        public string MoveGame { get; set; }       
    }
}