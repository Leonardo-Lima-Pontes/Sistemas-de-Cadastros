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
    public partial class Formulario_Inicial_Unidade : Form
    {
        public Formulario_Inicial_Unidade()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cadastro_Unidade cm = new Cadastro_Unidade();
            cm.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Pesquisa_Unidade cm = new Pesquisa_Unidade();
            cm.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Formulario_Inicial_Unidade_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: button1_Click_1(sender, e); break;
                case Keys.F4: button2_Click_1(sender, e); break;
                case Keys.Escape: this.Close(); break;
            }
        }
    }
}
