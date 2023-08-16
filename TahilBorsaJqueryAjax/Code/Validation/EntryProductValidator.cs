using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{
    public class EntryProductValidator : AbstractValidator<tblEntryProduct>
    {
        
        public EntryProductValidator()
        {
            RuleFor(k => k.tblFarmerId).NotEmpty().WithMessage("Çiftçi Id Boş Geçilemez").
            NotEqual(0).WithMessage("Çiftçi Id Alanı 0 Olamaz")
            .Must(BeInFarmers).WithMessage("Kayıtlı bir Çiftçi Bulunmamaktadır, Lütfen Kayıt Olunuz.!!");
            RuleFor(k => k.DateTime).NotEmpty().WithMessage("Tarih Boş Geçilemez");
        }

        private bool BeInFarmers(int id)
        {

            var k = 2;

            

            if (k == null) { return false; } else { return true; }
        }
    }
}
