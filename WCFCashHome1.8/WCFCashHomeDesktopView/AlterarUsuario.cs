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
using WCFCashHomeDesktopView.localhost;

namespace WCFCashHomeDesktopView
{
    public partial class AlterarUsuario : Form
    {
        Cliente cliente;
        Service1 sv = new Service1();
        string nome, email, cpf, dataNascimento, senha;

        public AlterarUsuario(Cliente cliente)
        {
            this.cliente = cliente;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void AlterarUsuario_Load(object sender, EventArgs e)
        {
            TextNome.Text = cliente.Nome;
            TextDT.Text = cliente.DataNascimento.ToString();
            TextCpf.Text = cliente.Cpf;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Service1 sv = new Service1();

            nome = TextNome.Text.ToString(); ;
            email = cliente.Email.ToString();
            dataNascimento = TextDT.Text.ToString();
            cpf = TextCpf.Text.ToString();
            senha = cliente.Senha.ToString();


            string isOk = testaCamposViewUpdate();

            if (isOk == "Campos Válidos")
            {
                Cliente clienteUpdate = new Cliente();
                clienteUpdate.Nome = nome;
                clienteUpdate.Email = email;
                clienteUpdate.DataNascimento = dataNascimento;
                clienteUpdate.Cpf = cpf;
                clienteUpdate.Senha = senha;

                MessageBox.Show(sv.UpdateClient(clienteUpdate));
            }

            else
            {
                MessageBox.Show(isOk);
            }

        }


        private string testaCamposViewUpdate()
        {
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
            if (senha.Length > 30)
            {
                return "Digite uma senha de até 30 digitos";
            }
            if (cpf == null || cpf == "")
            {
                return "Digite o campo CPF";
            }
            if (cpf.Length > 20 || cpf.Length < 11)
            {
                return "CPF inválido";
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
    }
}

        
        
  

