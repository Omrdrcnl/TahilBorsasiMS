using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{
   
        public class SaleValidator : AbstractValidator<tblSale>
        {

            public SaleValidator()
            {
                RuleFor(k => k.tblTradesmanId).NotEmpty().WithMessage(" Esnaf Id Boş Geçilemez");
                RuleFor(k => k.BasePrice).NotEmpty().WithMessage(" Başlangıç Fiyatı Boş Geçilemez");
                RuleFor(k => k.ActualPrice).NotEmpty().WithMessage(" Satış Fiyatı Boş Geçilemez");
                RuleFor(k => k.tblLabDataId).NotEmpty().WithMessage("Lab Id Boş Geçilemez");
            }
        }
}
