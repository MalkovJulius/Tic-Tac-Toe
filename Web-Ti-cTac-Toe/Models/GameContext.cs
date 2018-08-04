namespace Web_Tic_Tac_Toe.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GameContext : DbContext
    {
        // Контекст настроен для использования строки подключения "GameContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Web_Tic_Tac_Toe.Models.GameContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "GameContext" 
        // в файле конфигурации приложения.
        public DbSet<Game> Games { get; set; }

        public GameContext()
            : base("name=GameContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //в данном классе я не уверен
    public class GameDbInitializer : DropCreateDatabaseAlways<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            context.Games.Add(new Game { YouWin = true, MoveGame = "some step of player" });
            base.Seed(context);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}