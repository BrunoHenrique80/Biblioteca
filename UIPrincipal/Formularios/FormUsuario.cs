using BLL;
using DAL;
using Infra;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormUsuario : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        //Construtor 1
        public FormUsuario()
        {
            InitializeComponent();
            usuarioCadastroBindingSource.AddNew();
            inserindoNovo = true;
            buttonBuscar.Enabled = false;
        }
        //Construtor 2
        public FormUsuario(object _current)
        {
            InitializeComponent();
            usuarioCadastroBindingSource.DataSource = _current;
            inserindoNovo = false;
        }
        //Evento click do button de salvar um novo usuário.
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioCadastroBindingSource.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    UsuarioMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                if (inserindoNovo == false)
                {
                    UsuarioMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                nomeUsuarioTextBox.Focus();
            }
            buttonBuscar_Click(null, null);
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && TextBoxBuscar.Focused)
            {
                buttonBuscar_Click(null, null);
                return true;
            }
            if (keyData == Keys.Enter && senhaTextBox.Focused)
            {
                buttonSalvar_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Metodo de inserir um usuário.
        private void Inserir()
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            Usuario usuario = new Usuario();

            usuario.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            usuario.NOME_USUARIO = nomeUsuarioTextBox.Text;
            if (rbMasculino.Checked)
                usuario.SEXO = "Masculino";
            if (rbFeminino.Checked)
                usuario.SEXO = "Feminino";
            if (rbOutro.Checked)
                usuario.SEXO = "Outro";
            usuario.ENDERECO = enderecoTextBox.Text;
            usuario.BAIRRO = bairroTextBox.Text;
            usuario.CODIGO_CIDADE = Convert.ToInt32(cidadeTextBox.Tag);
            usuario.CODIGO_ESTADO = Convert.ToInt32(estadoTextBox.Tag);
            usuario.CEP = cepTextBox.Text;
            usuario.CPF = cpfTextBox.Text;
            usuario.RG = rgTextBox.Text;
            usuario.TELEFONE = telefoneTextBox.Text;
            usuario.EMAIL = emailTextBox.Text;
            usuario.USERNAME = userNameTextBox.Text;
            usuario.SENHA = AcaoCriptografarSenhaParaHash.Cript_md5(senhaTextBox.Text);
            usuario.DATA_NASCIMENTO = Convert.ToDateTime(dataNascimentoDateTimePicker.Text);

            if (inserindoNovo)
                usuarioBLL.Inserir(usuario);
            else
                usuarioBLL.Alterar(usuario);
            usuarioCadastroBindingSource.AddNew();
        }
        //Evento click do button de buscar um usuário cadastrado.
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBindingSource.DataSource = usuarioBLL.Buscar(TextBoxBuscar.Text);
            checkBoxMostrarTodos.Checked = false;
        }
        //Evento click do button de encerrar o programa.
        private void buttonEncerrar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        //Evento click de cadastrar um novo usuário no banco de dados.
        private void buttonSalvarEcadastrarNovo_Click(object sender, EventArgs e)
        {
            limpaForm();
        }
        //Evento click do button de sair.
        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Evento click do button de adicionar um novo usuário.
        private void buttonNovo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            inserindoNovo = true;
            usuarioCadastroBindingSource.AddNew();
        }
        //Evento click do button de editar um usuário cadastro no banco de dados.
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (usuarioBindingSource.Count == 0 || usuarioBindingSource.Count == null)
                return;

            tabControl1.SelectedTab = tabPage2;
            UsuarioBLL livroBLL = new UsuarioBLL();
            usuarioCadastroBindingSource.DataSource = livroBLL.Buscar(((DataRowView)usuarioBindingSource.Current).Row["CODIGO"].ToString());//Buscando o usuario por Id e passando os valores para o BindingSource.
            string sexo = (((DataRowView)usuarioBindingSource.Current).Row["SEXO"].ToString());
            if (sexo == "Masculino")
                rbMasculino.Checked = true;
            if (sexo == "Feminino")
                rbFeminino.Checked = true;
            if (sexo == "Outro")
                rbOutro.Checked = true;
            cidadeTextBox.Tag = (((DataRowView)usuarioBindingSource.Current).Row["CODIGO_CIDADE"].ToString());
            cidadeTextBox.Text = (((DataRowView)usuarioBindingSource.Current).Row["DESCRICAO_CIDADE"].ToString());
            estadoTextBox.Tag = (((DataRowView)usuarioBindingSource.Current).Row["CODIGO_ESTADO"].ToString());
            estadoTextBox.Text = (((DataRowView)usuarioBindingSource.Current).Row["DESCRICAO_ESTADO"].ToString());
            inserindoNovo = false;
        }
        //Evento click do button de Pesquisar uma cidade cadastrada no banco de dados.
        private void buttonPesquisaCidade_Click(object sender, EventArgs e)
        {
            using (FormSelecionarCidade frm = new FormSelecionarCidade())
            {
                frm.ShowDialog();
                cidadeTextBox.Tag = frm.codigo;
                cidadeTextBox.Text = frm.descricaoCidade;
            }
        }
        //Evento click do button de pesquisa de um estado cadastrado no banco de dados.
        private void buttonPesquisaEstado_Click(object sender, EventArgs e)
        {
            using (FormSelecionarEstado frm = new FormSelecionarEstado())
            {
                frm.ShowDialog();
                estadoTextBox.Tag = frm.codigo;
                estadoTextBox.Text = frm.descricaoEstado;
            }
        }
        //Evento click do button de excluir um usuário cadastro no banco de dados.
        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioBindingSource.Count == 0 || usuarioBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)usuarioBindingSource.Current).Row["CODIGO"]);
            usuarioBLL.Excluir(codigo);
            usuarioBindingSource.RemoveCurrent();
            UsuarioMensagens.Exluir(1);
        }
        //Metódo de limpar formulário de cadastro de um novo usuário.
        private void limpaForm()
        {
            codigoTextBox.Clear();
            nomeUsuarioTextBox.Clear();
            enderecoTextBox.Clear();
            bairroTextBox.Clear();
            cidadeTextBox.Clear();
            estadoTextBox.Clear();
            cepTextBox.Clear();
            cpfTextBox.Clear();
            rgTextBox.Clear();
            telefoneTextBox.Clear();
            emailTextBox.Clear();
            senhaTextBox.Clear();        
        }
        //Evento DoubleClick do datagridview de consulta de usuário. Que permite que o usuário vizualize informações do usuário com dois clicks no datagridview.
        private void usuarioDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click(null, null);
        }
        //Evento Click do CheckBox Mostrar todos, que permite o usuário vizualizar todos os usuários armazenados no banco de dados.
        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBindingSource.DataSource = usuarioBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }
        //Evento Click do TextBox buscar, que ativa o botão buscar e permite o usuário pesquisar com o filtro que desejar.
        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
    }
}
