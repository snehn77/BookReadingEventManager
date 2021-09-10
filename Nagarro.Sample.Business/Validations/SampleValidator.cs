using FluentValidation;
using Nagarro.Sample.Shared;

namespace Nagarro.Sample.Validations
{
    public class SampleValidator : AbstractValidator<UserDTO>
    {
        public SampleValidator()
        {
            //SampleProperty2 value should be not be null or empty
            RuleFor(dto => dto.Email).NotNull().NotEmpty();
            RuleFor(dto => dto.FirstName).NotNull().NotEmpty();
            RuleFor(dto => dto.LastName).NotNull().NotEmpty();
            RuleFor(dto => dto.Password).NotNull().NotEmpty();
            //SampleProperty1 value should be greater than 10
            //RuleFor(dto => dto.FirstName).GreaterThan(10);
        }
    }

}
