namespace Proyecto_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdUsuarios = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        Email = c.String(),
                        Contraseña = c.String(),
                        Miembro = c.Int(),
                        CantJuegos = c.Int(),
                        BiblioJuegos = c.Int(),
                        MiembroNavigation_IdMiembros = c.Int(),
                        BiblioJuegosNavigation_IdBiblio = c.Int(),
                    })
                .PrimaryKey(t => t.IdUsuarios)
                .ForeignKey("dbo.MiembrosPlus", t => t.MiembroNavigation_IdMiembros)
                .ForeignKey("dbo.Bibliotecas", t => t.BiblioJuegosNavigation_IdBiblio)
                .Index(t => t.MiembroNavigation_IdMiembros)
                .Index(t => t.BiblioJuegosNavigation_IdBiblio);
            
            CreateTable(
                "dbo.Bibliotecas",
                c => new
                    {
                        IdBiblio = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Juegos = c.Int(),
                        JuegosNavigation_IdJuegos = c.Int(),
                    })
                .PrimaryKey(t => t.IdBiblio)
                .ForeignKey("dbo.Juegoes", t => t.JuegosNavigation_IdJuegos)
                .Index(t => t.JuegosNavigation_IdJuegos);
            
            CreateTable(
                "dbo.Juegoes",
                c => new
                    {
                        IdJuegos = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Genero = c.String(),
                        ItiPlus = c.Int(),
                        Precio = c.Decimal(precision: 18, scale: 2),
                        Desarrolladora = c.String(),
                        ItiPlusNavigation_IdTipoMembresia = c.Int(),
                    })
                .PrimaryKey(t => t.IdJuegos)
                .ForeignKey("dbo.TipoMembresiums", t => t.ItiPlusNavigation_IdTipoMembresia)
                .Index(t => t.ItiPlusNavigation_IdTipoMembresia);
            
            CreateTable(
                "dbo.TipoMembresiums",
                c => new
                    {
                        IdTipoMembresia = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(),
                        TipoNavigation_IdMembresia = c.Int(),
                    })
                .PrimaryKey(t => t.IdTipoMembresia)
                .ForeignKey("dbo.Membresiums", t => t.TipoNavigation_IdMembresia)
                .Index(t => t.TipoNavigation_IdMembresia);
            
            CreateTable(
                "dbo.MiembrosPlus",
                c => new
                    {
                        IdMiembros = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(),
                        PrecioMembresia = c.Decimal(precision: 18, scale: 2),
                        FormaPago = c.String(),
                        CantidadJuegosMembresia = c.Int(),
                        Vigencia = c.DateTime(),
                        TipoNavigation_IdTipoMembresia = c.Int(),
                    })
                .PrimaryKey(t => t.IdMiembros)
                .ForeignKey("dbo.TipoMembresiums", t => t.TipoNavigation_IdTipoMembresia)
                .Index(t => t.TipoNavigation_IdTipoMembresia);
            
            CreateTable(
                "dbo.Membresiums",
                c => new
                    {
                        IdMembresia = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Detalle = c.String(),
                        TipoMembresia = c.Int(),
                    })
                .PrimaryKey(t => t.IdMembresia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "BiblioJuegosNavigation_IdBiblio", "dbo.Bibliotecas");
            DropForeignKey("dbo.TipoMembresiums", "TipoNavigation_IdMembresia", "dbo.Membresiums");
            DropForeignKey("dbo.Usuarios", "MiembroNavigation_IdMiembros", "dbo.MiembrosPlus");
            DropForeignKey("dbo.MiembrosPlus", "TipoNavigation_IdTipoMembresia", "dbo.TipoMembresiums");
            DropForeignKey("dbo.Juegoes", "ItiPlusNavigation_IdTipoMembresia", "dbo.TipoMembresiums");
            DropForeignKey("dbo.Bibliotecas", "JuegosNavigation_IdJuegos", "dbo.Juegoes");
            DropIndex("dbo.MiembrosPlus", new[] { "TipoNavigation_IdTipoMembresia" });
            DropIndex("dbo.TipoMembresiums", new[] { "TipoNavigation_IdMembresia" });
            DropIndex("dbo.Juegoes", new[] { "ItiPlusNavigation_IdTipoMembresia" });
            DropIndex("dbo.Bibliotecas", new[] { "JuegosNavigation_IdJuegos" });
            DropIndex("dbo.Usuarios", new[] { "BiblioJuegosNavigation_IdBiblio" });
            DropIndex("dbo.Usuarios", new[] { "MiembroNavigation_IdMiembros" });
            DropTable("dbo.Membresiums");
            DropTable("dbo.MiembrosPlus");
            DropTable("dbo.TipoMembresiums");
            DropTable("dbo.Juegoes");
            DropTable("dbo.Bibliotecas");
            DropTable("dbo.Usuarios");
        }
    }
}
