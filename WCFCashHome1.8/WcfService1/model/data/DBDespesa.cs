using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfService1.model.data
{
    public class DBDespesa : DBConn
    {
        private Despesas despesa;

        public DBDespesa(Despesas despesa)
        {
            abrirConexao();
            this.despesa = despesa;
        }

        public DBDespesa()
        {
            abrirConexao();
        }
        public string UpdateDespesa()
        {
            try
            {

                string sql = "UPDATE Despesas SET dataEmissao = @DATAEMISSAO,descricao = @DESCRICAO, categoria = @CATEGORIA, valorDespesa= @VALORDESPESA" +
                             " ,status = @STATUSDESPESA WHERE idDespesa = @ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@DATAEMISSAO", despesa.DataEmissao);
                cmd.Parameters.AddWithValue("@DESCRICAO", despesa.Descricao);
                cmd.Parameters.AddWithValue("@CATEGORIA", despesa.Categoria);
                cmd.Parameters.AddWithValue("@VALORDESPESA", despesa.ValorDespesa);
                cmd.Parameters.AddWithValue("@STATUSDESPESA", despesa.Status);
                cmd.Parameters.AddWithValue("@ID", despesa.IdDespesa);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Despesa Atualizada com Sucesso";
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentatar modificar" + "" + ex.Message);
            }
            finally
            {
                fecharConexao();
            }
        }


        public string InsertDespesa()
        {

            try
            {
                string sql = "INSERT INTO DESPESAS (dataEmissao,descricao,categoria,valorDespesa,status, emailCliente) "
                            + "VALUES ( @DATAEMISSAO, @DESCRICAO, @CATEGORIA,@VALORDESPESA, @STATUS, @EMAIL)";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@DATAEMISSAO", despesa.DataEmissao);
                cmd.Parameters.AddWithValue("@DESCRICAO", despesa.Descricao);
                cmd.Parameters.AddWithValue("@CATEGORIA", despesa.Categoria);
                cmd.Parameters.AddWithValue("@VALORDESPESA", despesa.ValorDespesa);
                cmd.Parameters.AddWithValue("@STATUS", despesa.Status);
                cmd.Parameters.AddWithValue("@EMAIL", despesa.EmailCliente);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Recebimento Inserido com Sucesso";
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

        public string DeleteDespesa()
        {
            try
            {
                string sql = "DELETE FROM DESPESAS WHERE idDespesa = @ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.AddWithValue("@ID", despesa.IdDespesa);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return "Despesa Removida com Sucesso";
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

        public List<Despesas> ListarDespesa()
        {
            try
            {
                List<Despesas> listaDespesa = new List<Despesas>();

                string sql = "SELECT idDespesa,dataEmissao,descricao,categoria,valorDespesa,status";
                sql += " FROM Despesas ";
                sql += " WHERE idDespesa > 0 ";


                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    string dataEmissao;
                    float valorDespesa;
                    string categoria, descricao;
                    int status, id;

                    id = DbReader.GetInt32(DbReader.GetOrdinal("idDespesa"));
                    dataEmissao = DbReader.GetDateTime(DbReader.GetOrdinal("dataEmissao")).ToShortDateString();
                    descricao = DbReader.GetString(DbReader.GetOrdinal("descricao"));
                    categoria = DbReader.GetString(DbReader.GetOrdinal("categoria"));
                    valorDespesa = (float)DbReader.GetDouble(DbReader.GetOrdinal("valorDespesa"));
                    status = DbReader.GetInt32(DbReader.GetOrdinal("status"));


                    Despesas despesa = new Despesas(id, dataEmissao, descricao, categoria, valorDespesa, status);
                    listaDespesa.Add(despesa);

                }
                DbReader.Close();
                cmd.Dispose();
                return listaDespesa;
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
        public List<Despesas> pegarDespesaPorData(string mes, string emailLogado)
        {
            try
            {
                List<Despesas> listaDespesa = new List<Despesas>();

                string sql = "SELECT idDespesa,dataEmissao,descricao,categoria,valorDespesa,status";
                sql += " FROM Despesas ";
                sql += " WHERE dataEmissao LIKE @MES and emailCliente = @EMAIL";



                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.AddWithValue("@EMAIL", emailLogado);
                cmd.Parameters.AddWithValue("@MES", "%" + mes + "%");
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    int id;
                    string dataRecebimento;
                    float valorRecebimento;
                    string categoria, descricao;
                    int status;

                    id = DbReader.GetInt32(DbReader.GetOrdinal("idDespesa"));
                    dataRecebimento = DbReader.GetDateTime(DbReader.GetOrdinal("dataEmissao")).ToShortDateString();
                    descricao = DbReader.GetString(DbReader.GetOrdinal("descricao"));
                    categoria = DbReader.GetString(DbReader.GetOrdinal("categoria"));
                    valorRecebimento = (float)DbReader.GetDouble(DbReader.GetOrdinal("valorDespesa"));
                    status = DbReader.GetInt32(DbReader.GetOrdinal("status"));

                    Despesas despesa = new Despesas(id, dataRecebimento, descricao, categoria, valorRecebimento, status);
                    listaDespesa.Add(despesa);
                }
                DbReader.Close();
                cmd.Dispose();
                return listaDespesa;
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
    
