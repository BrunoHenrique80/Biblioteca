using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using UIPrincipal.FormulariosSelecao;

namespace UIPrincipal
{
    public partial class FormSelecionarLivro : Form
    {
        //Atributos e propiedades.
        private int situacao;
        public int codigo;
        public string titulo;
        public string tombo;
        public string isbn;
        public string volume;
        //Constructor
        public FormSelecionarLivro()
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
        private void FormSelecionarLivro_Load(object sender, EventArgs e)
        {
            LivroBLL livroBLL = new LivroBLL();
            livroBindingSource.DataSource = livroBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento Click do button de buscar registros armazenados no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            LivroBLL livroBLL = new LivroBLL();
            livroBindingSource.DataSource = livroBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento DoubleClick do datagridview de livro, que permite o usuário selecionar um livro com dois clicks no datagridview.
        private void livroDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (livroBindingSource.Count == 0 || livroBindingSource.Count == null)
                return;
            try
            {
                situacao = Convert.ToInt32(((DataRowView)livroBindingSource.Current).Row["CODIGO_SITUACAO"].ToString());
                if (situacao == 2)
                {
                    MessageBox.Show("Livro está indisponível no momento!", "Sistema Biblioteca informa:",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (situacao == 3)
                {
                    MessageBox.Show("Livro está extraviado no momento!", "Sistema Biblioteca informa:",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    titulo = Convert.ToString(((DataRowView)livroBindingSource.Current).Row["TITULO"]);
                    codigo = Convert.ToInt32(((DataRowView)livroBindingSource.Current).Row["CODIGO"]);
                    tombo = Convert.ToString(((DataRowView)livroBindingSource.Current).Row["TOMBO"]);
                    isbn = Convert.ToString(((DataRowView)livroBindingSource.Current).Row["ISBN"]);
                    volume = Convert.ToString(((DataRowView)livroBindingSource.Current).Row["VOLUME"]);
                    Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Evento Click do button de selecionar um livro.
        private void buttonSelecionar_Click_1(object sender, EventArgs e)
        {
            livroDataGridView_DoubleClick(null, null);
        }
        //Evento Click do button de cancelar, que permite o usuário encerrar a tela de pesquisa.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (FormCadastroLivro frm = new FormCadastroLivro(this))
            {
                frm.ShowDialog();
            }
        }
    }
}
