using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FastTech.LojaCardapio.Application.Validations
{

        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class TwoDecimalPlacesAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value == null)
                    return ValidationResult.Success; // aceita null, use [Required] para obrigar

                if (value is decimal decValue)
                {
                    // Convertendo para string no formato invariante para facilitar análise
                    var stringValue = decValue.ToString(CultureInfo.InvariantCulture);

                    var parts = stringValue.Split('.');

                    // Se não tem parte decimal, ok
                    if (parts.Length == 1)
                        return ValidationResult.Success;

                    // Se tem parte decimal, verificar se tem até 2 dígitos
                    if (parts.Length == 2 && parts[1].Length <= 2)
                        return ValidationResult.Success;

                    // Se chegou aqui, tem mais que 2 casas decimais
                    return new ValidationResult(ErrorMessage ?? "The field must have up to two decimal places.");
                }

                return new ValidationResult(ErrorMessage ?? "Invalid decimal value.");
            }
        }
    
}
