namespace Web_Ti_cTac_Toe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "PlayerId", c => c.Int());
            CreateIndex("dbo.Games", "PlayerId");
            AddForeignKey("dbo.Games", "PlayerId", "dbo.Players", "PlayerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PlayerId", "dbo.Players");
            DropIndex("dbo.Games", new[] { "PlayerId" });
            DropColumn("dbo.Games", "PlayerId");
        }
    }
}
