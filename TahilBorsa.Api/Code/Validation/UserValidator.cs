﻿using FluentValidation;
using FluentValidation.AspNetCore;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Code.Validation
{
    public class UserValidator : AbstractValidator<tblUser>
    {
        public UserValidator()
        {
            RuleFor(k => k.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(k => k.Password).Length(6, 15).WithMessage("Kullanıcı Şifresi En az 6 en fazla 15 karakter olabilir");
        }


    }
}
