using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email Alanı Doğru Formatta Olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age Alanı 18-60 Arası Olmalıdır");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalıdır");

        }
    }
}
