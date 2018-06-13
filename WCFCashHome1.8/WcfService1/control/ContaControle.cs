using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.model;
using WcfService1.model.data;

namespace WcfService1.control
{
    public class ContaControle
    {
        Conta contaTeste;

        public ContaControle(Conta conta)
        {
            contaTeste = conta;
        }

        public ContaControle()
        {
            
        }
        private string ValidaCampos()
        {

            if (contaTeste.EmailCliente == null || contaTeste.EmailCliente == "" || contaTeste.EmailCliente.Length > 50)
            {
                return "Email inválido";
            }
            List<Conta> listaConta = new List<Conta>();
            DBConta db = new DBConta();
            listaConta = db.ListarContas();

            foreach (Conta conta in listaConta)
            {
                if (conta.EmailCliente == this.contaTeste.EmailCliente)
                {
                    return "Você já possui uma conta";
                }
            }


            return "Conta válida";
        }

        public String ContaValidaInsert()
        {
            String validar = ValidaCampos();

            if (validar == "Conta válida")
            {
                DBConta db = new DBConta(contaTeste);
                String result = db.InsertConta();
                return result;
            }
            return validar;
        }

        public List<Conta> ListarConta()
        {
            try
            {
                List<Conta> result;
                DBConta db = new DBConta();
                result = db.ListarContas();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar listar" + " " + ex.Message);
            }
        }

        public string AlterarSaldo()
        {
            try
            {
                DBConta db = new DBConta(this.contaTeste);
                db.UpdateConta();
                return "Conta Atualizada com Sucesso";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}