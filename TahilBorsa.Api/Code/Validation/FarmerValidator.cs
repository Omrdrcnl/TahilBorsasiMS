using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{
   
        public class FarmerValidator : AbstractValidator<tblFarmer>
        {

            public FarmerValidator()
            {
                RuleFor(k => k.FirstName).NotEmpty().WithMessage(" Adı Boş Geçilemez");
                RuleFor(k => k.LastName).NotEmpty().WithMessage("SoyAdı Boş Geçilemez");
                RuleFor(k => k.IdentityNo).NotEmpty().WithMessage("Kimlik numarası Boş Geçilemez");
                RuleFor(k => k.FirstName).Length(2, 30).WithMessage("Ad En az 2 en fazla 30 karakter olabilir");
                RuleFor(k => k.LastName).Length(2, 20).WithMessage("Ad En az 2 en fazla 20 karakter olabilir");
                RuleFor(k => k.Contact).Length(11).WithMessage("Nu 11 hane olmalıdır");
                RuleFor(k => k.IdentityNo).Length(11).WithMessage("Kimlik numarası 11 hane olmalıdır");
            }
        }
}
