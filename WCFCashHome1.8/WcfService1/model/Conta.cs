using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.model
{
    [DataContract]
    public class Conta
    {
       
        float salarioConta;
        string emailCliente;

        public Conta (float salario, string email)
        {
            this.salarioConta = salario;
            this.emailCliente = email;
        }

        public Conta()
        {

        }

        [DataMember(IsRequired = true)]
        public float SalarioConta
        {
            get { return salarioConta; }
            set { salarioConta = value; }
        }

        [DataMember(IsRequired = true)]
        public string EmailCliente
        {
            get { return emailCliente; }
            set { emailCliente = value; }
        }
    }
}