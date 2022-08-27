using BLL;
using Infra;
using Model;
using System;
using System.Windows.Forms;

namespace UIPrincipal.FormulariosSelecao
{
    public partial class FormCadastroAutor : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        FormSelecionarAutor FormAutor;
        public FormCadastroAutor(FormSelecionarAutor f)
        {
            InitializeComponent();
            BindingSourceCadastroAutor.AddNew();
            inserindoNovo = true;
            FormAutor = f;
            nomeAutorTextBox.Focus();
        }

        private void buttonSalvarEcadastrarNovo_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Metodo de inserir autor
        private void Inserir()
        {
            AutorBLL autorBLL = new AutorBLL();
            Autor autor = new Autor();

            autor.CODIGO = Convert.ToInt32(codigoTextBox.Text);
            autor.NOME_AUTOR = nomeAutorTextBox.Text;

            if (inserindoNovo)
                autorBLL.Inserir(autor);
            else
                autorBLL.Alterar(autor);
            BindingSourceCadastroAutor.AddNew();
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSourceCadastroAutor.EndEdit();
                Inserir();
                if (inserindoNovo == true)
                {
                    AutorMensagens.Inserir(1);
                    Close();
                }
                if (inserindoNovo == false)
                {
                    AutorMensagens.Alterar(1);
                    Close();
                }
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                nomeAutorTextBox.Focus();
            }
            AutorBLL autorBLL = new AutorBLL();
            FormAutor.autorBindingSource.DataSource = autorBLL.Buscar(nomeAutorTextBox.Text);
        }
    }
}
