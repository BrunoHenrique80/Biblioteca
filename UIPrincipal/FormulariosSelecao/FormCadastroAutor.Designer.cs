namespace UIPrincipal.FormulariosSelecao
{
    partial class FormCadastroAutor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codigoLabel;
            System.Windows.Forms.Label nomeAutorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroAutor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.BindingSourceCadastroAutor = new System.Windows.Forms.BindingSource(this.components);
            this.nomeAutorTextBox = new System.Windows.Forms.TextBox();
            this.buttonSalvarEcadastrarNovo = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            codigoLabel = new System.Windows.Forms.Label();
            nomeAutorLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCadastroAutor)).BeginInit();
            this.SuspendLayout();
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codigoLabel.Location = new System.Drawing.Point(19, 39);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(66, 20);
            codigoLabel.TabIndex = 0;
            codigoLabel.Text = "Código:";
            // 
            // nomeAutorLabel
            // 
            nomeAutorLabel.AutoSize = true;
            nomeAutorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeAutorLabel.Location = new System.Drawing.Point(154, 39);
            nomeAutorLabel.Name = "nomeAutorLabel";
            nomeAutorLabel.Size = new System.Drawing.Size(103, 20);
            nomeAutorLabel.TabIndex = 2;
            nomeAutorLabel.Text = "Nome Autor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.codigoTextBox);
            this.groupBox1.Controls.Add(codigoLabel);
            this.groupBox1.Controls.Add(this.nomeAutorTextBox);
            this.groupBox1.Controls.Add(nomeAutorLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 295);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceCadastroAutor, "CODIGO", true));
            this.codigoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoTextBox.Location = new System.Drawing.Point(22, 62);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(130, 27);
            this.codigoTextBox.TabIndex = 1;
            // 
            // BindingSourceCadastroAutor
            // 
            this.BindingSourceCadastroAutor.DataSource = typeof(Model.Autor);
            // 
            // nomeAutorTextBox
            // 
            this.nomeAutorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nomeAutorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceCadastroAutor, "NOME_AUTOR", true));
            this.nomeAutorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeAutorTextBox.Location = new System.Drawing.Point(158, 62);
            this.nomeAutorTextBox.Name = "nomeAutorTextBox";
            this.nomeAutorTextBox.Size = new System.Drawing.Size(607, 27);
            this.nomeAutorTextBox.TabIndex = 3;
            // 
            // buttonSalvarEcadastrarNovo
            // 
            this.buttonSalvarEcadastrarNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalvarEcadastrarNovo.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSalvarEcadastrarNovo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonSalvarEcadastrarNovo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSalvarEcadastrarNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvarEcadastrarNovo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonSalvarEcadastrarNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvarEcadastrarNovo.Location = new System.Drawing.Point(128, 366);
            this.buttonSalvarEcadastrarNovo.Name = "buttonSalvarEcadastrarNovo";
            this.buttonSalvarEcadastrarNovo.Size = new System.Drawing.Size(122, 45);
            this.buttonSalvarEcadastrarNovo.TabIndex = 3;
            this.buttonSalvarEcadastrarNovo.Text = "Cancelar";
            this.buttonSalvarEcadastrarNovo.UseVisualStyleBackColor = false;
            this.buttonSalvarEcadastrarNovo.Click += new System.EventHandler(this.buttonSalvarEcadastrarNovo_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonSalvar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(21, 366);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(101, 45);
            this.buttonSalvar.TabIndex = 2;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // FormCadastroAutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 423);
            this.Controls.Add(this.buttonSalvarEcadastrarNovo);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(845, 462);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(845, 462);
            this.Name = "FormCadastroAutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Autor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCadastroAutor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.TextBox nomeAutorTextBox;
        private System.Windows.Forms.Button buttonSalvarEcadastrarNovo;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.BindingSource BindingSourceCadastroAutor;
    }
}