using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using WCFCashHomeDesktopView.localhost;

namespace WCFCashHomeDesktopView
{
    public partial class Relatorio : Form
    {
        Service1 sv = new Service1();
        float totalAluguel,totalCarro,totalRoupa,totalPropina;
        Cliente cliente;
        public Relatorio(Cliente clienteLogado)
        {
            this.cliente = clienteLogado;
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Relatorio_Load(object sender, EventArgs e)
        {
            

        }

        private void graficoRecebimento_Click(object sender, EventArgs e)
        {
            
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            
            if (checkBoxTodos.Checked)
            {
                graficoRecebimento.Enabled = true;
                CarregarRecebimentos();
                checkBoxTodos.Checked = false;

            }
          
            if (checkBoxPagos.Checked)
            {
                graficoRecebimento.Enabled = true;
                CarregarRecebimentosPagos();
                checkBoxPagos.Checked = false;
            }
            if (checkBoxNaoPagos.Checked)
            {
                graficoRecebimento.Enabled = true;
                CarregarRecebimentosNaoPagos();
                checkBoxNaoPagos.Checked = false;
            }
            string dataatual;
            dataatual = maskedTextBox1.Text;
            List<Recebimento> listaRecebimento;
            listaRecebimento = sv.ListarRecebimento().ToList();
            foreach (Recebimento rece in listaRecebimento)
            {
               
                if (maskedTextBox1.Text!="" & dataatual == rece.DataRecebimento)
                   
                {
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }

                    CarregarPorData();
                    maskedTextBox1.Clear();
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void graficoDespesa_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (checkBoxTodos.Checked)
            {

                CarregarDespesas();

            }
            if (checkBoxPagos.Checked)
            {
                CarregarDespesasPagas();

            }
            if (checkBoxNaoPagos.Checked)
            {
                CarregarDespesasNaoPagas();

            }
            
        }

        private void CarregarRecebimentos()
        {
            totalAluguel = 0; totalCarro = 0; totalRoupa = 0; totalPropina = 0;
            Service1 sv = new Service1();
            List<Recebimento> listaRecebimento;
            listaRecebimento = sv.ListarRecebimento().ToList();
            foreach (Recebimento rece in listaRecebimento)
            {
                if(rece.Categoria == "Aluguel")
                {
                    totalAluguel += rece.ValorRecebimento;
                }
                if (rece.Categoria == "Carro")
                {
                    totalCarro += rece.ValorRecebimento;
                }
                if (rece.Categoria == "Roupa")
                {
                    totalRoupa += rece.ValorRecebimento;
                }
                if (rece.Categoria == "Propina")
                {
                    totalPropina += rece.ValorRecebimento;
                }
            }
            chart1.Series["Categoria"].Points.AddXY("Aluguel", totalAluguel.ToString());
            chart1.Series["Categoria"].Points.AddXY("Carro", totalCarro.ToString());
            chart1.Series["Categoria"].Points.AddXY("Roupa", totalRoupa.ToString());
            chart1.Series["Categoria"].Points.AddXY("Propina", totalPropina.ToString());
        }
        private void CarregarRecebimentosPagos()
        {
            totalAluguel = 0; totalCarro = 0; totalRoupa = 0; totalPropina = 0;
            Service1 sv = new Service1();
            List<Recebimento> listaRecebimento;
            listaRecebimento = sv.ListarRecebimento().ToList();
            foreach (Recebimento rece in listaRecebimento)
            {
                if (rece.Status ==1 & rece.Categoria == "Aluguel")
                {
                    totalAluguel += rece.ValorRecebimento;
                }
                if (rece.Status == 1 & rece.Categoria == "Carro")
                {
                    totalCarro += rece.ValorRecebimento;
                }
                if (rece.Status == 1 & rece.Categoria == "Roupa")
                {
                    totalRoupa += rece.ValorRecebimento;
                }
                if (rece.Status == 1 & rece.Categoria == "Propina")
                {
                    totalPropina += rece.ValorRecebimento;
                }
            }
            chart1.Series["Categoria"].Points.AddXY("Aluguel", totalAluguel.ToString());
            chart1.Series["Categoria"].Points.AddXY("Carro", totalCarro.ToString());
            chart1.Series["Categoria"].Points.AddXY("Roupa", totalRoupa.ToString());
            chart1.Series["Categoria"].Points.AddXY("Propina", totalPropina.ToString());
        }
        private void CarregarRecebimentosNaoPagos()
        {
            totalAluguel = 0; totalCarro = 0; totalRoupa = 0; totalPropina = 0;
           
            List<Recebimento> listaRecebimento;
            listaRecebimento = sv.ListarRecebimento().ToList();
            foreach (Recebimento rece in listaRecebimento)
            {
                if (rece.Status == 0 & rece.Categoria == "Aluguel")
                {
                    totalAluguel += rece.ValorRecebimento;
                }
                if (rece.Status == 0 & rece.Categoria == "Carro")
                {
                    totalCarro += rece.ValorRecebimento;
                }
                if (rece.Status == 0 & rece.Categoria == "Roupa")
                {
                    totalRoupa += rece.ValorRecebimento;
                }
                if (rece.Status == 0 & rece.Categoria == "Propina")
                {
                    totalPropina += rece.ValorRecebimento;
                }
            }
            chart1.Series["Categoria"].Points.AddXY("Aluguel", totalAluguel.ToString());
            chart1.Series["Categoria"].Points.AddXY("Carro", totalCarro.ToString());
            chart1.Series["Categoria"].Points.AddXY("Roupa", totalRoupa.ToString());
            chart1.Series["Categoria"].Points.AddXY("Propina", totalPropina.ToString());
        }
        private void CarregarPorData()
        {
            totalAluguel = 0; totalCarro = 0; totalRoupa = 0; totalPropina = 0;
            Service1 sv = new Service1();
            List<Recebimento> listaRecebimento;
            listaRecebimento = sv.ListarRecebimento().ToList();
            foreach (Recebimento rece in listaRecebimento)
            {
                if (rece.DataRecebimento == maskedTextBox1.Text & rece.Categoria == "Aluguel")
                {
                    totalAluguel += rece.ValorRecebimento;
                }
                if (rece.DataRecebimento == maskedTextBox1.Text & rece.Categoria == "Carro")
                {
                    totalCarro += rece.ValorRecebimento;
                }
                if (rece.DataRecebimento == maskedTextBox1.Text & rece.Categoria == "Roupa")
                {
                    totalRoupa += rece.ValorRecebimento;
                }
                if (rece.DataRecebimento == maskedTextBox1.Text & rece.Categoria == "Propina")
                {
                    totalPropina += rece.ValorRecebimento;
                }
            }
            chart1.Series["Categoria"].Points.AddXY("Aluguel", totalAluguel.ToString());
            chart1.Series["Categoria"].Points.AddXY("Carro", totalCarro.ToString());
            chart1.Series["Categoria"].Points.AddXY("Roupa", totalRoupa.ToString());
            chart1.Series["Categoria"].Points.AddXY("Propina", totalPropina.ToString());
        }

        private void extrato_Click(object sender, EventArgs e)
        {
            SaveFileDialog salvar = new SaveFileDialog();
            salvar.Filter = "PDF Files|*.pdf";
            salvar.FilterIndex = 0;

            string fileName = string.Empty;

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                fileName = salvar.FileName;

                Document myDocument = new Document(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter.GetInstance(myDocument, new FileStream(fileName, FileMode.Create));
                myDocument.Open();
                Paragraph p = new Paragraph();
                p.Alignment = Element.ALIGN_CENTER;
                myDocument.Add(new Paragraph("Gráfico Inserido", FontFactory.GetFont("Arial", 60, (int)System.Drawing.FontStyle.Bold)));
                MemoryStream ms = new MemoryStream();
                chart1.SaveImage(ms, ChartImageFormat.Png);
                iTextSharp.text.Image Chart_Image = iTextSharp.text.Image.GetInstance(ms.ToArray());
                Chart_Image.SetDpi(600, 600);
                Chart_Image.ScaleToFit(200f, 200f);
                myDocument.Add(Chart_Image);
                myDocument.Close();
            }



        }

        private void CarregarDespesas()
        {
            totalAluguel = 0; totalCarro = 0; totalRoupa = 0; totalPropina = 0;
            Service1 sv = new Service1();
            List<Despesas> listaDespesa;
            listaDespesa = sv.ListarDespesa().ToList();
            foreach (Despesas desp in listaDespesa)
            {
                if (desp.Categoria == "Aluguel")
                {
                    totalAluguel += desp.ValorDespesa;
                }
                if (desp.Categoria == "Carro")
                {
                    totalCarro += desp.ValorDespesa;
                }
                if (desp.Categoria == "Roupa")
                {
                    totalRoupa += desp.ValorDespesa;
                }
                if (desp.Categoria == "Propina")
                {
                    totalPropina += desp.ValorDespesa;
                }
            }
            chart1.Series["Categoria"].Points.AddXY("Aluguel", totalAluguel.ToString());
            chart1.Series["Categoria"].Points.AddXY("Carro", totalCarro.ToString());
            chart1.Series["Categoria"].Points.AddXY("Roupa", totalRoupa.ToString());
            chart1.Series["Categoria"].Points.AddXY("Propina", totalPropina.ToString());
        }
        private void CarregarDespesasPagas()
        {
            totalAluguel = 0; totalCarro = 0; totalRoupa = 0; totalPropina = 0;
            Service1 sv = new Service1();
            List<Despesas> listaDespesa;
            listaDespesa = sv.ListarDespesa().ToList();
            foreach (Despesas desp in listaDespesa)
            {
                if (desp.Status == 1 & desp.Categoria == "Aluguel")
                {
                    totalAluguel += desp.ValorDespesa;
                }
                if (desp.Status == 1 & desp.Categoria == "Carro")
                {
                    totalCarro += desp.ValorDespesa;
                }
                if (desp.Status == 1 & desp.Categoria == "Roupa")
                {
                    totalRoupa += desp.ValorDespesa;
                }
                if (desp.Status == 1 & desp.Categoria == "Propina")
                {
                    totalPropina += desp.ValorDespesa;
                }
            }
            chart1.Series["Categoria"].Points.AddXY("Aluguel", totalAluguel.ToString());
            chart1.Series["Categoria"].Points.AddXY("Carro", totalCarro.ToString());
            chart1.Series["Categoria"].Points.AddXY("Roupa", totalRoupa.ToString());
            chart1.Series["Categoria"].Points.AddXY("Propina", totalPropina.ToString());
        }
        private void CarregarDespesasNaoPagas()
        {
            totalAluguel = 0; totalCarro = 0; totalRoupa = 0; totalPropina = 0;
            Service1 sv = new Service1();
            List<Despesas> listaDespesa;
            listaDespesa = sv.ListarDespesa().ToList();
            foreach (Despesas desp in listaDespesa)
            {
                if (desp.Status == 0 & desp.Categoria == "Aluguel")
                {
                    totalAluguel += desp.ValorDespesa;
                }
                if (desp.Status == 0 & desp.Categoria == "Carro")
                {
                    totalCarro += desp.ValorDespesa;
                }
                if (desp.Status == 0 & desp.Categoria == "Roupa")
                {
                    totalRoupa += desp.ValorDespesa;
                }
                if (desp.Status == 0 & desp.Categoria == "Propina")
                {
                    totalPropina += desp.ValorDespesa;
                }
            }
            chart1.Series["Categoria"].Points.AddXY("Aluguel", totalAluguel.ToString());
            chart1.Series["Categoria"].Points.AddXY("Carro", totalCarro.ToString());
            chart1.Series["Categoria"].Points.AddXY("Roupa", totalRoupa.ToString());
            chart1.Series["Categoria"].Points.AddXY("Propina", totalPropina.ToString());
        }
    }
}
