using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfService1.model.data
{
    public class DBConta : DBConn
    {
        private Conta contaCliente;

        public DBConta(Conta conta)
        {
            abrirConexao();
            contaCliente = conta;
        }

        public DBConta()
        {
            abrirConexao();
            
        }


        public string InsertConta()
        {

            try
            {
                string sql = "INSERT INTO Conta (salarioConta, emailCliente) "
                            + "VALUES (@SALARIO, @EMAIL)";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@SALARIO", contaCliente.SalarioConta);
                cmd.Parameters.AddWithValue("@EMAIL", contaCliente.EmailCliente);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Conta Inserida com Sucesso";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar inserir" + "" + ex.Message);
            }
            finally
            {
                fecharConexao();
            }
        }
        public String UpdateConta()
        {
            try
            {

                string sql = "UPDATE Conta SET salarioConta = @SALARIO, emailCliente = @EMAIL WHERE emailCliente = @EMAIL";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@SALARIO", contaCliente.SalarioConta);
                cmd.Parameters.AddWithValue("@EMAIL", contaCliente.EmailCliente);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Conta Atualizada com Sucesso";
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentatar atualizar" + " " + ex.Message);
            }
            finally
            {
                fecharConexao();
            }
        }
        public void DeleteConta()
        {
            try
            {
                string sql = "DELETE FROM Cliente WHERE emailCliente = @EMAIL";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.AddWithValue("@EMAIL", contaCliente.EmailCliente);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentatar Deletar" + "" + ex.Message);
            }
            finally
            {
                fecharConexao();
            }
        }

        public List<Conta> ListarContas()
        {
            try
            {
                List<Conta> listaConta = new List<Conta>();

                string sql = "SELECT * FROM Conta";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    float salario;
                    String emailConta;
                   
                    salario = (float) DbReader.GetDouble(DbReader.GetOrdinal("salarioConta"));
                    emailConta = DbReader.GetString(DbReader.GetOrdinal("emailCliente"));
                    

                    Conta conta = new Conta(salario, emailConta);
                    listaConta.Add(conta);
                }
                DbReader.Close();
                cmd.Dispose();
                return listaConta;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentatar Selecionar" + " " + ex.Message);
            }

            finally
            {
                fecharConexao();
            }
        }
    }
}