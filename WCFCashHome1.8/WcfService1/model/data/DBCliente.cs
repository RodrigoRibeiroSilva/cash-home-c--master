using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfService1.model.data
{
    public class DBCliente : DBConn

    {
        private Cliente cliente;

        public DBCliente(Cliente clientePassado)
        {
            abrirConexao();
            this.cliente = clientePassado;
            
        }

        public DBCliente()
        {
            abrirConexao();
        }

       

        public string InsertClient()
        {

            try
            {
                string sql = "INSERT INTO CLIENTE (nomeCliente, emailCliente, senha ,cpf, dataNascimento) "
                            + "VALUES (@NOME, @EMAIL, @SENHA, @CPF, @DATANASCIMENTO)";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@NOME", cliente.Nome);
                cmd.Parameters.AddWithValue("@EMAIL", cliente.Email);
                cmd.Parameters.AddWithValue("@SENHA", cliente.Senha);
                cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Cliente Inserido com Sucesso";
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

        public String UpdateClient()
        {
            try
            {

                string sql = "UPDATE CLIENTE SET nomeCliente = @NOME, dataNascimento = @DATANASCIMENTO ,cpf = @CPF, senha = @SENHA WHERE emailCliente = @EMAIL";

                
                SqlCommand cmd = new SqlCommand(sql, sqlConn);

                cmd.Parameters.AddWithValue("@NOME", cliente.Nome);
                cmd.Parameters.AddWithValue("@EMAIL", cliente.Email);
                cmd.Parameters.AddWithValue("@SENHA", cliente.Senha);
                cmd.Parameters.AddWithValue("@CPF", cliente.Cpf);
                cmd.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Cliente Atualizado com Sucesso";
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

        public void DeleteClient()
        {
            try
            {
                string sql = "DELETE FROM Cliente WHERE emailCliente = @EMAIL";

                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.AddWithValue("@EMAIL", cliente.Email);
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

        public Cliente PegarClientePorEmail(string email)
        {
            try
            {
                Cliente retorno = new Cliente();

                string sql = "SELECT nomeCliente,emailCliente,senha,cpf,dataNascimento ";
                sql += " FROM Cliente ";
                sql += " WHERE emailCliente = @EMAIL ";
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                cmd.Parameters.AddWithValue("@EMAIL", email);
                SqlDataReader DbReader = cmd.ExecuteReader();
                while (DbReader.Read())
                {
                    retorno.Nome = DbReader.GetString(DbReader.GetOrdinal("nomeCliente"));
                    retorno.Email = DbReader.GetString(DbReader.GetOrdinal("emailCliente"));
                    retorno.Senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    retorno.Cpf = DbReader.GetString(DbReader.GetOrdinal("cpf"));
                    retorno.DataNascimento = DbReader.GetDataTypeName(DbReader.GetOrdinal("dataNascimento"));
                    break;
                }
                DbReader.Close();
                cmd.Dispose();
                return retorno;
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

        public List<Cliente> ListarClientes()
        {
            try
            {
                List<Cliente> listaCliente = new List<Cliente>();

                string sql = "SELECT nomeCliente,emailCliente,senha,cpf,dataNascimento ";
                sql += " FROM Cliente ";
                sql += " WHERE idCliente > 0 ";
                /*if (this.cliente.Email.Equals("") == false)
                {
                    sql += " and emailCliente = @EMAIL";
                }
                if (this.cliente.Nome.Equals("") == false)
                {
                    sql += " and nomeCliente = @NOME";
                }*/
                sql += " ORDER BY nomeCliente";

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
                    String nome;
                    String email;
                    String senha;
                    String cpf;
                    string dataNascimento;

                    nome = DbReader.GetString(DbReader.GetOrdinal("nomeCliente"));
                    email = DbReader.GetString(DbReader.GetOrdinal("emailCliente"));
                    senha = DbReader.GetString(DbReader.GetOrdinal("senha"));
                    cpf = DbReader.GetString(DbReader.GetOrdinal("cpf"));
                    dataNascimento = DbReader.GetDateTime(DbReader.GetOrdinal("dataNascimento")).ToString();

                    Cliente cliente = new Cliente(nome, email, senha, cpf, dataNascimento);
                    listaCliente.Add(cliente);
                }
                DbReader.Close();
                cmd.Dispose();
                return listaCliente;
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
