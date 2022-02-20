using Microsoft.AspNetCore.SignalR;
using Modelo;
using Modelo.OtherModels;
using System;
using System.Threading.Tasks;

namespace VectorWebAPI.Properties.EscalafonHub
{
    public class EscalafonHub : Hub
    {
        public async Task SendEstadoHub(PlanificacionDiariaDTO estado)
        {
            await Clients.All.SendAsync("RecibirEstado", estado);
        }

        public async Task SendEstadoBolsaHub(PlanificacionDiariaDTO estado)
        {
            await Clients.All.SendAsync("RecibirEnBolsa", estado);
        }

        public async Task SendAgregarABolsaHub(PlanificacionDiariaDTO estado)
        {
            await Clients.All.SendAsync("RecibirEstadoSoloBolsa", estado);
        }

        public async Task SendMoverDeServicioHub(PlanificacionDiariaDTO estado, ServicioDTO servicioAnterior)
        {
            await Clients.All.SendAsync("RecibirMoverDeServicio", estado, servicioAnterior);
        }

    }
}
