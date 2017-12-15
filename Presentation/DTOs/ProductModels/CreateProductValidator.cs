using FluentValidation;
using System;

namespace Presentation.DTOs.ProductModels
{
    public class CreateProductValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.Category).NotNull().NotEmpty();
            RuleFor(p => p.Price).NotNull().GreaterThan(0);
            RuleFor(p => p.Provider).NotNull().NotEmpty();
            RuleFor(p => p.Quantity).NotNull().GreaterThan(0);
            RuleFor(p => p.BoughtAt).NotEmpty().LessThanOrEqualTo(DateTime.Today);
        }
    }
}
