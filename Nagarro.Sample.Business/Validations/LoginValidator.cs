using FluentValidation;
using Nagarro.Sample.Shared;


namespace Nagarro.Sample.Validations
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {

            RuleFor(dto => dto.Email).NotNull().NotEmpty();
            RuleFor(dto => dto.Password).NotNull().NotEmpty();

        }
    }
}
