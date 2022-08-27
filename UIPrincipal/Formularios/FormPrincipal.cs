using DAL;
using Infra;
using System;
using System.Windows.Forms;
using UIPrincipal.Formularios;

namespace UIPrincipal
{
    public partial class FormPrincipal : Form
    {
        //Constructor
        public int codigo;
        public string nome;
        public string endereco;
        public string telefone;
        public FormPrincipal()
        {
            InitializeComponent();
        }
        //Metódo de abrir formulários.
        public void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        //Evento click da aba de Livro que abre o formulário de gestão de livros.
        private void livroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormLivro());
        }
        //Evento click da aba de Autor que abre o formulário de gestão de autores.
        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormAutor());
        }
        //Evento click da aba de Editora que abre o formulário de gestão de editoras.
        private void editoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormEditora());
        }
        //Evento click da aba de Empréstimos que abre o formulário de gestão de empréstimos.
        private void empréstimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormEmprestimo(this));
        }
        //Evento click da aba de Usuário que abre o formulário de gestão de usuários.
        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codigo == 1)
            {
                AbrirFormEnPanel(new FormUsuario());
            }
            else
                UsuarioMensagens.Acesso(1);
        }
        //Evento click da aba de Leitor que abre o formulário de gestão de leitores.
        private void leitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormLeitor());
        }
        //Evento Tick que exibe a data e hora na tela principal do sistema.
        //Evento click da aba de Devolução que abre o formulário de gestão de devoluções.
        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDevolucao());
        }
        //Evento click da aba de Categoria que abre o formulário de gestão de categorias.
        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormCategoria());
        }
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormSobre());
        }
        //Evento click da aba de logout que encerra o sistema e abre a tela de login.
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            lb_nomeUsuario.Text = "---";
            Login();
            this.Visible = !this.Visible;
        }
        //Método de verificação se o usuário teve acesso e conseguiu realizar o login no sistema.
        private bool Login()
        {
            using (FormLogin frm = new FormLogin())
            {
                frm.ShowDialog();
                lb_nomeUsuario.Text = frm.nomeUsuario;
                codigo = frm.codigoUsuario;
                nome = frm.nomeUsuario;
                endereco = frm.endereco;
                telefone = frm.telefone;
                return frm.Logou;
                //Application.Exit();
            }
        }

        //Evento de FormClosing que confirma se o usuário deseja encerrar o programa.
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja realmente encerrar o programa?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
            if (Login())
                this.Visible = !this.Visible;
            else
                Application.Exit();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDashboard());
        }
    }
}
