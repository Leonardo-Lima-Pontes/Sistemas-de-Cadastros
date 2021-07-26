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
    public partial class Pesquisa_Categoria : Form
    {
        public Pesquisa_Categoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char listaDesaOuAtivado = this.checkBox1.Checked == false ? 'N' : 'S';

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                ListaCategorias(listaDesaOuAtivado);
            }
            else
            {
                var categorias = Categoriaa.ListaCategoria(txtMarca.Text);
                this.dataGridView1.DataSource = categorias.ToList();
            }

        }

        public void ListaCategorias(char ativado = 'N')
        {
            var categorias = Categoriaa.ListaCategoria(ativado);
            this.dataGridView1.DataSource = categorias.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro_Categoria cm = new Cadastro_Categoria();
            cm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = Application.OpenForms["Cadastro_Inicial_Produtos"];

            if (a != null)
            {   
                a.Controls["categoria_textBox4"].Text = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                this.Close();
                return;
            }

            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            Cadastro_Categoria cm = new Cadastro_Categoria(id);
            cm.ShowDialog();
        }

        private void Pesquisa_Categoria_Load(object sender, EventArgs e)
        {
            var categorias = Categoriaa.ListaCategoria();
            this.dataGridView1.DataSource = categorias.ToList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                ListaCategorias('S');
            }
            else
            {
                ListaCategorias();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            Cadastro_Categoria cm = new Cadastro_Categoria(id);
            cm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pesquisa_Categoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Pesquisa_Categoria_Activated(object sender, EventArgs e)
        {
            this.txtMarca.Focus();
        }

        private void txtMarca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
