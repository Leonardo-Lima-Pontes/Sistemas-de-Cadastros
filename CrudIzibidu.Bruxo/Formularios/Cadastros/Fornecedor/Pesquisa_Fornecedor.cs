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

namespace CrudIzibidu.Bruxo.Formularios.Cadastros.Fornecedor
{
    public partial class Pesquisa_Fornecedor : Form
    {
        public Pesquisa_Fornecedor()
        {
            InitializeComponent();
        }

        private void Pesquisa_Fornecedor_Load(object sender, EventArgs e)
        {
            var fornecedores = Fornecedorr.ListaFornecedor();
            this.dataGridView1.DataSource = fornecedores.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char listaDesaOuAtivado = this.checkBox1.Checked == false ? 'S' : 'N';

            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                var fornecedores = Fornecedorr.ListaFornecedor(listaDesaOuAtivado);
                this.dataGridView1.DataSource = fornecedores.ToList();
            }
            else
            {
                var fornecedores = Fornecedorr.ListaFornecedor(txtMarca.Text, listaDesaOuAtivado);
                this.dataGridView1.DataSource = fornecedores.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var cadastroProduto = Application.OpenForms["Cadastro_Inicial_Produtos"];

            if (cadastroProduto != null)
            {
                cadastroProduto.Controls["nome_fornecedor_textBox9"].Text = this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                this.Close();
                return;
            }


            int index = dataGridView1.CurrentRow.Index;
            int id = (int)dataGridView1.Rows[index].Cells[0].Value;

            var a = Application.OpenForms["Cadastro_Fornecedor_Inicial"];

            ToolStrip b = (ToolStrip)Application.OpenForms["Cadastro_Fornecedor_Inicial"].Controls["tableLayoutPanel1"].Controls["toolStrip1"];
            b.Items[0].Text = "Alterar";

            ToolStrip f = (ToolStrip)Application.OpenForms["Cadastro_Fornecedor_Inicial"].Controls["tableLayoutPanel1"].Controls["toolStrip1"]; ;
            f.Items[2].Enabled = true;

            if (a != null)
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                supplier fornecedor = Fornecedorr.ListaFornecedor(id);
     
                city cidade = dc.city.FirstOrDefault(cidi => cidi.id == fornecedor.city_id);

                TextBox d = (TextBox)a.Controls["groupBox2"].Controls["razao_socialtextBox4"];
                d.Text = fornecedor.name_supplier;

                d = (TextBox)a.Controls["groupBox2"].Controls["nome_fantasia_textBox3"];
                d.Text = fornecedor.surname;

                d = (TextBox)a.Controls["groupBox2"].Controls["id_textBox1"];
                d.Text = fornecedor.id.ToString();

                d = (TextBox)a.Controls["groupBox2"].Controls["cnpj_textBox5"];
                d.Text = fornecedor.cpf;

                d = (TextBox)a.Controls["groupBox2"].Controls["incricao_estadual_textBox6"];
                d.Text = fornecedor.ie;

                d = (TextBox)a.Controls["groupBox2"].Controls["cep_textBox11"];
                d.Text = fornecedor.cep;

                d = (TextBox)a.Controls["groupBox2"].Controls["endereco_textBox12"];
                d.Text = fornecedor.adress;

                d = (TextBox)a.Controls["groupBox2"].Controls["numero_textBox13"];
                d.Text = fornecedor.adress_number;

                d = (TextBox)a.Controls["groupBox2"].Controls["bairro_textBox14"];
                d.Text = fornecedor.adress_district;

                d = (TextBox)a.Controls["groupBox2"].Controls["observacao_textBox18"];
                d.Text = fornecedor.obs;

                d = (TextBox)a.Controls["groupBox2"].Controls["data_cadastro_textBox2"];
                d.Text = fornecedor.register_data.ToString("d");

                CheckBox c = (CheckBox)a.Controls["groupBox2"].Controls["desativado_checkBox1"];
                c.Checked = fornecedor.activated == 'S' ? false : true;

                c = (CheckBox)a.Controls["groupBox2"].Controls["checkBox1"];
                c.Checked = fornecedor.custumer == 'N' ? false : true;

                ComboBox cidades = (ComboBox)a.Controls["groupBox2"].Controls["cidade_combobox2"];

                cidades.Items.Clear();

                var cidadesDoEstado = dc.city.Select(cde => new
                {
                    nome_cidade = cde.city_name,
                    nome_estado = cde.state_supplier.state_name
                }).Where(cde => cde.nome_estado == cidade.state_supplier.state_name).ToList();

                foreach (var item in cidadesDoEstado)
                {
                    cidades.Items.Add(item.nome_cidade);
                }

                ComboBox estado = (ComboBox)a.Controls["groupBox2"].Controls["estado_combobox1"];
                estado.SelectedItem = cidade.state_supplier.state_name;

                cidades.Text = cidade.city_name;
                

                var listcontatos = dc.contact.Select(s => new
                {
                    id_contato = s.id,
                    tipo_contato = s.type_contact.name_type_contact,
                    nome_contato = s.name_contact,
                    observacao = s.observation,
                    id_fornecedor = s.supplier_id
                }).Where(s => s.id_fornecedor == fornecedor.id).ToList();

                DataGridView dataGridViewContatos = (DataGridView)a.Controls["groupBox1"].Controls["dataGridView1"];
                dataGridViewContatos.Rows.Clear();
                foreach (var item in listcontatos)
                {
                    int indexContato = dataGridViewContatos.Rows.Add();
                    dataGridViewContatos.Rows[indexContato].Cells[0].Value = item.id_contato;
                    dataGridViewContatos.Rows[indexContato].Cells[1].Value = item.tipo_contato;
                    dataGridViewContatos.Rows[indexContato].Cells[2].Value = item.nome_contato;
                    dataGridViewContatos.Rows[indexContato].Cells[3].Value = item.observacao;
                }
            }

            f.Items[3].Enabled = true;
            this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            char listaDesaOuAtivado = this.checkBox1.Checked == false ? 'S' : 'N';

            var fornecedores = Fornecedorr.ListaFornecedor(listaDesaOuAtivado);
            this.dataGridView1.DataSource = fornecedores.ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button3_Click(sender, e);
        }

        private void Pesquisa_Fornecedor_Activated(object sender, EventArgs e)
        {
            this.txtMarca.Focus();
        }

        private void txtMarca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void Pesquisa_Fornecedor_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void Pesquisa_Fornecedor_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
