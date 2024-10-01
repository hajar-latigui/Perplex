using System.ComponentModel.DataAnnotations;

namespace Perplex.Models
{
    public class RequiredIfUitje : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public RequiredIfUitje(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var comparisonValue = validationContext.ObjectType.GetProperty(_comparisonProperty)?.GetValue(validationContext.ObjectInstance, null);

            if (comparisonValue != null && comparisonValue.ToString() == "uitje" && value == null)
            {
                return new ValidationResult(ErrorMessage ?? "Deze veld is vereist bij type 'uitje'.");
            }

            return ValidationResult.Success;
        }
    }
}
