using FluentValidation;
using TahilBorsaJqeryAjax.Areas.Admin.Model;

namespace TahilBorsaJqeryAjax.Code.Validation
{
    public class EntryProductValidator : AbstractValidator<EntryProductModel>
    {
        
        public EntryProductValidator()
        {
            RuleFor(k => k.FarmerId).NotEmpty().WithMessage("Çiftçi Id Boş Geçilemez");
            RuleFor(k => k.DateTime).NotEmpty().WithMessage("Tarih Boş Geçilemez");
            RuleFor(k => k.ProductId).NotEmpty().WithMessage("Ürün Boş Geçilemez");
        }
    }
}
