﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoveryDataEntity = CloudSuite.Modules.Domain.Models.Sintegra.RecoveryData;

namespace CloudSuite.Modules.Application.Handlers.Sintegra.CompaniesReciveryData
{
    public class CreateRecovertDataCommand
    {
        public Guid Id { get; private set; }

        public string? code { get; set; }

        public string? status { get; set; }

        public string? message { get; set; }
                        
        public string? data_situacao { get; set; }

        public string? complemento { get; set; }

        public string? nome { get; set; }

        public string? uf { get; set; }

        public string? telefone { get; set; }

        public string? email { get; set; }
                
        public string? situacao { get; set; }

        public string? bairro { get; set; }

        public string? logradouro { get; set; }

        public string? numero { get; set; }

        public string? cep { get; set; }

        public string? municipio { get; set; }

        public string? abertura { get; set; }

        public string? natureza_juridica { get; set; }

        public string? cnpj { get; set; }

        public string? ultima_atualizacao { get; set; }

        public string? tipo { get; set; }

        public string? fantasia { get; set; }

        public string? efr { get; set; }

        public string? motivo_situacao { get; set; }

        public string? situacao_especial { get; set; }

        public string? data_situacao_especial { get; set; }

        public string? capital_social { get; set; }

        public string? porte { get; set; }

        public CreateRecovertDataCommand()
        {
            Id = Guid.NewGuid();
        }

        public RecoveryDataEntity GetEntity()
        {
            return new RecoveryDataEntity(
                this.code,
                this.status,
                this.abertura,
                this.bairro,
                this.capital_social,
                this.cep,
                this.cnpj,
                this.message,
                this.data_situacao,
                this.complemento,
                this.nome,
                this.uf,
                this.telefone,
                this.email,
                this.situacao,
                this.logradouro,
                this.numero,
                this.municipio,
                this.natureza_juridica,
                this.ultima_atualizacao,
                this.tipo,
                this.fantasia,
                this.efr,
                this.motivo_situacao,
                this.situacao_especial,
                this.data_situacao_especial,
                this.porte);

        }


    }
}
