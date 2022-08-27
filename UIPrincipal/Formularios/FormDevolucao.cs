using BLL;
using Infra;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormDevolucao : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        public int codigoUsuario;
        public string nomeUsuario;
        string enderecoUsuario;
        string telefoneUsuario;
        public FormDevolucao()
        {
            InitializeComponent();
            devolucaoCadastroBindingSource.AddNew();
            inserindoNovo = true;
            buttonBuscar.Enabled = false;
        }
        //Construtor 2
        public FormDevolucao(object _current)
        {
            InitializeComponent();
            devolucaoCadastroBindingSource.DataSource = _current;
            inserindoNovo = false;
        }
        //Evento Click do button de buscar registros de devoluções armazenadas no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            DevolucaoBLL devolucaoBLL = new DevolucaoBLL();
            devolucaoBindingSource.DataSource = devolucaoBLL.Buscar(TextBoxBuscar.Text);
            checkBoxMostrarTodos.Checked = false;
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && TextBoxBuscar.Focused)
            {
                buttonBuscar_Click_1(null, null);
                return true;
            }
            if (keyData == Keys.Enter && dataHoraEmprestimoDateTimePicker.Focused)
            {
                buttonSalvar_Click_1(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Metodo de inserir uma nova devolucao.
        private void Inserir()
        {
            DevolucaoBLL devolucaoBLL = new DevolucaoBLL();
            Devolucao devolucao = new Devolucao();

            devolucao.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            devolucao.CODIGO_EMPRESTIMO = Convert.ToInt32(codigoEmprestimoTextBox.Tag);
            devolucao.CODIGO_LIVRO = Convert.ToInt32(livroTextBox.Tag);
            devolucao.TOMBO = textBoxTombo.Text;
            devolucao.ISBN = textBoxISBN.Text;
            devolucao.VOLUME = textBoxVolume.Text;
            devolucao.CODIGO_LEITOR = Convert.ToInt32(leitorTextBox.Tag);
            devolucao.ENDERECO_LEITOR = textBoxEnderecoLeitor.Text;
            devolucao.TELEFONE_LEITOR = textBoxTelefoneLeitor.Text;
            devolucao.CODIGO_USUARIO = codigoUsuario;
            devolucao.ENDERECO_USUARIO = enderecoUsuario;
            devolucao.TELEFONE_USUARIO = telefoneUsuario;
            devolucao.DATA_HORA_EMPRESTIMO = Convert.ToDateTime(dataHoraEmprestimoDateTimePicker.Text);
            devolucao.DATA_HORA_DEVOLUCAO = DateTime.Now;
            devolucao.EXEMPLAR = Convert.ToInt32(exemplarTextBox.Text);

            if (inserindoNovo)
                devolucaoBLL.Inserir(devolucao);
            else
                devolucaoBLL.Alterar(devolucao);
            devolucaoCadastroBindingSource.AddNew();
        }
        //Evento Click do button de adicionar um novo registro de uma devolução no banco de dados. 
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            inserindoNovo = true;
            devolucaoCadastroBindingSource.AddNew();
            buttonSalvar.Enabled = true;
            LimpaForm();
        }
        //Evento Click do button de editar um registro de uma devolução armazenado no banco de dados.
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (devolucaoBindingSource.Count == 0 || devolucaoBindingSource.Count == null)
                return;

            tabControl1.SelectedTab = tabPage2;
            DevolucaoBLL devolucaoBLL = new DevolucaoBLL();
            devolucaoCadastroBindingSource.DataSource = devolucaoBLL.Buscar(((DataRowView)devolucaoBindingSource.Current).Row["CODIGO"].ToString());//Buscando a devolucao por Id e passando os valores para o BindingSource.
            codigoEmprestimoTextBox.Tag = (((DataRowView)devolucaoBindingSource.Current).Row["CODIGO_EMPRESTIMO"].ToString());
            codigoEmprestimoTextBox.Text = (((DataRowView)devolucaoBindingSource.Current).Row["CODIGO_EMPRESTIMO"].ToString());
            textBoxTombo.Tag = (((DataRowView)devolucaoBindingSource.Current).Row["TOMBO"].ToString());
            textBoxTombo.Text = (((DataRowView)devolucaoBindingSource.Current).Row["TOMBO"].ToString());
            textBoxISBN.Tag = (((DataRowView)devolucaoBindingSource.Current).Row["ISBN"].ToString());
            textBoxISBN.Text = (((DataRowView)devolucaoBindingSource.Current).Row["ISBN"].ToString());
            textBoxVolume.Tag = (((DataRowView)devolucaoBindingSource.Current).Row["VOLUME"].ToString());
            textBoxVolume.Text = (((DataRowView)devolucaoBindingSource.Current).Row["VOLUME"].ToString());
            textBoxEnderecoLeitor.Tag = (((DataRowView)devolucaoBindingSource.Current).Row["ENDERECO_LEITOR"].ToString());
            textBoxEnderecoLeitor.Text = (((DataRowView)devolucaoBindingSource.Current).Row["ENDERECO_LEITOR"].ToString());
            textBoxTelefoneLeitor.Tag = (((DataRowView)devolucaoBindingSource.Current).Row["TELEFONE_LEITOR"].ToString());
            textBoxTelefoneLeitor.Text = (((DataRowView)devolucaoBindingSource.Current).Row["TELEFONE_LEITOR"].ToString());
            inserindoNovo = false;
            buttonSalvar.Enabled = false;
        }
        //Evento Click do button de excluir um registro de uma devolução armazenada no banco de dados.
        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            if (devolucaoBindingSource.Count == 0 || devolucaoBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            DevolucaoBLL devolucaoBLL = new DevolucaoBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)devolucaoBindingSource.Current).Row["CODIGO"]);
            devolucaoBLL.Excluir(codigo);
            devolucaoBindingSource.RemoveCurrent();
            DevolucaoMensagens.Exluir(1);
        }
        //Evento Click do button de salvar um novo registro de uma devolução no banco de dados.
        private void buttonSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                devolucaoCadastroBindingSource.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    DevolucaoMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                    codigoEmprestimoTextBox.Clear();
                }
                if (inserindoNovo == false)
                {
                    DevolucaoMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                buttonPesquisarEmprestimo.Focus();
            }
            buttonBuscar_Click_1(null, null);
        }
        //Evento Click do button sair e retornar para a tela principal.
        private void buttonSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonSalvarEcadastrarNovo_Click(object sender, EventArgs e)
        {
            inserindoNovo = true;
            LimpaForm();
        }
        //Evento Click do button de encerrar a aba de cadastro e retornar para a aba de consulta.
        private void buttonEncerrar_Click_1(object sender, EventArgs e)
        {
            inserindoNovo = true;
            tabControl1.SelectedTab = tabPage1;
            LimpaForm();
        }
        //Evento DoubleClick do datagridview de consulta que permite que o usuário vizualize informações da devolução com dois clicks no datagridview.
        private void devolucaoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click_1(null, null);
        }
        //Evento Click do button de pesquisar um registro de empréstimo armazenado no banco de dados. E permite que o usuário acesse a tela de pesquisa com as informações do empréstimo.
        private void buttonPesquisarEmprestimo_Click(object sender, EventArgs e)
        {
            using (FormSelecionarEmprestimo frm = new FormSelecionarEmprestimo())
            {
                frm.ShowDialog();
                codigoEmprestimoTextBox.Tag = frm.codigo;
                codigoEmprestimoTextBox.Text = frm.codigo.ToString();
                livroTextBox.Tag = frm.codigoLivro;
                livroTextBox.Text = frm.titulo;
                textBoxTombo.Text = frm.tombo;
                textBoxISBN.Text = frm.isbn;
                textBoxVolume.Text = frm.volume;
                leitorTextBox.Tag = frm.codigoLeitor;
                textBoxEnderecoLeitor.Text = frm.enderecoLeitor;
                textBoxTelefoneLeitor.Text = frm.telefoneLeitor;
                leitorTextBox.Text = frm.nomeLeitor;
                codigoUsuario = frm.codigoUsuario;
                enderecoUsuario = frm.enderecoUsuario;
                telefoneUsuario = frm.telefoneUsuario;
                nomeUsuario = frm.nomeUsuario;
                dataHoraEmprestimoDateTimePicker.Value = frm.dataHoraEmprestimo;
                exemplarTextBox.Text = Convert.ToString(frm.exemplar);
            }
        }
        //Evento Click do CheckBox Mostrar todos, que permite o usuário vizualizar todas as devoluções armazenadas no banco de dados.
        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            DevolucaoBLL devolucaoBLL = new DevolucaoBLL();
            devolucaoBindingSource.DataSource = devolucaoBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }
        //Evento Click do TextBoxBuscar, que ativa o botão de buscar e permite que o usuário pesquisar empréstimos com o filtro que ele desejar.
        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
        //Evento Click do button de buscar empréstimo armazenados no banco de dados por data inicial e final.
        private void buttonBuscarPorData_Click(object sender, EventArgs e)
        {
            DevolucaoBLL devolucaoBLL = new DevolucaoBLL();
            devolucaoBindingSource.DataSource = devolucaoBLL.BuscarDevolucaoPorData(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
            checkBoxMostrarTodos.Checked = false;
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }
        private void LimpaForm()
        {
            codigoEmprestimoTextBox.Clear();
            codigoTextBox.Text = "0";
            leitorTextBox.Clear();
            livroTextBox.Clear();
            textBoxTombo.Clear();
            textBoxISBN.Clear();
            textBoxVolume.Clear();
            textBoxEnderecoLeitor.Clear();
            textBoxTelefoneLeitor.Clear();
            exemplarTextBox.Text = "1";
            dataHoraDevolucaoDateTimePicker.Value = DateTime.Now;
            dataHoraEmprestimoDateTimePicker.Value = DateTime.Now;
        }
    }
}
