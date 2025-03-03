using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfService;

namespace SistemaOdonto
{
    public partial class frmCadDentista : Form
    {
        DentistaService service = new DentistaService();
        public frmCadDentista()
        {
            InitializeComponent();
            txtNome.Text = txtCelular.Text;
        }

        private string ValidarCad()
        {
            ts.ForeColor = Color.Red;
            if(txtNome.Text == string.Empty)
            {
                return "Preencha o campo nome!";
            }
            else if(txtCelular.Text == string.Empty)
            {
                return "Preencha o campo celular!";
            }
            else if (txtTelefone.Text == string.Empty)
            {
                return "Preencha o campo telefone!";
            }
            else if (txtCro.Text == string.Empty)
            {
                return "Preencha o campo CRO!";
            }
            else if (txtEmail.Text == string.Empty)
            {
                return "Preencha o campo Email!";
            }
            else
            {
                ts.ForeColor = Color.Black;
                return "Sucesso!";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            tsNenhuma.Text = string.Empty;
            try
            {
                ts.Text = ValidarCad();
                if(ts.Text == "Sucesso!")
                {
                    service.Cadastrar(objGerado());
                    MessageBox.Show("Cadastro efetuado com sucesso!");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar: " + ex.Message);
            }
        }

        public Dentista objGerado()
        {
            Dentista obj = new Dentista();
            obj.Nome = txtNome.Text;
            obj.Email = txtEmail.Text;
            obj.Telefone = txtTelefone.Text != "" ? Convert.ToInt64(txtTelefone.Text) : 0;
            obj.Celular = txtCelular.Text != "" ? Convert.ToInt64(txtCelular.Text) : 0;
            obj.CRO = txtCro.Text;

            return obj;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            frmConDentista frm = new frmConDentista();
            frm.ShowDialog();
        }

        public void Limpar()
        {
            txtCelular.Text = string.Empty;
            txtCro.Text = string.Empty;
            txtNome.Text = "";
            txtTelefone.Text = string.Empty;
            txtEmail.Text = "";
        }
    }
}
