namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicialPereiraCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabricantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modelos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Quantidade = c.Int(nullable: false),
                        FabricanteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fabricantes", t => t.FabricanteId, cascadeDelete: true)
                .Index(t => t.FabricanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modelos", "FabricanteId", "dbo.Fabricantes");
            DropIndex("dbo.Modelos", new[] { "FabricanteId" });
            DropTable("dbo.Modelos");
            DropTable("dbo.Fabricantes");
        }
    }
}
