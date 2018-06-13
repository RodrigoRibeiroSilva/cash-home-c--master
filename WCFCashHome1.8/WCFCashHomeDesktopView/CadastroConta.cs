using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WCFCashHomeDesktopView.localhost;

namespace WCFCashHomeDesktopView
{
    public partial class CadastroConta : Form
    {
        Cliente clienteLogado;
        Service1 sv = new Service1();
        public CadastroConta(Cliente cliente)
        {
            InitializeComponent();
            this.clienteLogado = cliente;
        }

        private void CadastroConta_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta conta = new Conta();
            conta.EmailCliente = clienteLogado.Email;
            conta.SalarioConta = float.Parse(textBoxSalario.Text);
            ContaXml();
            MessageBox.Show(sv.InsertConta(conta));
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
        private void ContaXml()
        {
            try
            {
                using (DataSet Resultado = new DataSet())
                {
                    Resultado.ReadXml(DadosXML(caminho) + @"Dados\Contas.xml");
                    if (true)
                    {
                        //Atribuindo valores propriedade
                        XmlTextWriter writer = new XmlTextWriter(DadosXML(caminho) + @"Dados\Contass.xml", System.Text.Encoding.UTF8);
                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("Contas");

                        writer.WriteStartElement("Conta");

                        writer.WriteStartElement("Email");
                        writer.WriteString(clienteLogado.Email.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Salario");
                        writer.WriteString(textBoxSalario.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();

                        Resultado.ReadXml(DadosXML(caminho) + @"Dados\Contas.xml");

                    }
                    else
                    {
                        //inclui os dados no DataSet
                        Resultado.Tables[0].Rows.Add(Resultado.Tables[0].NewRow());
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Email"] = clienteLogado.Email.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Salario"] = textBoxSalario.Text.ToString();
                        Resultado.AcceptChanges();
                        //--  Escreve para o arquivo XML final usando o método Write
                        Resultado.WriteXml(DadosXML(caminho) + @"Dados\Contas.xml", XmlWriteMode.IgnoreSchema);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Service1 sv = new Service1();
                List<Conta> list;
                list = sv.ListarConta().ToList<Conta>();

                foreach (Conta conta in list)
                {
                    if (conta.EmailCliente.Equals(clienteLogado.Email))
                    {
                        Conta teste = new Conta();
                        teste.SalarioConta = float.Parse(textBoxSalario.Text);
                        teste.EmailCliente = clienteLogado.Email;
                        MessageBox.Show(sv.UpdateConta(teste));
                        
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
