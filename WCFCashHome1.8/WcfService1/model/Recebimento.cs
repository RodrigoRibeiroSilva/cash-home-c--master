using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.model
{
    [DataContract]
    public class Recebimento
    {
        String dataRecebimento, descricao, categoria, emailCliente;
        float valorRecebimento;
        int idRecebimento, status;

        public Recebimento()
        {

        }
        public Recebimento(int id,String dataRecebimento, string descricao, string categoria, float valorRecebimento, int status)
        {
            this.dataRecebimento = dataRecebimento;
            this.descricao = descricao;
            this.categoria = categoria;
            this.valorRecebimento = valorRecebimento;
            this.status = status;
            this.idRecebimento = id;

        }

        public Recebimento(String dataRecebimento, string descricao, string categoria, float valorRecebimento, int status)
        {
            this.dataRecebimento = dataRecebimento;
            this.descricao= descricao;
            this.categoria = categoria;
            this.valorRecebimento = valorRecebimento;
            this.status = status;
            
        }

        [DataMember(IsRequired = true)]
        public string EmailRecebimento
        {
            get { return emailCliente; }
            set { emailCliente = value; }
        }

        [DataMember(IsRequired = true)]
        public string DataRecebimento
        {
            get { return dataRecebimento; }
            set { dataRecebimento = value; }
        }

        [DataMember(IsRequired = true)]
        public float ValorRecebimento
        {
            get { return valorRecebimento; }
            set { valorRecebimento = value; }
        }

        [DataMember(IsRequired = true)]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember(IsRequired = true)]
        public int IdRecebimento
        {
            get { return idRecebimento; }
            set { idRecebimento = value; }
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
    }
}