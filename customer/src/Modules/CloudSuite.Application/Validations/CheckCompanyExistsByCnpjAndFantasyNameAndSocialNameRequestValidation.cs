using CloudSuite.Application.Handlers.Companies.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Application.Validations
{
	public class CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequestValidation : AbstractValidator<CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest>
	{
		public CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequestValidation()
		{
			RuleFor(a => a.SocialName)
				.NotEmpty()
				.WithMessage("O campo SocialName é obrigatório.")
				.Length(1, 100)
				.WithMessage("O campo SocialName deve ter entre 1 e 100 caracteres.")
				.Matches(@"^[a-zA-Z\s]*$")
				.WithMessage("O campo SocialName deve conter apenas letras e espaços.")
				.NotNull()
				.WithMessage("O campo SocialName não pode ser nulo.");

			RuleFor(a => a.Cnpj)
				.Must(cnpj => IsValid(cnpj))
				.WithMessage("O campo cnpj é inválido");

			RuleFor(a => a.FantasyName)
				.NotEmpty()
				.WithMessage("O campo SocialName é obrigatório.")
				.Length(1, 100)
				.WithMessage("O campo SocialName deve ter entre 1 e 100 caracteres.")
				.Matches(@"^[a-zA-Z\s]*$")
				.WithMessage("O campo SocialName deve conter apenas letras e espaços.")
				.NotNull()
				.WithMessage("O campo SocialName não pode ser nulo.");
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
