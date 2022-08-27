namespace UIPrincipal
{
    partial class FormSelecionarEmprestimo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelecionarEmprestimo));
            this.TextBoxBuscar = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSelecionar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.emprestimoDataGridView = new System.Windows.Forms.DataGridView();
            this.emprestimoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cODIGODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDERECO_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONE_LEITOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENDERECO_LEITOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VOLUME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOMBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tITULODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMELEITORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMEUSUARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATAHORAEMPRESTIMODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATAHORADEVOLUCAODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXEMPLARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.emprestimoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emprestimoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxBuscar
            // 
            this.TextBoxBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxBuscar.Location = new System.Drawing.Point(12, 30);
            this.TextBoxBuscar.Name = "TextBoxBuscar";
            this.TextBoxBuscar.Size = new System.Drawing.Size(681, 26);
            this.TextBoxBuscar.TabIndex = 0;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCancelar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancelar.Location = new System.Drawing.Point(150, 397);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(122, 45);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click_1);
            // 
            // buttonSelecionar
            // 
            this.buttonSelecionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelecionar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSelecionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSelecionar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelecionar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelecionar.Location = new System.Drawing.Point(12, 397);
            this.buttonSelecionar.Name = "buttonSelecionar";
            this.buttonSelecionar.Size = new System.Drawing.Size(132, 45);
            this.buttonSelecionar.TabIndex = 2;
            this.buttonSelecionar.Text = "Selecionar";
            this.buttonSelecionar.UseVisualStyleBackColor = false;
            this.buttonSelecionar.Click += new System.EventHandler(this.buttonSelecionar_Click_1);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBuscar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonBuscar.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonBuscar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.buttonBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBuscar.Location = new System.Drawing.Point(699, 28);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(110, 30);
            this.buttonBuscar.TabIndex = 1;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = false;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click_1);
            // 
            // emprestimoDataGridView
            // 
            this.emprestimoDataGridView.AllowUserToAddRows = false;
            this.emprestimoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emprestimoDataGridView.AutoGenerateColumns = false;
            this.emprestimoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.emprestimoDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.emprestimoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.emprestimoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.emprestimoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emprestimoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODIGODataGridViewTextBoxColumn,
            this.ENDERECO_USUARIO,
            this.TELEFONE_LEITOR,
            this.ENDERECO_LEITOR,
            this.VOLUME,
            this.ISBN,
            this.TOMBO,
            this.tITULODataGridViewTextBoxColumn,
            this.nOMELEITORDataGridViewTextBoxColumn,
            this.nOMEUSUARIODataGridViewTextBoxColumn,
            this.dATAHORAEMPRESTIMODataGridViewTextBoxColumn,
            this.dATAHORADEVOLUCAODataGridViewTextBoxColumn,
            this.eXEMPLARDataGridViewTextBoxColumn,
            this.sTATUSDataGridViewTextBoxColumn});
            this.emprestimoDataGridView.DataSource = this.emprestimoBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.emprestimoDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.emprestimoDataGridView.Location = new System.Drawing.Point(12, 76);
            this.emprestimoDataGridView.Name = "emprestimoDataGridView";
            this.emprestimoDataGridView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.emprestimoDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.emprestimoDataGridView.RowHeadersVisible = false;
            this.emprestimoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.emprestimoDataGridView.Size = new System.Drawing.Size(797, 294);
            this.emprestimoDataGridView.TabIndex = 47;
            this.emprestimoDataGridView.DoubleClick += new System.EventHandler(this.emprestimoDataGridView_DoubleClick);
            // 
            // emprestimoBindingSource
            // 
            this.emprestimoBindingSource.DataSource = typeof(Model.Emprestimo);
            // 
            // cODIGODataGridViewTextBoxColumn
            // 
            this.cODIGODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cODIGODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cODIGODataGridViewTextBoxColumn.HeaderText = "Código";
            this.cODIGODataGridViewTextBoxColumn.Name = "cODIGODataGridViewTextBoxColumn";
            this.cODIGODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ENDERECO_USUARIO
            // 
            this.ENDERECO_USUARIO.DataPropertyName = "ENDERECO_USUARIO";
            this.ENDERECO_USUARIO.HeaderText = "ENDERECO_USUARIO";
            this.ENDERECO_USUARIO.Name = "ENDERECO_USUARIO";
            this.ENDERECO_USUARIO.ReadOnly = true;
            this.ENDERECO_USUARIO.Visible = false;
            // 
            // TELEFONE_LEITOR
            // 
            this.TELEFONE_LEITOR.DataPropertyName = "TELEFONE_LEITOR";
            this.TELEFONE_LEITOR.HeaderText = "TELEFONE_LEITOR";
            this.TELEFONE_LEITOR.Name = "TELEFONE_LEITOR";
            this.TELEFONE_LEITOR.ReadOnly = true;
            this.TELEFONE_LEITOR.Visible = false;
            // 
            // ENDERECO_LEITOR
            // 
            this.ENDERECO_LEITOR.DataPropertyName = "ENDERECO_LEITOR";
            this.ENDERECO_LEITOR.HeaderText = "ENDERECO_LEITOR";
            this.ENDERECO_LEITOR.Name = "ENDERECO_LEITOR";
            this.ENDERECO_LEITOR.ReadOnly = true;
            this.ENDERECO_LEITOR.Visible = false;
            // 
            // VOLUME
            // 
            this.VOLUME.DataPropertyName = "VOLUME";
            this.VOLUME.HeaderText = "VOLUME";
            this.VOLUME.Name = "VOLUME";
            this.VOLUME.ReadOnly = true;
            this.VOLUME.Visible = false;
            // 
            // ISBN
            // 
            this.ISBN.DataPropertyName = "ISBN";
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.Name = "ISBN";
            this.ISBN.ReadOnly = true;
            this.ISBN.Visible = false;
            // 
            // TOMBO
            // 
            this.TOMBO.DataPropertyName = "TOMBO";
            this.TOMBO.HeaderText = "TOMBO";
            this.TOMBO.Name = "TOMBO";
            this.TOMBO.ReadOnly = true;
            this.TOMBO.Visible = false;
            // 
            // tITULODataGridViewTextBoxColumn
            // 
            this.tITULODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tITULODataGridViewTextBoxColumn.DataPropertyName = "TITULO";
            this.tITULODataGridViewTextBoxColumn.HeaderText = "Título";
            this.tITULODataGridViewTextBoxColumn.Name = "tITULODataGridViewTextBoxColumn";
            this.tITULODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOMELEITORDataGridViewTextBoxColumn
            // 
            this.nOMELEITORDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nOMELEITORDataGridViewTextBoxColumn.DataPropertyName = "NOME_LEITOR";
            this.nOMELEITORDataGridViewTextBoxColumn.HeaderText = "Leitor";
            this.nOMELEITORDataGridViewTextBoxColumn.Name = "nOMELEITORDataGridViewTextBoxColumn";
            this.nOMELEITORDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOMEUSUARIODataGridViewTextBoxColumn
            // 
            this.nOMEUSUARIODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nOMEUSUARIODataGridViewTextBoxColumn.DataPropertyName = "NOME_USUARIO";
            this.nOMEUSUARIODataGridViewTextBoxColumn.HeaderText = "Usuário";
            this.nOMEUSUARIODataGridViewTextBoxColumn.Name = "nOMEUSUARIODataGridViewTextBoxColumn";
            this.nOMEUSUARIODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dATAHORAEMPRESTIMODataGridViewTextBoxColumn
            // 
            this.dATAHORAEMPRESTIMODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dATAHORAEMPRESTIMODataGridViewTextBoxColumn.DataPropertyName = "DATA_HORA_EMPRESTIMO";
            this.dATAHORAEMPRESTIMODataGridViewTextBoxColumn.HeaderText = "Data Empréstimo";
            this.dATAHORAEMPRESTIMODataGridViewTextBoxColumn.Name = "dATAHORAEMPRESTIMODataGridViewTextBoxColumn";
            this.dATAHORAEMPRESTIMODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dATAHORADEVOLUCAODataGridViewTextBoxColumn
            // 
            this.dATAHORADEVOLUCAODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dATAHORADEVOLUCAODataGridViewTextBoxColumn.DataPropertyName = "DATA_HORA_DEVOLUCAO";
            this.dATAHORADEVOLUCAODataGridViewTextBoxColumn.HeaderText = "Data Devolução";
            this.dATAHORADEVOLUCAODataGridViewTextBoxColumn.Name = "dATAHORADEVOLUCAODataGridViewTextBoxColumn";
            this.dATAHORADEVOLUCAODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eXEMPLARDataGridViewTextBoxColumn
            // 
            this.eXEMPLARDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.eXEMPLARDataGridViewTextBoxColumn.DataPropertyName = "EXEMPLAR";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.eXEMPLARDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.eXEMPLARDataGridViewTextBoxColumn.HeaderText = "Exemplar";
            this.eXEMPLARDataGridViewTextBoxColumn.Name = "eXEMPLARDataGridViewTextBoxColumn";
            this.eXEMPLARDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sTATUSDataGridViewTextBoxColumn
            // 
            this.sTATUSDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sTATUSDataGridViewTextBoxColumn.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.HeaderText = "Status";
            this.sTATUSDataGridViewTextBoxColumn.Name = "sTATUSDataGridViewTextBoxColumn";
            this.sTATUSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormSelecionarEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(829, 454);
            this.Controls.Add(this.emprestimoDataGridView);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSelecionar);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.TextBoxBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(845, 493);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(845, 493);
            this.Name = "FormSelecionarEmprestimo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Empréstimo";
            this.Load += new System.EventHandler(this.FormSelecionarLeitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.emprestimoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emprestimoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxBuscar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSelecionar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView emprestimoDataGridView;
        private System.Windows.Forms.BindingSource emprestimoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODIGODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDERECO_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONE_LEITOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENDERECO_LEITOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn VOLUME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOMBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn tITULODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMELEITORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMEUSUARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATAHORAEMPRESTIMODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATAHORADEVOLUCAODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXEMPLARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSDataGridViewTextBoxColumn;
    }
}