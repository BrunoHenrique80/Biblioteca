using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormSelecionarCidade : Form
    {
        //Atributos e propiedades.
        public int codigo;
        public string descricaoCidade;
        public FormSelecionarCidade()
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
        //Evento Load que carrega os dados do formulário quando inicia.
        private void FormSelecionarCidadeUsuario_Load(object sender, EventArgs e)
        {
            CidadeBLL cidadeBLL = new CidadeBLL();
            cidadeBindingSource.DataSource = cidadeBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento click do button de busca de cidade por descrição e código.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            CidadeBLL cidadeBLL = new CidadeBLL();
            cidadeBindingSource.DataSource = cidadeBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento DoubleClick do datagridview cidade que seleciona uma cidade com click duplo.
        private void cidadeDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (cidadeBindingSource.Count == 0 || cidadeBindingSource.Count == null)
                return;
            codigo = Convert.ToInt32(((DataRowView)cidadeBindingSource.Current).Row["CODIGO"]);
            descricaoCidade = Convert.ToString(((DataRowView)cidadeBindingSource.Current).Row["DESCRICAO_CIDADE"]);// Pegando a descrição da cidade selecionada pelo datagridview cidade e setando no campo Text da propiedade cidadeTextBox.
            Close();
        }
        //Evento click do button de selecinar uma cidade.
        private void buttonSelecionar_Click_1(object sender, EventArgs e)
        {
            cidadeDataGridView_DoubleClick(null, null);
        }
        //Evento click do button de cancelar.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
