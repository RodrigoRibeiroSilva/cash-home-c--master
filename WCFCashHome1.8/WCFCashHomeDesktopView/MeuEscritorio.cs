using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WCFCashHomeDesktopView.localhost;
using System.IO;
using System.Net.Sockets;
using System.Threading;
namespace WCFCashHomeDesktopView
{
    public partial class MeuEscritorio : Form
    {
        private int childFormNumber = 0;
        private Service1 sv = new Service1();
        public Cliente clienteEscritorio;
        Conta contaLogada = new Conta();
        string movimentacaoAtual = "";
        float valorAtual;
        string anoAtual = "2017";

      


        public MeuEscritorio(Cliente cliente)
        {
            InitializeComponent();
            this.clienteEscritorio = cliente;
            this.Text = "Meu Escritório " + this.clienteEscritorio.Nome;
            DateTime data = DateTime.Now;
            textBoxData.Text = data.ToShortDateString();
            

            CarregarRecebimento();
            calculaSaldo();
            CarregaSaldo();
            CarregarDespesa();

        }
       
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MeuEscritorio_Load(object sender, EventArgs e)
        {

        }

        private void MeuEscritorio_Shown(object sender, EventArgs e)
        {
            try
            {
                sv.AbrirConexão();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao tentatar conectar" + " " + ex.Message);
            }
        }


