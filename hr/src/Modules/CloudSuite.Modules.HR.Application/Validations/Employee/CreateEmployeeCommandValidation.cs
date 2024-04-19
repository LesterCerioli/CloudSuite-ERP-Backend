using CloudSuite.Modules.HR.Application.Core;
using CloudSuite.Modules.HR.Application.Handlers.Employees;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace CloudSuite.Modules.HR.Application.Validations.Employee
{
    public class CreateEmployeeCommandValidation : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidation()
        {

            RuleFor(a => a.Fullname)
               .NotEmpty()
               .WithMessage("The FullName field is mandatory.")
               .Length(3, 100)
               .WithMessage("The FullName field must be between 3 and 100 characters.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo FullName deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo FullName não pode ser nulo.");

            RuleFor(a => a.Cpf)
                .Must(cpf => IsValid(cpf))
                .WithMessage("O campo Cpf é inválido.");

            RuleFor(a => a.EmailAddress)
                .NotEmpty()
                .WithMessage("Completing the e-mail is mandatoryo");

        }

        private bool IsValid(string cpf)
        {
           
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
                return false;

            var sum = 0;
            var rest = 0;
            for (var i = 1; i <= 9; i++)
                sum = sum + int.Parse(cpf[i - 1].ToString()) * (11 - i);
            rest = (sum * 10) % 11;

            if ((rest == 10) || (rest == 11))
                rest = 0;
            if (rest != int.Parse(cpf[9].ToString()))
                return false;

            sum = 0;
            for (var i = 1; i <= 10; i++)
                sum = sum + int.Parse(cpf[i - 1].ToString()) * (12 - i);
            rest = (sum * 10) % 11;

            if ((rest == 10) || (rest == 11))
                rest = 0;
            if (rest != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }

    }
}
