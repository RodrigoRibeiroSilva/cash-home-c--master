using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketServerMelo
{
    public partial class ServerApp : Form
    {

        private Socket socket;
        private Thread thread;


        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;

        TcpListener tcpListener;

        public ServerApp()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(RunServer));
            thread.Start();

            textBox1.Hide();
            button1.Hide();

        }
        private void AddToListBox(object oo)
        {
            Invoke(new MethodInvoker(
                           delegate { listBoxMensagensRecebidas.Items.Add(oo);
                           }
            ));
        }


        public void RunServer()
        {

            try
            {
               
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2001);
                tcpListener = new TcpListener(ipEndPoint);
                tcpListener.Start();

                AddToListBox("Servidor habilitado e escutando porta..." + "Server App");

                socket = tcpListener.AcceptSocket();
                networkStream = new NetworkStream(socket);
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);

                AddToListBox("conexão recebida!" + "Server App");
                binaryWriter.Write("\nconexão efetuada!");
               
                string messageReceived = "";
                do
                {

                    messageReceived = binaryReader.ReadString();
                    string[] palavras = messageReceived.Split(' ');
                    AddToListBox("Filtro da pesquisa:"+messageReceived);
                    if (messageReceived.Equals("Acesso Inválido"))
                    {
                        binaryWriter.Write("\nAcesso negado!");
                    }
                    else if (palavras.Contains("autorizado!"))
                    {
                        binaryWriter.Write("\nAcesso Permitido.");
                    }


                } while (socket.Connected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (binaryReader != null)
                {
                    binaryReader.Close();
                }
                if (binaryWriter != null)
                {
                    binaryWriter.Close();
                }
                if (networkStream != null)
                {
                    networkStream.Close();
                }
                if (socket != null)
                {
                    socket.Close();
                }
                MessageBox.Show("conexão finalizada", "Server App");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                binaryWriter.Write(textBox1.Text);
            }
            catch (SocketException socketEx)
            {
                MessageBox.Show(socketEx.Message, "Erro");
            }
            catch (Exception socketEx)
            {
                MessageBox.Show(socketEx.Message, "Erro");
            }
        }

        private void ServerApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            tcpListener.Stop();
            Environment.Exit(0);
           
        }

        private void ServerApp_Load(object sender, EventArgs e)
        {

        }
    }
}
