namespace SocketServerMelo
{
    partial class ServerApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxMensagensRecebidas = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxMensagensRecebidas);
            this.groupBox1.Location = new System.Drawing.Point(10, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 136);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensagens recebidas";
            // 
            // listBoxMensagensRecebidas
            // 
            this.listBoxMensagensRecebidas.FormattingEnabled = true;
            this.listBoxMensagensRecebidas.Location = new System.Drawing.Point(6, 20);
            this.listBoxMensagensRecebidas.Name = "listBoxMensagensRecebidas";
            this.listBoxMensagensRecebidas.Size = new System.Drawing.Size(265, 108);
            this.listBoxMensagensRecebidas.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Enviar Mensagem para o Cliente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 20);
            this.textBox1.TabIndex = 5;
            // 
            // ServerApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 263);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "ServerApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerApp_FormClosing);
            this.Load += new System.EventHandler(this.ServerApp_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxMensagensRecebidas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

