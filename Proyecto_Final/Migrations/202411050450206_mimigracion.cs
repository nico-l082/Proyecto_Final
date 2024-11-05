namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mimigracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Juegoes", "ImagenUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Juegoes", "ImagenUrl");
        }
    }
}
