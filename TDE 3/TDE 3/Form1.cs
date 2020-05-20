using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TDE_3
{
    public partial class Form1 : Form
    {
        Thread nt;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSenha_Click(object sender, EventArgs e)
        {
            
           
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Henrique" && txtSenha.Text == "123")
            {
                this.Close();
                nt = new Thread(novoForm);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
            else
            {
                MessageBox.Show("Login ou Senha invalidos!");
            }
        }
        private void novoForm()
        {
            Application.Run(new Form2());
        }
    }
}
