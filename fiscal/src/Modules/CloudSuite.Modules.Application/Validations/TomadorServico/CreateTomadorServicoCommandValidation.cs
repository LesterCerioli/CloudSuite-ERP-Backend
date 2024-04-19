﻿using CloudSuite.Modules.Application.Handlers.TomadorServico;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Validations.TomadorServico
{
    public class CreateTomadorServicoCommandValidation : AbstractValidator<CreateTomadorServicoCommand>
    {
        public CreateTomadorServicoCommandValidation()
        {

            RuleFor(a => a.InscricaoMunicipal)
                .NotNull()
                .WithMessage("A inscrição municipal não pode ser nula.")
                .MaximumLength(100)
                .WithMessage("A inscrição municipal não pode ter mais de 100 caracteres.");

            RuleFor(a => a.InscricaoEstadual)
                .NotNull()
                .WithMessage("A inscrição estadual não pode ser nula.")
                .MaximumLength(100)
                .WithMessage("A inscrição estadual não pode ter mais de 100 caracteres.");

            RuleFor(a => a.DocTomadorEstrangeiro)
                .NotNull()
                .WithMessage("O documento do tomador estrangeiro não pode ser nulo.")
                .MaximumLength(100)
                .WithMessage("O documento do tomador estrangeiro não pode ter mais de 100 caracteres.");

            RuleFor(a => a.SocialReason)
                .NotNull()
                .WithMessage("A razão social não pode ser nula.")
                .MaximumLength(100)
                .WithMessage("A razão social não pode ter mais de 100 caracteres.");

            RuleFor(a => a.NomeFantasia)
                .NotNull()
                .WithMessage("O nome fantasia não pode ser nulo.")
                .MaximumLength(100)
                .WithMessage("O nome fantasia não pode ter mais de 100 caracteres.");

            RuleFor(a => a.Address)
                .NotNull()
                .WithMessage("O endereço não pode ser nulo.");

            RuleFor(a => a.Tipo)
                .NotNull()
                .WithMessage("O tipo não pode ser nulo.")
                .IsInEnum()
                .WithMessage("O tipo deve ser um valor válido.");

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