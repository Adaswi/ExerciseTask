using FluentValidation;
using IntegraTestTask.Entities;

namespace IntegraTestTask.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(255);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Birthdate).NotEmpty().Must(birthdate => IsBirthdateValid(birthdate)).WithMessage("Data urodzenia musi być poprawna.");
            RuleFor(x => x.Address).NotEmpty().EmailAddress();
        }

        public static bool IsBirthdateValid(DateTime birthdate)
        {
            return (birthdate <= DateTime.Now && birthdate > DateTime.Now.AddYears(-150));
        }
    }
}
