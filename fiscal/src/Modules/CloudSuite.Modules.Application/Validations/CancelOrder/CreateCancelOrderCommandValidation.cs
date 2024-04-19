﻿using CloudSuite.Modules.Application.Handlers.CancelOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.CancelOrder
{
    public class CreateCancelOrderCommandValidation : AbstractValidator<CreateCancelOrderCommand>
    {
        public CreateCancelOrderCommandValidation() 
        {

            RuleFor(a => a.IdeCancelamento.CancelReason)
                .NotNull()
                .WithMessage("O motivo do cancelamento não pode ser nulo.")
                .MaximumLength(200)
                .WithMessage("O motivo do cancelamento não pode ter mais de 200 caracteres.")
                .MinimumLength(10)
                .WithMessage("O motivo do cancelamento deve ter pelo menos 10 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O motivo do cancelamento só pode conter letras, números, espaços e vírgulas.");

            RuleFor(a => a.IdeCancelamento.TimeDate)
                .NotEmpty()
                .WithMessage("A data e hora não podem estar vazias.")
                .Must(date => date != default(DateTimeOffset))
                .WithMessage("A data e hora devem ser uma data válida.");

            RuleFor(a => a.RequestDate)
                .NotEmpty()
                .WithMessage("A data de solicitação não pode estar vazia.")
                .Must(date => date != default(DateTimeOffset))
                .WithMessage("A data de solicitação deve ser uma data válida.");

                RuleFor(a => a.Cnpj)
                    .Must(cnpj => IsValid(cnpj.CnpjNumber))
                    .WithMessage("O campo Cnpj é inválido.");

            
    }

        private bool IsValid(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            // Remove non-digit characters
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            // CNPJ must have 14 digits
            if (cnpj.Length != 14)
                return false;

            // Check for repeated digits or invalid checksum
            if (IsRepeatedDigits(cnpj) || !IsValidChecksum(cnpj))
                return false;

            return true;
        }

        private bool IsRepeatedDigits(string cnpjNumber)
        {
            return cnpjNumber == new string(cnpjNumber[0], 14);
        }

        // Private method to validate the CNPJ checksum
        private bool IsValidChecksum(string cnpjNumber)
        {
            var sum = 0;
            var multiplier = 5;

            // Calculate the first checksum digit
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            var remainder = sum % 11;
            var digit1 = (remainder < 2) ? 0 : 11 - remainder;

            sum = 0;
            multiplier = 6;

            // Calculate the second checksum digit
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            remainder = sum % 11;
            var digit2 = (remainder < 2) ? 0 : 11 - remainder;

            // Compare the calculated checksum digits with the provided ones
            return (int.Parse(cnpjNumber[12].ToString()) == digit1) && (int.Parse(cnpjNumber[13].ToString()) == digit2);
        }
    }
}