namespace WCFCashHomeDesktopView
{
    partial class AlterarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlterarUsuario));
            this.TextCpf = new System.Windows.Forms.MaskedTextBox();
            this.TextDT = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextNome = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextCpf
            // 
            this.TextCpf.Location = new System.Drawing.Point(226, 59);
            this.TextCpf.Mask = "000000000-00";
            this.TextCpf.Name = "TextCpf";
            this.TextCpf.Size = new System.Drawing.Size(164, 20);
            this.TextCpf.TabIndex = 36;
            // 
            // TextDT
            // 
            this.TextDT.Location = new System.Drawing.Point(33, 116);
            this.TextDT.Mask = "00/00/0000";
            this.TextDT.Name = "TextDT";
            this.TextDT.Size = new System.Drawing.Size(132, 20);
            this.TextDT.TabIndex = 35;
            this.TextDT.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Data de Nascimento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "CPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nome";
            // 
            // TextNome
            // 
            this.TextNome.Location = new System.Drawing.Point(34, 59);
            this.TextNome.Name = "TextNome";
            this.TextNome.Size = new System.Drawing.Size(136, 20);
            this.TextNome.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 27);
            this.button1.TabIndex = 26;
            this.button1.Text = "Alterar Senha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 27);
            this.button2.TabIndex = 37;
            this.button2.Text = "Atualizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlterarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 229);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TextCpf);
            this.Controls.Add(this.TextDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextNome);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AlterarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Usuario";
            this.Load += new System.EventHandler(this.AlterarUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox TextCpf;
        private System.Windows.Forms.MaskedTextBox TextDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextNome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}