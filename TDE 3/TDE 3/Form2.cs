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
using TDE_3.Properties;
using WinFormValidation;

namespace TDE_3
{
    public partial class Form2 : Form
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory + "data";
        static string file = path + "/Form2.txt";
        ErrorProvider Erro = new ErrorProvider(); 
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Validation Validacao = new Validation(this,Erro);
            Validacao.AddRule(txtNome, "Nome", "required");
            Validacao.AddRule(txtSobrenome, "Sobrenome", "required");
            Validacao.AddRule(txtTelefone, "Telefone", "required|telefone");
            Validacao.AddRule(txtEmail, "Email", "required|email");
            Validacao.AddRule(txtCEP, "CEP", "required|cep");
            Validacao.Validate();
            
            if (Validacao.IsValid())
            {
                bool checkDirExist = Directory.Exists(path);
                //if (checkDirExist == false)
                //if (!checkDirExist == true)
                if (!checkDirExist)
                    Directory.CreateDirectory(path);


                String line = txtNome.Text + "|" + txtSobrenome.Text + "|" + txtTelefone.Text + "|" + txtEmail.Text + "|" + txtCEP.Text;

                bool checkFileExist = File.Exists(file);

                if (!checkFileExist)
                {
                    using (StreamWriter sw = File.CreateText(file))
                    {
                        sw.WriteLine(line);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(line);
                    }
                }

                MessageBox.Show("Cadastrado com Sucesso");
                Validacao.CleanAllComponents();
                this.LoadLista();
            }
            else
            {
                Validacao.ErrorProviderShow(Resources.icons8_unavailable_48,20,20,-30);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadLista()
        {
            if (File.Exists(file))
            {
                dgvlista.Rows.Clear();
                using (StreamReader sr = new StreamReader(file))
                {
                    int line = 0;
                    string ln;

                    while ((ln = sr.ReadLine()) != null)
                    {
                        

                        string[] fields = ln.Split('|');

                        dgvlista.Rows.Add(fields[0], fields[1], fields[2], fields[3], fields[4]);

                        line++;
                    }
                    sr.Close();
                   
                  
                }
            }
          
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.LoadLista();
        }
    }
}
