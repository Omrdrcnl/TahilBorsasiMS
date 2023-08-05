using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{

    public class LabValidator : AbstractValidator<tblLabData>
    {
        public LabValidator()
        {
            RuleFor(k => k.NutritionalValue).NotEmpty().WithMessage("Kimlik numarası Boş Geçilemez");
            RuleFor(k => k.NutritionalValue).LessThanOrEqualTo(100).WithMessage("Besin değeri en fazla 100 olabilir");

        }
    }
}
