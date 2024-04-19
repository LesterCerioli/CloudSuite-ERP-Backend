using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.ViewModels
{
    public class WorkHourViewmodel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("HorasMes")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public int? Month { get; private set; }

        [DisplayName("HorasAno")]
        public int? Year { get; private set; }

        [DisplayName("HorasTrabalho")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public double? WorkedHours { get; set; }
    }
}
