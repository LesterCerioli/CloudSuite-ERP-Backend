using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.ViewModels
{
    public class TimeRecordViewModel
    {


        [Key]
        public Guid Id { get; private set; }


        [DisplayName("HoraEntrada")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? EntryTime { get; set; }


        [DisplayName("HoraSaida")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? ExitTime { get; set; }

        [DisplayName("AlmocoHoraEntrada")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? LunchEntryTime { get; set; }


        [DisplayName("HoraAlmocoRetorno")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? LunchReturnTime { get; set; }

        
    }
}
