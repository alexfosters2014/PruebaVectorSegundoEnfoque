#pragma checksum "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f636c16500a80970a289b01281a70da192d80500"
// <auto-generated/>
#pragma warning disable 1591
namespace VectorCliente.Shared
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
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<BlazorAnimate.Animate>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(2, "div");
                __builder2.AddAttribute(3, "class", "page");
                __builder2.AddAttribute(4, "b-zhbzpxf81l");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "sidebar" + " " + (
#nullable restore
#line 10 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
                         Esconder

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(7, "b-zhbzpxf81l");
#nullable restore
#line 11 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
         if(usuario != null)
            {

#line default
#line hidden
#nullable disable
                __builder2.OpenComponent<VectorCliente.Shared.NavMenuAdmin>(8);
                __builder2.AddAttribute(9, "usuario", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Modelo.UsuarioDTO>(
#nullable restore
#line 13 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
                                    usuario

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
#nullable restore
#line 14 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
            }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(10, "\r\n\r\n    ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "main animated bounceOutDown infinite");
                __builder2.AddAttribute(13, "b-zhbzpxf81l");
                __builder2.OpenElement(14, "div");
                __builder2.AddAttribute(15, "class", "top-row px-4");
                __builder2.AddAttribute(16, "b-zhbzpxf81l");
                __builder2.OpenElement(17, "a");
                __builder2.AddAttribute(18, "href", "");
                __builder2.AddAttribute(19, "class", "navbar-brand");
                __builder2.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
                                                      Toggle

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddEventPreventDefaultAttribute(21, "onclick", true);
                __builder2.AddAttribute(22, "b-zhbzpxf81l");
                __builder2.AddMarkupContent(23, "<img src=\"icons/hamburguesa.png\" class=\"imgTable\" b-zhbzpxf81l>");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n            ");
                __builder2.OpenElement(25, "a");
                __builder2.AddAttribute(26, "href", "");
                __builder2.AddAttribute(27, "class", "ml-md-auto");
                __builder2.AddAttribute(28, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
                                                    Salir

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddEventPreventDefaultAttribute(29, "onclick", true);
                __builder2.AddAttribute(30, "b-zhbzpxf81l");
                __builder2.AddContent(31, "Salir");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(32, "\r\n\r\n        ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "content px-4");
                __builder2.AddAttribute(35, "b-zhbzpxf81l");
#nullable restore
#line 26 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
__builder2.AddContent(36, Body);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(37, "\r\n\r\n");
            __builder.OpenComponent<Blazored.Toast.BlazoredToasts>(38);
            __builder.AddAttribute(39, "Position", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazored.Toast.Configuration.ToastPosition>(
#nullable restore
#line 34 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
                          Blazored.Toast.Configuration.ToastPosition.TopCenter

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(40, "IconType", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazored.Toast.IconType?>(
#nullable restore
#line 35 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
                          IconType.FontAwesome

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(41, "InfoIcon", "fa fa-info");
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 38 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\MainLayout.razor"
      

    private UsuarioDTO usuario;

    private bool toggle = true;

    protected async override Task OnInitializedAsync()
    {
        await CargaInicialMenu();
    }

    private async Task CargaInicialMenu()
    {
        usuario = await localStorage.GetItemAsync<UsuarioDTO>(SD.LocalUsuario);
        if (usuario == null)
        {
            nav.NavigateTo("/", true);
            return;
        }
    }

    private void Toggle()
    {
        toggle = !toggle;
    }

    private string Esconder => !toggle ? "collapse" : null; 

    private async Task Salir()
    {
        await localStorage.ClearAsync();
        nav.NavigateTo("/", true);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService localStorage { get; set; }
    }
}
#pragma warning restore 1591