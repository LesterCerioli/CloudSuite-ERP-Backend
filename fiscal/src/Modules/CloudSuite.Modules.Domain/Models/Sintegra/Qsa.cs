using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Sintegra
{
    public class Qsa : Entity, IAggregateRoot
    {
        public Qsa(string? qual, string? qual_rep_legal, 
            string? nome_rep_legal, string? pais_origem, 
            string? nome)
        {
            this.qual = qual;
            this.qual_rep_legal = qual_rep_legal;
            this.nome_rep_legal = nome_rep_legal;
            this.pais_origem = pais_origem;
            this.nome = nome;
        }

        public string? qual { get; private set; }

        public string? qual_rep_legal { get; private set; }

        public string? nome_rep_legal { get; private set; }

        public string? pais_origem { get; private set; }

        public string? nome { get; private set; }
    }
}
