using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.model
{
    [DataContract]
    public class Despesas
    {
        string dataEmissao, descricao, categoria, emailCliente;
        int status , idDespesa;
        float valorDespesa;


        public Despesas(int id, String dataEmissao, string descricao, string categoria, float valorDespesa, int status)
        {
            this.dataEmissao = dataEmissao;
            this.descricao = descricao;
            this.categoria = categoria;
            this.valorDespesa = valorDespesa;
            this.status = status;
            this.idDespesa = id;
        }

        public Despesas(String dataEmissao, string descricao, string categoria, float valorDespesa, int status)
        {
            this.dataEmissao = dataEmissao;
            this.descricao = descricao;
            this.categoria = categoria;
            this.valorDespesa = valorDespesa;
            this.status = status;
        }
        [DataMember(IsRequired = true)]
        public string EmailCliente
        {
            get { return emailCliente; }
            set { emailCliente = value; }
        }

        [DataMember(IsRequired = true)]
        public string DataEmissao
        {
            get { return dataEmissao; }
            set { dataEmissao = value; }
        }

        [DataMember(IsRequired = true)]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember(IsRequired = true)]
        public float ValorDespesa
        {
            get { return valorDespesa; }
            set { valorDespesa = value; }
        }

        [DataMember(IsRequired = true)]
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        [DataMember(IsRequired = true)]
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        [DataMember(IsRequired = true)]
        public int IdDespesa
        {
            get { return idDespesa; }
            set { idDespesa = value; }
        }
    }
}