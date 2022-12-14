using BLL;
using Infra;
using Model;
using System;
using System.Windows.Forms;

namespace UIPrincipal.FormulariosSelecao
{
    public partial class FormCadastroCategoria : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        FormSelecionarCategoria formCategoria;
        public FormCadastroCategoria(FormSelecionarCategoria f)
        {
            InitializeComponent();
            BindingSourceCadastroCategoria.AddNew();
            inserindoNovo = true;
            formCategoria = f;
            descricaoCategoriaTextBox.Focus();
        }

        private void buttonSalvarEcadastrarNovo_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Metodo de inserir categoria
        private void Inserir()
        {
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            Categoria categoria = new Categoria();

            categoria.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            categoria.DESCRICAO_CATEGORIA = descricaoCategoriaTextBox.Text;

            if (inserindoNovo)
                categoriaBLL.Inserir(categoria);
            else
                categoriaBLL.Alterar(categoria);
            BindingSourceCadastroCategoria.AddNew();
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSourceCadastroCategoria.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    CategoriaMensagens.Inserir(1);
                    Close();
                }
                if (inserindoNovo == false)
                {
                    CategoriaMensagens.Alterar(1);
                    Close();
                }
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                descricaoCategoriaTextBox.Focus();
            }
            CategoriaBLL categoriaBLL = new CategoriaBLL();
            formCategoria.categoriaBindingSource.DataSource = categoriaBLL.Buscar(descricaoCategoriaTextBox.Text);
        }
    }
}
