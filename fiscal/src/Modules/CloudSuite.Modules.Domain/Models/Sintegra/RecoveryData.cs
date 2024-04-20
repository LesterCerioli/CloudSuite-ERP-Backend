﻿using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Sintegra
{
    public class RecoveryData : Entity, IAggregateRoot
    {
        private object value;

        public RecoveryData(string? code, object value, string? abertura)
        {
            this.code = code;
            this.value = value;
        }

        public Guid Id { get; private set; }

        public string? code { get; set; }

        public string? status { get; set; }

        public string? message { get; set; }


        public List<AtividadePrincipal> atividade_principal { get; set; }

        public string? data_situacao { get; set; }

        public string? complemento { get; set; }

        public string? nome { get; set; }

        public string? uf { get; set; }

        public string? telefone { get; set; }

        public string? email { get; set; }

        public AtividadeSecundaria SecondActivity { get; private set; }

        //public List<AtividadesSecundaria> atividades_secundarias { get; set; }

        public List<Qsa> qsa { get; set; }

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

        public Ibge ibge { get; set; }

    }
}
