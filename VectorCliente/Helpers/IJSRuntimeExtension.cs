using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorCliente.Helpers
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask<bool> MsgExitoso(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("MsgSuccess",mensaje);
        }
        public static async ValueTask<bool> MsgAdvertencia(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("MsgWarning", mensaje);
        }
        public static async ValueTask<bool> MsgError(this IJSRuntime js, string mensaje)
        {
           return await js.InvokeAsync<bool>("MsgError", mensaje);
        }
        public static async ValueTask<bool> MsgConfirmacion(this IJSRuntime js, string pregunta)
        {
            return await js.InvokeAsync<bool>("ConfirmarOperacion", pregunta);
        }
        public static async ValueTask WindowPopUp(this IJSRuntime js, string url, int width)
        {
           await js.InvokeVoidAsync("OpenWindow", url, width);
        }
        public static async ValueTask<string> OnInputText(this IJSRuntime js)
        {
            return await js.InvokeAsync<string>("OnInputText", "Info!", "Ingrese dato");
        }
        public static async ValueTask<string> OnSelectComputoSegundoNivel(this IJSRuntime js)
        {
            return await js.InvokeAsync<string>("OnSelectComputoSegundoNivel", "Selección", "Seleccione el tipo de estado del funcionario de segundo nivel");
        }
        public static async ValueTask<string[]> OnInputChangePass(this IJSRuntime js)
        {
            return await js.InvokeAsync<string[]>("OnInputTextPass");
        }
        public static async ValueTask DescargarExcel(this IJSRuntime js,string fileName, byte[] fileByte)
        {
            await js.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileByte));
        }
        public static async ValueTask DeshabilitarComponente(this IJSRuntime js, string componenteId, bool valorBooleano)
        {
            await js.InvokeVoidAsync("DeshabilitarComponente", componenteId, valorBooleano );
        }
        public static async ValueTask<DateTime?> InputDate(this IJSRuntime js, string titulo)
        {
            try { 
            return await js.InvokeAsync<DateTime?>("OnInputDate", titulo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
