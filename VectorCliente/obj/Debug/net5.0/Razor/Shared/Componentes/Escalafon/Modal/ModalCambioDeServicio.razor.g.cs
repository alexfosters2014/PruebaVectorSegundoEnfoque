#pragma checksum "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "378c537356276051f54b09e1e6757a3a971346fa"
// <auto-generated/>
#pragma warning disable 1591
namespace VectorCliente.Shared.Componentes.Escalafon.Modal
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
    public partial class ModalCambioDeServicio : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(0);
            __builder.AddAttribute(1, "Width", "650px");
            __builder.AddAttribute(2, "Target", "#target");
            __builder.AddAttribute(3, "IsModal", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 5 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                                  true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 5 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                                                       Visibilidad

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "VisibleChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Visibilidad = __value, Visibilidad))));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(7);
                __builder2.AddAttribute(8, "Header", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(9, " Mover a otro Servicio ");
                }
                ));
                __builder2.AddAttribute(10, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(11, "<hr>\r\n            ");
                    __builder3.OpenElement(12, "div");
                    __builder3.AddAttribute(13, "class", "form-group");
                    __builder3.OpenElement(14, "input");
                    __builder3.AddAttribute(15, "type", "text");
                    __builder3.AddAttribute(16, "class", "form-control");
                    __builder3.AddAttribute(17, "placeholder", "Buscar Servicio");
                    __builder3.AddAttribute(18, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 11 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                          busqueda

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(19, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => busqueda = __value, busqueda));
                    __builder3.SetUpdatesAttributeName("value");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(20, "\r\n                ");
                    __builder3.OpenElement(21, "button");
                    __builder3.AddAttribute(22, "class", "btn btn-primary");
                    __builder3.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                                          BuscarServicios

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(24, "Buscar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(25, "\r\n             <hr>");
#nullable restore
#line 15 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
              if (servicios != null)
            {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(26, "table");
                    __builder3.AddAttribute(27, "class", "table table-borderless");
#nullable restore
#line 19 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                     foreach (var serv in servicios)
                    {

#line default
#line hidden
#nullable disable
                    __builder3.OpenElement(28, "tr");
                    __builder3.OpenElement(29, "td");
#nullable restore
#line 22 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
__builder3.AddContent(30, serv.NombreDescriptivo);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(31, "\r\n                            ");
                    __builder3.OpenElement(32, "td");
#nullable restore
#line 23 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
__builder3.AddContent(33, serv.Direccion);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(34, "\r\n                            ");
                    __builder3.OpenElement(35, "td");
                    __builder3.OpenElement(36, "a");
                    __builder3.AddAttribute(37, "href", "");
                    __builder3.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                                     () => CambioDeServicio(serv)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddEventPreventDefaultAttribute(39, "onclick", true);
                    __builder3.AddMarkupContent(40, "<img src=\"icons/selector.png\" class=\"imgTable\">");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
#nullable restore
#line 30 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                    }

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
#nullable restore
#line 32 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
              }

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(41, "\r\n     ");
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogButtons>(42);
                __builder2.AddAttribute(43, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Syncfusion.Blazor.Popups.DialogButton>(44);
                    __builder3.AddAttribute(45, "Content", "Cerrar");
                    __builder3.AddAttribute(46, "IsPrimary", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 37 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                                  true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(47, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                                                  CerrarModalActual

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(48, "\r\n    ");
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogAnimationSettings>(49);
                __builder2.AddAttribute(50, "Effect", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Popups.DialogEffect>(
#nullable restore
#line 40 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
                                      DialogEffect.Fade

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(51, "\r\n");
            __builder.AddMarkupContent(52, "<style>\r\n    #target {\r\n        max-height: 800px;\r\n        height: 100%;\r\n    }\r\n</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalCambioDeServicio.razor"
       
    [Parameter]
    public bool Visibilidad { get; set; }

    [Parameter]
    public EventCallback<ServicioDTO> CambiarDeServicio { get; set; }

    [Parameter]
    public EventCallback<bool> CerrarModal { get; set; }

    private string busqueda = "";
    private ServicioDTO servicioDTO = new();
    private List<ServicioDTO> servicios = null;

    //protected async override Task OnParametersSetAsync()
    //{
    //    return base.OnParametersSetAsync();
    //}

    private async Task CambioDeServicio(ServicioDTO servicio)
    {
        if (servicio == null )
        {
            toastService.ShowWarning("No se ha podido cambiar de servicio al funcionario seleccionado");
            return;
        }
        await CambiarDeServicio.InvokeAsync(servicio);
    }

    private async Task BuscarServicios()
    {
        servicios = serviceEscalafon.EscalafonModel.ServiciosDTO.Where(w => w.NombreDescriptivo.Contains(busqueda.ToUpper())).ToList();
    }

    private async void CerrarModalActual()
    {
        await CerrarModal.InvokeAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ServiceEscalafon serviceEscalafon { get; set; }
    }
}
#pragma warning restore 1591
