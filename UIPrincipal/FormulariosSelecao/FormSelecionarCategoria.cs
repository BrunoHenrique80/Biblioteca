using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using UIPrincipal.FormulariosSelecao;

namespace UIPrincipal
{
    public partial class FormSelecionarCategoria : Form
    {
        //Atributos e propiedades.
        public int codigo;
        public string descricaoCategoria;
        //Constructor
        public FormSelecionarCategoria()
        {
            InitializeComponent();
        }
        //Evento Load que carrega os dados quando o formulário inicia.
        private void FormSelecionarCategoria_Load(object sender, EventArgs e)
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            categoriaBindingSource.DataSource = categoriaBLL.Buscar(TextBoxBuscar.Text);
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
        //Evento Click do button de buscar registros de categorias armazenadas no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            categoriaBindingSource.DataSource = categoriaBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento DoubleClick do datagridview de categoria, que permite o usuário selecionar uma categoria com dois clicks no datagridview.
        private void categoriaDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (categoriaBindingSource.Count == 0 || categoriaBindingSource.Count == null)
                return;
            codigo = Convert.ToInt32(((DataRowView)categoriaBindingSource.Current).Row["CODIGO"]);
            descricaoCategoria = Convert.ToString(((DataRowView)categoriaBindingSource.Current).Row["DESCRICAO_CATEGORIA"]);
            Close();
        }
        //Evento Click do button de selecionar uma categoria.
        private void buttonSelecionar_Click(object sender, EventArgs e)
        {
            categoriaDataGridView_DoubleClick(null, null);
        }
        //Evento Click do button de cancelar, que permite o usuário encerrar a tela de pesquisa.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FormCadastroCategoria frm = new FormCadastroCategoria(this))
            {
                frm.ShowDialog();
            }
        }
    }
}
