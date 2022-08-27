using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormSelecionarEmprestimo : Form
    {
        //Atributos e propiedades.
        public int codigo;
        public int codigoLivro;
        public string tombo;
        public string isbn;
        public string volume;
        public string titulo;
        public int codigoLeitor;
        public string enderecoLeitor;
        public string telefoneLeitor;
        public string nomeLeitor;
        public int codigoUsuario;
        public string enderecoUsuario;
        public string telefoneUsuario;
        public string nomeUsuario;
        public DateTime dataHoraEmprestimo;
        public int exemplar;
        //Constructor
        public FormSelecionarEmprestimo()
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
        //Evento Load que carrega os dados quando o formulário inicia.
        private void FormSelecionarLeitor_Load(object sender, EventArgs e)
        {
            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            emprestimoBindingSource.DataSource = emprestimoBLL.BuscarEmprestimoDevolucao(TextBoxBuscar.Text);
        }
        //Evento Click do button de buscar registros de empréstimos armazenados no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            emprestimoBindingSource.DataSource = emprestimoBLL.BuscarEmprestimoDevolucao(TextBoxBuscar.Text);
        }
        //Evento Click do button de selecionar um empréstimo.
        private void buttonSelecionar_Click_1(object sender, EventArgs e)
        {
            if (emprestimoBindingSource.Count == 0 || emprestimoBindingSource.Count == null)
                return;
            string Status = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["STATUS"]);
            if (Status == "Devolvido")
            {
                MessageBox.Show("Esse empréstimo já está devolvido!", "Sistema Biblioteca informa:",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
            codigo =  Convert.ToInt32(((DataRowView)emprestimoBindingSource.Current).Row["CODIGO"]);
            codigo = Convert.ToInt32(((DataRowView)emprestimoBindingSource.Current).Row["CODIGO"]);
            titulo = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["TITULO"]);
            codigoLivro = Convert.ToInt32(((DataRowView)emprestimoBindingSource.Current).Row["CODIGO_LIVRO"]);
            tombo = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["TOMBO"]);
            isbn = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["ISBN"]);
            volume = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["VOLUME"]);
            nomeLeitor = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["NOME_LEITOR"]);
            codigoLeitor = Convert.ToInt32(((DataRowView)emprestimoBindingSource.Current).Row["CODIGO_LEITOR"]);
            enderecoLeitor = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["ENDERECO_LEITOR"]);
            telefoneLeitor = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["TELEFONE_LEITOR"]);
            nomeUsuario = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["NOME_USUARIO"]);
            enderecoUsuario = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["ENDERECO_USUARIO"]);
            telefoneUsuario = Convert.ToString(((DataRowView)emprestimoBindingSource.Current).Row["TELEFONE_USUARIO"]);
            codigoUsuario = Convert.ToInt32(((DataRowView)emprestimoBindingSource.Current).Row["CODIGO_USUARIO"]);
            dataHoraEmprestimo = Convert.ToDateTime(((DataRowView)emprestimoBindingSource.Current).Row["DATA_HORA_EMPRESTIMO"]);
            exemplar = Convert.ToInt32(((DataRowView)emprestimoBindingSource.Current).Row["EXEMPLAR"]);

            Close();
            }
        }
        //Evento DoubleClick do datagridview de empréstimo, que permite o usuário selecionar um empréstimo com dois clicks no datagridview.
        private void emprestimoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonSelecionar_Click_1(null, null);
        }
        //Evento Click do button de cancelar, que permite o usuário encerrar a tela de pesquisa.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
