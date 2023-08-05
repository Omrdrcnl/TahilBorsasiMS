using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{
    public class ProductValidator : AbstractValidator<tblProduct>
    {
        public ProductValidator()
        {
            RuleFor(k => k.Name).NotEmpty().WithMessage("Kimlik numarası Boş Geçilemez");
            RuleFor(k => k.Name ).Length(2, 30).WithMessage("Ad En az 2 en fazla 30 karakter olabilir");
        }
    }
}
