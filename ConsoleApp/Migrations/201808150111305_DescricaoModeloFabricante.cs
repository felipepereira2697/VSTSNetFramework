namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescricaoModeloFabricante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fabricantes", "Descricao", c => c.String(maxLength: 255));
            AddColumn("dbo.Modelos", "Descricao", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modelos", "Descricao");
            DropColumn("dbo.Fabricantes", "Descricao");
        }
    }
}
