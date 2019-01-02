namespace Web_Tic_Tac_Toe.Models
{
    using System.Data.Entity;

    public class GameContext : DbContext
    {        
        public DbSet<Game> Games { get; set; }

        public GameContext()
            : base("name=GameContext")
        {
        }
    }

}