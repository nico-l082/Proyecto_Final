using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Final.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeTuMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    idAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    contraseña = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__B2C3ADE5F2A5DF96", x => x.idAdmin);
                });

            migrationBuilder.CreateTable(
                name: "Membresia",
                columns: table => new
                {
                    idMembresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    detalle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tipoMembresia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Membresi__BDDB80E94CDE81D8", x => x.idMembresia);
                });

            migrationBuilder.CreateTable(
                name: "TipoMembresia",
                columns: table => new
                {
                    idTipoMembresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoMemb__1D164B22339793F0", x => x.idTipoMembresia);
                    table.ForeignKey(
                        name: "Tipo_Memb_FK",
                        column: x => x.tipo,
                        principalTable: "Membresia",
                        principalColumn: "idMembresia");
                });

            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    idJuegos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    genero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    itiPlus = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<decimal>(type: "money", nullable: true),
                    desarrolladora = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    imagenURL = table.Column<string>(type: "varchar(225)", unicode: false, maxLength: 225, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Juegos__E4EEF679CB006B0B", x => x.idJuegos);
                    table.ForeignKey(
                        name: "Juegos_TipoMemb_FK",
                        column: x => x.itiPlus,
                        principalTable: "TipoMembresia",
                        principalColumn: "idTipoMembresia");
                });

            migrationBuilder.CreateTable(
                name: "MiembrosPlus",
                columns: table => new
                {
                    idMiembros = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<int>(type: "int", nullable: true),
                    precioMembresia = table.Column<decimal>(type: "money", nullable: true),
                    formaPago = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cantidadJuegosMembresia = table.Column<int>(type: "int", nullable: true),
                    vigencia = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Miembros__F1261B7C5B75030D", x => x.idMiembros);
                    table.ForeignKey(
                        name: "Plus_TipoMemb_FK",
                        column: x => x.tipo,
                        principalTable: "TipoMembresia",
                        principalColumn: "idTipoMembresia");
                });

            migrationBuilder.CreateTable(
                name: "Biblioteca",
                columns: table => new
                {
                    idBiblio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    juegos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bibliote__C721831F871764D8", x => x.idBiblio);
                    table.ForeignKey(
                        name: "biblio_Juego_fk",
                        column: x => x.juegos,
                        principalTable: "Juegos",
                        principalColumn: "idJuegos");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    contraseña = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    miembro = table.Column<int>(type: "int", nullable: true),
                    cantJuegos = table.Column<int>(type: "int", nullable: true),
                    biblioJuegos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3940559A03D1B9BB", x => x.idUsuarios);
                    table.ForeignKey(
                        name: "Usu_Memb_fk",
                        column: x => x.miembro,
                        principalTable: "MiembrosPlus",
                        principalColumn: "idMiembros");
                    table.ForeignKey(
                        name: "usu_biblio_fk",
                        column: x => x.biblioJuegos,
                        principalTable: "Biblioteca",
                        principalColumn: "idBiblio");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_juegos",
                table: "Biblioteca",
                column: "juegos");

            migrationBuilder.CreateIndex(
                name: "IX_Juegos_itiPlus",
                table: "Juegos",
                column: "itiPlus");

            migrationBuilder.CreateIndex(
                name: "IX_MiembrosPlus_tipo",
                table: "MiembrosPlus",
                column: "tipo");

            migrationBuilder.CreateIndex(
                name: "IX_TipoMembresia_tipo",
                table: "TipoMembresia",
                column: "tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_biblioJuegos",
                table: "Usuarios",
                column: "biblioJuegos");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_miembro",
                table: "Usuarios",
                column: "miembro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "MiembrosPlus");

            migrationBuilder.DropTable(
                name: "Biblioteca");

            migrationBuilder.DropTable(
                name: "Juegos");

            migrationBuilder.DropTable(
                name: "TipoMembresia");

            migrationBuilder.DropTable(
                name: "Membresia");
        }
    }
}
