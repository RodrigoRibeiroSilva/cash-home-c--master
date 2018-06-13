using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WCFCashHomeDesktopView.localhost;
using WCFCashHomeDesktopView.Dados;

namespace WCFCashHomeDesktopView
{
    public partial class CadastroCliente : Form
    {
        private string nome, email, cpf, dataNascimento, senha;
        public Cliente clienteLogado;


        public CadastroCliente()
        {
            InitializeComponent();
        }
        //Método para limpar todos os campos
        void LimparTextBox(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if ((c is MaskedTextBox))
                    ((MaskedTextBox)c).Clear();
                else
                    LimparTextBox(c);
            }
        }
        //Criação da variável para aplicação de Domínio diretório 
        String caminho = AppDomain.CurrentDomain.BaseDirectory;

        //Método Estático para caminho DadosXML
        public static string DadosXML(string caminho)
        {

            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }
        //------------------------------------------------------------ 

        private void button1_Click(object sender, EventArgs e)
        {

            string isOk = testaCamposViewInsert();

            if (isOk == "Campos Válidos")
            {
                Service1 sv = new Service1();
                try
                {
                    using (DataSet Resultado = new DataSet())
                    {
                        //Leitura nos arquivos em XML
                        Resultado.ReadXml(DadosXML(caminho) + @"Dados\Clientes.xml");


                        //Instanciamento das classes

                        Cliente cliente = new Cliente()
                        {
                            Nome = nome,
                            Email = email,
                            DataNascimento = dataNascimento,
                            Cpf = cpf,
                            Senha = senha
                        };

                        if (Resultado.Tables.Count==0)
                        {
  
                            //Atribuindo valores propriedade
                            XmlTextWriter writer = new XmlTextWriter(DadosXML(caminho) + @"Dados\Clientes.xml", System.Text.Encoding.UTF8);
                            writer.WriteStartDocument(true);
                            writer.Formatting = Formatting.Indented;
                            writer.Indentation = 2;
                            writer.WriteStartElement("Clientes");

                            writer.WriteStartElement("Cliente");

                            writer.WriteStartElement("Nome");
                            writer.WriteString(cliente.Nome.ToString());
                            writer.WriteEndElement();

                            writer.WriteStartElement("Cpf");
                            writer.WriteString(cliente.Cpf.ToString());
                            writer.WriteEndElement();

                            writer.WriteStartElement("Nascimento");
                            writer.WriteValue(cliente.DataNascimento.ToString());
                            writer.WriteEndElement();

                            writer.WriteStartElement("Email");
                            writer.WriteString(cliente.Email.ToString());
                            writer.WriteEndElement();

                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();

                            Resultado.ReadXml(DadosXML(caminho) + @"Dados\Clientes.xml");
                        }
                        else
                        {
                            //inclui os dados no DataSet
                            Resultado.Tables[0].Rows.Add(Resultado.Tables[0].NewRow());
                            Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Nome"] = nome.ToString();
                            Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Cpf"] = cpf.ToString();
                            Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Nascimento"] = dataNascimento.ToString();
                            Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Email"] = email.ToString();
                            Resultado.AcceptChanges();
                            //--  Escreve para o arquivo XML final usando o método Write
                            Resultado.WriteXml(DadosXML(caminho) + @"Dados\Clientes.xml", XmlWriteMode.IgnoreSchema);
                        }
                        string result = sv.InsertClient(cliente);
                        MessageBox.Show(result);
                        LimparTextBox(this);

                        Conta clienteConta = new Conta();
                        clienteConta.EmailCliente = email;
                        sv.InsertConta(clienteConta);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(isOk);
            }
        }

        /*
        private void button4_Click(object sender, EventArgs e)
        {
            Service1 sv = new Service1();

            nome = TextNome.Text;
            email = TextEmail.Text;
            dataNascimento = TextDT.Text;
            cpf = TextCpf.Text;
            senha = TextSenha.Text;

            Cliente cliente = new Cliente()
            {
                Nome = nome,
                Email = email,
                DataNascimento = dataNascimento,
                Cpf = cpf,
                Senha = senha
            };

           //sv.ListarClientes(cliente);
            
        }
        */

        /*
        private void button2_Click(object sender, EventArgs e)
        {
            string nome, email, cpf, dataNascimento, senha;

            Service1 sv = new Service1();
            
            nome = TextNome.Text;
            email = TextEmail.Text;
            dataNascimento = TextDT.Text;
            cpf = TextCpf.Text;
            senha = TextSenha.Text;

            string isOk = testaCamposViewUpdate();

            if (isOk == "Campos Válidos")
            {
                Cliente clienteUpdate = new Cliente();
                if (nome.Equals("") == false)
                    clienteUpdate.Nome = nome;
                else
                    clienteUpdate.Nome = this.clienteLogado.Nome;

                if (email.Equals("") == false)
                    clienteUpdate.Email = email;
                else
                    clienteUpdate.Email = this.clienteLogado.Nome;

                if (dataNascimento.Equals("") == false)
                    clienteUpdate.DataNascimento = dataNascimento;
                else
                    clienteUpdate.DataNascimento = this.clienteLogado.DataNascimento;

                if (cpf.Equals("") == false)
                    clienteUpdate.Cpf = cpf;
                else
                    clienteUpdate.Cpf = this.clienteLogado.Cpf;

                if (senha.Equals("") == false)
                    clienteUpdate.Senha = senha;
                else
                    clienteUpdate.Senha = this.clienteLogado.Senha;

                string result = sv.UpdateClient(clienteUpdate);
                MessageBox.Show(result); 
            }
            else
            {
                MessageBox.Show(isOk);
            }
        }
        */

        private void CadastroCliente_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private string testaCamposViewInsert()
        {
            nome = TextNome.Text;
            email = TextEmail.Text;
            dataNascimento = Convert.ToDateTime(TextDT.Text).ToString("dd/MM/yyyy");
            cpf = TextCpf.Text;
            senha = TextSenha.Text;
            if (nome == null || nome == "")
            {
                return "Digite o campo nome";
            }
            if (nome.Length > 20)
            {
                return "Nome não pode possuir mais do que 20 caracteres";
            }
            if (email == null || email == "")
            { 
                return "Digite o campo email";
            }
            if (email.Length > 50)
            {
                return "Email não pode possuir mais do que 20 caracteres";
            }
            if (senha == null || senha == "")
            {
                return "Digite o campo senha";
            }
            if (cpf == null || cpf == "")
            {
                return "Digite o campo CPF";
            }
            if (dataNascimento == null || dataNascimento == "")
            {
                return "Digite o campo Data de Nascimento";
            }

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!(rg.IsMatch(email)))
            {
                return "Email Inválido!";
            }
            return "Campos Válidos";
        }

        private string testaCamposViewUpdate()
        {
           
            if (nome.Length > 20)
            {
                return "Nome não pode possuir mais do que 20 caracteres";
            }
                       
            if (cpf.Length > 20)
            {
                return "CPF não pode possuir mais do que 20 caracteres";
            }
            if (email.Length > 50)
            {
                return "Email não pode possuir mais do que 20 caracteres";
            }
            if (senha.Length > 20)
            {
                return "Senha não pode possuir mais do que 20 caracteres";
            }

            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!(rg.IsMatch(email)))
            {
                return "Email Inválido!";
            }

            //Validação Data Nascimento
            Regex exNasc = new Regex(@"(\d{2}\/\d{2}\/\d{4})");
            if (!(exNasc.IsMatch(dataNascimento)))
            {
                TextDT.Focus();
                return "Data Nascimento Inválido";
            }

            //Validação Cpf
            Regex exCpf = new Regex(@"(\d{8}\-\d{2})");
            if (!(exCpf.IsMatch(cpf)))
            {
                TextCpf.Focus();
                return "Cpf Inválido";
            }
            return "Campos Válidos";
        }

        private void textBoxnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextEmail_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
