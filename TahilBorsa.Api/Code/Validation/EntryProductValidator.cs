using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{
        public class EntryProductValidator : AbstractValidator<tblEntryProduct>
        {

            public EntryProductValidator()
            {
                RuleFor(k => k.tblProductId).NotEmpty().WithMessage(" Ürün Id Boş Geçilemez");
                RuleFor(k => k.tblFarmerId).NotEmpty().WithMessage("Çiftçi Id Boş Geçilemez");
                RuleFor(k => k.DateTime).NotEmpty().WithMessage("Tarih Boş Geçilemez");
            }
        }
}
