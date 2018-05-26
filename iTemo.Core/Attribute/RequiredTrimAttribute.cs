using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace iTemo.Core.Attribute
{
    public class RequiredTrimAttribute : ValidationAttribute, IClientValidatable
    {
        public RequiredTrimAttribute()
        {
            ErrorMessage = Constants.Messages.CommonMsg005;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString().Trim()))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule { ErrorMessage = ErrorMessage, ValidationType = "requiredtrim" };

            yield return rule;
        }
    }
}
