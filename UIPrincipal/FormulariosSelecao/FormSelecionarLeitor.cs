using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using UIPrincipal.FormulariosSelecao;

namespace UIPrincipal
{
    public partial class FormSelecionarLeitor : Form
    {
        //Atributos e propiedades.
        public int codigo;
        public string nomeLeitor;
        public string endereco;
        public string telefone;
        //Constructor
        public FormSelecionarLeitor()
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
            LeitorBLL livroBLL = new LeitorBLL();
            leitorBindingSource.DataSource = livroBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento Click do button de buscar registros de leitores armazenados no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            LeitorBLL livroBLL = new LeitorBLL();
            leitorBindingSource.DataSource = livroBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento DoubleClick do datagridview de leitor, que permite o usuário selecionar um leitor com dois clicks no datagridview.
        private void leitorDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (leitorBindingSource.Count == 0 || leitorBindingSource.Count == null)
                return;
            codigo = Convert.ToInt32(((DataRowView)leitorBindingSource.Current).Row["CODIGO"]);
            nomeLeitor = Convert.ToString(((DataRowView)leitorBindingSource.Current).Row["NOME_LEITOR"]);
            endereco = Convert.ToString(((DataRowView)leitorBindingSource.Current).Row["ENDERECO"]);
            telefone = Convert.ToString(((DataRowView)leitorBindingSource.Current).Row["TELEFONE"]);
            Close();
        }
        //Evento Click do button de selecionar um leitor.
        private void buttonSelecionar_Click_1(object sender, EventArgs e)
        {
            leitorDataGridView_DoubleClick(null, null);
        }
        //Evento Click do button de cancelar, que permite o usuário encerrar a tela de pesquisa.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FormCadastroLeitor frm = new FormCadastroLeitor(this))
            {
                frm.ShowDialog();
            }
        }
    }
}
