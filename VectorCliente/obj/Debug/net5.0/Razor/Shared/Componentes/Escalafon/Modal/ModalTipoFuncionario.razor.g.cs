#pragma checksum "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a37822f8491bda9435656582071361bb782767d0"
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
    public partial class ModalTipoFuncionario : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(0);
            __builder.AddAttribute(1, "Width", "500px");
            __builder.AddAttribute(2, "Target", "#target");
            __builder.AddAttribute(3, "IsModal", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 3 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                  true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 3 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                                       Visibilidad

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "VisibleChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Visibilidad = __value, Visibilidad))));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(7);
                __builder2.AddAttribute(8, "Header", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(9, " Tipo ");
                }
                ));
                __builder2.AddAttribute(10, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(11, "div");
                    __builder3.AddAttribute(12, "style", "padding:15px;border-radius:15px;border:1px solid orange;");
                    __builder3.OpenElement(13, "table");
                    __builder3.AddAttribute(14, "class", "table table-borderless");
                    __builder3.OpenElement(15, "tr");
                    __builder3.AddMarkupContent(16, "<td><img src=\"/iconosPuesto/civil.png\" class=\"imgTablePresentacion\"></td>\r\n                        ");
                    __builder3.AddMarkupContent(17, "<td>CIVIL</td>\r\n                        ");
                    __builder3.OpenElement(18, "td");
                    __builder3.OpenElement(19, "button");
                    __builder3.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                () => SeleccionarTipo.InvokeAsync("CIVIL")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(21, "class", "btn btn-outline-secondary");
                    __builder3.AddContent(22, "Seleccionar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(23, "\r\n                    ");
                    __builder3.OpenElement(24, "tr");
                    __builder3.AddMarkupContent(25, "<td><img src=\"/iconosPuesto/civil-traje.png\" class=\"imgTablePresentacion\"></td>\r\n                        ");
                    __builder3.AddMarkupContent(26, "<td>CIVIL CON TRAJE</td>\r\n                        ");
                    __builder3.OpenElement(27, "td");
                    __builder3.OpenElement(28, "button");
                    __builder3.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                () => SeleccionarTipo.InvokeAsync("CIVIL C/TRAJE")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(30, "lass", "btn btn-outline-secondary");
                    __builder3.AddContent(31, "Seleccionar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(32, "\r\n                    ");
                    __builder3.OpenElement(33, "tr");
                    __builder3.AddMarkupContent(34, "<td><img src=\"/iconosPuesto/civil-armado.png\" class=\"imgTablePresentacion\"></td>\r\n                        ");
                    __builder3.AddMarkupContent(35, "<td>CIVIL ARMADO</td>\r\n                        ");
                    __builder3.OpenElement(36, "td");
                    __builder3.OpenElement(37, "button");
                    __builder3.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                () => SeleccionarTipo.InvokeAsync("CIVIL ARMADO")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(39, "class", "btn btn-outline-secondary");
                    __builder3.AddContent(40, "Seleccionar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(41, "\r\n                    ");
                    __builder3.OpenElement(42, "tr");
                    __builder3.AddMarkupContent(43, "<td><img src=\"/iconosPuesto/civil-traje-armado.png\" class=\"imgTablePresentacion\"></td>\r\n                        ");
                    __builder3.AddMarkupContent(44, "<td>CIVIL ARMADO CON TRAJE</td>\r\n                        ");
                    __builder3.OpenElement(45, "td");
                    __builder3.OpenElement(46, "button");
                    __builder3.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                () => SeleccionarTipo.InvokeAsync("CIVIL ARMADO C/TRAJE")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(48, "class", "btn btn-outline-secondary");
                    __builder3.AddContent(49, "Seleccionar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(50, "\r\n                    ");
                    __builder3.OpenElement(51, "tr");
                    __builder3.AddMarkupContent(52, "<td><img src=\"/iconosPuesto/militar-sinArma.png\" class=\"imgTablePresentacion\"></td>\r\n                        ");
                    __builder3.AddMarkupContent(53, "<td>MILITAR</td>\r\n                        ");
                    __builder3.OpenElement(54, "td");
                    __builder3.OpenElement(55, "button");
                    __builder3.AddAttribute(56, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 32 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                () => SeleccionarTipo.InvokeAsync("MILITAR NO ARMADO")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(57, "class", "btn btn-outline-secondary");
                    __builder3.AddContent(58, "Seleccionar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(59, "\r\n                    ");
                    __builder3.OpenElement(60, "tr");
                    __builder3.AddMarkupContent(61, "<td><img src=\"/iconosPuesto/militar-armado.png\" class=\"imgTablePresentacion\"></td>\r\n                        ");
                    __builder3.AddMarkupContent(62, "<td>MILITAR ARMADO</td>\r\n                        ");
                    __builder3.OpenElement(63, "td");
                    __builder3.OpenElement(64, "button");
                    __builder3.AddAttribute(65, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                () => SeleccionarTipo.InvokeAsync("MILITAR ARMADO")

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(66, "class", "btn btn-outline-secondary");
                    __builder3.AddContent(67, "Seleccionar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(68, "\r\n    ");
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogButtons>(69);
                __builder2.AddAttribute(70, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Syncfusion.Blazor.Popups.DialogButton>(71);
                    __builder3.AddAttribute(72, "Content", "Cerrar");
                    __builder3.AddAttribute(73, "IsPrimary", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 44 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                  true

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(74, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 44 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                                                  CerrarModalComponent

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(75, "\r\n    ");
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogAnimationSettings>(76);
                __builder2.AddAttribute(77, "Effect", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Popups.DialogEffect>(
#nullable restore
#line 47 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
                                      DialogEffect.Fade

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(78, "   \r\n\r\n");
            __builder.AddMarkupContent(79, "<style>\r\n    #target {\r\n        max-height: 800px;\r\n        height: 100%;\r\n    }\r\n</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Escalafon\Modal\ModalTipoFuncionario.razor"
       
    [Parameter]
    public EventCallback<string> SeleccionarTipo { get; set; }

    [Parameter]
    public bool Visibilidad { get; set; }

    [Parameter]
    public EventCallback CerrarModal { get; set; }



    private void CerrarModalComponent()
    {
        CerrarModal.InvokeAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ServiceEscalafon serviceEscalafon { get; set; }
    }
}
#pragma warning restore 1591
