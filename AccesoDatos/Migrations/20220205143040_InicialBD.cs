using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccesoDatos.Migrations
{
    public partial class InicialBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutCi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDescriptivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputaFalta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MesasOperativas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesasOperativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAsignado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grupo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SubGrupo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposContratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    CargaTrabajoDiaria = table.Column<double>(type: "float", nullable: false),
                    CargaTrabajoSemanal = table.Column<double>(type: "float", nullable: false),
                    Modalidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposContratos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDescriptivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geolocalizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCoordinacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelCoordinacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreContactoServicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelContactoServicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependeDeId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    GuardiaFisica = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_MesasOperativas_DependeDeId",
                        column: x => x.DependeDeId,
                        principalTable: "MesasOperativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    MesaOperativaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_MesasOperativas_MesaOperativaId",
                        column: x => x.MesaOperativaId,
                        principalTable: "MesasOperativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoContratoId = table.Column<int>(type: "int", nullable: true),
                    VtoCarneSalud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEmisionCAJ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SueldoNominal = table.Column<double>(type: "float", nullable: false),
                    RespondeAId = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoActividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reingreso = table.Column<bool>(type: "bit", nullable: false),
                    UltimaFechadeBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    habArmado = table.Column<bool>(type: "bit", nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoOperativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RubroId = table.Column<int>(type: "int", nullable: true),
                    UltimaActualizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoResumido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rotativo = table.Column<bool>(type: "bit", nullable: false),
                    SegundoLibreTrabajado = table.Column<bool>(type: "bit", nullable: false),
                    SegundoLibrePosterior = table.Column<bool>(type: "bit", nullable: false),
                    DiaLibre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_MesasOperativas_RespondeAId",
                        column: x => x.RespondeAId,
                        principalTable: "MesasOperativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_TiposContratos_TipoContratoId",
                        column: x => x.TipoContratoId,
                        principalTable: "TiposContratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NombresPuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NombresPuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NombresPuestos_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ausencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true),
                    ComputoId = table.Column<int>(type: "int", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmadoPorRRHH = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ausencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ausencias_Computos_ComputoId",
                        column: x => x.ComputoId,
                        principalTable: "Computos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ausencias_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ausencias_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperativasDiarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioOperativoId = table.Column<int>(type: "int", nullable: true),
                    NombrePuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    HoraEntradaMarcada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalidaMarcada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Facturable = table.Column<bool>(type: "bit", nullable: false),
                    ComputoId = table.Column<int>(type: "int", nullable: true),
                    CantidadHorasTotales = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasExtras = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasArmado = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncionarioSegundoNivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    ComienzoJornada = table.Column<bool>(type: "bit", nullable: false),
                    TipoFuncionarioOperativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extra = table.Column<bool>(type: "bit", nullable: false),
                    HoySegundoLibre = table.Column<bool>(type: "bit", nullable: false),
                    ProximoSegundoLibre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoResumido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MostrarEnEscalafon = table.Column<bool>(type: "bit", nullable: false),
                    Rotativo = table.Column<bool>(type: "bit", nullable: false),
                    SegundoNivel = table.Column<bool>(type: "bit", nullable: false),
                    TengoSegundoNivelActivo = table.Column<bool>(type: "bit", nullable: false),
                    IdMesaOperativa = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<bool>(type: "bit", nullable: false),
                    CheckOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperativasDiarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperativasDiarias_Computos_ComputoId",
                        column: x => x.ComputoId,
                        principalTable: "Computos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperativasDiarias_Funcionarios_FuncionarioOperativoId",
                        column: x => x.FuncionarioOperativoId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperativasDiarias_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanificacionesDiarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioOperativoId = table.Column<int>(type: "int", nullable: true),
                    NombrePuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    HoraEntradaMarcada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalidaMarcada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Facturable = table.Column<bool>(type: "bit", nullable: false),
                    ComputoId = table.Column<int>(type: "int", nullable: true),
                    CantidadHorasTotales = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasExtras = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasArmado = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncionarioSegundoNivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    ComienzoJornada = table.Column<bool>(type: "bit", nullable: false),
                    TipoFuncionarioOperativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extra = table.Column<bool>(type: "bit", nullable: false),
                    HoySegundoLibre = table.Column<bool>(type: "bit", nullable: false),
                    ProximoSegundoLibre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoResumido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MostrarEnEscalafon = table.Column<bool>(type: "bit", nullable: false),
                    Rotativo = table.Column<bool>(type: "bit", nullable: false),
                    SegundoNivel = table.Column<bool>(type: "bit", nullable: false),
                    TengoSegundoNivelActivo = table.Column<bool>(type: "bit", nullable: false),
                    IdMesaOperativa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanificacionesDiarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanificacionesDiarias_Computos_ComputoId",
                        column: x => x.ComputoId,
                        principalTable: "Computos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanificacionesDiarias_Funcionarios_FuncionarioOperativoId",
                        column: x => x.FuncionarioOperativoId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanificacionesDiarias_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreferenciasFuncionariosServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenciasFuncionariosServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferenciasFuncionariosServicio_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreferenciasFuncionariosServicio_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosHoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    NombrePuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComputoId = table.Column<int>(type: "int", nullable: true),
                    Falta = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasDiurnas = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasNocturnas = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasEfectivas = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasExtras = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasArmado = table.Column<double>(type: "float", nullable: false),
                    CantidadHrsExtrasLibreTrabajado = table.Column<double>(type: "float", nullable: false),
                    CantidadHorasNocLibreTrabajado = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facturable = table.Column<bool>(type: "bit", nullable: false),
                    ComienzoJornada = table.Column<bool>(type: "bit", nullable: false),
                    EnlaceHorario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosHoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosHoras_Computos_ComputoId",
                        column: x => x.ComputoId,
                        principalTable: "Computos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosHoras_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosHoras_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ausencias_ComputoId",
                table: "Ausencias",
                column: "ComputoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ausencias_FuncionarioId",
                table: "Ausencias",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ausencias_ServicioId",
                table: "Ausencias",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_RespondeAId",
                table: "Funcionarios",
                column: "RespondeAId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_RubroId",
                table: "Funcionarios",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_TipoContratoId",
                table: "Funcionarios",
                column: "TipoContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_NombresPuestos_Nombre",
                table: "NombresPuestos",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NombresPuestos_ServicioId",
                table: "NombresPuestos",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_OperativasDiarias_ComputoId",
                table: "OperativasDiarias",
                column: "ComputoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperativasDiarias_FuncionarioOperativoId",
                table: "OperativasDiarias",
                column: "FuncionarioOperativoId");

            migrationBuilder.CreateIndex(
                name: "IX_OperativasDiarias_ServicioId",
                table: "OperativasDiarias",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanificacionesDiarias_ComputoId",
                table: "PlanificacionesDiarias",
                column: "ComputoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanificacionesDiarias_FuncionarioOperativoId",
                table: "PlanificacionesDiarias",
                column: "FuncionarioOperativoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanificacionesDiarias_ServicioId",
                table: "PlanificacionesDiarias",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenciasFuncionariosServicio_FuncionarioId",
                table: "PreferenciasFuncionariosServicio",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenciasFuncionariosServicio_ServicioId",
                table: "PreferenciasFuncionariosServicio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosHoras_ComputoId",
                table: "RegistrosHoras",
                column: "ComputoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosHoras_FuncionarioId",
                table: "RegistrosHoras",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosHoras_ServicioId",
                table: "RegistrosHoras",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ClienteId",
                table: "Servicios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_DependeDeId",
                table: "Servicios",
                column: "DependeDeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MesaOperativaId",
                table: "Usuarios",
                column: "MesaOperativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ausencias");

            migrationBuilder.DropTable(
                name: "NombresPuestos");

            migrationBuilder.DropTable(
                name: "OperativasDiarias");

            migrationBuilder.DropTable(
                name: "PlanificacionesDiarias");

            migrationBuilder.DropTable(
                name: "PreferenciasFuncionariosServicio");

            migrationBuilder.DropTable(
                name: "RegistrosHoras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Computos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Rubros");

            migrationBuilder.DropTable(
                name: "TiposContratos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "MesasOperativas");
        }
    }
}
