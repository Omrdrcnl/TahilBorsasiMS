using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{

    public class LabValidator : AbstractValidator<tblLabData>
    {
       
        public LabValidator()
        {
            RuleFor(k => k.tblEntryProductId).NotEmpty().WithMessage("Ürün Giriş Numarası Boş Geçilemez");
                //.Must(BeInProductEntryId).WithMessage("Bu numarada bir ürün girişi Bulunmamaktadır.!");
            RuleFor(k => k.NutritionalValue).NotEmpty().WithMessage("Besin Değeri Boş Geçilemez")
                .LessThanOrEqualTo(100).WithMessage("Besin değeri en fazla 100 olabilir");

        }

        private bool BeInProductEntryId(int id)
        {
            //var k = db.tblEntryProduct.Find(id);
            //if(k == null)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return false;
        }
    }
}
