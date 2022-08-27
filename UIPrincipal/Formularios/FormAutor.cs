using BLL;
using Infra;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormAutor : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        //Construtor 1
        public FormAutor()
        {
            InitializeComponent();
            autorCadastroBindingSource.AddNew();
            inserindoNovo = true;
            groupBoxLivros.Visible = false;
            buttonBuscar.Enabled = false;
        }
        //Construtor 2
        public FormAutor(object _current)
        {
            InitializeComponent();
            autorCadastroBindingSource.DataSource = _current;
            inserindoNovo = false;
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && TextBoxBuscar.Focused)
            {
                buttonBuscar_Click_1(null, null);
                return true;
            }
            if (keyData == Keys.Enter && nomeAutorTextBox.Focused)
            {
                buttonSalvar_Click_1(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Metodo de inserir autor
        private void Inserir()
        {
            AutorBLL autorBLL = new AutorBLL();
            Autor autor = new Autor();

            autor.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            autor.NOME_AUTOR = nomeAutorTextBox.Text;

            if (inserindoNovo)
                autorBLL.Inserir(autor);
            else
                autorBLL.Alterar(autor);
            autorCadastroBindingSource.AddNew();
        }
        //Evento click do button novo autor.
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            inserindoNovo = true;
            autorCadastroBindingSource.AddNew();
            groupBoxLivros.Visible = false;
        }
        //Evento click do button de editar um autor cadastrado.
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (autorBindingSource.Count == 0 || autorBindingSource.Count == null)
                return;
            tabControl1.SelectedTab = tabPage2;
            AutorBLL autorBLL = new AutorBLL();
            LivroBLL livroBLL = new LivroBLL();
            autorCadastroBindingSource.DataSource = autorBLL.Buscar(((DataRowView)autorBindingSource.Current).Row["CODIGO"].ToString());//Buscando o autor por Id e passando os valores para o BindingSource.
            livroBindingSource.DataSource = livroBLL.BuscarLivroPorAutor(Convert.ToInt32(((DataRowView)autorBindingSource.Current).Row["CODIGO"]));
            inserindoNovo = false;
            groupBoxLivros.Visible = true;
        }
        //Evento click do button de excluir um autor cadastrado.
        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            if (autorBindingSource.Count == 0 || autorBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            AutorBLL autorBLL = new AutorBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)autorBindingSource.Current).Row["CODIGO"]);
            autorBLL.Excluir(codigo);
            autorBindingSource.RemoveCurrent();
            AutorMensagens.Exluir(1);
        }
        //Evento click do button de sair.
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Evento click do button de buscar um autor cadastrado no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            AutorBLL autorBLL = new AutorBLL();
            autorBindingSource.DataSource = autorBLL.Buscar(TextBoxBuscar.Text);
            checkBoxMostrarTodos.Checked = false;
        }
        //Evento click do button de salvar um novo autor.
        private void buttonSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                autorCadastroBindingSource.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    AutorMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                if (inserindoNovo == false)
                {
                    AutorMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                } 
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                nomeAutorTextBox.Focus();
            }
            buttonBuscar_Click_1(null, null);
        }

        private void buttonSalvarEcadastrarNovo_Click(object sender, EventArgs e)
        {
        }
        //Evento click do button de voltar para tela de consulta.
        private void buttonEncerrar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            groupBoxLivros.Visible = false;
            autorCadastroBindingSource.AddNew();
        }
        //Evento DoubleClick do datagridview de consulta de autor que permite o usuário vizualizar as informações do autor com dois clicks no datagridview.
        private void autorDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click_1(null, null);
        }

        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            AutorBLL autorBLL = new AutorBLL();
            autorBindingSource.DataSource = autorBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }

        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
    }
}
