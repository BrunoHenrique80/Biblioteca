using BLL;
using DAL;
using Infra;
using Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormLivro : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        //Construtor 1
        public FormLivro()
        {
            InitializeComponent();
            livroCadastroBindingSource.AddNew();
            inserindoNovo = true;
            buttonBuscar.Enabled = false;
        }
        //Construtor 2
        public FormLivro(object _current)
        {
            InitializeComponent();
            livroCadastroBindingSource.DataSource = _current;
            inserindoNovo = false;
        }
        //Evento Load que carrega dados ao iniciar o formulário.
        private void FormLivro_Load(object sender, EventArgs e)
        {
            RetornarSituacao();
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && TextBoxBuscar.Focused)
            {
                buttonBuscar_Click_1(null, null);
                return true;
            }
            if (keyData == Keys.Enter && areaConhecimentoTextBox.Focused)
            {
                buttonSalvar_Click_1(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Metodo de inserir livro
        private void Inserir()
        {
            LivroBLL livroBLL = new LivroBLL();
            Livro livro = new Livro();

            livro.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            livro.TOMBO = tomboTextBox.Text;
            livro.CODIGO_SITUACAO = Convert.ToInt32(cmbSituacao.SelectedValue.ToString());
            livro.TITULO = tituloTextBox.Text;
            livro.CODIGO_AUTOR = Convert.ToInt32(TextBoxAutor.Tag);
            livro.CODIGO_CATEGORIA = Convert.ToInt32(TextBoxCategoria.Tag);
            livro.CODIGO_EDITORA = Convert.ToInt32(TextBoxEditora.Tag);
            livro.ANO = anoTextBox.Text;
            livro.DATA_CADASTRO = DateTime.Now;
            livro.CLASSIFICACAO = classificacaoTextBox.Text;
            livro.EXEMPLAR = Convert.ToInt32(exemplarTextBox.Text);
            livro.ISBN = isbnTextBox.Text;
            livro.ISSN = issnTextBox.Text;
            livro.MATERIAL = materialTextBox.Text;
            livro.VOLUME = volumeTextBox.Text;
            livro.LOCAL_PUBLICACAO = localPublicacaoTextBox.Text;
            livro.ASSUNTO = assuntoTextBox.Text;
            livro.AREA_CONHECIMENTO = areaConhecimentoTextBox.Text;

            if (inserindoNovo)
                livroBLL.Inserir(livro);
            else
                livroBLL.Alterar(livro);
            livroCadastroBindingSource.AddNew();
        }
        //Metodo que retorna as situações cadastradas no banco de dados.
        private void RetornarSituacao()
        {
            LivroDAL livro = new LivroDAL();

            cmbSituacao.Items.Clear();
            cmbSituacao.DataSource = Banco.dql(livro.vquerySituacao);
            cmbSituacao.DisplayMember = "DESCRICAO_SITUACAO";
            cmbSituacao.ValueMember = "CODIGO";
        }
        //Evento click do button de pesquisa de um registro de uma categoria. Que permite que o usuário acesse a tela de pesquisa de categoria.
        private void buttonPesquisaCategoria_Click(object sender, EventArgs e)
        {
            using (FormSelecionarCategoria frm = new FormSelecionarCategoria())
            {
                frm.ShowDialog();
                TextBoxCategoria.Tag = frm.codigo;
                TextBoxCategoria.Text = frm.descricaoCategoria;
            }
        }
        //Evento click do button de pesquisa de um registro de um autor. Que permite que o usuário acesse a tela de pesquisa de autor.
        private void buttonPesquisaAutor_Click(object sender, EventArgs e)
        {
            using (FormSelecionarAutor frm = new FormSelecionarAutor())
            {
                frm.ShowDialog();
                TextBoxAutor.Tag = frm.codigo;
                TextBoxAutor.Text = frm.nomeAutor;
            }
        }
        //Evento click do button de pesquisa de um registro de uma editora. Que permite que o usuário acesse a tela de pesquisa de editora.
        private void buttonPesquisaEditora_Click(object sender, EventArgs e)
        {
            using (FormSelecionarEditora frm = new FormSelecionarEditora())
            {
                frm.ShowDialog();
                TextBoxEditora.Tag = frm.codigo;
                TextBoxEditora.Text = frm.nome;
            }
        }
        //Evento click do button buscar livros cadastrados
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            LivroBLL livroBLL = new LivroBLL();
            livroBindingSource.DataSource = livroBLL.Buscar(TextBoxBuscar.Text);
            checkBoxMostrarTodos.Checked = false;
        }
        //Evento click do button novo livro.
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            inserindoNovo = true;
            livroCadastroBindingSource.AddNew();
            button2_Click(null, null);
        }
        //Evento click do button de editar um livro cadastrado
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (livroBindingSource.Count == 0 || livroBindingSource.Count == null)
                return;
            inserindoNovo = false;
            tabControl1.SelectedTab = tabPage2;
            LivroBLL livroBLL = new LivroBLL();
            livroCadastroBindingSource.DataSource = livroBLL.Buscar(((DataRowView)livroBindingSource.Current).Row["CODIGO"].ToString());//Buscando o livro por Id e passando os valores para o BindingSource.
            TextBoxAutor.Tag = (((DataRowView)livroBindingSource.Current).Row["CODIGO_AUTOR"].ToString());
            TextBoxAutor.Text = (((DataRowView)livroBindingSource.Current).Row["NOME_AUTOR"].ToString());
            TextBoxCategoria.Tag = (((DataRowView)livroBindingSource.Current).Row["CODIGO_CATEGORIA"].ToString());
            TextBoxCategoria.Text = (((DataRowView)livroBindingSource.Current).Row["DESCRICAO_CATEGORIA"].ToString());
            TextBoxEditora.Tag = (((DataRowView)livroBindingSource.Current).Row["CODIGO_EDITORA"].ToString());
            TextBoxEditora.Text = (((DataRowView)livroBindingSource.Current).Row["NOME"].ToString());
            tomboTextBox.Tag = (((DataRowView)livroBindingSource.Current).Row["TOMBO"].ToString());
            tomboTextBox.Text = (((DataRowView)livroBindingSource.Current).Row["TOMBO"].ToString());
        }
        //Evento click do button de excluir um livro cadastro.
        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            if (livroBindingSource.Count == 0 || livroBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            LivroBLL livroBLL = new LivroBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)livroBindingSource.Current).Row["CODIGO"]);
            livroBLL.Excluir(codigo);
            livroBindingSource.RemoveCurrent();
            LivroMensagens.Exluir(1);
        }
        //Evento click do button de sair.
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Evento click do button de salvar um novo livro.
        private void buttonSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                livroCadastroBindingSource.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    LivroMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                if (inserindoNovo == false)
                {
                    LivroMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                tituloTextBox.Focus();
            }
            buttonBuscar_Click_1(null, null);
        }
        private void buttonSalvarEcadastrarNovo_Click(object sender, EventArgs e)
        {
            limpaForm();
        }
        //Evento click do button de voltar para tela de consulta.
        private void buttonEncerrar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        //Metódo privado de limpar formulário de cadastro de um novo livro.
        private void limpaForm()
        {
            codigoTextBox.Clear();
            tomboTextBox.Clear();
            //cmbSituacao.Items.Clear();
            tituloTextBox.Clear();
            TextBoxAutor.Clear();
            TextBoxCategoria.Clear();
            TextBoxEditora.Clear();
            anoTextBox.Clear();
            //dataCadastroDateTimePicker
            classificacaoTextBox.Clear();
            exemplarTextBox.Clear();
            isbnTextBox.Clear();
            issnTextBox.Clear();
            materialTextBox.Clear();
            volumeTextBox.Clear();
            localPublicacaoTextBox.Clear();
            assuntoTextBox.Clear();
            areaConhecimentoTextBox.Clear();
        }
        //Evento DoubleClick do datagridview de consulta que permite que o usuário vizualize informações do livro com dois clicks no datagridview.
        private void livroDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click_1(null, null);
        }
        //Evento Click do CheckBox Mostrar todos, que permite o usuário vizualizar todos os livros armazenados no banco de dados.
        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            LivroBLL livroBLL = new LivroBLL();
            livroBindingSource.DataSource = livroBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }
        //Evento Click do TextBox buscar, que ativa o botão buscar e permite o usuário pesquisar com o filtro que desejar.
        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbPesquisaLivros.SelectedIndex == 0)
            {
                LivroBLL livroBLL = new LivroBLL();
                livroBindingSource.DataSource = livroBLL.BuscarLivroDisponivel(TextBoxBuscar.Text);
            }
            if (cmbPesquisaLivros.SelectedIndex == 1)
            {
                LivroBLL livroBLL = new LivroBLL();
                livroBindingSource.DataSource = livroBLL.BuscarLivroIndisponivel(TextBoxBuscar.Text);
            }
            if (cmbPesquisaLivros.SelectedIndex == 2)
            {
                LivroBLL livroBLL = new LivroBLL();
                livroBindingSource.DataSource = livroBLL.BuscarLivroExtraviado(TextBoxBuscar.Text);
            }
            checkBoxMostrarTodos.Checked = false;
            buttonBuscar.Enabled = false;
        }
        private void GeradorTombo()
        {
            Random numTomboAleatorio = new Random();
            int tomboGerado = numTomboAleatorio.Next(10000, 90000);
            tomboTextBox.Text = tomboGerado.ToString();
        }

        //                                       --------------------EVENTOS---------------------- 

        private void exemplarTextBox_TextChanged(object sender, EventArgs e)
        {
            if (tomboTextBox.Text == "")
                tomboTextBox.Text = "0";
        }

        private void exemplarTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inserindoNovo == true)
            {
            Random numTomboAleatorio = new Random();
            int tomboGerado = numTomboAleatorio.Next(10000, 90000);
            tomboTextBox.Text = tomboGerado.ToString();
            tomboTextBox.Tag = tomboGerado.ToString();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && inserindoNovo == true)
            {
                button2_Click(null, null);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
