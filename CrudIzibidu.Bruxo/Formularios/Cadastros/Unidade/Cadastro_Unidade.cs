using CrudIzibidu.Bruxo.Auxiliares;
using CrudIzibidu.Bruxo.data.data_classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudIzibidu.Bruxo.Formularios.Cadastros.Unidade
{
    public partial class Cadastro_Unidade : Form
    {
        public Cadastro_Unidade(int id = 0)
        {
            InitializeComponent();

            if (id != 0)
            {
                unit unidade = Unidadee.RetornaUnidade(id);
                this.txtId.Text = unidade.id.ToString();
                this.txtMarca.Text = unidade.name_unit;
                this.checkBox1.Checked = unidade.desativado == 'N' ? false : true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            if (string.IsNullOrEmpty(this.txtMarca.Text))
            {
                MessageBox.Show("Entre com um valor ou SAIA, by bruxo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                unit unidade = new unit();
                unidade.name_unit = this.txtMarca.Text;
                unidade.desativado = this.checkBox1.Checked == false ? 'N' : 'S'; ;

                dc.unit.InsertOnSubmit(unidade);
                dc.SubmitChanges();
                this.Close();
                Auxi.MostraMesagemDeGrava();
            }
            else
            {
                unit unidade = dc.unit.FirstOrDefault(id => id.id == int.Parse(this.txtId.Text));
                unidade.name_unit = this.txtMarca.Text;
                unidade.desativado = this.checkBox1.Checked == false ? 'N' : 'S';

                DialogResult result = MessageBox.Show("Tem certeza que deseja alterar alterar a unidade ?", "Alterar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    dc.SubmitChanges();
                    this.Close();
                    Auxi.MostraMesagemDeGrava();
                }

            }

            var a = Application.OpenForms["Pesquisa_Unidade"];
            if (a != null)
            {
                Button d = (Button)a.Controls["button1"];
                d.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cadastro_Unidade_Load(object sender, EventArgs e)
        {

        }

        private void Cadastro_Unidade_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: button1_Click(sender, e); break;
                case Keys.Escape: this.Close(); break;
            }
        }
    }
}
