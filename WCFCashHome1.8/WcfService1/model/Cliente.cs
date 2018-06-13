using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace WcfService1.model
{
   [DataContract]
    public class Cliente
    {
        private String nome;
        private String email;
        private String dataNascimento;
        private String cpf;
        private String senha;
        private int id;

        public Cliente()
        {

        }
        public Cliente(String nome, String email, String senha, String dataNascimento, String cpf)
        {
            this.nome = nome;
            this.email = email;
            this.dataNascimento = dataNascimento;
            this.cpf = cpf;
            this.senha = senha;
        }
 
        [DataMember(IsRequired = true)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember(IsRequired = true)]
        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        [DataMember(IsRequired = true)]
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember(IsRequired = true)]
        public String DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        [DataMember(IsRequired = true)]
        public String Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        [DataMember(IsRequired = true)]
        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

    }
}