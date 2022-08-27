using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using UIPrincipal.FormulariosSelecao;

namespace UIPrincipal
{
    public partial class FormSelecionarEditora : Form
    {
        //Atributos e propiedades.
        FormLivro formLivro;
        public int codigo;
        public string nome;
        //Constructor 
        public FormSelecionarEditora()
        {
            InitializeComponent();
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && TextBoxBuscar.Focused)
            {
                buttonBuscar_Click_1(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Evento Load que carrega os dados quando inicia o formulário.
        private void FormSelecionarEditora_Load(object sender, EventArgs e)
        {
            EditoraBLL editoraBLL = new EditoraBLL();
            editoraBindingSource.DataSource = editoraBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento Click do button de buscar registros de editoras armazenadas no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            EditoraBLL editoraBLL = new EditoraBLL();
            editoraBindingSource.DataSource = editoraBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento DoubleClick do datagridview de editora que permite o usuário selecionar uma editora.
        private void editoraDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (editoraBindingSource.Count == 0 || editoraBindingSource.Count == null)
                return;
            codigo = Convert.ToInt32(((DataRowView)editoraBindingSource.Current).Row["CODIGO"]);
            nome = Convert.ToString(((DataRowView)editoraBindingSource.Current).Row["NOME"]);
            Close();
        }
        //Evento Click do button de selecionar uma editora.
        private void buttonSelecionar_Click_1(object sender, EventArgs e)
        {
            editoraDataGridView_DoubleClick(null, null);
        }
        //Evento Click do button de cancelar, que permite o usuário encerrar a tela de pesquisa.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(FormCadastroEditora frm = new FormCadastroEditora(this))
            {
                frm.ShowDialog();
            }
        }
    }
}
