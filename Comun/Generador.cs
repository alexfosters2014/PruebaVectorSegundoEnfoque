using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public static class Generador
    {
        public static string GenerarPassword(int longitud)
        {
            string password = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random EleccionAleatoria = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int LetraAleatoria = EleccionAleatoria.Next(0, 100);
                int NumeroAleatorio = EleccionAleatoria.Next(0, 9);

                if (LetraAleatoria < letras.Length)
                {
                    password += letras[LetraAleatoria];
                }
                else
                {
                    password += NumeroAleatorio.ToString();
                }
            }
            return password;
        }

        public static string GenerarToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
        public static string GenerarGUID()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}