        public void CarregarRecebimento()
        {
            listView1.Items.Clear();
            List<Recebimento> listaRecebimento;
            Double valor;
            listaRecebimento = sv.ListarRecebimento().ToList();

            foreach (Recebimento rece in listaRecebimento)
            {
                ListViewItem item = new ListViewItem(rece.DataRecebimento.ToString());

                item.SubItems.Add(rece.Descricao.ToString());
                item.SubItems.Add(rece.Categoria.ToString());

                valor = Double.Parse(rece.ValorRecebimento.ToString());
                valor.ToString("C");

                item.SubItems.Add(valor.ToString("C"));

                if (rece.Status == 1)
                {
                    item.SubItems.Add("Pago");
                }
                else
                {
                    item.SubItems.Add("Pendente");
                }
                item.SubItems.Add(rece.IdRecebimento.ToString());
                listView1.Items.Add(item);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (listView1.SelectedItems.Count != 0)
            {
                string status;

                if (listView1.SelectedItems[0].Selected)
                {
                    textBoxData.Text = listView1.FocusedItem.SubItems[0].Text;
                    textBoxDesc.Text = listView1.FocusedItem.SubItems[1].Text;
                    textBoxcateg.Text = listView1.FocusedItem.SubItems[2].Text;
                    string valor = listView1.FocusedItem.SubItems[3].Text;
                    textBoxValor.Text = valor.ToString().ToString().Replace("R$", "");
                    textBoxValor.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:#,###,##}", textBoxValor.Text);
                    movimentacaoAtual = listView1.FocusedItem.SubItems[5].Text;
                    status = listView1.FocusedItem.SubItems[4].Text;
                    valorAtual = float.Parse(textBoxValor.Text);


                    if (status.Equals("Pago"))
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }

                    checkBoxRecebimento.Checked = true;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        public void CarregarDespesa()
        {
            listView2.Items.Clear();
            List<Despesas> listaDespesa;
            Double valor;
            listaDespesa = sv.ListarDespesa().ToList();

            foreach (Despesas rece in listaDespesa)
            {
                ListViewItem item = new ListViewItem(rece.DataEmissao.ToString());

                item.SubItems.Add(rece.Descricao.ToString());
                item.SubItems.Add(rece.Categoria.ToString());

                valor = Double.Parse(rece.ValorDespesa.ToString());
                valor.ToString("C");

                item.SubItems.Add(valor.ToString("C"));


                if (rece.Status == 1)
                {
                    item.SubItems.Add("Pago");
                }
                else
                {
                    item.SubItems.Add("Pendente");

                }
                item.SubItems.Add(rece.IdDespesa.ToString());

                listView2.Items.Add(item);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                string status;

                if (listView2.SelectedItems[0].Selected)
                {
                    textBoxData.Text = listView2.FocusedItem.SubItems[0].Text;
                    textBoxDesc.Text = listView2.FocusedItem.SubItems[1].Text;
                    textBoxcateg.Text = listView2.FocusedItem.SubItems[2].Text;

                    string valor = listView2.FocusedItem.SubItems[3].Text;
                    textBoxValor.Text = valor.ToString().ToString().Replace("R$", "");
                    textBoxValor.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:#,###,##}", textBoxValor.Text);

                    movimentacaoAtual = listView2.FocusedItem.SubItems[5].Text;
                    status = listView2.FocusedItem.SubItems[4].Text;
                    valorAtual = float.Parse(textBoxValor.Text);


                    if (status.Equals("Pago"))
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }

                    checkBoxDespesa.Checked = true;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
            CadastroConta cadastro = new CadastroConta(clienteEscritorio);
            cadastro.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CarregaSaldo()
        {
            Double valor;
            List<Conta> lista;
            lista = sv.ListarConta().ToList<Conta>();

            foreach (Conta conta in lista)
            {
                if (conta.EmailCliente.Equals(clienteEscritorio.Email))
                {
                    valor = Double.Parse(conta.SalarioConta.ToString());
                    textBox1.Text = valor.ToString("C");
                }
            }
        }
        private void calculaSaldo()
        {
            List<Recebimento> listaRecebimento;
            List<Despesas> listaDespesa;
            List<Conta> lista;
            Double valor = 0;


            listaRecebimento = sv.ListarRecebimento().ToList<Recebimento>();
            listaDespesa = sv.ListarDespesa().ToList<Despesas>();
            lista = sv.ListarConta().ToList<Conta>();

            foreach (Conta conta in lista)
            {
                if (conta.EmailCliente.Equals(clienteEscritorio.Email))
                {
                    contaLogada.EmailCliente = clienteEscritorio.Email;
                    contaLogada.SalarioConta = conta.SalarioConta;
                }
            }
            foreach (Recebimento rece in listaRecebimento)
            {
                valor += rece.ValorRecebimento;
            }

            foreach (Despesas despe in listaDespesa)
            {
                valor -= despe.ValorDespesa;
            }

            contaLogada.SalarioConta = (float)valor;
            sv.UpdateConta(contaLogada);
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void alterarDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarUsuario alterar = new AlterarUsuario(clienteEscritorio);
            alterar.ShowDialog();
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

        //--------------------------------------------------------------

        private void adicionarMovimentacao(object sender, EventArgs e)
        {
            Service1 sv = new Service1();
            String result;
            String testado = testaCampoMovimentacaoInsert();

            if (testado.Equals("Recebimento válido"))
            {
                if (checkBoxRecebimento.Checked)
                {
                    Recebimento recebimento = new Recebimento()
                    {
                        DataRecebimento = textBoxData.Text,
                        Descricao = textBoxDesc.Text,
                        Categoria = textBoxcateg.Text,
                        ValorRecebimento = float.Parse(string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:#,###,##}", textBoxValor.Text)),
                        EmailRecebimento = clienteEscritorio.Email
                    };

                    if (checkBox1.Checked)
                    {
                        recebimento.Status = 1;
                    }
                    else
                    {
                        recebimento.Status = 0;
                    }

                    RecebimentoXML();
                    result = sv.InsertRecebimento(recebimento);
                    MessageBox.Show(result);

                    if (recebimento.Status == 1)
                    {
                        contaLogada.SalarioConta += recebimento.ValorRecebimento;
                        sv.UpdateConta(contaLogada);
                    }

                    CarregarRecebimento();
                    CarregaSaldo();
                    CarregarDespesa();
                }
                else if (checkBoxDespesa.Checked)
                {
                    Despesas despesa = new Despesas()
                    {
                        DataEmissao = textBoxData.Text,
                        Descricao = textBoxDesc.Text,
                        Categoria = textBoxcateg.Text,
                        ValorDespesa = float.Parse(textBoxValor.Text),
                        EmailCliente = clienteEscritorio.Email
                    };
                    if(despesa.DataEmissao == textBoxData.Text)
                    {

                    }
                    if (checkBox1.Checked)
                    {
                        despesa.Status = 1;
                    }
                    else
                    {
                        despesa.Status = 0;
                    }

                    DespesaXML();
                    result = sv.InsertDespesa(despesa);
                    MessageBox.Show(result);

                    if (despesa.Status == 1)
                    {
                        contaLogada.SalarioConta -= despesa.ValorDespesa;
                        sv.UpdateConta(contaLogada);
                    }

                    CarregarRecebimento();
                    CarregaSaldo();
                    CarregarDespesa();
                }
                else
                {
                    MessageBox.Show("Marque a opção Recebimento ou Despesa");
                }
            }
            else
            {
                MessageBox.Show(testado);
            }
        }

        private void DespesaXML()
        {
            try
            {
                using (DataSet Resultado = new DataSet())
                {
                    //Leitura existente do arquivo XML
                    Resultado.ReadXml(DadosXML(caminho) + @"Dados\Despesas.xml");
                    if (Resultado.Tables.Count == 0)
                    {
                        //Atribuindo valores propriedade
                        XmlTextWriter writer = new XmlTextWriter(DadosXML(caminho) + @"Dados\Despesas.xml", System.Text.Encoding.UTF8);
                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("Despesas");

                        writer.WriteStartElement("Despesa");

                        writer.WriteStartElement("Emissao");
                        writer.WriteString(textBoxData.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Descricao");
                        writer.WriteString(textBoxDesc.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Categoria");
                        writer.WriteString(textBoxcateg.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Valor");
                        writer.WriteString(textBoxValor.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Status");
                        writer.WriteString(checkBox1.Checked.ToString());
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();

                        Resultado.ReadXml(DadosXML(caminho) + @"Dados\Despesas.xml");

                    }
                    else
                    {
                        //-- inclui os dados no DataSet
                        Resultado.Tables[0].Rows.Add(Resultado.Tables[0].NewRow());
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Emissao"] = textBoxData.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Descricao"] = textBoxDesc.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Categoria"] = textBoxcateg.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Valor"] = textBoxValor.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Status"] = checkBox1.Checked.ToString();
                        Resultado.AcceptChanges();
                        //--  Escreve para o arquivo XML final usando o método Write
                        Resultado.WriteXml(DadosXML(caminho) + @"Dados\Despesas.xml", XmlWriteMode.IgnoreSchema);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecebimentoXML()
        {
            try
            {
                using (DataSet Resultado = new DataSet())
                {
                    Resultado.ReadXml(DadosXML(caminho) + @"Dados\Recebimentos.xml");

                    if (Resultado.Tables.Count == 0)
                    {
                        //Atribuindo valores propriedade
                        XmlTextWriter writer = new XmlTextWriter(DadosXML(caminho) + @"Dados\Recebimentos.xml", System.Text.Encoding.UTF8);
                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;

                        writer.WriteStartElement("Recebimentos");

                        writer.WriteStartElement("Recebimento");

                        writer.WriteStartElement("Emissao");
                        writer.WriteString(textBoxData.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Valor");
                        writer.WriteString(textBoxValor.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Descricao");
                        writer.WriteString(textBoxDesc.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Categoria");
                        writer.WriteString(textBoxcateg.Text.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Status");
                        writer.WriteString(checkBox1.Checked.ToString());
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();

                        Resultado.ReadXml(DadosXML(caminho) + @"Dados\Recebimentos.xml");

                    }
                    else
                    {
                        //inclui os dados no DataSet
                        Resultado.Tables[0].Rows.Add(Resultado.Tables[0].NewRow());
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Emissao"] = textBoxData.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Valor"] = textBoxValor.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Descricao"] = textBoxDesc.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Categoria"] = textBoxcateg.Text.ToString();
                        Resultado.Tables[0].Rows[Resultado.Tables[0].Rows.Count - 1]["Status"] = checkBox1.Checked.ToString();
                        Resultado.AcceptChanges();
                        
                        Resultado.WriteXml(DadosXML(caminho) + @"Dados\Recebimentos.xml", XmlWriteMode.IgnoreSchema);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRecebimento.Checked)
            {
                checkBoxDespesa.Checked = false;
            }

        }

        private void checkBoxDespesa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDespesa.Checked)
            {
                checkBoxRecebimento.Checked = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxData.Clear();
            textBoxDesc.Clear();
            textBoxValor.Clear();

        }

        private void textBoxValor_TextChanged(object sender, EventArgs e)
        {

        }

        private string testaCampoMovimentacaoInsert()
        {
            if (textBoxData.Text.Equals("") || textBoxData.Text.Equals(null) || textBoxData.Text.Length < 8)
            {
                return "Data inválida";
            }
            if (textBoxDesc.Text.Equals("") || textBoxData.Text.Equals(null) || textBoxData.Text.Length > 20)
            {
                return "Descrição inválida";
            }
            if (textBoxcateg.Text.Equals("") || textBoxcateg.Text.Equals(null) || textBoxcateg.Text.Length > 20)
            {
                return "Categoria inválida";
            }
            if (textBoxValor.Text.Equals("") || textBoxcateg.Text.Equals(null))
            {
                return "Digite um valor";
            }

            return "Recebimento válido";
            
        }

        private void atualizarMovimentacao(object sender, EventArgs e)
        {
            Recebimento rece = new Recebimento();
            if (checkBoxRecebimento.Checked)

            {
                var result = MessageBox.Show("Deseja Alterar as Informações do Recebimento  Selecionado", "Atualização Recebimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    rece.DataRecebimento = textBoxData.Text;
                    rece.Descricao = textBoxDesc.Text;
                    rece.Categoria = textBoxcateg.Text;
                    rece.IdRecebimento = int.Parse(movimentacaoAtual.ToString());
                    rece.ValorRecebimento = float.Parse(textBoxValor.Text);
                    rece.EmailRecebimento = clienteEscritorio.Email;

                    if (checkBox1.Checked)
                    {
                        rece.Status = 1;
                    }
                    else
                    {
                        rece.Status = 0;
                    }

                }
                MessageBox.Show(sv.UpdateRecebimento(rece));

                if (rece.Status == 1 && rece.ValorRecebimento != valorAtual)
                {
                    contaLogada.SalarioConta -= valorAtual;
                    contaLogada.SalarioConta += rece.ValorRecebimento;
                    sv.UpdateConta(contaLogada);
                    CarregaSaldo();
                }
                else if (rece.Status == 0 && rece.ValorRecebimento != valorAtual)
                {
                    contaLogada.SalarioConta -= valorAtual;
                    sv.UpdateConta(contaLogada);
                    CarregaSaldo();
                }


                CarregarRecebimento();

            }

            
            else if (checkBoxDespesa.Checked)

            {
                var result = MessageBox.Show("Deseja Alterar as Informações da Despesa  Selecionada", "Atualização Despesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Despesas despe = new Despesas();
                    despe.DataEmissao = textBoxData.Text;
                    despe.Descricao = textBoxDesc.Text;
                    despe.Categoria = textBoxcateg.Text;
                    despe.IdDespesa = int.Parse(movimentacaoAtual.ToString());
                    despe.ValorDespesa = float.Parse(textBoxValor.Text);
                    despe.EmailCliente = clienteEscritorio.Email;

                    if (checkBox1.Checked)
                    {
                        despe.Status = 1;
                    }
                    else
                    {
                        despe.Status = 0;
                    }

                    MessageBox.Show(sv.UpdateDespesa(despe));

                    if (despe.Status == 1 && despe.ValorDespesa != valorAtual)
                    {
                        contaLogada.SalarioConta += valorAtual;
                        contaLogada.SalarioConta -= despe.ValorDespesa;
                        sv.UpdateConta(contaLogada);
                        CarregaSaldo();
                    }
                    else if (despe.Status == 0 && despe.ValorDespesa != valorAtual)
                    {
                        contaLogada.SalarioConta += valorAtual;
                        sv.UpdateConta(contaLogada);
                        CarregaSaldo();
                    }

                    CarregarDespesa();
                }
                else
                {
                    MessageBox.Show("Selecione despesa ou Recebimento");
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ComboBox comboBox = textBoxcateg;
           
        }

        private void removerMovimentacao(object sender, EventArgs e)
        {
            if (checkBoxDespesa.Checked)
            {
                var result = MessageBox.Show("Deseja Exclir as Informações Selecionada", "Excluir Despesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Despesas despe = new Despesas();

                    despe.DataEmissao = textBoxData.Text;
                    despe.Descricao = textBoxDesc.Text;
                    despe.Categoria = textBoxcateg.Text;
                    despe.IdDespesa = int.Parse(movimentacaoAtual.ToString());
                    despe.ValorDespesa = float.Parse(textBoxValor.Text);
                    despe.EmailCliente = clienteEscritorio.Email;


                    if (checkBox1.Checked)
                    {
                        despe.Status = 1;
                    }
                    else
                    {
                        despe.Status = 0;
                    }

                    MessageBox.Show(sv.DeleteDespesa(despe));
                    if (despe.Status == 1)
                    {

                        contaLogada.SalarioConta += despe.ValorDespesa;
                        sv.UpdateConta(contaLogada);
                        CarregarDespesa();
                        CarregaSaldo();
                    }

                    CarregarDespesa();
                    CarregaSaldo();
                }
            }
            else if (checkBoxRecebimento.Checked)
            {

                var result1 = MessageBox.Show("Deseja Exclir as Informações Selecionada", "Excluir Recebimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result1 == System.Windows.Forms.DialogResult.Yes)
                {
                    Recebimento rece = new Recebimento();

                    rece.DataRecebimento = textBoxData.Text;
                    rece.Descricao = textBoxDesc.Text;
                    rece.Categoria = textBoxcateg.Text;
                    rece.IdRecebimento = int.Parse(movimentacaoAtual.ToString());
                    rece.ValorRecebimento = float.Parse(textBoxValor.Text);
                    rece.EmailRecebimento = clienteEscritorio.Email;

                    if (checkBox1.Checked)
                    {
                        rece.Status = 1;
                    }
                    else
                    {
                        rece.Status = 0;
                    }


                    MessageBox.Show(sv.DeleteRecebimento(rece));
                    if (rece.Status == 1)
                    {

                        contaLogada.SalarioConta -= rece.ValorRecebimento;
                        sv.UpdateConta(contaLogada);
                        CarregarDespesa();
                        CarregaSaldo();
                    }

                    CarregarRecebimento();
                    CarregaSaldo();
                }

            }
            }
        
        private void junhoFiltro(object sender, EventArgs e)
        {

        }
        private void CarregarRecebimentoMes(List<Recebimento> lista)
        {
            listView1.Items.Clear();
            
            Double valor;
            

            foreach (Recebimento rece in lista)
            {
                ListViewItem item = new ListViewItem(rece.DataRecebimento.ToString());

                item.SubItems.Add(rece.Descricao.ToString());
                item.SubItems.Add(rece.Categoria.ToString());

                valor = Double.Parse(rece.ValorRecebimento.ToString());
                valor.ToString("C");

                item.SubItems.Add(valor.ToString("C"));

                if (rece.Status == 1)
                {
                    item.SubItems.Add("Pago");
                }
                else
                {
                    item.SubItems.Add("Pendente");
                }
                item.SubItems.Add(rece.IdRecebimento.ToString());
                listView1.Items.Add(item);
            }

        }

        private void CarregarDespesaMes(List<Despesas> lista)
        {
            listView2.Items.Clear();

            Double valor;


            foreach (Despesas desp in lista)
            {
                ListViewItem item = new ListViewItem(desp.DataEmissao.ToString());

                item.SubItems.Add(desp.Descricao.ToString());
                item.SubItems.Add(desp.Categoria.ToString());

                valor = Double.Parse(desp.ValorDespesa.ToString());
                valor.ToString("C");

                item.SubItems.Add(valor.ToString("C"));

                if (desp.Status == 1)
                {
                    item.SubItems.Add("Pago");
                }
                else
                {
                    item.SubItems.Add("Pendente");
                }
                item.SubItems.Add(desp.IdDespesa.ToString());
                listView2.Items.Add(item);
            }

        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-06%", clienteEscritorio.Email).ToList<Recebimento>();
 
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-06%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-07%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-07%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-08%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-08%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-09%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-09%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-10%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-10%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-11%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-11%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-12%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-12%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-01%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-01%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-02%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-02%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-03%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-03%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            List<Recebimento> listRecebimento;
            listRecebimento = sv.pegarRecebimentoPorData("2017-04%", clienteEscritorio.Email).ToList<Recebimento>();
            CarregarRecebimentoMes(listRecebimento);

            List<Despesas> listDespesas;
            listDespesas = sv.ListarDespesaPorData("2017-04%", clienteEscritorio.Email).ToList<Despesas>();

            CarregarDespesaMes(listDespesas);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relatorio relatorio = new Relatorio(clienteEscritorio);
            relatorio.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CarregarDespesa();
            CarregarRecebimento();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
 
