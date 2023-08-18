using FluentValidation;
using System.Linq;
using TahilBorsaJqeryAjax.Areas.Admin.Model;


namespace TahilBorsaJqeryAjax.Code.Validation
{

    public class FarmerValidator : AbstractValidator<FarmerModel>
    {


        public FarmerValidator()
        {
            RuleFor(k => k.FirstName).NotEmpty().WithMessage(" Adı Boş Geçilemez");
            RuleFor(k => k.LastName).NotEmpty().WithMessage("Soyadı Boş Geçilemez");
            RuleFor(k => k.FirstName).Length(2, 30).WithMessage("Ad En az 2 en fazla 30 karakter olabilir");
            RuleFor(k => k.LastName).Length(2, 20).WithMessage("Ad En az 2 en fazla 20 karakter olabilir");
            RuleFor(k => k.Contact).Length(11).WithMessage("Nu 11 hane olmalıdır");
            RuleFor(farmer => farmer.IdentityNo)
        .NotEmpty().WithMessage("TC Kimlik No boş olamaz.")
        .Length(11).WithMessage("TC Kimlik No 11 haneli olmalıdır.");
        }


    }
}
