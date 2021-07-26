using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudIzibidu.Bruxo.data.data_classe
{
    static class Produtoo
    {
        public static produto ListaProduto(int id)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            produto prod = new produto();
            prod = dc.produto.FirstOrDefault(produ => produ.id == id);

            return prod;
        }

        public static IQueryable<object> ListaProduto(string nomeProduto, char ativado = 'S')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var produto = from prod in dc.produto
                          where (prod.nome_produto.Contains(nomeProduto))
                          && prod.ativado == ativado
                          select new
                          {
                              id_produto = prod.id,
                              nome_produto = prod.nome_produto,
                              preco_produto = prod.preco_venda_produto.ToString(),
                              estoque_produto = prod.estoque_produto.ToString()
                          };

            return produto;
        }

        public static IQueryable<object> ListaProduto(string nomeProduto, int? codigoProduto = 0, char ativado = 'S')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var produto = from prod in dc.produto
                          where nomeProduto == "" ? prod.id == codigoProduto && prod.ativado == ativado :
                                                    prod.nome_produto.Contains(nomeProduto) && prod.ativado == ativado || prod.id == codigoProduto && prod.ativado == ativado
                          select new
                          {
                              id_produto = prod.id,
                              nome_produto = prod.nome_produto,
                              preco_produto = prod.preco_venda_produto.ToString(),
                              estoque_produto = prod.estoque_produto.ToString()
                          };

            return produto;
        }

        public static IQueryable<object> ListaProduto(string nomeProduto, string nomeCategoria, int? codigoProduto = 0, char ativado = 'S')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            int idCategoria = Categoriaa.RetornaIdCategoria(nomeCategoria);

            var produto = from prod in dc.produto
                          where nomeProduto == "" ? prod.id == codigoProduto && prod.ativado == ativado && prod.id_category == idCategoria:
                                                    prod.nome_produto.Contains(nomeProduto) && prod.ativado == ativado && prod.id_category == idCategoria || prod.id == codigoProduto && prod.ativado == ativado && prod.id_category == idCategoria
                          select new
                          {
                              id_produto = prod.id,
                              nome_produto = prod.nome_produto,
                              preco_produto = prod.preco_venda_produto.ToString(),
                              estoque_produto = prod.estoque_produto.ToString()
                          };

            return produto;
        }

        public static IQueryable<object> ListaProduto(char ativado = 'S')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            var produto = from prod in dc.produto
                          where prod.ativado == ativado
                          && prod.ativado == ativado
                          select new
                          {
                              id_produto = prod.id,
                              nome_produto = prod.nome_produto,
                              preco_produto = prod.preco_venda_produto.ToString().Substring(0, 5),
                              estoque_produto = prod.estoque_produto.ToString().Substring(0, 5)
                          };

            return produto;
        }

        public static IQueryable<object> ListaProdutoCategoria(string nomeCategoria, char ativado = 'S')
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            int idCategoria = Categoriaa.RetornaIdCategoria(nomeCategoria);

            var produto = from prod in dc.produto
                          where prod.ativado == ativado && prod.id_category == idCategoria
                          && prod.ativado == ativado
                          select new
                          {
                              id_produto = prod.id,
                              nome_produto = prod.nome_produto,
                              preco_produto = prod.preco_venda_produto.ToString(),
                              estoque_produto = prod.estoque_produto.ToString()
                          };

            return produto;
        }
    }
}
