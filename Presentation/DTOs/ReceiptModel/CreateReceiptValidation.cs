using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.DTOs.ReceiptModel
{
    class CreateReceiptValidation : AbstractValidator<CreateReceiptModel>
    {
        public CreateReceiptValidation()
        {
            RuleFor(r => r.PrintedAt).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
