using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using VectorCliente.Services.IServices;
using Modelo.OtherModels;

namespace VectorCliente.Services
{
    public class ServiceImportar
    {
        private List<FuncionarioDTO> funcionarios = null;
        private readonly IServiceFuncionario serviceFuncionario;
        private readonly IServiceDataEscalafon serviceDataEscalafon;
        public ServiceImportar(IServiceFuncionario _serviceFuncionario, IServiceDataEscalafon _serviceDataEscalafon)
        {
            serviceFuncionario = _serviceFuncionario;
            serviceDataEscalafon = _serviceDataEscalafon;
        }

        public async Task<bool> ImportarFuncionariosDesdeExcel(Stream fileStream, string token)
        {
            //DateTime.FromOADate  -> este método convierte la fecha numerica de Excel en una fecha Datetime
            try
            {
                FuncionarioImport funcionarioImport;
                //FuncionarioDTO funcionarioImport = new();
                List<FuncionarioImport> funcionarios = new();
                ExcelPackage package = new ExcelPackage(fileStream);
                ExcelWorksheet sheet = package.Workbook.Worksheets["funcionarios"];
                int totalRows = sheet.Dimension.Rows;

                for (int row = 2; row <= totalRows; row++)
                {
                    funcionarioImport = new();

                    funcionarioImport.Numero = int.Parse(sheet.Cells[row, 1].Value.ToString());
                    funcionarioImport.Cedula = sheet.Cells[row, 2].Value.ToString().Trim();
                    funcionarioImport.Nombres = sheet.Cells[row, 3].Value.ToString().Trim();
                    funcionarioImport.Apellidos = sheet.Cells[row, 4].Value.ToString().Trim();
                    funcionarioImport.Direccion = sheet.Cells[row, 5].Value.ToString().Trim();
                    funcionarioImport.Celular = sheet.Cells[row, 6].Value.ToString().Trim();
                    double fechaNac = double.Parse(sheet.Cells[row, 7].Value.ToString().Trim());
                    double fechaIng = double.Parse(sheet.Cells[row, 8].Value.ToString().Trim());
                    funcionarioImport.FechaNacimiento = DateTime.FromOADate(fechaNac);
                    funcionarioImport.FechaIngreso = DateTime.FromOADate(fechaIng);
                    funcionarioImport.SueldoNominal = double.Parse(sheet.Cells[row, 9].Value.ToString().Trim());
                    funcionarioImport.Observaciones = sheet.Cells[row, 10].Value.ToString().Trim();
                    funcionarioImport.Rubro = new() { Id = int.Parse(sheet.Cells[row, 11].Value.ToString().Trim()) };
                    funcionarioImport.RespondeA = new() { Id = int.Parse(sheet.Cells[row, 12].Value.ToString().Trim()) };
                    funcionarioImport.DepartamentoOperativo = sheet.Cells[row, 13].Value.ToString().Trim();
                    funcionarioImport.TipoContrato = new() { Id = int.Parse(sheet.Cells[row, 14].Value.ToString().Trim()) };
                    funcionarioImport.TipoResumido = sheet.Cells[row, 15].Value.ToString().Trim();

                    funcionarios.Add(funcionarioImport);
                    funcionarioImport = null;
                }
                bool resultado = await serviceFuncionario.Importar(funcionarios, token);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        public async Task<bool> ImportarClientesYServiciosDesdeExcel(Stream fileStream, string token)
        {
            try
            {
                ClientesServiciosImport csImport = new();

                ExcelPackage package = new ExcelPackage(fileStream);
                ExcelWorksheet sheet = package.Workbook.Worksheets["CLIENTES"];
                int totalRows = sheet.Dimension.Rows;

                for (int row = 2; row <= totalRows; row++)
                {
                    ClienteDTO cliente = new();

                    cliente.RutCi = sheet.Cells[row, 1].Value.ToString();
                    cliente.RazonSocial = sheet.Cells[row, 2].Value.ToString();
                    cliente.NombreFantasia = sheet.Cells[row, 3].Value.ToString();
                    cliente.Direccion = sheet.Cells[row, 4].Value.ToString();
                    cliente.Telefono = sheet.Cells[row, 5].Value.ToString();
                    cliente.Observacion = sheet.Cells[row, 6].Value.ToString();
                    cliente.Activo = true;
                    csImport.ClientesDTO.Add(cliente);
                }

                sheet = package.Workbook.Worksheets["SERVICIOS"];
                totalRows = sheet.Dimension.Rows;

                for (int row = 2; row <= totalRows; row++)
                {
                    ServicioImport servicio = new();

                    servicio.NombreDescriptivo = sheet.Cells[row, 1].Value.ToString();
                    servicio.Cliente = new ClienteImport() {RazonSocial = sheet.Cells[row, 2].Value.ToString() };
                    servicio.Ciudad = sheet.Cells[row, 3].Value.ToString();
                    servicio.Departamento = sheet.Cells[row, 4].Value.ToString();
                    servicio.Geolocalizacion = sheet.Cells[row, 5].Value.ToString();
                    servicio.Direccion = sheet.Cells[row, 6].Value.ToString();
                    servicio.NombreCoordinacion = sheet.Cells[row, 7].Value.ToString();
                    servicio.TelCoordinacion = sheet.Cells[row, 8].Value.ToString();
                    servicio.NombreContactoServicio = sheet.Cells[row, 9].Value.ToString();
                    servicio.TelContactoServicio = sheet.Cells[row, 10].Value.ToString();
                    servicio.Estado = sheet.Cells[row, 11].Value.ToString();
                    servicio.Detalle = sheet.Cells[row, 12].Value.ToString();
                    servicio.DependeDe = new MesaOpImport() { Id = int.Parse(sheet.Cells[row, 13].Value.ToString()) };
                    servicio.GuardiaFisica = bool.Parse(sheet.Cells[row, 14].Value.ToString());
                    servicio.Activo = true;

                    csImport.ServiciosImport.Add(servicio);
                }

                bool resultado = await serviceDataEscalafon.ImportarClientesYServicios(csImport, token);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
