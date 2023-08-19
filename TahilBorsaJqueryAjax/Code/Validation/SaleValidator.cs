using FluentValidation;
using TahilBorsaJqeryAjax.Areas.Admin.Model;

namespace TahilBorsaJqeryAjax.Code.Validation
{

    public class SaleValidator : AbstractValidator<SaleModel>
    {

        public SaleValidator()
        {
            RuleFor(k => k.TradesmanId).NotEmpty().WithMessage("Esnaf Kayıt No Boş Geçilemez");
            RuleFor(k => k.BasePrice).NotEmpty().WithMessage("Başlangıç Fiyatı Boş Geçilemez");
            RuleFor(k => k.ActualPrice).NotEmpty().WithMessage("Satış Fiyatı Boş Geçilemez");
            RuleFor(k => k.BasePrice).NotEmpty().WithMessage("Başlangıç Fiyatı Boş Geçilemez");
        }
    }
}
