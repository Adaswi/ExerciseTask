using FluentValidation;
using IntegraTestTask.Entities;

namespace IntegraTestTask.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        private DateOnly today = DateOnly.FromDateTime(DateTime.UtcNow);
        private DateOnly tooLongAgo = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-150));

        public PersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(255);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Birthdate).Must(birthdate => !birthdate.Equals(default(DateOnly))).WithMessage("Data musi być w formacie YYYY-MM-DD").Must(birthdate => IsBirthdateValid(birthdate)).WithMessage($"Data urodzenia nie może być przed {tooLongAgo} lub po {today}");
            RuleFor(x => x.Address).NotEmpty().EmailAddress();
        }

        public static bool IsBirthdateValid(DateOnly birthdate)
        {
            return (birthdate <= DateOnly.FromDateTime(DateTime.UtcNow) && birthdate > DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-150)));
        }
    }
}
