#pragma checksum "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "118519ec75829a9eeabf0838af8890894f64e4c3"
// <auto-generated/>
#pragma warning disable 1591
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
    public partial class PlanificacionBolsa : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<VectorCliente.Shared.Componentes.Escalafon.Modal.ModalFuncionarioOperativoBolsa>(0);
            __builder.AddAttribute(1, "ObtenerFuncionarioFechaDTO", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Modelo.OtherModels.FuncionarioFecha>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Modelo.OtherModels.FuncionarioFecha>(this, 
#nullable restore
#line 8 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                            SeleccionarTipoFuncionarioFecha

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(2, "Visibilidad", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 8 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                                                                          modal

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "CerrarModal", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 8 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                                                                                              CerrarModal

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "card m-2 p-5 scrolVertical");
            __builder.AddMarkupContent(7, "<h5 class=\"estiloTituloBolsa\">Retenes/Rotativos</h5>");
#nullable restore
#line 12 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
     if (bolsaRotativos != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
         foreach (var estado in bolsaRotativos.Where(w => w.TipoResumido == SD.EstadoRotatividad.RETEN.ToString())
                                                             .OrderBy(o => o.FuncionarioOperativo.Numero)
                                                             .ToList())
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<VectorCliente.Shared.Componentes.Escalafon.Planificacion.EstadoContenedorBolsa>(8);
            __builder.AddAttribute(9, "PlanDiarioDTO", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Modelo.PlanificacionDiariaDTO>(
#nullable restore
#line 18 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                  estado

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "ActualizarPlanDiario", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Modelo.PlanificacionDiariaDTO>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Modelo.PlanificacionDiariaDTO>(this, 
#nullable restore
#line 19 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                            ActualizarPlanDiario

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(11, "EliminarPlanDiario", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Modelo.PlanificacionDiariaDTO>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Modelo.PlanificacionDiariaDTO>(this, 
#nullable restore
#line 20 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                          EliminarPlanDiario

#line default
#line hidden
#nullable disable
            )));
            __builder.SetKey(
#nullable restore
#line 18 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                                estado.Id+1234

#line default
#line hidden
#nullable disable
            );
            __builder.CloseComponent();
#nullable restore
#line 21 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<VectorCliente.Shared.Widget.Divider>(12);
            __builder.AddAttribute(13, "Altura", "25px");
            __builder.CloseComponent();
            __builder.AddMarkupContent(14, "<h5 class=\"estiloTituloBolsa\">Puntuales/Rotativos</h5>");
#nullable restore
#line 25 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
         foreach (var estado in bolsaRotativos.Where(w => w.TipoResumido == SD.EstadoRotatividad.PUNTUAL.ToString()&&
                                                                         w.Rotativo == true)
                                                             .OrderBy(o => o.FuncionarioOperativo.Numero)
                                                             .ToList())
        {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<VectorCliente.Shared.Componentes.Escalafon.Planificacion.EstadoContenedorBolsa>(15);
            __builder.AddAttribute(16, "PlanDiarioDTO", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Modelo.PlanificacionDiariaDTO>(
#nullable restore
#line 30 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                  estado

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "ActualizarPlanDiario", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Modelo.PlanificacionDiariaDTO>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Modelo.PlanificacionDiariaDTO>(this, 
#nullable restore
#line 31 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                            ActualizarPlanDiario

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(18, "EliminarPlanDiario", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Modelo.PlanificacionDiariaDTO>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Modelo.PlanificacionDiariaDTO>(this, 
#nullable restore
#line 32 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                          EliminarPlanDiario

#line default
#line hidden
#nullable disable
            )));
            __builder.SetKey(
#nullable restore
#line 30 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                                                                estado.Id+23456

#line default
#line hidden
#nullable disable
            );
            __builder.CloseComponent();
#nullable restore
#line 33 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
         
    }

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<VectorCliente.Shared.Widget.Divider>(19);
            __builder.AddAttribute(20, "Altura", "15px");
            __builder.CloseComponent();
            __builder.AddMarkupContent(21, "\r\n    ");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "d-flex justify-content-center");
            __builder.OpenElement(24, "a");
            __builder.AddAttribute(25, "href", "");
            __builder.AddAttribute(26, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
                             ModalNuevoEstadoBolsa

#line default
#line hidden
#nullable disable
            ));
            __builder.AddEventPreventDefaultAttribute(27, "onclick", true);
            __builder.OpenComponent<VectorCliente.Shared.Widget.IconEdit>(28);
            __builder.AddAttribute(29, "Icon", "add");
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Pages\Planificacion\PlanificacionBolsa.razor"
       
    [Parameter]
    public List<PlanificacionDiariaDTO> bolsaRotativos { get; set; }

    private bool modal = false;
    private string estadoRotatividad = SD.EstadoRotatividad.FIJO.ToString();

    protected override async Task OnInitializedAsync()
    {
    }

    private void ModalNuevoEstadoBolsa()
    {
        modal = true;
    }
    private void CerrarModal()
    {
        modal = false;
    }

    private async Task SeleccionarTipoFuncionarioFecha(FuncionarioFecha funcionarioFechaDTO)
    {
        try
        {
            PlanificacionDiariaDTO estaAgregado = await serviceEscalafon.AgregarFuncionarioPlanDiarioBolsa(funcionarioFechaDTO);
            modal = false;
            if (estaAgregado == null) throw new Exception("No se pudo agregar el funcionario en la bolsa. Err 125");
            //await serviceEscalafon.AgregarEstadoBolsaFrontEnd(estaAgregado);
            //StateHasChanged();
        }
        catch(Exception ex)
        {
            await js.MsgAdvertencia(ex.Message);
        }
    }

    private async Task ActualizarPlanDiario(PlanificacionDiariaDTO estado)
    {
        
    }

    private async Task EliminarPlanDiario(PlanificacionDiariaDTO estado)
    {
        
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HubConnection hubConnection { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ServiceEscalafon serviceEscalafon { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService localStorage { get; set; }
    }
}
#pragma warning restore 1591
