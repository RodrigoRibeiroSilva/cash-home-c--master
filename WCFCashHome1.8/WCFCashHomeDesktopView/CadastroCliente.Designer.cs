namespace WCFCashHomeDesktopView
{
    partial class CadastroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroCliente));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextSenha = new System.Windows.Forms.TextBox();
            this.TextEmail = new System.Windows.Forms.TextBox();
            this.TextNome = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TextDT = new System.Windows.Forms.MaskedTextBox();
            this.TextCpf = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Data de Nascimento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "CPF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nome";
            // 
            // TextSenha
            // 
            this.TextSenha.Location = new System.Drawing.Point(236, 95);
            this.TextSenha.Name = "TextSenha";
            this.TextSenha.Size = new System.Drawing.Size(136, 20);
            this.TextSenha.TabIndex = 18;
            this.TextSenha.UseSystemPasswordChar = true;
            // 
            // TextEmail
            // 
            this.TextEmail.Location = new System.Drawing.Point(236, 38);
            this.TextEmail.Name = "TextEmail";
            this.TextEmail.Size = new System.Drawing.Size(136, 20);
            this.TextEmail.TabIndex = 15;
            this.TextEmail.TextChanged += new System.EventHandler(this.TextEmail_TextChanged);
            // 
            // TextNome
            // 
            this.TextNome.Location = new System.Drawing.Point(11, 25);
            this.TextNome.Name = "TextNome";
            this.TextNome.Size = new System.Drawing.Size(136, 20);
            this.TextNome.TabIndex = 14;
            this.TextNome.TextChanged += new System.EventHandler(this.textBoxnome_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cadastrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextDT
            // 
            this.TextDT.Location = new System.Drawing.Point(11, 79);
            this.TextDT.Name = "TextDT";
            this.TextDT.Size = new System.Drawing.Size(101, 20);
            this.TextDT.TabIndex = 24;
            // 
            // TextCpf
            // 
            this.TextCpf.Location = new System.Drawing.Point(238, 149);
            this.TextCpf.Mask = "000000000-00";
            this.TextCpf.Name = "TextCpf";
            this.TextCpf.Size = new System.Drawing.Size(133, 20);
            this.TextCpf.TabIndex = 25;
            // 
            // CadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(408, 256);
            this.Controls.Add(this.TextCpf);
            this.Controls.Add(this.TextDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextSenha);
            this.Controls.Add(this.TextEmail);
            this.Controls.Add(this.TextNome);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Clientes";
            this.Load += new System.EventHandler(this.CadastroCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextSenha;
        private System.Windows.Forms.TextBox TextEmail;
        private System.Windows.Forms.TextBox TextNome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox TextDT;
        private System.Windows.Forms.MaskedTextBox TextCpf;
    }
}

