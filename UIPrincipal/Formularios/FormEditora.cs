using BLL;
using Infra;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormEditora : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        //Construtor 1
        public FormEditora()
        {
            InitializeComponent();
            editoraCadastroBindingSource.AddNew();
            inserindoNovo = true;
            groupBoxLivros.Visible = false;
            buttonBuscar.Enabled = false;
        }
        //Construtor 2
        public FormEditora(object _current)
        {
            InitializeComponent();
            editoraCadastroBindingSource.DataSource = _current;
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
            if (keyData == Keys.Enter && nomeTextBox.Focused)
            {
                buttonSalvar_Click_1(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Metodo de inserir editora
        private void Inserir()
        {
            EditoraBLL editoraBLL = new EditoraBLL();
            Editora editora = new Editora();

            editora.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            editora.NOME = nomeTextBox.Text;

            if (inserindoNovo)
                editoraBLL.Inserir(editora);
            else
                editoraBLL.Alterar(editora);
            editoraCadastroBindingSource.AddNew();
        }
        //Evento click do button de novo cadastro de uma editora.
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            inserindoNovo = true;
            editoraCadastroBindingSource.AddNew();
            groupBoxLivros.Visible = false;
        }
        //Evento click do button de editar uma editora cadastrada.
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (editoraBindingSource.Count == 0 || editoraBindingSource.Count == null)
                return;
            tabControl1.SelectedTab = tabPage2;
            EditoraBLL editoraBLL = new EditoraBLL();
            LivroBLL livroBLL = new LivroBLL();
            editoraCadastroBindingSource.DataSource = editoraBLL.Buscar(((DataRowView)editoraBindingSource.Current).Row["CODIGO"].ToString());//Buscando a editora por Id e passando os valores para o BindingSource.
            inserindoNovo = false;
            livroBindingSource.DataSource = livroBLL.BuscarLivroPorEditora(Convert.ToInt32(((DataRowView)editoraBindingSource.Current).Row["CODIGO"]));
            groupBoxLivros.Visible = true;
        }
        //Evento click do button de excluir uma editora cadastrada.
        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            if (editoraBindingSource.Count == 0 || editoraBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            EditoraBLL editoraBLL = new EditoraBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)editoraBindingSource.Current).Row["CODIGO"]);
            editoraBLL.Excluir(codigo);
            editoraBindingSource.RemoveCurrent();
            EditoraMensagens.Exluir(1);
        }
        //Evento click do button de sair.
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Evento click do button de buscar uma editora cadastrada no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            EditoraBLL editoraBLL = new EditoraBLL();
            editoraBindingSource.DataSource = editoraBLL.Buscar(TextBoxBuscar.Text);
            checkBoxMostrarTodos.Checked = false;
        }
        //Evento click do button de salvar uma nova editora.
        private void buttonSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                editoraCadastroBindingSource.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    EditoraMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                if (inserindoNovo == false)
                {
                    EditoraMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                nomeTextBox.Focus();
            }
            buttonBuscar_Click_1(null, null);
        }
        private void buttonSalvarEcadastrarNovo_Click_1(object sender, EventArgs e)
        {
        }
        //Evento Click do button de encerrar a aba de cadastro e retorna para a aba de consulta.
        private void buttonEncerrar_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            groupBoxLivros.Visible = false;
            editoraCadastroBindingSource.AddNew();
        }
        //Evento DoubleClick do datagridview de consulta que permite o usuário vizualize informações da editora com dois clicks no datagridview.
        private void editoraDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click_1(null, null);
        }

        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            EditoraBLL editoraBLL = new EditoraBLL();
            editoraBindingSource.DataSource = editoraBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }

        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
    }
}
