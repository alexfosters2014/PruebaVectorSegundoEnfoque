// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace VectorCliente.Pages.Planificacion
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Blazored.SessionStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Comun;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Modelo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Modelo.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Modelo.OtherModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Services.IServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Shared.Componentes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Shared.Componentes.Escalafon;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Shared.Widget;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Shared.Componentes.Escalafon.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Shared.Componentes.Escalafon.Planificacion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using VectorCliente.Shared.Componentes.Funcionarios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using BlazorAnimate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\_Imports.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\EscalafonPlanificacion.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Planificacion/Escalafon")]
    public partial class EscalafonPlanificacion : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 156 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\EscalafonPlanificacion.razor"
       

    private UsuarioDTO usuario;

    private int clienteSeleccionado = 0;
    private int servicioSeleccionado = 0;
    private int tabSeleccionado = 0;
    private ServicioDTO ServicioPref = new();

    List<PreferenciaFuncionarioServicioDTO> preferenciasFuncEnServicio = new();
    private bool VisibilidadPrefFunServ = false;
    protected async override Task OnInitializedAsync()
    {
        usuario = await localStorage.GetItemAsync<UsuarioDTO>(SD.LocalUsuario);
        if (usuario == null)
        {
            nav.NavigateTo("/", true);
            return;
        }
        if (serviceEscalafon.EscalafonModel == null)
        {
            nav.NavigateTo("/Planificacion/Index");
        }
        serviceEscalafon.IdMesaOperativaEnPlanificacion = usuario.MesaOperativa.Id;


        hubConnection.On<PlanificacionDiariaDTO>("RecibirEstado", async (estado) =>
        {
            if (estado.IdMesaOperativa == serviceEscalafon.IdMesaOperativaEnPlanificacion &&
       estado.Fecha.Date == serviceEscalafon.FechaPlanificacion &&
        !string.IsNullOrEmpty(estado.ModalidadActualizacionEscalafon))
            {
            //await serviceEscalafon.AgregarActualizarEliminarEscalafonFrontEnd(estado);

            await serviceEscalafon.ABMEscalafonBolsaFrontEnd(estado);
            // await FiltrarServicios();
            StateHasChanged();

            }
        });    


        hubConnection.On<PlanificacionDiariaDTO>("RecibirEstadoSoloBolsa", async (estado) =>
     {
         if (estado.Rotativo && estado.IdMesaOperativa == serviceEscalafon.IdMesaOperativaEnPlanificacion &&
           estado.Fecha.Date == serviceEscalafon.FechaPlanificacion)
         {
             await serviceEscalafon.ABMBolsaFrontEnd(estado);
             StateHasChanged();
         }

     });

        hubConnection.On<PlanificacionDiariaDTO,ServicioDTO>("RecibirMoverDeServicio", async (estado, servicioAnterior) =>
                {
                    if (estado.IdMesaOperativa == serviceEscalafon.IdMesaOperativaEnPlanificacion &&
               estado.Fecha.Date == serviceEscalafon.FechaPlanificacion &&
                !string.IsNullOrEmpty(estado.ModalidadActualizacionEscalafon))
                    {
                        await serviceEscalafon.ABMEscalafonBolsaFrontEnd(estado);
                        await serviceEscalafon.MoverAOtroServicioPlanDiarioFrontEnd(estado, servicioAnterior);
                        StateHasChanged();
                    }
                });  

    }
    private string ColorEstado(string estado)
    {
        return SD.EstadosComputosColor[estado];
    }
    private string TituloFecha() => ($"{SD.DiaDeSemana[(int)serviceEscalafon.FechaPlanificacion.DayOfWeek]}, {serviceEscalafon.FechaPlanificacion.ToString("dd/MM/yyyy")}");

    private void Cerrar()
    {
        nav.NavigateTo("/Planificacion/Index",true);
    }

    private async Task FiltrarServicios()
    {
        await serviceEscalafon.ReestructuraEscalafonFiltrado();
    }

    private async Task Visor()
    {
        nav.NavigateTo("GanttAusencias");
    }

    public void Select(SelectingEventArgs args)
    {
        if(args.IsSwiped)
        {
            args.Cancel = true;
        }
    }

    private async Task VerPrefFuncionarioServicio(ServicioDTO servicio)
    {
        ServicioPref = servicio;
        preferenciasFuncEnServicio = await servicePrefFunServicio.Obtener(servicio.Id, serviceEscalafon.UsuarioDTO.Token);
        VisibilidadPrefFunServ = true;
    }

    private async Task CerrarModal()
    {
        VisibilidadPrefFunServ = false;
        preferenciasFuncEnServicio = new();
    }
    //public void OnTabSeleccionado(SelectEventArgs args) 
    //{
    //    if (tabSeleccionado == 1)
    //    {
    //        StateHasChanged();
    //    }
    //} 

    private string Estado = SD.EditEnum.LISTA.ToString();

    private bool visibilidadFunOperativoCL = false;
    private bool visibilidadNombrePuesto = false;
    private bool visibilidadFechasInicioFin = false;
    private bool visibilidadTipo = false;
    private bool visibilidadOpciones = false;

    public int idEstado = 0;

    private OpcionesExtendidasEstado opcionesExtendidas = new();
    private int servicioIdAnterior = -1;
    private int turnoAnterior = -1;


    private string CssParaSegundoNivel(bool seguNivel) => seguNivel ? "BordeSegundoNivel" : "";

    private string DatoFuncionarioCubreLibre(FuncionarioDTO func) => (func != null ? $"{func.Numero} - {func.NombreCorto()}" : "---");

    private string FacturableIcono(bool dato) => dato ? "facturable.png" : "noFacturable.png";

    private string RecorteObservaciones(string obs)
    {
        string recorteObs;

        if (string.IsNullOrEmpty(obs))
        {
            recorteObs = "---";
        }
        else
        {
            if (obs.Length < 31)
            {
                recorteObs = obs;
            }
            else
            {
                recorteObs = $"{obs.Substring(0, 27)}...";
            }
        }
        return recorteObs;
    }

    private string ImagenTipoFunOperativo(string tipo) => tipo != null ? SD.TipoFuncionarioOperativo[tipo] : null;

    private string ImagenComienzoJornada(bool comienzoJornada) => comienzoJornada ? "comienzoJornada.png" : "vacio.png";


    private async Task CambiarFuncionarioCubreLibre()
    {
        visibilidadFunOperativoCL = true;
    }
    private async Task CambiarNombrePuesto()
    {
        visibilidadNombrePuesto = true;
    }
    private async Task CambiarTipoFuncionario()
    {
        visibilidadTipo = true;
    }

    private bool EsServicioDiferente(int servicioIdActual)
    {
        bool resultado = servicioIdAnterior != servicioIdActual;
        servicioIdAnterior = resultado ? servicioIdActual : servicioIdAnterior;
        return resultado;
    }

    private bool EsTurnoDiferente(int turnoActual)
    {
        bool resultado = turnoAnterior != turnoActual;
        turnoAnterior = resultado ? turnoActual : turnoAnterior;
        return resultado;
    }



    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HubConnection hubConnection { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IServicePrefFunServicio servicePrefFunServicio { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ServiceEscalafon serviceEscalafon { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISessionStorageService sessionStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService localStorage { get; set; }
    }
}
#pragma warning restore 1591
