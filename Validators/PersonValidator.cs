using FluentValidation;
using IntegraTestTask.Entities;
using System.Text.RegularExpressions;

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
                RuleFor(x => x.Address).NotEmpty().MaximumLength(255).Must(address => Regex.IsMatch(address, "[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+,\\s[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\\s]+,\\s[A-Za-z0-9żźćńółęąśŻŹĆĄŚĘŁÓŃ/\\s]+")).WithMessage("Adres musi być w formacie WOJEWÓDZTWO, MIASTO, ULICA NR");
            }

        public bool IsBirthdateValid(DateOnly birthdate)
        {
            return birthdate <= today && birthdate > tooLongAgo;
        }
    }
}
