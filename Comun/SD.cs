using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class SD
    {
        public const string LocalUsuario = "UsuarioLocalLogin";
        public const string LocalFuncionario = "FuncionarioLocalStorage";
        public const string VisorHistorialServicio = "VisorHistorialServicioRef";
        public const string SessionEscalafon = "EscalafonSessionImport";
        public const string SessionEdicionEstado = "SessionEdicionEstado";
        public const string FechaPlanificacionGantt = "FechaPlanificacionGanttAusencias";
        public const string SinJornalAsignado = "SIN JORNAL ASIGNADO";
        public const string otro = "";


        public enum EstadoServicioEnum
        {
            ACTIVO,
            BAJA,
        }

        public enum OpcionesFABEnum
        {
            MOVER_A_SERVICIO,
            PASAR_A_ROTATIVO,
            ELIMINAR_DE_ESCALAFON,
            DAR_BAJA_FUNCIONARIO,
        }
        public enum RolesEnum
        {
            ADMINISTRADOR,
            FINANZAS,
            RRHH,
            SUBJEFE_OPERATIVO,
            ASISTENTE_OPERATIVO
        }
        public static Dictionary<string, int> tipo = new()
        {
            { "COMUN", 0 },
            { "EVENTUAL", 1 },
            { "JORNALERO", 2 },
        };

        public enum EstadoFuncionarioEnum
        {
            ACTIVO,
            BAJA_PARA_LIQUIDACION,
            BAJA_DEFINITIVA
        }
        public enum DepartamentosEnum
        {
            MONTEVIDEO, ARTIGAS, CANELONES, CERRO_LARGO, COLONIA, DURAZNO,
            FLORES, FLORIDA, LAVALLEJA, MALDONADO, PAYSANDU, RIO_NEGRO, RIVERA,
            ROCHA, SALTO, SAN_JOSE, SORIANO, TACUAREMBO, TREINTA_Y_TRES

        }
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }
        public static int ConvertStringToInt(string value)
        {
            int retorno = -1;
            Int32.TryParse(value, out retorno);
            return retorno;
        }

        public enum ModalidadActualizacion
        {
            AGREGAR,
            ACTUALIZAR,
            ELIMINAR
        }
        public static bool AnyString(string textoABuscar, string cadenaAComparar)
        {
            string[] textoArray = textoABuscar.Split(" ");
            bool resultado = textoArray.Any(alguno => cadenaAComparar.Contains(alguno));
            return resultado;
        }
        public enum EditEnum
        {
            NUEVO,
            EDICION,
            LISTA
        }
        public enum TurnosEnum
        {
            Matutino,
            Matutino_Intermedio,
            Vespertino,
            Vespertino_Intermedio,
            Nocturno,
            Nocturno_Intermedio,
            Sin_Turno
        }
        public enum EstadoRotatividad
        {
            RETEN,
            PUNTUAL,
            FIJO
        }

        //public static Dictionary<string, bool> DictionaryEsRotativo = new()
        //{
        //    { "RETEN", true },
        //    { "PUNTUAL", true },
        //    { "FIJO", false },
        //};

        public static Dictionary<int, string> TurnosDiccionario = new()
        {
            { 0,"MATUTINO" },
            { 1, "MATUTINO INTERMEDIO" },
            { 2, "VESPERTINO" },
            { 3, "VESPERTINO INTERMEDIO" },
            { 4, "NOCTURNO" },
            { 5, "NOCTURNO INTERMEDIO" },
            { 6, "SIN TURNO" },
        };

        public static Dictionary<string, bool> ComputaAusencia = new()
        {
            { "NORMAL", false },
            { "LIBRE", false },
            { "LIBRE TRABAJADO", false },
            { "FALTA", true },
            { "LICENCIA", true },
            { "LICENCIA ESPECIAL", true },
            { "LICENCIA SIN GOCE SUELDO", true },
            { "SANCION", true },
            { "CERTIFICACION", true },
            { "SEGURO DE PARO", true },
            { "SIN JORNAL ASIGNADO", false },
            { "BAJA", true }
        };

        public static Dictionary<string, bool> EstadosComputosBD = new()
        {
            { "NORMAL", false },
            { "LIBRE", false },
            { "LIBRE TRABAJADO", false },
            { "FALTA", true },
            { "LICENCIA", false },
            { "LICENCIA ESPECIAL", false },
            { "LICENCIA SIN GOCE SUELDO", true },
            { "SANCION", true },
            { "CERTIFICACION", true },
            { "SEGURO DE PARO", true },
            { "SIN JORNAL ASIGNADO", true },
            { "BAJA", true }
        };
        //region Computos utilidades
        public static Dictionary<string, bool> EstadosComputosModal = new()
        {
            { "NORMAL", false },
            { "LIBRE", false },
            { "LIBRE TRABAJADO", false },
            { "FALTA", false },
            { "LICENCIA", true },
            { "LICENCIA ESPECIAL", true },
            { "LICENCIA SIN GOCE SUELDO", true },
            { "SANCION", true },
            { "CERTIFICACION", true },
            { "SEGURO DE PARO", true },
            { "SIN JORNAL ASIGNADO", false }
        };
        public enum ComputosEnum
        {
            NORMAL,
            LIBRE,
            LIBRE_TRABAJADO,
            FALTA,
            LICENCIA,
            LICENCIA_ESPECIAL,
            LICENCIA_SIN_GOCE_SUELDO,
            SANCION,
            CERTIFICACION,
            SEGURO_DE_PARO,
            SIN_JORNAL_ASIGNADO,
            BAJA
        }
        public static Dictionary<string, string> EstadosComputosColor = new()
        {
            { "NORMAL", "#3DE351" },//verde claro
            { "LIBRE", "#66B7ED" },//celeste
            { "LIBRE TRABAJADO", "#FAFB2E" },//amarillo
            { "FALTA", "#FF7575" },//rojo claro   
            { "LICENCIA", "#CA62D2" },//violeta
            { "LICENCIA ESPECIAL", "#BA62D2" },//lila
            { "LICENCIA SIN GOCE SUELDO", "#CDCDCD" },//GRIS INTERMEDIO
            { "SANCION", "#FFC21C" },//anaranjado
            { "CERTIFICACION", "#5B6DC7" },//azul grisaseo
            { "SEGURO DE PARO", "#F2A2DF" }, //rosado
            { "SIN JORNAL ASIGNADO", "#F5F0BD" },// mostaza suave
            { "BAJA", "#FF2E2E" },//rojo
        };
        public static Dictionary<int, string> DiaDeSemana = new()
        {
            { 0, "Domingo" },
            { 1, "Lunes" },
            { 2, "Martes" },
            { 3, "Miércoles" },
            { 4, "Jueves" },
            { 5, "Viernes" },
            { 6, "Sábado" }
        };
        public static Dictionary<string, string> TipoFuncionarioOperativo = new()
        {
            { "MILITAR ARMADO", "militar-armado.png" },
            { "MILITAR NO ARMADO", "militar-sinArma.png" },
            { "CIVIL ARMADO", "civil-armado.png" },
            { "CIVIL ARMADO C/TRAJE", "civil-traje-armado.png" },
            { "CIVIL C/TRAJE", "civil-traje.png" },
            { "CIVIL", "civil.png" }
        };

        public static Dictionary<string, bool> FiltroGantt = new()
        {
            { "LICENCIA", false },
            { "LICENCIA ESPECIAL", false },
            { "LICENCIA SIN GOCE SUELDO", true },
            { "SANCION", true },
            { "CERTIFICACION", true },
            { "SEGURO DE PARO", true },
        };
    }
}
