using FluentValidation;
using Nagarro.Sample.Shared;
using System.Collections.Generic;

namespace Nagarro.Sample.Validations
{

    public class EventValidator : AbstractValidator<EventDTO>
    {
        public EventValidator()
        {

            RuleFor(dto => dto.BookTitle).NotNull().NotEmpty();
            RuleFor(dto => dto.Date).NotNull().NotEmpty();
            RuleFor(dto => dto.Location).NotNull().NotEmpty();
        }
    }
}
