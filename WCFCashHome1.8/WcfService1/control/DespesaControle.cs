using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.model;
using WcfService1.model.data;

namespace WcfService1.control
{
    public class DespesaControle
    {
        Despesas despesa;

        public DespesaControle (Despesas despesaTeste)
        {
            this.despesa = despesaTeste;
        }

        public string testaDespesa()
        {
            try
            {
                if (despesa.DataEmissao.Equals("") || despesa.DataEmissao.Length < 8 || despesa.DataEmissao.Equals(null))
                {
                    return "Data inválida";
                }
                else if (despesa.Descricao.Equals("") || despesa.Descricao.Equals(null) || despesa.Descricao.Length > 20)
                {
                    return "Descrição inválida";
                }
                else if (despesa.Categoria.Equals("") || despesa.Categoria.Equals(null) || despesa.Categoria.Length > 20)
                {
                    return "Categoria inválida";
                }
                else if (despesa.ValorDespesa == 0 || despesa.ValorDespesa.Equals(null))
                {
                    return "Digite o valor";
                }
                else if (despesa.Status < 0 || despesa.Status > 1 || despesa.Status.Equals(null))
                {
                    return "Status inválido";
                }

                DBDespesa db = new DBDespesa(despesa);
                db.InsertDespesa();
                return "Despesa Inserida co Sucesso";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}