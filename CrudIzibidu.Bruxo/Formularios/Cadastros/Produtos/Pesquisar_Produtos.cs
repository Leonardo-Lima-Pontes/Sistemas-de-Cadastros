using CrudIzibidu.Bruxo.data.data_classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudIzibidu.Bruxo.Formularios.Cadastros.Produtos
{
    public partial class Pesquisar_Produtos : Form
    {
        public Pesquisar_Produtos()
        {
            InitializeComponent();
        }

        DataClasses1DataContext dc = new DataClasses1DataContext();

        private void Pesquisar_Produtos_Load(object sender, EventArgs e)
        {
            var produtos = Produtoo.ListaProduto();
            this.dataGridView1.DataSource = produtos.ToList();

            var categorias = dc.category.Select(cate => new
            {
                nome_categoria = cate.name_categoria
            }).ToList();

            foreach (var item in categorias)
            {
                this.categoria_comboBox1.Items.Add(item.nome_categoria);
            }

            this.categoria_comboBox1.SelectedItem = "TODOS";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ListaDesativadoECategoria();
        }

        private void categoria_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaDesativadoECategoria();
        }

        public void ListaDesativadoECategoria()
        {
            char listaDesaOuAtivado = this.checkBox1.Checked == false ? 'S' : 'N';
            string nomeCategoria = this.categoria_comboBox1.Text;
            if (nomeCategoria == "TODOS")
            {
                var produtos = Produtoo.ListaProduto(listaDesaOuAtivado);
                this.dataGridView1.DataSource = produtos.ToList();
            }
            else
            {
                var produtos = Produtoo.ListaProdutoCategoria(nomeCategoria, listaDesaOuAtivado);
                this.dataGridView1.DataSource = produtos.ToList();
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = this.dataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            char listaDesaOuAtivado = this.checkBox1.Checked == false ? 'S' : 'N';
            string nomeCategoria = this.categoria_comboBox1.Text;
            string nomeProduto = this.nome_produto_txtMarca.Text;
            int? codigoProduto = null;

            if (!string.IsNullOrEmpty(this.codigo_produto_textBox1.Text))
                codigoProduto = int.Parse(this.codigo_produto_textBox1.Text);

            if (string.IsNullOrEmpty(nomeProduto) && codigoProduto == null)
            {
                if (nomeCategoria == "TODOS")
                {
                    var produtos = Produtoo.ListaProduto(listaDesaOuAtivado);
                    this.dataGridView1.DataSource = produtos.ToList();
                }
                else
                {
                    var produtos = Produtoo.ListaProdutoCategoria(nomeCategoria, listaDesaOuAtivado);
                    this.dataGridView1.DataSource = produtos.ToList();
                }
            }
            else
            {
                if (nomeCategoria == "TODOS")
                {
                    var produtos = Produtoo.ListaProduto(nomeProduto, codigoProduto, listaDesaOuAtivado);
                    this.dataGridView1.DataSource = produtos.ToList();
                }
                else
                {
                    var produtos = Produtoo.ListaProduto(nomeProduto, nomeCategoria, codigoProduto, listaDesaOuAtivado);
                    this.dataGridView1.DataSource = produtos.ToList();
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            var formularioDeCadastroAberto = Application.OpenForms["Cadastro_Inicial_Produtos"];

            if (formularioDeCadastroAberto != null)
            {


                ToolStrip btnsNoMenu = (ToolStrip)Application.OpenForms["Cadastro_Inicial_Produtos"].Controls["tableLayoutPanel1"].Controls["toolStrip1"];
                btnsNoMenu.Items[0].Text = "Alterar";
                btnsNoMenu.Items[2].Enabled = true;

                DataClasses1DataContext dc = new DataClasses1DataContext();
                produto prod = Produtoo.ListaProduto(id);

                TextBox caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["id_produto_textBox1"];
                caixaDeTexto.Text = prod.id.ToString();

                caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["data_registro_textBox1"];
                caixaDeTexto.Text = prod.data_registro.ToString();

                caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["codigo_barras_textBox3"];
                caixaDeTexto.Text = prod.codigo_barras;

                caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["nome_produto_textBox5"];
                caixaDeTexto.Text = prod.nome_produto;

                ComboBox comboBox = (ComboBox)formularioDeCadastroAberto.Controls["unidade_comboBox1"];
                comboBox.Text = prod.unit.name_unit;

                caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["categoria_textBox4"];
                caixaDeTexto.Text = prod.category.name_categoria;

                caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["preco_custo_textBox1"];
                caixaDeTexto.Text = prod.preco_custo_produto.ToString();

                caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["preco_venda_textBox2"];
                caixaDeTexto.Text = prod.preco_venda_produto.ToString();

                if (prod.id_brand != null)
                {
                    caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["marca_textBox10"];
                    caixaDeTexto.Text = prod.brand.name_brand;
                }

                caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["estoque_textBox7"];
                caixaDeTexto.Text = prod.estoque_produto.ToString();

                if (prod.id_supplier != null)
                {
                    caixaDeTexto = (TextBox)formularioDeCadastroAberto.Controls["nome_fornecedor_textBox9"];
                    caixaDeTexto.Text = prod.supplier.name_supplier;
                }
                

                CheckBox checkBox = (CheckBox)formularioDeCadastroAberto.Controls["ativado_checkBox1"];
                checkBox.Checked = prod.ativado == 'S' ? false : true;

            }

            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button3_Click(sender, e);
        }

        private void nome_produto_txtMarca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void codigo_produto_textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void Pesquisar_Produtos_Activated(object sender, EventArgs e)
        {
            this.nome_produto_txtMarca.Focus();
        }


        private void Pesquisar_Produtos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
