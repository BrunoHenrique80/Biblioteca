namespace UIPrincipal.FormulariosSelecao
{
    partial class FormCadastroCategoria
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
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label codigoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroCategoria));
            this.Dad = new System.Windows.Forms.GroupBox();
            this.descricaoCategoriaTextBox = new System.Windows.Forms.TextBox();
            this.BindingSourceCadastroCategoria = new System.Windows.Forms.BindingSource(this.components);
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.buttonSalvarEcadastrarNovo = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            nomeLabel = new System.Windows.Forms.Label();
            codigoLabel = new System.Windows.Forms.Label();
            this.Dad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCadastroCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeLabel.Location = new System.Drawing.Point(171, 45);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(58, 20);
            nomeLabel.TabIndex = 2;
            nomeLabel.Text = "Nome:";
            // 
            // codigoLabel
            // 
            codigoLabel.AutoSize = true;
            codigoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codigoLabel.Location = new System.Drawing.Point(13, 45);
            codigoLabel.Name = "codigoLabel";
            codigoLabel.Size = new System.Drawing.Size(66, 20);
            codigoLabel.TabIndex = 1;
            codigoLabel.Text = "Código:";
            // 
            // Dad
            // 
            this.Dad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dad.Controls.Add(this.descricaoCategoriaTextBox);
            this.Dad.Controls.Add(nomeLabel);
            this.Dad.Controls.Add(this.codigoTextBox);
            this.Dad.Controls.Add(codigoLabel);
            this.Dad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dad.Location = new System.Drawing.Point(22, 22);
            this.Dad.Name = "Dad";
            this.Dad.Size = new System.Drawing.Size(781, 293);
            this.Dad.TabIndex = 2;
            this.Dad.TabStop = false;
            this.Dad.Text = "Dados";
            // 
            // descricaoCategoriaTextBox
            // 
            this.descricaoCategoriaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descricaoCategoriaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceCadastroCategoria, "DESCRICAO_CATEGORIA", true));
            this.descricaoCategoriaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoCategoriaTextBox.Location = new System.Drawing.Point(172, 68);
            this.descricaoCategoriaTextBox.Name = "descricaoCategoriaTextBox";
            this.descricaoCategoriaTextBox.Size = new System.Drawing.Size(584, 27);
            this.descricaoCategoriaTextBox.TabIndex = 0;
            // 
            // BindingSourceCadastroCategoria
            // 
            this.BindingSourceCadastroCategoria.DataSource = typeof(Model.Categoria);
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.codigoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceCadastroCategoria, "CODIGO", true));
            this.codigoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoTextBox.Location = new System.Drawing.Point(16, 68);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.ReadOnly = true;
            this.codigoTextBox.Size = new System.Drawing.Size(150, 27);
            this.codigoTextBox.TabIndex = 2;
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
            this.buttonSalvarEcadastrarNovo.Location = new System.Drawing.Point(129, 366);
            this.buttonSalvarEcadastrarNovo.Name = "buttonSalvarEcadastrarNovo";
            this.buttonSalvarEcadastrarNovo.Size = new System.Drawing.Size(122, 45);
            this.buttonSalvarEcadastrarNovo.TabIndex = 1;
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
            this.buttonSalvar.Location = new System.Drawing.Point(22, 366);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(101, 45);
            this.buttonSalvar.TabIndex = 0;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // FormCadastroCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 423);
            this.Controls.Add(this.buttonSalvarEcadastrarNovo);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.Dad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(845, 462);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(845, 462);
            this.Name = "FormCadastroCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Categoria";
            this.Dad.ResumeLayout(false);
            this.Dad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCadastroCategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Dad;
        private System.Windows.Forms.TextBox descricaoCategoriaTextBox;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.Button buttonSalvarEcadastrarNovo;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.BindingSource BindingSourceCadastroCategoria;
    }
}