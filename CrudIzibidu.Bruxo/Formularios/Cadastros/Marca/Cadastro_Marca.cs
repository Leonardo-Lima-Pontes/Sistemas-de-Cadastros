using CrudIzibidu.Bruxo.Auxiliares;
using CrudIzibidu.Bruxo.data.data_classe;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Marca;

namespace CrudIzibidu.Bruxo
{

    public partial class Cadastro_Marca : Form
    {

        public Cadastro_Marca(int id = 0)
        {
            InitializeComponent();

            if (id != 0)
            {
                brand marca = Marcaa.RetornaMarca(id);
                this.txtId.Text = marca.id.ToString();
                this.txtMarca.Text = marca.name_brand;
                this.checkBox1.Checked = marca.desativado == 'N' ? false : true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtMarca.Text))
            {
                MessageBox.Show("Entre com um valor ou SAIA, by bruxo");
                return;
            }

            DataClasses1DataContext dc = new DataClasses1DataContext();

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                brand brand = new brand();
                brand.name_brand = this.txtMarca.Text;
                brand.desativado = this.checkBox1.Checked == false ? 'N' : 'S'; ;

                dc.brand.InsertOnSubmit(brand);
                dc.SubmitChanges();
                this.Close();
                Auxi.MostraMesagemDeGrava();
            }
            else
            {
                brand marca = dc.brand.FirstOrDefault(id => id.id == int.Parse(this.txtId.Text));
                marca.name_brand = this.txtMarca.Text;
                marca.desativado = this.checkBox1.Checked == false ? 'N' : 'S';

                DialogResult result = MessageBox.Show("Tem certeza que deseja alterar alterar a marca ?", "Alterar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    dc.SubmitChanges();
                    this.Close();
                    Auxi.MostraMesagemDeGrava();
                }
               
            }

            var a = Application.OpenForms["Pesquisa_Marca"];
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

        private void Cadastro_Marca_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = this.checkBox1.Checked.ToString();
        }

        private void marca_groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Cadastro_Marca_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: button1_Click(sender, e); break;
                case Keys.Escape: this.Close(); break;
            }
        }
    }
}
