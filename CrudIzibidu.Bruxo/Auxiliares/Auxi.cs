using CrudIzibidu.Bruxo.Formularios.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudIzibidu.Bruxo.Auxiliares
{
    public static class Auxi
    {
        public static void MostraMesagemDeGrava()
        {
            Gravado_com_sucesso gs = new Gravado_com_sucesso();
            gs.Show();
        }
    }
}
