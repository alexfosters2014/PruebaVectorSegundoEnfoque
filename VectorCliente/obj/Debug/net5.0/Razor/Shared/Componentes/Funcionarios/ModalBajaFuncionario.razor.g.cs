#pragma checksum "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51a119f91b116c6b445fac997c0a5efa0bdff8ed"
// <auto-generated/>
#pragma warning disable 1591
namespace VectorCliente.Shared.Componentes.Funcionarios
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
    public partial class ModalBajaFuncionario : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(0);
            __builder.AddAttribute(1, "Width", "350px");
            __builder.AddAttribute(2, "Target", "#target");
            __builder.AddAttribute(3, "IsModal", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 3 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
                                                  true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 3 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
                                                                       Visibilidad

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "VisibleChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Visibilidad = __value, Visibilidad))));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(7);
                __builder2.AddAttribute(8, "Header", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(9, "p");
                    __builder3.AddAttribute(10, "style", "color:blueviolet;font-weight:300");
#nullable restore
#line 5 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
__builder3.AddContent(11, modelBajaFuncionarioDTO.Funcionario);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
                }
                ));
                __builder2.AddAttribute(12, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(13, "div");
                    __builder3.AddAttribute(14, "class", "form-group");
                    __builder3.AddMarkupContent(15, "<label>Fecha de egreso</label>\r\n                ");
                    __builder3.OpenElement(16, "input");
                    __builder3.AddAttribute(17, "type", "date");
                    __builder3.AddAttribute(18, "class", "form-control borderActive");
                    __builder3.AddAttribute(19, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 9 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
                                          modelBajaFuncionarioDTO.FechaBaja

#line default
#line hidden
#nullable disable
                    , format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
                    __builder3.AddAttribute(20, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => modelBajaFuncionarioDTO.FechaBaja = __value, modelBajaFuncionarioDTO.FechaBaja, format: "yyyy-MM-dd", culture: global::System.Globalization.CultureInfo.InvariantCulture));
                    __builder3.SetUpdatesAttributeName("value");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(21, "\r\n            ");
                    __builder3.OpenElement(22, "div");
                    __builder3.AddAttribute(23, "class", "form-group");
                    __builder3.AddMarkupContent(24, "<label>Motivo de egreso</label>\r\n                    ");
                    __builder3.OpenElement(25, "input");
                    __builder3.AddAttribute(26, "type", "text");
                    __builder3.AddAttribute(27, "class", "form-control borderActive");
                    __builder3.AddAttribute(28, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 13 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
                                              modelBajaFuncionarioDTO.Motivo

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => modelBajaFuncionarioDTO.Motivo = __value, modelBajaFuncionarioDTO.Motivo));
                    __builder3.SetUpdatesAttributeName("value");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(30, "\r\n            ");
                    __builder3.OpenElement(31, "div");
                    __builder3.AddAttribute(32, "class", "row justify-content-center");
                    __builder3.OpenElement(33, "button");
                    __builder3.AddAttribute(34, "class", "btn btn-primary form-control col-5 mr-2");
                    __builder3.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
                                                                                  BajaDefinitivaFuncionario

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(36, "Dar de Baja");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(37, "\r\n                ");
                    __builder3.OpenElement(38, "button");
                    __builder3.AddAttribute(39, "class", "btn btn-primary form-control col-5 ml-2");
                    __builder3.AddAttribute(40, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
                                                                                  Cerrar

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(41, "Cancelar");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(42, "\r\n    ");
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogAnimationSettings>(43);
                __builder2.AddAttribute(44, "Effect", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Popups.DialogEffect>(
#nullable restore
#line 22 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
                                      DialogEffect.Fade

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(45, "\r\n");
            __builder.AddMarkupContent(46, "<style>\r\n    #target {\r\n        max-height: 800px;\r\n        height: 100%;\r\n    }\r\n</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Componentes\Funcionarios\ModalBajaFuncionario.razor"
       
    [Parameter]
    public bool Visibilidad { get; set; }

    [Parameter]
    public EventCallback<ModelBajaFuncionario> BajaDefinitiva { get; set; }

    [Parameter]
    public EventCallback CerrarModal { get; set; }

    [Parameter]
    public ModelBajaFuncionario modelBajaFuncionarioDTO { get; set; }

    private string motivo;

    private async Task BajaDefinitivaFuncionario()
    {
        if (modelBajaFuncionarioDTO.FechaBaja <= DateTime.Today.Date && !string.IsNullOrEmpty(modelBajaFuncionarioDTO.Motivo))
        {
            await BajaDefinitiva.InvokeAsync(modelBajaFuncionarioDTO);
        }
        else
        {
            await js.MsgAdvertencia("La fecha debe ser anterior a la fecha de hoy y el motivo no puede ser un campo vacio");
            return;
        }
    }
    private async Task Cerrar()
    {
        await CerrarModal.InvokeAsync();
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
    }
}
#pragma warning restore 1591
