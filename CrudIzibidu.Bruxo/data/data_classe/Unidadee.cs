using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudIzibidu.Bruxo.data.data_classe
{
    class Unidadee
    {

        public static int RetornaIdUnidade(string nameUnidade)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            unit unidade = new unit();
            unidade = dc.unit.FirstOrDefault(uni => uni.name_unit == nameUnidade);
            return unidade.id;
        }

        public static IQueryable<object> ListaUnidade(char ativado = 'N')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var unidades = from unidade in dc.unit
                         where unidade.desativado == ativado
                         select new
                         {
                             id = unidade.id,
                             unidade = unidade.name_unit,
                         };

            return unidades;
        }

        public static IQueryable<object> ListaUnidade(string name)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var unidades = from unidade in dc.unit
                           where unidade.name_unit.Contains(name)
                           select new
                           {
                               id = unidade.id,
                               unidade = unidade.name_unit,
                           };

            return unidades;
        }

        public static IQueryable<object> ListaUnidade(int id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var unidades = from unidade in dc.unit
                           where unidade.id == id
                           select new
                           {
                               id = unidade.id,
                               unidade = unidade.name_unit,
                           };

            return unidades;
        }

        public static unit RetornaUnidade(int idunidade)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            unit unidade = new unit();
            unidade = dc.unit.FirstOrDefault(id => id.id == idunidade);

            return unidade;
        }

    }
}
