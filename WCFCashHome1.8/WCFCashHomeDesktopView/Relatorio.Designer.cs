namespace WCFCashHomeDesktopView
{
    partial class Relatorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorio));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxTodos = new System.Windows.Forms.CheckBox();
            this.checkBoxPagos = new System.Windows.Forms.CheckBox();
            this.checkBoxNaoPagos = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.graficoRecebimento = new System.Windows.Forms.Button();
            this.extrato = new System.Windows.Forms.Button();
            this.graficoDespesa = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            chartArea1.BorderColor = System.Drawing.Color.Maroon;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(195, 32);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Color = System.Drawing.Color.Transparent;
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Transparent;
            series1.Name = "Categoria";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(813, 417);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lançamentos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lançamentos por  data:";
            // 
            // checkBoxTodos
            // 
            this.checkBoxTodos.AutoSize = true;
            this.checkBoxTodos.Location = new System.Drawing.Point(15, 57);
            this.checkBoxTodos.Name = "checkBoxTodos";
            this.checkBoxTodos.Size = new System.Drawing.Size(56, 17);
            this.checkBoxTodos.TabIndex = 5;
            this.checkBoxTodos.Text = "Todos";
            this.checkBoxTodos.UseVisualStyleBackColor = true;
            // 
            // checkBoxPagos
            // 
            this.checkBoxPagos.AutoSize = true;
            this.checkBoxPagos.Location = new System.Drawing.Point(15, 80);
            this.checkBoxPagos.Name = "checkBoxPagos";
            this.checkBoxPagos.Size = new System.Drawing.Size(101, 17);
            this.checkBoxPagos.TabIndex = 6;
            this.checkBoxPagos.Text = "Somente Pagos";
            this.checkBoxPagos.UseVisualStyleBackColor = true;
            // 
            // checkBoxNaoPagos
            // 
            this.checkBoxNaoPagos.AutoSize = true;
            this.checkBoxNaoPagos.Location = new System.Drawing.Point(15, 103);
            this.checkBoxNaoPagos.Name = "checkBoxNaoPagos";
            this.checkBoxNaoPagos.Size = new System.Drawing.Size(124, 17);
            this.checkBoxNaoPagos.TabIndex = 7;
            this.checkBoxNaoPagos.Text = "Somente Não Pagos";
            this.checkBoxNaoPagos.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Gerar Relatórios";
            // 
            // graficoRecebimento
            // 
            this.graficoRecebimento.Location = new System.Drawing.Point(15, 290);
            this.graficoRecebimento.Name = "graficoRecebimento";
            this.graficoRecebimento.Size = new System.Drawing.Size(158, 23);
            this.graficoRecebimento.TabIndex = 15;
            this.graficoRecebimento.Text = "Recebimento por categoria";
            this.graficoRecebimento.UseVisualStyleBackColor = true;
            this.graficoRecebimento.Click += new System.EventHandler(this.graficoRecebimento_Click);
            // 
            // extrato
            // 
            this.extrato.Location = new System.Drawing.Point(15, 372);
            this.extrato.Name = "extrato";
            this.extrato.Size = new System.Drawing.Size(158, 23);
            this.extrato.TabIndex = 16;
            this.extrato.Text = "Extrato";
            this.extrato.UseVisualStyleBackColor = true;
            this.extrato.Click += new System.EventHandler(this.extrato_Click);
            // 
            // graficoDespesa
            // 
            this.graficoDespesa.Location = new System.Drawing.Point(15, 331);
            this.graficoDespesa.Name = "graficoDespesa";
            this.graficoDespesa.Size = new System.Drawing.Size(158, 23);
            this.graficoDespesa.TabIndex = 17;
            this.graficoDespesa.Text = "Despesa por categoria";
            this.graficoDespesa.UseVisualStyleBackColor = true;
            this.graficoDespesa.Click += new System.EventHandler(this.graficoDespesa_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(15, 198);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 18;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 461);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.graficoDespesa);
            this.Controls.Add(this.extrato);
            this.Controls.Add(this.graficoRecebimento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxNaoPagos);
            this.Controls.Add(this.checkBoxPagos);
            this.Controls.Add(this.checkBoxTodos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Relatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio";
            this.Load += new System.EventHandler(this.Relatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxTodos;
        private System.Windows.Forms.CheckBox checkBoxPagos;
        private System.Windows.Forms.CheckBox checkBoxNaoPagos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button graficoRecebimento;
        private System.Windows.Forms.Button extrato;
        private System.Windows.Forms.Button graficoDespesa;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}