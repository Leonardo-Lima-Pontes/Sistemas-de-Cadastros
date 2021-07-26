using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudIzibidu.Bruxo.data.data_classe
{
    static class Marcaa
    {

        public static int RetornaIdMarca(string nameMarca)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            brand marca = new brand();
            marca = dc.brand.FirstOrDefault(mar => mar.name_brand == nameMarca);
            return marca.id;
        }

        public static IQueryable<object> ListaMarca(char ativado = 'N')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var marcas = from marca in dc.brand
                         where marca.desativado == ativado
                         select new
                         {
                             id = marca.id,
                             marca = marca.name_brand,
                         };

            return marcas;
        }

        public static IQueryable<object> ListaMarca(string name)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var marcas = from marca in dc.brand
                         where marca.name_brand.Contains(name)
                         select new
                         {
                             id = marca.id,
                             nome = marca.name_brand,
                         };

            return marcas;
        }

        public static IQueryable<object> ListaMarca(int id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var marcas = from marca in dc.brand
                         where marca.id == id
                         select new
                         {
                             id = marca.id,
                             nome = marca.name_brand,
                         };

            return marcas;
        }

        public static brand RetornaMarca(int idmarca)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            brand marca = new brand();
            marca = dc.brand.FirstOrDefault(id => id.id == idmarca);

            return marca;
        }

    }
}
