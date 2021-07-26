using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudIzibidu.Bruxo.data.data_classe
{
    class Categoriaa
    {
        public static int RetornaIdCategoria(string nameCategoria)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            category categoria = new category();
            categoria = dc.category.FirstOrDefault(cate => cate.name_categoria == nameCategoria);
            return categoria.id;
        }

        public static IQueryable<object> ListaCategoria(char ativado = 'N')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var categorias = from categoria in dc.category
                         where categoria.desativado == ativado
                         select new
                         {
                             id = categoria.id,
                             categoria = categoria.name_categoria,
                         };

            return categorias;
        }

        public static IQueryable<object> ListaCategoria(string name)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var categorias = from categoria in dc.category
                         where categoria.name_categoria.Contains(name)
                         select new
                         {
                             id = categoria.id,
                             nome = categoria.name_categoria,
                         };

            return categorias;
        }

        public static IQueryable<object> ListaCategoria(int id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var categorias = from categoria in dc.category
                         where categoria.id == id
                         select new
                         {
                             id = categoria.id,
                             nome = categoria.name_categoria,
                         };

            return categorias;
        }

        public static category RetornaCategoria(int idcategoria)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            category categoria = new category();
            categoria = dc.category.FirstOrDefault(id => id.id == idcategoria);

            return categoria;
        }

    }
}
