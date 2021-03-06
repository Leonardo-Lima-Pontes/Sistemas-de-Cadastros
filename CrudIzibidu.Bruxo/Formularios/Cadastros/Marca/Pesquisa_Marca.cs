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

namespace CrudIzibidu.Bruxo.Formularios.Cadastros.Marca
{
    public partial class Pesquisa_Marca : Form
    {
        public Pesquisa_Marca()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            char listaDesaOuAtivado = this.checkBox1.Checked == false ? 'N' : 'S';

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                ListaMarcas(listaDesaOuAtivado);
            }
            else
            {
                var marcas = Marcaa.ListaMarca(txtMarca.Text);
                this.dataGridView1.DataSource = marcas.ToList();
            }

        }

        public void ListaMarcas(char ativado = 'N')
        {
            var marcas = Marcaa.ListaMarca(ativado);
            this.dataGridView1.DataSource = marcas.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro_Marca cm = new Cadastro_Marca();
            cm.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = Application.OpenForms["Cadastro_Inicial_Produtos"];

            if (a != null)
            {
                a.Controls["marca_textBox10"].Text = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                this.Close();
                return;
            }

            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            Cadastro_Marca cm = new Cadastro_Marca(id);
            cm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pesquisa_Marca_Load(object sender, EventArgs e)
        {
            var marcas = Marcaa.ListaMarca();
            this.dataGridView1.DataSource = marcas.ToList();
        }

        private void Pesquisa_Marca_Activated(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                ListaMarcas('S');
            }
            else
            {
                ListaMarcas();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            Cadastro_Marca cm = new Cadastro_Marca(id);
            cm.ShowDialog();
        }

        private void Pesquisa_Marca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtMarca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void marca_groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Pesquisa_Marca_Activated_1(object sender, EventArgs e)
        {
            this.txtMarca.Focus();
        }
    }
}
