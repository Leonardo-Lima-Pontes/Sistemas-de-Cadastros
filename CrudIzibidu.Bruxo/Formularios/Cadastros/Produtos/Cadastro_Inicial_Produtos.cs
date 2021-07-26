using CrudIzibidu.Bruxo.Auxiliares;
using CrudIzibidu.Bruxo.data.data_classe;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Categoria;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Fornecedor;
using CrudIzibidu.Bruxo.Formularios.Cadastros.Marca;
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
    public partial class Cadastro_Inicial_Produtos : Form
    {
        public Cadastro_Inicial_Produtos()
        {
            InitializeComponent();
        }

        DataClasses1DataContext dc = new DataClasses1DataContext();

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cadastro_Inicial_Produtos_Load(object sender, EventArgs e)
        {
            var unidades = dc.unit.Select(unid => new
            {
                nome_unidade = unid.name_unit,
            }).ToList();

            foreach (var item in unidades)
            {
                this.unidade_comboBox1.Items.Add(item.nome_unidade);
            }

            this.unidade_comboBox1.SelectedIndex = 0;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Pesquisa_Categoria pc = new Pesquisa_Categoria();
            pc.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Pesquisa_Fornecedor pf = new Pesquisa_Fornecedor();
            pf.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pesquisa_Marca pm = new Pesquisa_Marca();
            pm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nome_produto_textBox5.Text) || string.IsNullOrEmpty(this.preco_venda_textBox2.Text))
            {
                MessageBox.Show("PREENCHA OS CAMPOS OBRIGATÓRIOS");
                return;
            }

            if (string.IsNullOrEmpty(this.id_produto_textBox1.Text))
            {
                produto prod = new produto();

                if (this.categoria_textBox4.Text != "")
                    prod.id_category = Categoriaa.RetornaIdCategoria(this.categoria_textBox4.Text);

                if (this.nome_fornecedor_textBox9.Text != "")
                    prod.id_supplier = Fornecedorr.RetornaIdFornecedor(this.nome_fornecedor_textBox9.Text);

                if (this.nome_fornecedor_textBox9.Text != "")
                    prod.id_brand = Marcaa.RetornaIdMarca(this.marca_textBox10.Text);

                prod.data_registro = DateTime.Now;
                prod.nome_produto = this.nome_produto_textBox5.Text;
                prod.id_unit = Unidadee.RetornaIdUnidade(this.unidade_comboBox1.Text);
                prod.preco_custo_produto = decimal.Parse(this.preco_custo_textBox1.Text);
                prod.preco_venda_produto = decimal.Parse(this.preco_venda_textBox2.Text);
                prod.estoque_produto = int.Parse(this.estoque_textBox7.Text.Replace(",", ""));
                prod.codigo_barras = this.codigo_barras_textBox3.Text;
                prod.ativado = this.ativado_checkBox1.Checked == false ? 'S' : 'N';

                dc.produto.InsertOnSubmit(prod);
                dc.SubmitChanges();

                ClearButtonClick();
                Auxi.MostraMesagemDeGrava();

            }
            else
            {
                produto prod = dc.produto.FirstOrDefault(pro => pro.id == int.Parse(this.id_produto_textBox1.Text));

                prod.nome_produto = this.nome_produto_textBox5.Text;
                prod.id_unit = Unidadee.RetornaIdUnidade(this.unidade_comboBox1.Text);
                prod.id_category = Categoriaa.RetornaIdCategoria(this.categoria_textBox4.Text);
                prod.preco_custo_produto = int.Parse(this.preco_custo_textBox1.Text.Replace(",", ""));
                prod.preco_venda_produto = int.Parse(this.preco_venda_textBox2.Text.Replace(",", ""));
                prod.estoque_produto = int.Parse(this.estoque_textBox7.Text.Replace(",", ""));
                prod.id_supplier = Fornecedorr.RetornaIdFornecedor(this.nome_fornecedor_textBox9.Text);
                prod.id_brand = Marcaa.RetornaIdMarca(this.marca_textBox10.Text);
                prod.codigo_barras = this.codigo_barras_textBox3.Text;
                prod.ativado = this.ativado_checkBox1.Checked == false ? 'S' : 'N';

                DialogResult result = MessageBox.Show("Tem certeza que deseja alterar alterar o PRODUTO ?", "Alterar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ClearButtonClick();
                    Pesquisar_Produtos pp = new Pesquisar_Produtos();
                    dc.SubmitChanges();
                    this.toolStripButton4.Enabled = false;
                    pp.ShowDialog();
                }
            }
            
        }

        private void ClearButtonClick()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Text != "0,00")
                    {
                        ((TextBox)control).ResetText();
                    }
                }
            }
        }



        private void preco_custo_textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void preco_venda_textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void estoque_textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult resultDesativado = MessageBox.Show("Todas as alterações feitas serão perdidas, deseja prosseguir ?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultDesativado == DialogResult.Yes)
            {
                ClearButtonClick();
                this.toolStripButton4.Enabled = false;
                this.toolStripButton3.Text = "Salvar";
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Pesquisar_Produtos pp = new Pesquisar_Produtos();
            pp.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult resultDesativado = MessageBox.Show("Deseja realmente escluir o PRODUTO ?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultDesativado == DialogResult.Yes)
            {
                produto prod = dc.produto.FirstOrDefault(produto => produto.id == int.Parse(this.id_produto_textBox1.Text));
                prod.ativado = 'N';
                dc.SubmitChanges();

                Pesquisar_Produtos pp = new Pesquisar_Produtos();
                ClearButtonClick();
                this.toolStripButton4.Enabled = false;
                pp.ShowDialog();
            }
        }

        private void Cadastro_Inicial_Produtos_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5: toolStripButton3_Click(sender, e); break;
                case Keys.F2: toolStripButton2_Click(sender, e); break;

                case Keys.F3:
                    if (this.toolStripButton4.Enabled == true)
                    {
                        toolStripButton4_Click(sender, e);

                    }; break;

                case Keys.F4: toolStripButton6_Click(sender, e); break;
                case Keys.Escape: toolStripButton5_Click(sender, e); break;

            }
        }

    }
}
