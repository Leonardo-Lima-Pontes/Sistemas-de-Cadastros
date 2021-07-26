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
    public partial class Pesquisa_Unidade : Form
    {
        public Pesquisa_Unidade()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            Cadastro_Unidade cm = new Cadastro_Unidade(id);
            cm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char listaDesaOuAtivado = this.checkBox1.Checked == false ? 'N' : 'S';

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                ListaUnidades(listaDesaOuAtivado);
            }
            else
            {
                var unidades = Unidadee.ListaUnidade(txtMarca.Text);
                this.dataGridView1.DataSource = unidades.ToList();
            }
        }

        public void ListaUnidades(char ativado = 'N')
        {
            var unidades = Unidadee.ListaUnidade(ativado);
            this.dataGridView1.DataSource = unidades.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro_Unidade cm = new Cadastro_Unidade();
            cm.ShowDialog();
        }

        private void Pesquisa_Unidade_Load(object sender, EventArgs e)
        {
            var unidades = Unidadee.ListaUnidade();
            this.dataGridView1.DataSource = unidades.ToList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                ListaUnidades('S');
            }
            else
            {
                ListaUnidades();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            Cadastro_Unidade cm = new Cadastro_Unidade(id);
            cm.ShowDialog();
        }

        private void Pesquisa_Unidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Pesquisa_Unidade_Activated(object sender, EventArgs e)
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
