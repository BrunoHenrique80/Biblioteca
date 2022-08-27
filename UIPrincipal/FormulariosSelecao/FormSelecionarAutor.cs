using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using UIPrincipal.FormulariosSelecao;

namespace UIPrincipal
{
    public partial class FormSelecionarAutor : Form
    {
        //Atributos e propiedades.
        FormLivro formLivro;
        public int codigo;
        public string nomeAutor;
        //Constructor
        public FormSelecionarAutor()
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
        private void FormSelecionarAutor_Load(object sender, EventArgs e)
        {
            AutorBLL autorBLL = new AutorBLL();
            autorBindingSource.DataSource = autorBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento Click do button de buscar registros de autores armazenados no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            AutorBLL autorBLL = new AutorBLL();
            autorBindingSource.DataSource = autorBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento DoubleClick do datagridview do autor que permite o usuário selecionar o autor com dois clicks no datagridview.
        private void autorDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (autorBindingSource.Count == 0 || autorBindingSource.Count == null)
                return;
            codigo = Convert.ToInt32(((DataRowView)autorBindingSource.Current).Row["CODIGO"]);
            nomeAutor = Convert.ToString(((DataRowView)autorBindingSource.Current).Row["NOME_AUTOR"]);
            Close();
        }
        //Evento Click do button de selecionar um autor. 
        private void buttonSelecionar_Click_1(object sender, EventArgs e)
        {
            autorDataGridView_DoubleClick(null, null);
        }
        //Evento Click do button de cancelar, que permite o usuário encerrar a tela de pesquisa.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (FormCadastroAutor frm = new FormCadastroAutor(this))
            {
                frm.ShowDialog();
            }
        }
    }
}
