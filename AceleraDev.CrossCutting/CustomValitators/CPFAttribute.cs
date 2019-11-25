using System.ComponentModel.DataAnnotations;

namespace AceleraDev.CrossCutting.CustomValitators
{
    public class CPFAttribute: ValidationAttribute
    {
        public CPFAttribute(string errorMessage = "O campo CPF é inválido.") : base(errorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            return Utils.Utils.ValidaCPF(value.ToString());
        }
    }
}
