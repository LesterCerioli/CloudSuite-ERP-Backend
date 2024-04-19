using CloudSuite.Commons.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public Guid Id { get; private set; }


        [DisplayName("Fullname")]
        [MaxLength(50)]
        [Required(ErrorMessage = "O nome completo do funcionário deve ser informado")]
        public string? Fullname { get; set; }


        [DisplayName("Email")]
        [MaxLength(50)]
        [Required(ErrorMessage = "O email deve ser informado.")]
        public string? EmailAddress { get; set; }


        [DisplayName("Cpf")]
        [MinLength(11)]
        [MaxLength(11)]
        [Required(ErrorMessage = "O Cpf do funcionário deve ser informado")]
        public string? Cpf { get; set; }
    }
}
