using FluentValidation;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Code.Validation
{
    public class UserValidator : AbstractValidator<tblUser>
    {
        public UserValidator()
        {
            RuleFor(k => k.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(k => k.Password).NotEmpty().WithMessage("Kullanıcı Şifre Boş Geçilemez");

            //RuleFor(k => k.Password).Length(6, 15).WithMessage("Kullanıcı Şifresi En az 6 en fazla 15 karakter olabilir");
        }


    }
}
