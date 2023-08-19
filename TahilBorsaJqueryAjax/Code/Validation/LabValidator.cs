using FluentValidation;
using TahilBorsaJqeryAjax.Areas.Admin.Model;

namespace TahilBorsaJqeryAjax.Code.Validation
{

    public class LabValidator : AbstractValidator<LabaratuarModel>
    {

        public LabValidator()
        {
            RuleFor(k => k.EntryProductId).NotEmpty().WithMessage("Ürün Giriş Numarası Boş Geçilemez");

            RuleFor(k => k.NutritionalValue).LessThanOrEqualTo(100).WithMessage("Besin değeri en fazla 100 olabilir");
            RuleFor(k=> k.NutritionalValue).NotEmpty().WithMessage("Besin Değeri Boş Geçilemez");
        }

    }
}
