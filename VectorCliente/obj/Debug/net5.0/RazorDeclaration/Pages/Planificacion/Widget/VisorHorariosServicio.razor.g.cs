// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace VectorCliente.Pages.Planificacion.Widget
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
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(EmptyLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/VisorHorariosServicio/{idServicio:int}")]
    public partial class VisorHorariosServicio : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 106 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\Widget\VisorHorariosServicio.razor"
       
    [Parameter]
    public int idServicio { get; set; }

    private List<PlanificacionDiariaDTO> PlanificacionesDTO { get; set; }
    private UsuarioDTO usuarioDTO;
    private DateTime fechaLimiteInferior;
    private DateTime fechaLimiteSuperior;
    private DateTime fechaFiltro;
    private DateTime fechaNavegacionActual;

    private bool HabilitadoAtras = true;
    private bool HabilitadoAdelante = true;

    private VisorHistorialServicio visor;


    protected async override Task OnInitializedAsync()
    {
        await Iniciar();
    }

    protected async override Task OnParametersSetAsync()
    {
        await Iniciar();
    }

    private async Task Iniciar()
    {
        try
        {
            usuarioDTO = await localStorage.GetItemAsync<UsuarioDTO>(SD.LocalUsuario);
            if (usuarioDTO == null)
                nav.NavigateTo("/", true);

            visor = await localStorage.GetItemAsync<VisorHistorialServicio>(SD.VisorHistorialServicio);
            if (visor == null)
                throw new Exception("No se ha pasado ningun valor de servicio");

            if ( visor.ServicioDTORef.Id != idServicio)
                throw new Exception("El Servicio no coincide con lo pasado por parámetro");

            fechaLimiteInferior = visor.FechaPlanificacionActual.Date.AddDays(-10);
            fechaLimiteSuperior = visor.FechaPlanificacionActual.Date.AddDays(10);
            fechaFiltro = visor.FechaPlanificacionActual.Date;
            fechaNavegacionActual = visor.FechaPlanificacionActual.Date.AddDays(-1);

            PlanificacionesDTO = await serviceDataEscalafon.ObtenerPlanificacionServicio(visor, usuarioDTO.Token);
            StateHasChanged();

        }
        catch(Exception ex)
        {
            await js.MsgAdvertencia(ex.Message);
        }
    }

    private async Task IrAdelante()
    {
        fechaNavegacionActual = fechaNavegacionActual.AddDays(1);
        if (fechaNavegacionActual == fechaFiltro)
            fechaNavegacionActual = fechaNavegacionActual.AddDays(1);

        if (fechaNavegacionActual == fechaLimiteSuperior)
            HabilitadoAdelante = false;
        else
            HabilitadoAtras = true;

        visor.FechaPlanificacionActual = fechaNavegacionActual;
        PlanificacionesDTO = await serviceDataEscalafon.ObtenerPlanificacionServicio(visor, usuarioDTO.Token);
        StateHasChanged();
        
    }

     private async Task IrAtras()
    {
         fechaNavegacionActual = fechaNavegacionActual.AddDays(-1);
        if (fechaNavegacionActual == fechaFiltro)
            fechaNavegacionActual = fechaNavegacionActual.AddDays(-1);

        if (fechaNavegacionActual == fechaLimiteInferior)
            HabilitadoAtras = false;
        else
             HabilitadoAdelante = true;

        visor.FechaPlanificacionActual = fechaNavegacionActual;
        PlanificacionesDTO = await serviceDataEscalafon.ObtenerPlanificacionServicio(visor, usuarioDTO.Token);
        StateHasChanged();
    }

    private string ImagenTipoFunOperativo(string tipo) => tipo != null ? SD.TipoFuncionarioOperativo[tipo] : null;
    private string ImagenComienzoJornada(bool cj) => cj ? "comienzoJornada.png" : "vacio.png";

    private string ColorEstado(string estado)
    {
        return SD.EstadosComputosColor[estado];
    }

    private string CssParaSegundoNivel(bool segundoNivel) => segundoNivel ? "BordeSegundoNivel" : "";
    private string FacturableIcono(bool dato) => dato ? "facturable.png" : "noFacturable.png";
    private string HoySegundoLibreIcono(bool dato) => dato ? "indicadordoLibreHoy.png" : "vacio.png";
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

     private string IndicadorJornadaDiaSiguiente(DateTime horario) => horario.Date > visor.FechaPlanificacionActual.Date ? "siguienteDia.png" : "vacio.png";


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IServiceDataEscalafon serviceDataEscalafon { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService localStorage { get; set; }
    }
}
#pragma warning restore 1591