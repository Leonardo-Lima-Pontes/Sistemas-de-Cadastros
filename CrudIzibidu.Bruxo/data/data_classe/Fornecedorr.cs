using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudIzibidu.Bruxo.data.data_classe
{
    static class Fornecedorr
    {

        public static int RetornaIdFornecedor(string nomeFornecedor)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            supplier fornecedor = new supplier();
            fornecedor = dc.supplier.FirstOrDefault(forn => forn.name_supplier == nomeFornecedor);
            return fornecedor.id;
        }

        public static int RetornaIdCidade(string nameCidade)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            city cidade = new city();
            cidade = dc.city.FirstOrDefault(name => name.city_name == nameCidade);
            return cidade.id;
        }

        public static int RetornaIdTipoContato(string nameContato)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            type_contact tipo_contato = new type_contact();
            tipo_contato = dc.type_contact.FirstOrDefault(tipo => tipo.name_type_contact == nameContato);
            return tipo_contato.id;
        }

        public static IQueryable<object> ListaFornecedor(char ativado = 'S')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var fornecedor = from forne in dc.supplier
                             where forne.activated == ativado
                             select new
                             {
                                 id = forne.id,
                                 nome = forne.name_supplier,
                                 cnpj = forne.cpf,
                                 razao_social = forne.surname,
                             };

            return fornecedor;
        }

        public static IQueryable<object> ListaFornecedor(string nomeFornecedor, char ativado = 'S')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var fornecedor = from forne in dc.supplier
                             where (forne.surname.Contains(nomeFornecedor) || forne.name_supplier.Contains(nomeFornecedor))
                             && forne.activated == ativado
                             select new
                             {
                                 id = forne.id,
                                 nome = forne.name_supplier,
                                 cnpj = forne.cpf,
                                 razao_social = forne.surname,
                             };

            return fornecedor;
        }

        public static supplier ListaFornecedor(int id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            supplier fornecedor = new supplier();
            fornecedor = dc.supplier.FirstOrDefault(forn => forn.id == id);

            return fornecedor;
        }


        public static IQueryable<object> ListaFornecedor(string name)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var fornecedor = from marca in dc.supplier
                         where marca.name_supplier.Contains(name)
                         select new
                         {
                             id = marca.id,
                             nome = marca.name_supplier,
                         };

            return fornecedor;
        }


    }
}
