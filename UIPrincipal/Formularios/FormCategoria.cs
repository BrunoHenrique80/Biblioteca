using BLL;
using Infra;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormCategoria : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        //Construtor 1
        public FormCategoria()
        {
            InitializeComponent();
            categoriaCadastroBindingSource.AddNew();
            inserindoNovo = true;
            groupBoxLivros.Visible = false;
            buttonBuscar.Enabled = false;
        }
        //Construtor 2
        public FormCategoria(object _current)
        {
            InitializeComponent();
            categoriaCadastroBindingSource.DataSource = _current;
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
            if (keyData == Keys.Enter && descricaoCategoriaTextBox.Focused)
            {
                buttonSalvar_Click_1(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Metodo de inserir categoria
        private void Inserir()
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            Categoria categoria = new Categoria();

            categoria.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            categoria.DESCRICAO_CATEGORIA = descricaoCategoriaTextBox.Text;

            if (inserindoNovo)
                categoriaBLL.Inserir(categoria);
            else
                categoriaBLL.Alterar(categoria);
            categoriaCadastroBindingSource.AddNew();
        }
        //Evento Click do button de buscar registros de categorias armazenadas no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            categoriaBindingSource.DataSource = categoriaBLL.Buscar(TextBoxBuscar.Text);
            checkBoxMostrarTodos.Checked = false;
        }
        //Evento Click do button de adicionar uma nova categoria no banco de dados.
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            inserindoNovo = true;
            categoriaCadastroBindingSource.AddNew();
            groupBoxLivros.Visible = false;
        }
        //Evento Click do button de editar um cadastro de uma categoria armazenada no banco de dados.
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (categoriaBindingSource.Count == 0 || categoriaBindingSource.Count == null)
                return;
            tabControl1.SelectedTab = tabPage2;
            CategoriaBLL editoraBLL = new CategoriaBLL();
            LivroBLL livroBLL = new LivroBLL();
            categoriaCadastroBindingSource.DataSource = editoraBLL.Buscar(((DataRowView)categoriaBindingSource.Current).Row["CODIGO"].ToString());//Buscando a categoria por Id e passando os valores para o BindingSource.
            inserindoNovo = false;
            livroBindingSource.DataSource = livroBLL.BuscarLivroPorCategoria(Convert.ToInt32(((DataRowView)categoriaBindingSource.Current).Row["CODIGO"]));
            groupBoxLivros.Visible = true;
        }
        //Evento Click do button de excluir um registro de uma categoria armazenada no banco de dados.
        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            if (categoriaBindingSource.Count == 0 || categoriaBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            CategoriaBLL categoriaBLL = new CategoriaBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)categoriaBindingSource.Current).Row["CODIGO"]);
            categoriaBLL.Excluir(codigo);
            categoriaBindingSource.RemoveCurrent();
            CategoriaMensagens.Exluir(1);
        }
        //Evento Click do button de sair e retornar para a tela principal.
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Evento Click do button de salvar o cadastro de uma nova categoria no banco de dados.
        private void buttonSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                categoriaCadastroBindingSource.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    CategoriaMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                if (inserindoNovo == false)
                {
                    CategoriaMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                }          
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                descricaoCategoriaTextBox.Focus();
            }
            buttonBuscar_Click_1(null, null);
        }
        private void buttonSalvarEcadastrarNovo_Click_1(object sender, EventArgs e)
        {
        }
        //Evento Click do button de voltar para tela de consulta. 
        private void buttonEncerrar_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            groupBoxLivros.Visible = false;
            categoriaCadastroBindingSource.AddNew();
        }
        //Evento DoubleClick do datagridview de consulta de categoria que permite que o usuário vizualize informações da categoria com dois clicks no datagridview.
        private void categoriaDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click_1(null, null);
        }

        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            categoriaBindingSource.DataSource = categoriaBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }

        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
    }
}
