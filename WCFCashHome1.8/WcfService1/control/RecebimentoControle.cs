using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.model;
using WcfService1.model.data;

namespace WcfService1.control
{
    public class RecebimentoControle
    {
        Recebimento recebimento;

        public RecebimentoControle(Recebimento recebimentoTeste)
        {
            this.recebimento = recebimentoTeste;
            
        }


        public string testaRecebimento()
        {
            try
            {
                if(recebimento.DataRecebimento.Equals("") || recebimento.DataRecebimento.Length < 8 || recebimento.DataRecebimento.Equals(null))
                {
                    return "Data inválida";
                }
                else if (recebimento.Descricao.Equals("") || recebimento.Descricao.Equals(null) || recebimento.Descricao.Length > 20)
                {
                    return "Descrição inválida";
                }
                else if (recebimento.Categoria.Equals("") || recebimento.Categoria.Equals(null) || recebimento.Categoria.Length > 20)
                {
                    return "Categoria inválida";
                }
                else if (recebimento.ValorRecebimento == 0 || recebimento.ValorRecebimento.Equals(null))
                {
                    return "Digite o valor";
                }
                else if (recebimento.Status < 0 || recebimento.Status > 1 || recebimento.Status.Equals(null))
                {
                    return "Status inválido";
                }

                DBRecebimento db = new DBRecebimento(recebimento);
                db.InsertRecebimento();
                return "Recebimento Inserido com Sucesso";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
    }
}