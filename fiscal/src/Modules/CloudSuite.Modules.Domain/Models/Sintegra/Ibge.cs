using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Sintegra
{
    public class Ibge : Entity, IAggregateRoot
    {
        public Ibge(string? codigo_municipio, string? codigo_uf)
        {
            this.codigo_municipio = codigo_municipio;
            this.codigo_uf = codigo_uf;
        }

        public string? codigo_municipio { get; private set; }

        public string? codigo_uf { get; private set; }
    }
}
