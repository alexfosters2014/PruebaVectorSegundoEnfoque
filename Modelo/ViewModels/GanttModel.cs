using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Modelo.ViewModels
{
    public class GanttModel
    {
        public string x { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        public string FillColor { get; set; }
        //rango es: FechaInicio, FechaFinalizacion
        public GanttModel(string item, DateTime _fechaInicio, DateTime _fechaFin, DateTime _fechaPlanificacion)
        {
            FechaInicio = _fechaInicio.ToString("yyyy-MM-dd");
            FechaFin = _fechaFin.ToString("yyyy-MM-dd");
            TimeSpan difFechas = _fechaFin - _fechaInicio;
            int cantidadDias = difFechas.Days + 1;
            x = $"{item} ({cantidadDias} dias)";
            FillColor = _fechaPlanificacion.Date == _fechaFin.Date ? "#FEB019" : "#008FFB";
        }
    }
}
