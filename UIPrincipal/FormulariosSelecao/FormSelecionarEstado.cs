using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormSelecionarEstado : Form
    {
        //Atributos e propiedades.
        public int codigo;
        public string descricaoEstado;
        //Constructor
        public FormSelecionarEstado()
        {
            InitializeComponent();
        }
        //Evento Load que carrega os dados quando o formulário inicia.
        private void FormSelecionarEstado_Load(object sender, EventArgs e)
        {
            EstadoBLL estadoBLL = new EstadoBLL();
            estadoBindingSource.DataSource = estadoBLL.Buscar(TextBoxBuscar.Text);
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
        //Evento Click do button de buscar registros de estados armazenados no banco de dados.
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            EstadoBLL estadoBLL = new EstadoBLL();
            estadoBindingSource.DataSource = estadoBLL.Buscar(TextBoxBuscar.Text);
        }
        //Evento DoubleClick do datagridview de estado, que permite o usuário selecione um estado com dois clicks no datagridview.
        private void estadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (estadoBindingSource.Count == 0 || estadoBindingSource.Count == null)
                return;
            codigo = Convert.ToInt32(((DataRowView)estadoBindingSource.Current).Row["CODIGO"]);
            descricaoEstado = Convert.ToString(((DataRowView)estadoBindingSource.Current).Row["DESCRICAO_ESTADO"]);
            Close();
        }
        //Evento Click do button de selecinar um estado.
        private void buttonSelecionar_Click_1(object sender, EventArgs e)
        {
            estadoDataGridView_DoubleClick(null, null);
        }
        //Evento Click do button de cancelar, que permite o usuário encerrar a tela de pesquisa.
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

    }
}
