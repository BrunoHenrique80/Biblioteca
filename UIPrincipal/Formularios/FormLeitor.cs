using BLL;
using DAL;
using Infra;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormLeitor : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;

        //Construtor 1
        public FormLeitor()
        {
            InitializeComponent();
            leitorCadastroBindingSource.AddNew();
            inserindoNovo = true;
            groupBoxLivros.Visible = false;
            buttonBuscar.Enabled = false;
        }

        //Construtor 2
        public FormLeitor(object _current)
        {
            InitializeComponent();
            leitorCadastroBindingSource.DataSource = _current;
            inserindoNovo = false;
        }

        //Evento Load ao carregar formulário
        private void FormLeitor_Load(object sender, EventArgs e)
        {
            RetornarTipoLeitor();
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && TextBoxBuscar.Focused)
            {
                buttonBuscar_Click(null, null);
                return true;
            }
            if (keyData == Keys.Enter && emailTextBox.Focused)
            {
                buttonSalvar_Click_1(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Metodo de inserir leitor
        private void Inserir()
        {
            LeitorBLL leitorBLL = new LeitorBLL();
            Leitor leitor = new Leitor();

            leitor.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            leitor.NOME_LEITOR = nomeLeitorTextBox.Text;
            leitor.DATA_NASCIMENTO = Convert.ToDateTime(dataNascimentoDateTimePicker.Text);
            leitor.CPF = cpfTextBox.Text;
            leitor.RG = rgTextBox.Text;
            if (rbMasculino.Checked)
                leitor.SEXO = "Masculino";
            if (rbFeminino.Checked)
                leitor.SEXO = "Feminino";
            if (rbOutro.Checked)
                leitor.SEXO = "Outro";
            leitor.ENDERECO = enderecoTextBox.Text;
            leitor.BAIRRO = bairroTextBox.Text;
            leitor.CEP = cepTextBox.Text;
            leitor.CODIGO_CIDADE = Convert.ToInt32(TextBoxCidade.Tag);
            leitor.CODIGO_ESTADO = Convert.ToInt32(TextBoxEstado.Tag);
            leitor.CODIGO_TIPO_LEITOR = Convert.ToInt32(cmbTipoLeitor.SelectedValue.ToString());
            leitor.TELEFONE = telefoneTextBox.Text;
            leitor.EMAIL = emailTextBox.Text;
            leitor.DATA_CADASTRO = DateTime.Now;


            if (inserindoNovo)
                leitorBLL.Inserir(leitor);
            else
                leitorBLL.Alterar(leitor);
            leitorCadastroBindingSource.AddNew();
        }
        //Metodo que retorna todos os tipos de usuarios cadastrados no banco de dados.
        private void RetornarTipoLeitor()
        {
            LeitorDAL leitor = new LeitorDAL();

            cmbTipoLeitor.Items.Clear();
            cmbTipoLeitor.DataSource = Banco.dql(leitor.vqueryTipoLeitor);
            cmbTipoLeitor.DisplayMember = "DESCRICAO";
            cmbTipoLeitor.ValueMember = "CODIGO";
        }
        //Evento Click do button de pesquisar um registro de uma cidade. Que permite que o usuário acesse a tela de pesquisa de cidade.
        private void buttonPesquisaCidade_Click(object sender, EventArgs e)
        {
            using (FormSelecionarCidade frm = new FormSelecionarCidade())
            {
                frm.ShowDialog();
                TextBoxCidade.Tag = frm.codigo;
                TextBoxCidade.Text = frm.descricaoCidade;
            }
        }
        //Evento Click do button de pesquisar um registro de um estado. Que permite que o usuário acesse a tela de pesquisa de estado.
        private void buttonPesquisaEstado_Click(object sender, EventArgs e)
        {
            using (FormSelecionarEstado frm = new FormSelecionarEstado())
            {
                frm.ShowDialog();
                TextBoxEstado.Tag = frm.codigo;
                TextBoxEstado.Text = frm.descricaoEstado;
            }
        }
        //Evento click do button de Novo cadastro de leitor
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            inserindoNovo = true;
            leitorCadastroBindingSource.AddNew();
        }
        //Evento click do button de Editar uma cadastro de leitor
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (leitorBindingSource.Count == 0 || leitorBindingSource.Count == null)
                return;
            tabControl1.SelectedTab = tabPage2;
            LeitorBLL leitorBLL = new LeitorBLL();
            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            leitorCadastroBindingSource.DataSource = leitorBLL.Buscar(((DataRowView)leitorBindingSource.Current).Row["CODIGO"].ToString());//Buscando o leitor por Id e passando os valores para o BindingSource.
            string sexo = (((DataRowView)leitorBindingSource.Current).Row["SEXO"].ToString());
            if (sexo == "Masculino")
                rbMasculino.Checked = true;
            if (sexo == "Feminino")
                rbFeminino.Checked = true;
            if (sexo == "Outro")
                rbOutro.Checked = true;
            TextBoxCidade.Tag = (((DataRowView)leitorBindingSource.Current).Row["CODIGO_CIDADE"].ToString());
            TextBoxCidade.Text = (((DataRowView)leitorBindingSource.Current).Row["DESCRICAO_CIDADE"].ToString());
            TextBoxEstado.Tag = (((DataRowView)leitorBindingSource.Current).Row["CODIGO_ESTADO"].ToString());
            TextBoxEstado.Text = (((DataRowView)leitorBindingSource.Current).Row["DESCRICAO_ESTADO"].ToString());
            emprestimoBindingSource.DataSource = emprestimoBLL.BuscarEmprestimoPorLeitor(Convert.ToInt32(((DataRowView)leitorBindingSource.Current).Row["CODIGO"]));
            inserindoNovo = false;
            groupBoxLivros.Visible = true;
        }
        //Evento click do button de Excluir um cadastro de um leitor
        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            if (leitorBindingSource.Count == 0 || leitorBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            LeitorBLL leitorBLL = new LeitorBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)leitorBindingSource.Current).Row["CODIGO"]);
            leitorBLL.Excluir(codigo);
            leitorBindingSource.RemoveCurrent();
            LeitorMensagens.Exluir(1);
        }
        //Evento click do button de sair.
        private void buttonSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        //Evento click do button de salvar um novo leitor
        private void buttonSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                leitorCadastroBindingSource.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    LeitorMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                if (inserindoNovo == false)
                {
                    LeitorMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                nomeLeitorTextBox.Focus();
            }
            buttonBuscar_Click(null, null);
        }
        //Evento click do button de salvar e cadastro um novo leitor
        private void buttonSalvarEcadastrarNovo_Click_1(object sender, EventArgs e)
        {
        }
        //Evento click do button de voltar para tela de consulta.
        private void buttonEncerrar_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            groupBoxLivros.Visible = false;
            leitorCadastroBindingSource.AddNew();
        }
        //Evento DoubleClick do datagridview de consulta que permite que o usuário vizualize informações do leitor com dois clicks no datagridview.
        private void leitorDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click_1(null, null);
        }
        //Evento SelectionChangeCommitted do combobox, que permite o usuário selecionar um tipo de pesquisa referente ao tipo de leitor dos leitores armazenados no banco de dados.
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                LeitorBLL leitorBLL = new LeitorBLL();
                leitorBindingSource.DataSource = leitorBLL.BuscarLeitorAluno(TextBoxBuscar.Text);
            }
            if (comboBox2.SelectedIndex == 1)
            {
                LeitorBLL leitorBLL = new LeitorBLL();
                leitorBindingSource.DataSource = leitorBLL.BuscarLeitorInstrutor(TextBoxBuscar.Text);
            }
            if (comboBox2.SelectedIndex == 2)
            {
                LeitorBLL leitorBLL = new LeitorBLL();
                leitorBindingSource.DataSource = leitorBLL.BuscarLeitorColaborador(TextBoxBuscar.Text);
            }
            if (comboBox2.SelectedIndex == 3)
            {
                LeitorBLL leitorBLL = new LeitorBLL();
                leitorBindingSource.DataSource = leitorBLL.BuscarLeitorOutro(TextBoxBuscar.Text);
            }
            checkBoxMostrarTodos.Checked = false;
            buttonBuscar.Enabled = false;
        }

        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            LeitorBLL leitorBLL = new LeitorBLL();
            leitorBindingSource.DataSource = leitorBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }
        //Evento click do button de buscar de leitor cadastrado
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            LeitorBLL leitorBLL = new LeitorBLL();
            leitorBindingSource.DataSource = leitorBLL.Buscar(TextBoxBuscar.Text);
            checkBoxMostrarTodos.Checked = false;
        }

        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
    }
}
