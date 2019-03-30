using System.Data.Entity;

namespace Web_Tic_Tac_Toe.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        public GameContext()
            : base("name=GameContext")
        {
        }       
    }
}