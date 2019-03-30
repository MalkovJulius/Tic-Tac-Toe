namespace Web_Ti_cTac_Toe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        SchoreWin = c.Int(nullable: false),
                        SchoreLose = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
