using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.control;
using WcfService1.model;
using WcfService1.model.data;

namespace WcfService1
{
    
    public class Service1 : IService1
    {
       
        public string InsertClient(Cliente cliente)
        {
            try
            {
                String result;
                ClienteControle clienteTeste = new ClienteControle(cliente);
                result = clienteTeste.ClienteValidoInsert();
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar inserir" + "" + ex.Message);
            }
        }

        public string UpdateClient(Cliente cliente)
        {
            try
            {

                String result;
                ClienteControle clienteTeste = new ClienteControle(cliente);
                result = clienteTeste.ClienteValidoUpdate();
                return result;
                
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar atualizar" + "" + ex.Message);
            }
        }

        public string InsertConta(Conta conta)
        {
            try
            {
                String result;
                ContaControle contaTeste = new ContaControle(conta);
                result = contaTeste.ContaValidaInsert();
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar inserir:" + " " + ex.Message);
            }
        }

        public List<Cliente> ListarClientes()
        {
            try
            {

                List<Cliente> result;
                DBCliente clienteTeste = new DBCliente();
                result = clienteTeste.ListarClientes();

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar listar" + "" + ex.Message);
            }
        }

        public Cliente PegarClientePorEmail(String email)
        {
            try
            {
                DBCliente clienteTeste = new DBCliente();
                return  clienteTeste.PegarClientePorEmail(email);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar selecionar" + "" + ex.Message);
            }
        }

        public string AbrirConexão()
        {
            try
            {
                DBConn conn = new DBConn();
                conn.abrirConexao();
                return "Conexão efetuada";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar conectar" + " " + ex.Message);
            }
        }

        public string InsertRecebimento(Recebimento recebimento)
        {
            try
            {
                
                RecebimentoControle controle = new RecebimentoControle(recebimento);
                string result = controle.testaRecebimento();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentatar inserir" + " " + ex.Message);
            }
            
        }

        public string UpdateRecebimento(Recebimento recebimento)
        {
            try
            {
                String result;
                DBRecebimento db = new DBRecebimento(recebimento);
                result = db.UpdateRecebimento();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentatar atualizar" + " " + ex.Message);
            }
        }

        public List<Recebimento> ListarRecebimento()
        {
            try
            {

                List<Recebimento> result;
                DBRecebimento db = new DBRecebimento();
                result = db.ListarRecebimento();

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar listar" + " " + ex.Message);
            }
        }
             public List<Despesas> ListarDespesa()
        {
            try
            {

                List<Despesas> result;
                DBDespesa db = new DBDespesa();
                result = db.ListarDespesa();

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar listar" + " " + ex.Message);
            }
        }

        public string InsertDespesa(Despesas despesa)
        {
            try
            {
                String result;
                DespesaControle controle = new DespesaControle(despesa);
                result = controle.testaDespesa();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentatar inserir" + " " + ex.Message);
            }
        }

        public List<Conta> ListarConta()
        {

            try
            {
                List<Conta> result;
                ContaControle controle = new ContaControle();
                result = controle.ListarConta();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar listar" + " " + ex.Message);
            }
        }

        public string UpdateConta(Conta conta)
        {
            try
            {
                ContaControle controle = new ContaControle(conta);
                controle.AlterarSaldo();
                return "Conta alterada";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string UpdateDespesa(Despesas despesa)
        {
            try
            {
                String result;
                DBDespesa db = new DBDespesa(despesa);
                result = db.UpdateDespesa();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string DeleteDespesa(Despesas despesa)
        {
            string result;
            DBDespesa db = new DBDespesa(despesa);
            result = db.DeleteDespesa();
            return result;
        }

        public string DeleteRecebimento(Recebimento recebimento)
        {
            string result;
            DBRecebimento db = new DBRecebimento(recebimento);
            result = db.DeleteRecebimento();
            return result;
        }

        public List<Recebimento> pegarRecebimentoPorData(string mes, string emailLogado)
        {
            try
            {
                List<Recebimento> retorno;
                DBRecebimento db = new DBRecebimento();
                retorno = db.pegarRecebimentoPorData(mes, emailLogado);
                return retorno;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public List<Despesas> ListarDespesaPorData(string mes, string emailLogado)
        {
            try
            {
                List<Despesas> retorno;
                DBDespesa db = new DBDespesa();
                retorno = db.pegarDespesaPorData(mes, emailLogado);
                return retorno;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
  }

