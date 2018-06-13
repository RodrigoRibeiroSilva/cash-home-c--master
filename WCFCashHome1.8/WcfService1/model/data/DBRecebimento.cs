using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfService1.model.data
{
    public class DBRecebimento : DBConn
    {
        private Recebimento recebimento;

        public DBRecebimento(Recebimento recebimento)
        {
            abrirConexao();
            this.recebimento = recebimento;
        }

        public DBRecebimento()
        {
            abrirConexao();
        }



        public string InsertRecebimento()
        {

            try
            {
                string sql = "INSERT INTO RECEBIMENTO (dataRecebimento,descricao,categoria,valorRecebimento,status, emailCliente) "
                            + "VALUES (@DATARECEBIMENTO, @DESCRICAO, @CATEGORIA, @VALORRECEBIMENTO, @STATUS, @EMAIL)";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@DATARECEBIMENTO", recebimento.DataRecebimento);
                cmd.Parameters.AddWithValue("@DESCRICAO", recebimento.Descricao);
                cmd.Parameters.AddWithValue("@CATEGORIA", recebimento.Categoria);
                cmd.Parameters.AddWithValue("@VALORRECEBIMENTO", recebimento.ValorRecebimento);
                cmd.Parameters.AddWithValue("@STATUS", recebimento.Status);
                cmd.Parameters.AddWithValue("@EMAIL", recebimento.EmailRecebimento);
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

        public String UpdateRecebimento()
        {
            try
            {

                string sql = "UPDATE RECEBIMENTO SET dataRecebimento = @DATARECEBIMENTO,descricao = @DESCRICAO, categoria = @CATEGORIA, valorRecebimento = @VALORRECEBIMENTO" +
                             " ,status = @STATUSRECEBIMENTO WHERE idRecebimento = @ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@DATARECEBIMENTO", recebimento.DataRecebimento);
                cmd.Parameters.AddWithValue("@DESCRICAO", recebimento.Descricao);
                cmd.Parameters.AddWithValue("@CATEGORIA", recebimento.Categoria);
                cmd.Parameters.AddWithValue("@VALORRECEBIMENTO", recebimento.ValorRecebimento);
                cmd.Parameters.AddWithValue("@STATUSRECEBIMENTO", recebimento.Status);
                cmd.Parameters.AddWithValue("@ID", recebimento.IdRecebimento);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Recebimento Atualizado com Sucesso";
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

        public string DeleteRecebimento()
        {
            try
            {
                string sql = "DELETE FROM RECEBIMENTO WHERE idRecebimento = @ID";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.AddWithValue("@ID", recebimento.IdRecebimento);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return "Recebimento Removido com Sucesso ";
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

        public List<Recebimento> ListarRecebimento()
        {
            try
            {
                List<Recebimento> listaRecebimento = new List<Recebimento>();

                string sql = "SELECT idRecebimento, cast(CONVERT(varchar(10),dataRecebimento, 103) as date )as dataRecebimento,descricao,categoria,valorRecebimento,status";
                sql += " FROM Recebimento ";
                sql += " WHERE idRecebimento > 0 ";
                /*if (this.cliente.Email.Equals("") == false)
                {
                    sql += " and emailCliente = @EMAIL";
                }
                if (this.cliente.Nome.Equals("") == false)
                {
                    sql += " and nomeCliente = @NOME";
                }*/
                //sql += " ORDER BY valorRecebimento";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);


                /*if (this.cliente.Email.Equals("") == false)
                {
                    cmd.Parameters.AddWithValue("@EMAIL", this.cliente.Email);
                }
                if (this.cliente.Nome.Equals("") == false)
                {
                    cmd.Parameters.AddWithValue("@NOME", this.cliente.Nome);
                }*/
                SqlDataReader DbReader = cmd.ExecuteReader();

                while (DbReader.Read())
                {
                    int id;
                    string dataRecebimento;
                    float valorRecebimento;
                    string categoria, descricao;
                    int status;

                    id = DbReader.GetInt32(DbReader.GetOrdinal("idRecebimento"));
                    dataRecebimento = DbReader.GetDateTime(DbReader.GetOrdinal("dataRecebimento")).ToShortDateString();
                    descricao = DbReader.GetString(DbReader.GetOrdinal("descricao"));
                    categoria = DbReader.GetString(DbReader.GetOrdinal("categoria"));
                    valorRecebimento = (float)DbReader.GetDouble(DbReader.GetOrdinal("valorRecebimento"));
                    status = DbReader.GetInt32(DbReader.GetOrdinal("status"));


                    Recebimento recebimento = new Recebimento(id, dataRecebimento, descricao, categoria, valorRecebimento, status);
                    listaRecebimento.Add(recebimento);

                }
                DbReader.Close();
                cmd.Dispose();
                return listaRecebimento;
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
        public List<Recebimento> pegarRecebimentoPorData(string mes, string emailLogado)
        {
            try
            {
                List<Recebimento> listaRecebimento = new List<Recebimento>();

                string sql = "SELECT idRecebimento, cast(CONVERT(varchar(10),dataRecebimento, 103) as date )as dataRecebimento,descricao,categoria,valorRecebimento,status";
                sql += " FROM Recebimento ";
                sql += " WHERE dataRecebimento LIKE @MES and emailCliente = @EMAIL";



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

                    id = DbReader.GetInt32(DbReader.GetOrdinal("idRecebimento"));
                    dataRecebimento = DbReader.GetDateTime(DbReader.GetOrdinal("dataRecebimento")).ToShortDateString();
                    descricao = DbReader.GetString(DbReader.GetOrdinal("descricao"));
                    categoria = DbReader.GetString(DbReader.GetOrdinal("categoria"));
                    valorRecebimento = (float)DbReader.GetDouble(DbReader.GetOrdinal("valorRecebimento"));
                    status = DbReader.GetInt32(DbReader.GetOrdinal("status"));

                    Recebimento recebimento = new Recebimento(id, dataRecebimento, descricao, categoria, valorRecebimento, status);
                    listaRecebimento.Add(recebimento);
                }
                DbReader.Close();
                cmd.Dispose();
                return listaRecebimento;
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