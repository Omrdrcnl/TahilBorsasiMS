using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{
    public class ProductValidator : AbstractValidator<tblProduct>
    {
        public ProductValidator()
        {
            RuleFor(k => k.Name).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez").
                Length(2, 30).WithMessage("Ad En az 2 en fazla 30 karakter olabilir");
            RuleFor(k => k.Information).NotEmpty().WithMessage("Ürün Bilgisi Boş Geçilemez");
        }
    }
}
