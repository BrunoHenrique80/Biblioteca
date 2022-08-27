using BLL;
using DAL;
using Infra;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace UIPrincipal
{
    public partial class FormEmprestimo : Form
    {
        //Atributos e propiedades
        private bool inserindoNovo;
        public int codigoUsuario;
        FormPrincipal form;
        string enderecoUsuario;
        string telefoneUsuario;
        //Construtor 1
        public FormEmprestimo(FormPrincipal f)
        {
            InitializeComponent();
            emprestimoCadastroBindingSource.AddNew();
            inserindoNovo = true;
            buttonBuscar.Enabled = false;
            dataHoraDevolucaoDateTimePicker.Value = DateTime.Today.AddDays(+6);
            exemplarTextBox.Text = "1";
            form = f;
        }
        //Construtor 2
        public FormEmprestimo(object _current)
        {
            InitializeComponent();
            emprestimoCadastroBindingSource.DataSource = _current;
            inserindoNovo = false;
        }
        //Método processCmdKey.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && TextBoxBuscar.Focused)
            {
                buttonBuscar_Click_1(null, null);
                return true;
            }
            if (keyData == Keys.Enter && exemplarTextBox.Focused)
            {
                button7_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        //Evento click do button novo emprestimo.
        private void buttonNovo_Click_1(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPage2;
                inserindoNovo = true;
                emprestimoCadastroBindingSource.AddNew();
                button7.Enabled = true;
                SetUsuario();
                LimpaForm();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Evento click do button de editar um emprestimo cadastrado.
        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (emprestimoBindingSource.Count == 0 || emprestimoBindingSource.Count == null)
                return;
            tabControl1.SelectedTab = tabPage2;
            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            emprestimoCadastroBindingSource.DataSource = emprestimoBLL.Buscar(((DataRowView)emprestimoBindingSource.Current).Row["CODIGO"].ToString());//Buscando o emprestimo por Id e passando os valores para o BindingSource.
            TextBoxLeitor.Tag = (((DataRowView)emprestimoBindingSource.Current).Row["CODIGO_LEITOR"].ToString());
            TextBoxLeitor.Text = (((DataRowView)emprestimoBindingSource.Current).Row["NOME_LEITOR"].ToString());
            TextBoxLivro.Tag = (((DataRowView)emprestimoBindingSource.Current).Row["CODIGO_LIVRO"].ToString());
            TextBoxLivro.Text = (((DataRowView)emprestimoBindingSource.Current).Row["TITULO"].ToString());
            textBoxTombo.Tag = (((DataRowView)emprestimoBindingSource.Current).Row["TOMBO"].ToString());
            textBoxTombo.Text = (((DataRowView)emprestimoBindingSource.Current).Row["TOMBO"].ToString());
            textBoxISBN.Tag = (((DataRowView)emprestimoBindingSource.Current).Row["ISBN"].ToString());
            textBoxISBN.Text = (((DataRowView)emprestimoBindingSource.Current).Row["ISBN"].ToString());
            textBoxVolume.Tag = (((DataRowView)emprestimoBindingSource.Current).Row["VOLUME"].ToString());
            textBoxVolume.Text = (((DataRowView)emprestimoBindingSource.Current).Row["VOLUME"].ToString());
            textBoxEnderecoLeitor.Tag = (((DataRowView)emprestimoBindingSource.Current).Row["ENDERECO_LEITOR"].ToString());
            textBoxEnderecoLeitor.Text = (((DataRowView)emprestimoBindingSource.Current).Row["ENDERECO_LEITOR"].ToString());
            textBoxTelefoneLeitor.Tag = (((DataRowView)emprestimoBindingSource.Current).Row["TELEFONE_LEITOR"].ToString());
            textBoxTelefoneLeitor.Text = (((DataRowView)emprestimoBindingSource.Current).Row["TELEFONE_LEITOR"].ToString());
            exemplarTextBox.Text = (((DataRowView)emprestimoBindingSource.Current).Row["EXEMPLAR"].ToString());
            inserindoNovo = false;
            button7.Enabled = false;
        }
        //Evento click do button de excluir um emprestimo cadastrado.
        private void buttonExcluir_Click_1(object sender, EventArgs e)
        {
            if (emprestimoBindingSource.Count == 0 || emprestimoBindingSource.Count == null)
                return;

            if (MessageBox.Show("Deseja realmente excluir este registro?", "Sistema Biblioteca informa:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            int codigo;
            codigo = Convert.ToInt32(((DataRowView)emprestimoBindingSource.Current).Row["CODIGO"]);
            emprestimoBLL.Excluir(codigo);
            emprestimoBindingSource.RemoveCurrent();
            EmprestimoMensagens.Exluir(1);
        }
        //Evento click do button de sair.
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Evento click do button buscar emprestimos cadastrados
        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            emprestimoBindingSource.DataSource = emprestimoBLL.Buscar(TextBoxBuscar.Text);
            comboBox2.SelectedText = "Tipo de Pesquisa por Status";
            checkBoxMostrarTodos.Checked = false;

        }
        private void SetUsuario()
        {
            enderecoUsuario = form.endereco;
            telefoneUsuario = form.telefone;
        }
        private void buttonSalvarEcadastrarNovo_Click_1(object sender, EventArgs e)
        {
        }
        //Evento DoubleClick do datagridview de consulta que permite que o usuário vizualize informações do empréstimo com dois clicks no datagridview.
        private void emprestimoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            buttonEditar_Click_1(null, null);
        }
        //Evento click do button de salvar um novo emprestimo no banco dados.
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                emprestimoCadastroBindingSource.EndEdit();

                EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
                Emprestimo emprestimo = new Emprestimo();

                emprestimo.CODIGO = Convert.ToInt32(codigoTextBox.Text);
                emprestimo.CODIGO_LIVRO = Convert.ToInt32(TextBoxLivro.Tag);
                emprestimo.TOMBO = textBoxTombo.Text;
                emprestimo.ISBN = textBoxISBN.Text;
                emprestimo.VOLUME = textBoxVolume.Text;
                emprestimo.CODIGO_LEITOR = Convert.ToInt32(TextBoxLeitor.Tag);
                emprestimo.ENDERECO_LEITOR = textBoxEnderecoLeitor.Text;
                emprestimo.TELEFONE_LEITOR = textBoxTelefoneLeitor.Text;
                emprestimo.CODIGO_USUARIO = form.codigo;
                emprestimo.ENDERECO_USUARIO = enderecoUsuario;
                emprestimo.TELEFONE_USUARIO = telefoneUsuario;
                emprestimo.EXEMPLAR = 1;
                emprestimo.DATA_HORA_EMPRESTIMO = DateTime.Now;
                if (EhDiaUtil(DateTime.Today.AddDays(+9)) != true)
                {
                    emprestimo.DATA_HORA_DEVOLUCAO = DateTime.Today.AddDays(+10);
                }
                else
                    emprestimo.DATA_HORA_DEVOLUCAO = DateTime.Today.AddDays(+6);
                emprestimo.STATUS = "Pendente";

                if (inserindoNovo == true)
                {
                    emprestimoBLL.Inserir(emprestimo);
                    EmprestimoMensagens.Inserir(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                if (inserindoNovo == false)
                {
                    emprestimoBLL.Alterar(emprestimo);
                    EmprestimoMensagens.Alterar(1);
                    tabControl1.SelectedTab = tabPage1;
                }
                emprestimoCadastroBindingSource.AddNew();
            }
            catch (Exception ex)
            {
                Mensagens.Afirmacao(3, ex.Message);
                exemplarTextBox.Focus();
            }
            buttonBuscar_Click_1(null, null);
        }
        public bool EhDiaUtil(DateTime data)
        {
            return !DiasUteis.EhFinalDeSemana(data);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            inserindoNovo = true;
            LimpaForm();
        }
        //Evento click do button de voltar para tela de consulta.
        private void button5_Click(object sender, EventArgs e)
        {
            inserindoNovo = true;
            tabControl1.SelectedTab = tabPage1;
            LimpaForm();
        }
        //Evento Click do button de pesquisar um registro de um livro. Que permite que o usuário acesse a tela de pesquisa de livro.
        private void button4_Click(object sender, EventArgs e)
        {
            using (FormSelecionarLivro frm = new FormSelecionarLivro())
            {
                frm.ShowDialog();
                if (frm.codigo > 0)
                {
                    TextBoxLivro.Tag = frm.codigo;
                    TextBoxLivro.Text = frm.titulo;
                    textBoxTombo.Text = frm.tombo;
                    textBoxISBN.Text = frm.isbn;
                    textBoxVolume.Text = frm.volume;
                }
            }
        }
        //Evento Click do button de pesquisar um resgistro de um leitor. Que permite que o usuário acesse a tela de pesquisa de leitor.
        private void button2_Click(object sender, EventArgs e)
        {
            using (FormSelecionarLeitor frm = new FormSelecionarLeitor())
            {
                frm.ShowDialog();
                if (frm.codigo > 0)
                {
                    TextBoxLeitor.Tag = frm.codigo;
                    TextBoxLeitor.Text = frm.nomeLeitor;
                    textBoxEnderecoLeitor.Text = frm.endereco;
                    textBoxTelefoneLeitor.Text = frm.telefone;
                }
            }
        }
        //Evento Click do CheckBox Mostrar todos, que permite o usuário vizualizar todos os empréstimos armazenados no banco de dados.
        private void checkBoxMostrarTodos_Click(object sender, EventArgs e)
        {
            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            emprestimoBindingSource.DataSource = emprestimoBLL.Buscar(TextBoxBuscar.Text);
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }
        //Evento SelectionChangeCommitted do combobox, que permite o usuário selecionar um tipo de pesquisa referente ao status dos empréstimos armazenados no banco de dados.
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
                emprestimoBindingSource.DataSource = emprestimoBLL.BuscarEmprestimoPendente(TextBoxBuscar.Text);
            }
            if (comboBox2.SelectedIndex == 1)
            {
                EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
                emprestimoBindingSource.DataSource = emprestimoBLL.BuscarEmprestimoDevolvido(TextBoxBuscar.Text);
            }
            if (comboBox2.SelectedIndex == 2)
            {
                EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
                emprestimoBindingSource.DataSource = emprestimoBLL.BuscarEmprestimoAtrasado(TextBoxBuscar.Text);
            }
            checkBoxMostrarTodos.Checked = false;
            buttonBuscar.Enabled = false;
        }
        //Evento Click do TextBoxBuscar, que ativa o botão de buscar e permite o usuário buscar empréstimos armazenados no banco de dados de acordo com o filtro de que ele desejar.
        private void TextBoxBuscar_Click(object sender, EventArgs e)
        {
            buttonBuscar.Enabled = true;
        }
        //Evento Click do button de buscar empréstimos armazenados no banco de dados por data inicial e final.
        private void buttonBuscarPorData_Click(object sender, EventArgs e)
        {
            EmprestimoBLL emprestimoBLL = new EmprestimoBLL();
            emprestimoBindingSource.DataSource = emprestimoBLL.BuscarEmprestimoPorData(dateTimePickerFromDate.Value, dateTimePickerToDate.Value);
            checkBoxMostrarTodos.Checked = false;
            TextBoxBuscar.Clear();
            buttonBuscar.Enabled = false;
        }

        private void exemplarTextBox_TextChanged(object sender, EventArgs e)
        {
            if (exemplarTextBox.Text == "")
                exemplarTextBox.Text = "0";
        }

        private void exemplarTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
                e.Handled = true;
        }
        private void buttonImprimirComprovante_Click_1(object sender, EventArgs e)
        {
            if (TextBoxLivro.Text == "")
                return;
            if (TextBoxLeitor.Text == "")
                return;

            string nomeArquivo = Globais.caminho + @"\comprovante.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A5);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            Image logo = Image.GetInstance(Globais.caminho + @"\logoSenai.png");
            logo.ScaleToFit(140f, 120f);
            logo.Alignment = Element.ALIGN_CENTER;
            //logo.SetAbsolutePosition(100f, 700f);

            doc.Open();
            string dados = "";
            Paragraph paragrafo = new Paragraph(dados, new Font(iTextSharp.text.Font.NORMAL, 18, (int)System.Drawing.FontStyle.Bold));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("Sistema Biblioteca\n");

            paragrafo.Font = new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("Comprovante de Empréstimo\n\n");

            Paragraph paragrafo1 = new Paragraph(dados, new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));
            paragrafo1.Font = new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);
            paragrafo1.Alignment = Element.ALIGN_LEFT;
            paragrafo1.Add("Informações do Empréstimo:" +
                          "\nData do Empréstimo: " + dateTimePicker.Value +
                          "\nData da Devolução: " + dataHoraDevolucaoDateTimePicker.Value +
                          "\nNº de Exemplar: " + exemplarTextBox.Text);

            Paragraph paragrafo2 = new Paragraph(dados, new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));
            paragrafo2.Font = new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);
            paragrafo2.Alignment = Element.ALIGN_LEFT;
            paragrafo2.Add("\nInformações do Livro:" +
                          "\nTítulo: " + TextBoxLivro.Text +
                          "\nTombo: " + textBoxTombo.Text +
                          "\nISBN: " + textBoxISBN.Text +
                          "\nVolume: " + textBoxVolume.Text);

            Paragraph paragrafo3 = new Paragraph(dados, new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));
            paragrafo3.Font = new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);
            paragrafo3.Alignment = Element.ALIGN_LEFT;
            paragrafo3.Add("\nInformações do Leitor:" +
                          "\nNome: " + TextBoxLeitor.Text +
                          "\nEndereço: " + textBoxEnderecoLeitor.Text +
                          "\nTelefone: " + textBoxTelefoneLeitor.Text);

            Paragraph paragrafo4 = new Paragraph(dados, new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));
            paragrafo4.Font = new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);
            paragrafo4.Alignment = Element.ALIGN_LEFT;
            paragrafo4.Add("\nAssinatura do Leitor: _________________________________________");

            Paragraph paragrafo5 = new Paragraph(dados, new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));
            paragrafo5.Font = new Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Regular);
            paragrafo5.Alignment = Element.ALIGN_LEFT;
            paragrafo5.Add("Assinatura da Bibliotecária: _________________________________________");

            doc.Open();
            doc.Add(logo);
            doc.Add(paragrafo);
            doc.Add(paragrafo1);
            doc.Add(paragrafo2);
            doc.Add(paragrafo3);
            doc.Add(paragrafo4);
            doc.Add(paragrafo5);
            doc.Close();

            System.Diagnostics.Process.Start(Globais.caminho + @"\comprovante.pdf");
        }
        private void LimpaForm()
        {
            codigoTextBox.Text = "0";
            TextBoxLeitor.Clear();
            TextBoxLivro.Clear();
            textBoxTombo.Clear();
            textBoxISBN.Clear();
            textBoxVolume.Clear();
            textBoxEnderecoLeitor.Clear();
            textBoxTelefoneLeitor.Clear();
            exemplarTextBox.Text = "1";
            dataHoraDevolucaoDateTimePicker.Value = DateTime.Today.AddDays(+6);
            dateTimePicker.Value = DateTime.Now;
        }
    }
}
