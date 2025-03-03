using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using WcfService;

namespace SistemaOdonto
{
    public partial class frmEditarDentista : Form
    {
        public string status;
        Dentista obj = new Dentista();
        DentistaService service = new DentistaService();


        public frmEditarDentista(Dentista obj)
        {
            InitializeComponent();
            IniciarFormulario(obj);
        }

        private void IniciarFormulario(Dentista objP)
        {
            this.obj = objP;
            lblCod.Text = this.obj.Id.ToString();
            txtNome.Text = this.obj.Nome;
            txtEmail.Text = this.obj.Email;
            txtTelefone.Text = this.obj.Telefone.ToString();
            txtCelular.Text = this.obj.Celular.ToString();
            txtCro.Text = this.obj.CRO;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ts.Text = ValidarCad();
            tsNenhuma.Text = "";
            if(ts.Text == "Sucesso!")
            {
                if(Convert.ToInt32(lblCod.Text) != this.obj.Id)
                {
                    status = "apagado";
                    MessageBox.Show("Regístro excluído por outro usuário");
                }
                else
                {
                    status = "editado";
                    this.obj.Nome = txtNome.Text;
                    this.obj.Email = txtEmail.Text;
                    this.obj.Telefone = txtTelefone.Text != "" ? Convert.ToInt64(txtTelefone.Text) : 0;
                    this.obj.Celular = txtCelular.Text != "" ? Convert.ToInt64(txtCelular.Text) : 0;
                    this.obj.CRO = txtCro.Text;
                    service.Editar(this.obj);
                    this.Close();
                }
            }
        }

        private string ValidarCad()
        {
            ts.ForeColor = Color.Red;
            if (txtNome.Text == string.Empty)
            {
                return "Preencha o campo nome!";
            }
            else if (txtCelular.Text == string.Empty)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            tsNenhuma.Text = "";
            if (ValidarExclusao())
            {
                service.Deletar(this.obj.Id);
                MessageBox.Show("Excluido com sucesso");
                status = "apagado";
                this.Close();
            }
        }

        public bool ValidarExclusao()
        {
            DialogResult con = MessageBox.Show("Deseja excluir esse registro?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if(con.ToString().ToUpper() == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
