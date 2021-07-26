using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudIzibidu.Bruxo
{
    public partial class Gravado_com_sucesso : Form
    {
        public Gravado_com_sucesso()
        {
            InitializeComponent();
        }

        private void Gravado_com_sucesso_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
