using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingCuncerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator,object Context)
        {
            var context = new ValidationContext<object>(Context);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
