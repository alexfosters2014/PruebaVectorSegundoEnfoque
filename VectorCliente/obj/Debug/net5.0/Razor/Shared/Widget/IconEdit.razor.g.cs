#pragma checksum "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "298a3ff5da3bd73028388018db83bd2afa27b831"
// <auto-generated/>
#pragma warning disable 1591
namespace VectorCliente.Shared.Widget
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
    public partial class IconEdit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 2 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "add")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "img");
            __builder.AddAttribute(1, "src", "/icons/add.png");
            __builder.AddAttribute(2, "class", "botonPDFVisor");
            __builder.AddAttribute(3, "title", 
#nullable restore
#line 4 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                            Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 5 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "addChico")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(4, "img");
            __builder.AddAttribute(5, "src", "/icons/add.png");
            __builder.AddAttribute(6, "class", "imgTable");
            __builder.AddAttribute(7, "title", 
#nullable restore
#line 8 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                       Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 9 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "delete")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "img");
            __builder.AddAttribute(9, "src", "/icons/delete.png");
            __builder.AddAttribute(10, "class", "imgTable");
            __builder.AddAttribute(11, "title", 
#nullable restore
#line 12 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                          Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 13 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "BAJA_DEFINITIVA")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(12, "img");
            __builder.AddAttribute(13, "src", "/icons/false.png");
            __builder.AddAttribute(14, "class", "imgTable");
            __builder.AddAttribute(15, "title", 
#nullable restore
#line 16 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                         Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 17 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "BAJA_PARA_LIQUIDACION")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(16, "img");
            __builder.AddAttribute(17, "src", "/icons/bajaParcial.png");
            __builder.AddAttribute(18, "class", "imgTable");
            __builder.AddAttribute(19, "title", 
#nullable restore
#line 20 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                               Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 21 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "ACTIVO")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(20, "img");
            __builder.AddAttribute(21, "src", "/icons/true.png");
            __builder.AddAttribute(22, "class", "imgTable");
            __builder.AddAttribute(23, "title", 
#nullable restore
#line 24 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                        Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 25 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "ver")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(24, "img");
            __builder.AddAttribute(25, "src", "/icons/eye.png");
            __builder.AddAttribute(26, "class", "imgTable");
            __builder.AddAttribute(27, "title", 
#nullable restore
#line 28 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                       Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 29 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "editar")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(28, "img");
            __builder.AddAttribute(29, "src", "/icons/edit.png");
            __builder.AddAttribute(30, "class", "imgTable");
            __builder.AddAttribute(31, "title", 
#nullable restore
#line 32 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                        Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 33 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "preferenciaFunServicio")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(32, "img");
            __builder.AddAttribute(33, "src", "/icons/PreferenciaFunServicio.png");
            __builder.AddAttribute(34, "class", "imgTable");
            __builder.AddAttribute(35, "title", 
#nullable restore
#line 36 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                                          Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 37 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
 if (Icon == "HistoricoServicio")
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(36, "img");
            __builder.AddAttribute(37, "src", "/icons/HistorialServicio.png");
            __builder.AddAttribute(38, "class", "imgTable");
            __builder.AddAttribute(39, "title", 
#nullable restore
#line 40 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
                                                                     Titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 41 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "C:\Users\Alex\Source\Repos\alexfosters2014\PruebaVectorSegundoEnfoque\VectorCliente\Shared\Widget\IconEdit.razor"
      
    [Parameter]
    public string Icon { get; set; }

    [Parameter]
    public string Titulo { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591