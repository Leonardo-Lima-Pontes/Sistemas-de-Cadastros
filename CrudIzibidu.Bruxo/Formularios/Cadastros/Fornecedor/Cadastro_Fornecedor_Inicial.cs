using Consulta.CNPJ.Services;
using CrudIzibidu.Bruxo.Auxiliares;
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
    public partial class Cadastro_Fornecedor_Inicial : Form
    {
        public Cadastro_Fornecedor_Inicial()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cadastro_Fornecedor_Inicial_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.estado_comboBox1.SelectedIndex = 25;
            this.cidade_comboBox2.SelectedIndex = 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.nome_fantasia_textBox3.Text))
            {
                MessageBox.Show("O Campo NOME FANTASIA É OBRIGADTÓRIO");
                return;
            }

            DataClasses1DataContext dc = new DataClasses1DataContext();

            if (string.IsNullOrEmpty(this.id_textBox1.Text))
            {
                supplier fornecedor = new supplier();
                fornecedor.name_supplier = this.razao_socialtextBox4.Text;
                fornecedor.surname = this.nome_fantasia_textBox3.Text;
                fornecedor.cpf = this.cnpj_textBox5.Text;
                fornecedor.ie = this.incricao_estadual_textBox6.Text;
                fornecedor.cep = this.cep_textBox11.Text;
                fornecedor.adress = this.endereco_textBox12.Text;
                fornecedor.city_id = Fornecedorr.RetornaIdCidade(this.cidade_comboBox2.Text);
                fornecedor.adress_number = this.numero_textBox13.Text;
                fornecedor.adress_district = this.bairro_textBox14.Text;
                fornecedor.obs = this.observacao_textBox18.Text;
                fornecedor.register_data = DateTime.Now;
                fornecedor.activated = this.desativado_checkBox1.Checked == false ? 'S' : 'N';
                fornecedor.custumer = this.checkBox1.Checked == false ? 'N' : 'S';

                dc.supplier.InsertOnSubmit(fornecedor);
                dc.SubmitChanges();


                int quantidadeContatos = this.dataGridView1.RowCount;
                if (quantidadeContatos > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        int idTipoContato = Fornecedorr.RetornaIdTipoContato((string)this.dataGridView1.Rows[i].Cells[1].Value);
                        contact contato = new contact();
                        contato.supplier_id = fornecedor.id;
                        contato.type_contact_id = idTipoContato;
                        contato.name_contact = this.dataGridView1.Rows[i].Cells[2].Value.ToString();

                        if (this.dataGridView1.Rows[i].Cells[3].Value != null)
                        {
                            contato.observation = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }

                        dc.contact.InsertOnSubmit(contato);
                        dc.SubmitChanges();

                    }
                }
                Auxi.MostraMesagemDeGrava();
                ClearButtonClick();
            }
            else
            {
                supplier fornecedor = dc.supplier.FirstOrDefault(forn => forn.id == int.Parse(this.id_textBox1.Text));

                fornecedor.name_supplier = this.razao_socialtextBox4.Text;
                fornecedor.surname = this.nome_fantasia_textBox3.Text;
                fornecedor.cpf = this.cep_textBox11.Text;
                fornecedor.ie = this.incricao_estadual_textBox6.Text;
                fornecedor.cep = this.cep_textBox11.Text;
                fornecedor.adress = this.endereco_textBox12.Text;
                fornecedor.city_id = Fornecedorr.RetornaIdCidade(this.cidade_comboBox2.Text);
                fornecedor.adress_number = this.numero_textBox13.Text;
                fornecedor.adress_district = this.bairro_textBox14.Text;
                fornecedor.obs = this.observacao_textBox18.Text;
                fornecedor.register_data = DateTime.Now;
                fornecedor.activated = this.desativado_checkBox1.Checked == false ? 'S' : 'N';
                fornecedor.custumer = this.checkBox1.Checked == false ? 'N' : 'S';

                int quantidadeContatos = this.dataGridView1.RowCount;
                if (quantidadeContatos > 0)
                {
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        int id = (int)this.dataGridView1.Rows[i].Cells[0].Value;
                        if (id != 0)
                        {
                            contact contato = dc.contact.FirstOrDefault(cont => cont.id == id);
                            int idTipoContato = Fornecedorr.RetornaIdTipoContato((string)this.dataGridView1.Rows[i].Cells[1].Value);
                            contato.type_contact_id = idTipoContato;
                            contato.name_contact = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            contato.observation = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                        }
                        else
                        {
                            int idTipoContato = Fornecedorr.RetornaIdTipoContato((string)this.dataGridView1.Rows[i].Cells[1].Value);
                            contact contato = new contact();
                            contato.supplier_id = fornecedor.id;
                            contato.type_contact_id = idTipoContato;
                            contato.name_contact = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                            contato.observation = this.dataGridView1.Rows[i].Cells[3].Value.ToString();

                            dc.contact.InsertOnSubmit(contato);
                        }


                    }
                }


                DialogResult result = MessageBox.Show("Tem certeza que deseja alterar alterar o FORNECEDOR ?", "Alterar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ClearButtonClick();
                    Pesquisa_Fornecedor pf = new Pesquisa_Fornecedor();
                    dc.SubmitChanges();
                    pf.ShowDialog();
                }
            }

            this.toolStripButton4.Enabled = false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = 0;
            dataGridView1.Rows[index].Cells[1].Value = this.comboBox1.Text;
            dataGridView1.Rows[index].Cells[2].Value = this.textBox20.Text;
            dataGridView1.Rows[index].Cells[3].Value = this.textBox21.Text;

            this.textBox20.Text = "";
            this.textBox21.Text = "";
        }

        private void ClearButtonClick()
        {
            foreach (Control control in this.Controls["groupBox2"].Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).ResetText();
                }
            }

            this.dataGridView1.Rows.Clear();
            this.checkBox1.Checked = false;
            this.desativado_checkBox1.Checked = false;
            this.textBox20.ResetText();
            this.textBox21.ResetText();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Pesquisa_Fornecedor pf = new Pesquisa_Fornecedor();
            pf.ShowDialog();
        }

        private void desativado_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.desativado_checkBox1.Checked == true)
            {

            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult resultDesativado = MessageBox.Show("Deseja realmente escluir o cadastro ?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultDesativado == DialogResult.Yes)
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                supplier fornecedor = dc.supplier.FirstOrDefault(forn => forn.id == int.Parse(this.id_textBox1.Text));
                fornecedor.activated = 'N';
                dc.SubmitChanges();

                Pesquisa_Fornecedor pf = new Pesquisa_Fornecedor();
                ClearButtonClick();
                this.toolStripButton4.Enabled = false;
                pf.ShowDialog();


            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult resultDesativado = MessageBox.Show("Todas as alterações feitas serão perdidas deseja prosseguir ?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultDesativado == DialogResult.Yes)
            {
                ClearButtonClick();
                this.toolStripButton4.Enabled = false;
                this.toolStripButton3.Text = "Salvar";
            }
        }

        private void codigoContatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns["Codigo"].Visible = true;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.contextMenuStrip1.Show();
        }

        private void estado_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();

            this.cidade_comboBox2.Items.Clear();

            var cidadesDoEstado = dc.city.Select(cde => new
            {
                nome_cidade = cde.city_name,
                nome_estado = cde.state_supplier.state_name
            }).Where(cde => cde.nome_estado == this.estado_comboBox1.Text).ToList();

            foreach (var item in cidadesDoEstado)
            {
                this.cidade_comboBox2.Items.Add(item.nome_cidade);
            }

            this.cidade_comboBox2.SelectedIndex = 0;
        }


        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            DialogResult resultDesativado = MessageBox.Show("Todas as alterações feitas serão perideda, sedeja prosseguir ?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultDesativado == DialogResult.Yes)
            {
                ClearButtonClick();
                this.toolStripButton4.Enabled = false;
                this.toolStripButton3.Text = "Salvar";
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            DialogResult resultDesativado = MessageBox.Show("Deseja realmente escluir o cadastro ?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultDesativado == DialogResult.Yes)
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                supplier fornecedor = dc.supplier.FirstOrDefault(forn => forn.id == int.Parse(this.id_textBox1.Text));
                fornecedor.activated = 'N';
                dc.SubmitChanges();

                Pesquisa_Fornecedor pf = new Pesquisa_Fornecedor();
                ClearButtonClick();
                this.toolStripButton4.Enabled = false;
                pf.ShowDialog();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultDesativado = MessageBox.Show("Deseja realmente excluir todas a informações de contato do fornecedor ?", "EXCLUSÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultDesativado == DialogResult.Yes)
            {
                this.dataGridView1.Rows.Clear();
                this.textBox20.ResetText();
                this.textBox21.ResetText();
            }

        }

        private void Cadastro_Fornecedor_Inicial_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: toolStripButton3_Click(sender, e); break;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CNPJService service = new CNPJService();

            try
            {
                var infoCNPJ = service.ConsultarCPNJ(this.cnpj_textBox5.Text.Replace(".", "").Replace("/", "").Replace("-", ""));
                this.razao_socialtextBox4.Text = infoCNPJ.Nome;
                this.nome_fantasia_textBox3.Text = infoCNPJ.Fantasia;
                this.incricao_estadual_textBox6.Text = infoCNPJ.DataSituacaoEspecial;
                this.cep_textBox11.Text = infoCNPJ.Cep;
                this.endereco_textBox12.Text = infoCNPJ.Logradouro;
                this.estado_comboBox1.Text = infoCNPJ.Uf;
                this.cidade_comboBox2.Text = infoCNPJ.Municipio;
                this.numero_textBox13.Text = infoCNPJ.Numero;
                this.bairro_textBox14.Text = infoCNPJ.Bairro;

                if (!string.IsNullOrWhiteSpace(infoCNPJ.Telefone))
                {
                    int indexNovaColuna = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[indexNovaColuna].Cells[1].Value = "Telefone";
                    this.dataGridView1.Rows[indexNovaColuna].Cells[2].Value = infoCNPJ.Telefone;
                }

                if (!string.IsNullOrWhiteSpace(infoCNPJ.Email))
                {
                    int indexNovaColuna = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[indexNovaColuna].Cells[1].Value = "Email";
                    this.dataGridView1.Rows[indexNovaColuna].Cells[2].Value = infoCNPJ.Email;
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (AggregateException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
