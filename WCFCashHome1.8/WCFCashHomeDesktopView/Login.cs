using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFCashHomeDesktopView.localhost;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace WCFCashHomeDesktopView
{
    public partial class Login : Form
    {
        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;
        private TcpClient tcpClient;

        private Thread thread;

        public Cliente clienteLogin = new Cliente();
        public Login()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(RunClient));
            thread.Start();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Service1 sv = new Service1();

            clienteLogin = sv.PegarClientePorEmail(textBoxEmail.Text);
            if (clienteLogin.Equals(null) == false)
            {
                if (clienteLogin.Senha == textBoxSenha.Text)
                {
                    binaryWriter.Write(textBoxEmail.Text.ToString() + " Acesso autorizado!");
                    MeuEscritorio meuEscritorio = new MeuEscritorio(clienteLogin);
                    meuEscritorio.clienteEscritorio = clienteLogin;
                    meuEscritorio.Show();
                    this.Hide();
                }
                else
                    binaryWriter.Write("Acesso Inválido");
            }
        }

        private void RunClient()
        {
            try
            {
                tcpClient = new TcpClient();
                //conectando ao servidor
                tcpClient.Connect("127.0.0.1", 2001);

                networkStream = tcpClient.GetStream();
                binaryWriter = new BinaryWriter(networkStream);

                binaryReader = new BinaryReader(networkStream);
                binaryWriter.Write("Iniciando conexão cliente entrada");
                String message = "";
                do
                {
                    try
                    {
                        message = binaryReader.ReadString();
                        Invoke(new MethodInvoker(
                          delegate { MessageBox.Show(message.ToString()); }
                          ));
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Erro");
                        message = "FIM";
                    }
                } while (message != "FIM");

                binaryWriter.Close();
                binaryReader.Close();
                networkStream.Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadastroCliente c = new CadastroCliente();
            c.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBoxSenha_TextChanged(object sender, EventArgs e)
        {
            textBoxSenha.PasswordChar = '*';
        }
    }
}
