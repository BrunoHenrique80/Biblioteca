using BLL;
using Infra;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormLogin : Form
    {
        //Atributos e propiedades.
        public bool Logou;
        public string nomeUsuario;
        public int codigoUsuario;
        public string endereco;
        public string telefone;
        //Constructor
        public FormLogin()
        {
            InitializeComponent();
            Logou = false;
        }
        //Dll importada que permite a movimentação do formulário de login.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //Metódo privado que permite a movimentação do formulário de login.
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        //Evento click do button de encerrar a tela de login.
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Evento click do button de login que permite o usuário entrar no sistema.
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                BindingSource usuarioBindingSource = new BindingSource();
                usuarioBindingSource.DataSource = usuarioBLL.Buscar(usuarioTextBox.Text);

                if (usuarioBindingSource.Count != 0)
                {
                    string userName = ((DataRowView)usuarioBindingSource.Current).Row["USERNAME"].ToString();
                    string senha = ((DataRowView)usuarioBindingSource.Current).Row["SENHA"].ToString();
                    string senhaCriptografada = AcaoCriptografarSenhaParaHash.Cript_md5(senhaTextBox.Text);

                    if (userName == usuarioTextBox.Text && senha == senhaTextBox.Text)
                    {
                        Logou = true;
                        nomeUsuario = ((DataRowView)usuarioBindingSource.Current).Row["NOME_USUARIO"].ToString();
                        codigoUsuario = Convert.ToInt32(((DataRowView)usuarioBindingSource.Current).Row["CODIGO"]);
                        endereco = ((DataRowView)usuarioBindingSource.Current).Row["ENDERECO"].ToString();
                        telefone = ((DataRowView)usuarioBindingSource.Current).Row["TELEFONE"].ToString();
                        Arquivo.GravarLog("O usuário logou no sistema.");
                        Close();
                    }
                    else
                    {
                        Arquivo.GravarLog("O usuário informou um nome de usuário ou senha incorreta.");
                        MessageBox.Show("Usuário ou senha incorreta!");
                        senhaTextBox.Text = "";
                        senhaTextBox.Focus();
                    }
                }
                else
                {
                    Arquivo.GravarLog("O usuário informou um nome de usuário ou senha incorreta.");
                    MessageBox.Show("Usuário ou senha incorreta!");
                    senhaTextBox.Text = "";
                    senhaTextBox.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Evento MouseDown que permite a movimentação da tela de login.
        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Evento load que carrega os dados do formulário de login.
        private void FormLogin_Load(object sender, EventArgs e)
        {
            Arquivo.GravarLog("A tela de login foi aberta");
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && senhaTextBox.Focused)
            {
                buttonLogin_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
