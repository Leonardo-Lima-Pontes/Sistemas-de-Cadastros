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

namespace CrudIzibidu.Bruxo.Formularios.Cadastros.Categoria
{
    public partial class Cadastro_Categoria : Form
    {
        public Cadastro_Categoria(int id = 0)
        {
            InitializeComponent();

            if (id != 0)
            {
                category categoria = Categoriaa.RetornaCategoria(id);
                this.txtId.Text = categoria.id.ToString();
                this.txtMarca.Text = categoria.name_categoria;
                this.checkBox1.Checked = categoria.desativado == 'N' ? false : true;
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
                category categoria = new category();
                categoria.name_categoria = this.txtMarca.Text;
                categoria.desativado = this.checkBox1.Checked == false ? 'N' : 'S'; ;

                dc.category.InsertOnSubmit(categoria);
                dc.SubmitChanges();
                this.Close();
                Auxi.MostraMesagemDeGrava();
            }
            else
            {
                category categoria = dc.category.FirstOrDefault(id => id.id == int.Parse(this.txtId.Text));
                categoria.name_categoria = this.txtMarca.Text;
                categoria.desativado = this.checkBox1.Checked == false ? 'N' : 'S';

                DialogResult result = MessageBox.Show("Tem certeza que deseja alterar alterar a categoria ?", "Alterar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    dc.SubmitChanges();
                    this.Close();
                    Auxi.MostraMesagemDeGrava();
                }

            }

            var a = Application.OpenForms["Pesquisa_Categoria"];
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

        private void Cadastro_Categoria_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: button1_Click(sender, e); break;
                case Keys.Escape: this.Close(); break;
            }
        }
    }
}
