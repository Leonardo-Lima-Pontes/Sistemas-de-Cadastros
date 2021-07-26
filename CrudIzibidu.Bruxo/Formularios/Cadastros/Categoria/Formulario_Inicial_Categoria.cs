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
    public partial class Formulario_Inicial_Categoria : Form
    {
        public Formulario_Inicial_Categoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastro_Categoria cm = new Cadastro_Categoria();
            cm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pesquisa_Categoria cm = new Pesquisa_Categoria();
            cm.ShowDialog();
        }

        private void Formulario_Inicial_Categoria_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: button1_Click(sender, e); break;
                case Keys.F4: button2_Click(sender, e); break;
                case Keys.Escape: this.Close(); break;
            }
        }
    }
}
