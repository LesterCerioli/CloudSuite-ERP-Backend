using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Sintegra
{
    public class AtividadeSecundaria : Entity, IAggregateRoot
    {
        public AtividadeSecundaria(string? text, string? code)
        {
            this.text = text;
            this.code = code;
        }

        public string? text { get; private set; }

        public string? code { get; private set; }
    }
}
