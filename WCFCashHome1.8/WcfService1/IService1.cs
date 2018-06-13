using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.model;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        #region ações do cliente
        [OperationContract]
        string InsertClient(Cliente cliente);

        [OperationContract]
        string UpdateClient(Cliente cliente);

        [OperationContract]
        List<Cliente> ListarClientes();

        [OperationContract]
        Cliente PegarClientePorEmail(string email);
        #endregion

        #region recebimento
        [OperationContract]
        string InsertRecebimento(Recebimento recebimento);

        [OperationContract]
        string UpdateRecebimento(Recebimento recebimento);

        [OperationContract]
        string DeleteRecebimento(Recebimento recebimento);
        
        [OperationContract]
        List<Recebimento> ListarRecebimento();

        [OperationContract]
        List<Recebimento> pegarRecebimentoPorData(string mes, string emailLogado);

        #endregion

        #region ações da conta
        [OperationContract]
        string InsertConta(Conta cliente);
        [OperationContract]
        string UpdateConta(Conta conta);
        [OperationContract]
        List<Conta> ListarConta();
        #endregion

        #region despesa
        [OperationContract]
        List<Despesas> ListarDespesa();

        [OperationContract]
        string InsertDespesa(Despesas despesa);

        [OperationContract]
        string UpdateDespesa(Despesas despesa);

        [OperationContract]
        string DeleteDespesa(Despesas despesa);

        [OperationContract]
        List<Despesas> ListarDespesaPorData(string mes, string rmailLogado);
        #endregion


        [OperationContract]
        string AbrirConexão();



    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
