using Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Validations
{
    public class CedulaVerification : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cedula = (string)value;

            if (string.IsNullOrEmpty(cedula))
            {
                return new ValidationResult("No puede dejar el campo vacio");
            }
            if (cedula.Length != 8)
            {
                return new ValidationResult("La cedula no tiene formato correcto");
            }

            string documento = cedula.Substring(0, cedula.Length - 1);
            string digitoVerificador = cedula.Substring(cedula.Length-1, 1);

            char[] digitos = documento.ToCharArray();

            int sumaDigitos = 2 * ToInt(digitos[0].ToString()) + 9* ToInt(digitos[1].ToString()) + 8* ToInt(digitos[2].ToString()) 
                + 7* ToInt(digitos[3].ToString()) + 6* ToInt(digitos[4].ToString()) + 3* ToInt(digitos[5].ToString()) +
                4* ToInt(digitos[6].ToString());

            int mod = sumaDigitos % 10;
            int resultadoaVerificar = (10 - mod) % 10;


            if (ToInt(digitoVerificador) != resultadoaVerificar)
            {
                return new ValidationResult("La cedula no es correcta");
            }
            return ValidationResult.Success;
        }
        private int ToInt(string value)
        {
            return SD.ConvertStringToInt(value);
        }
    }
}
