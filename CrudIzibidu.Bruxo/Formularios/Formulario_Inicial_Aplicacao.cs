using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Categoria;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Fornecedor;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Marca;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Produtos;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Unidade;

namespace CrudIzibidu.Bruxo
{
    public partial class Formulario_Inicial : Form
    {
        public Formulario_Inicial()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Formulario_Inicial_Marca fim = new Formulario_Inicial_Marca();
            fim.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Cadastro_Inicial_Produtos cp = new Cadastro_Inicial_Produtos();
            cp.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Formulario_Inicial_Categoria fim = new Formulario_Inicial_Categoria();
            fim.ShowDialog();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Formulario_Inicial_Unidade fim = new Formulario_Inicial_Unidade();
            fim.ShowDialog();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            Cadastro_Fornecedor_Inicial f = new Cadastro_Fornecedor_Inicial();
            f.ShowDialog();
        }

        private void Formulario_Inicial_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F1: toolStripButton3_Click(sender, e); break;
                case Keys.F2: toolStripButton2_Click(sender, e); break;
                case Keys.F3: toolStripButton1_Click_1(sender, e); break;
                case Keys.F4: toolStripButton4_Click(sender, e); break;
                case Keys.F5: toolStripButton4_Click_1(sender, e); break;
                case Keys.Escape: toolStripSplitButton1_ButtonClick(sender, e); break;

            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair do sistema ?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
