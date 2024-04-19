﻿using CloudSuite.Modules.Application.Hadlers.Address.Requests;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Address
{
    public class CheckAddressExistsByAddressLineRequestValidation : AbstractValidator<CheckAddressExistsByAddressLineRequest>
    {
        public CheckAddressExistsByAddressLineRequestValidation()
        {
            RuleFor(a => a.AddressLine1)
                .NotEmpty()
                .WithMessage("O campo AddressLine1 é obrigatório.")
                .Length(1, 300)
                .WithMessage("O campo AddressLine1 deve ter entre 1 e 300 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O campo AddressLine1 deve conter apenas letras, números, espaços e vírgulas.")
                .NotNull()
                .WithMessage("O campo AddressLine1 não pode ser nulo.");
        }
    }
}
