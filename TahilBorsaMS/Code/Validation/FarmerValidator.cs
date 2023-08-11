using FluentValidation;
using System.Linq;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{

    public class FarmerValidator : AbstractValidator<tblFarmer>
    {
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5();

        public FarmerValidator()
        {
            RuleFor(k => k.FirstName).NotEmpty().WithMessage(" Adı Boş Geçilemez");
            RuleFor(k => k.LastName).NotEmpty().WithMessage("Soyadı Boş Geçilemez");
            RuleFor(k => k.IdentityNo).NotEmpty().WithMessage("Kimlik numarası Boş Geçilemez");
            RuleFor(k => k.FirstName).Length(2, 30).WithMessage("Ad En az 2 en fazla 30 karakter olabilir");
            RuleFor(k => k.LastName).Length(2, 20).WithMessage("Ad En az 2 en fazla 20 karakter olabilir");
            RuleFor(k => k.Contact).Length(11).WithMessage("Nu 11 hane olmalıdır");
            RuleFor(farmer => farmer.IdentityNo)
        .NotEmpty().WithMessage("TC Kimlik No boş olamaz.")
        .Length(11).WithMessage("TC Kimlik No 11 haneli olmalıdır.")
        .Must(BeUniqueIdentityNo).WithMessage("Bu TC Kimlik No zaten kayıtlı.");
        }

        private bool BeUniqueIdentityNo(string IdentityNo)
        {
            var uniq = db.tblFarmer.Where(x => x.IdentityNo == IdentityNo).SingleOrDefault();
            if (uniq != null)
            {
                return false;
            }
            else { return true; }
        }
    }
}
