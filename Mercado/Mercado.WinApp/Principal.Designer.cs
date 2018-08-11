namespace Mercado.WinApp
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.produtoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.lbllControle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.rdBtnSQL = new System.Windows.Forms.RadioButton();
            this.rdbtnXML = new System.Windows.Forms.RadioButton();
            this.tdBtnCSV = new System.Windows.Forms.RadioButton();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtoMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1137, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // produtoMenuItem
            // 
            this.produtoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtoMenuItem1});
            this.produtoMenuItem.Name = "produtoMenuItem";
            this.produtoMenuItem.Size = new System.Drawing.Size(80, 24);
            this.produtoMenuItem.Text = "Cadastro";
            // 
            // produtoMenuItem1
            // 
            this.produtoMenuItem1.Name = "produtoMenuItem1";
            this.produtoMenuItem1.Size = new System.Drawing.Size(137, 26);
            this.produtoMenuItem1.Text = "Produto";
            this.produtoMenuItem1.Click += new System.EventHandler(this.produtoToolStripMenuItem1_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Enabled = false;
            this.btnCadastrar.Location = new System.Drawing.Point(16, 46);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(111, 30);
            this.btnCadastrar.TabIndex = 1;
            this.btnCadastrar.Text = "Adicionar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lbllControle
            // 
            this.lbllControle.AutoSize = true;
            this.lbllControle.Location = new System.Drawing.Point(436, 11);
            this.lbllControle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllControle.Name = "lbllControle";
            this.lbllControle.Size = new System.Drawing.Size(165, 17);
            this.lbllControle.TabIndex = 2;
            this.lbllControle.Text = "Selecione uma operação";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(16, 100);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 418);
            this.panel1.TabIndex = 3;
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(135, 46);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(111, 30);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Location = new System.Drawing.Point(253, 46);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(111, 30);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // rdBtnSQL
            // 
            this.rdBtnSQL.AutoSize = true;
            this.rdBtnSQL.Enabled = false;
            this.rdBtnSQL.Location = new System.Drawing.Point(439, 54);
            this.rdBtnSQL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdBtnSQL.Name = "rdBtnSQL";
            this.rdBtnSQL.Size = new System.Drawing.Size(57, 21);
            this.rdBtnSQL.TabIndex = 6;
            this.rdBtnSQL.TabStop = true;
            this.rdBtnSQL.Text = "SQL";
            this.rdBtnSQL.UseVisualStyleBackColor = true;
            this.rdBtnSQL.CheckedChanged += new System.EventHandler(this.rdBtnSQL_CheckedChanged);
            // 
            // rdbtnXML
            // 
            this.rdbtnXML.AutoSize = true;
            this.rdbtnXML.Enabled = false;
            this.rdbtnXML.Location = new System.Drawing.Point(536, 54);
            this.rdbtnXML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbtnXML.Name = "rdbtnXML";
            this.rdbtnXML.Size = new System.Drawing.Size(57, 21);
            this.rdbtnXML.TabIndex = 7;
            this.rdbtnXML.TabStop = true;
            this.rdbtnXML.Text = "XML";
            this.rdbtnXML.UseVisualStyleBackColor = true;
            this.rdbtnXML.CheckedChanged += new System.EventHandler(this.rdbtnXML_CheckedChanged);
            // 
            // tdBtnCSV
            // 
            this.tdBtnCSV.AutoSize = true;
            this.tdBtnCSV.Enabled = false;
            this.tdBtnCSV.Location = new System.Drawing.Point(640, 54);
            this.tdBtnCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tdBtnCSV.Name = "tdBtnCSV";
            this.tdBtnCSV.Size = new System.Drawing.Size(56, 21);
            this.tdBtnCSV.TabIndex = 8;
            this.tdBtnCSV.TabStop = true;
            this.tdBtnCSV.Text = "CSV";
            this.tdBtnCSV.UseVisualStyleBackColor = true;
            this.tdBtnCSV.CheckedChanged += new System.EventHandler(this.tdBtnCSV_CheckedChanged);
            // 
            // btnFiltro
            // 
            this.btnFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltro.Enabled = false;
            this.btnFiltro.Location = new System.Drawing.Point(1021, 50);
            this.btnFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(100, 28);
            this.btnFiltro.TabIndex = 9;
            this.btnFiltro.Text = "Buscar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(811, 53);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(201, 22);
            this.txtNome.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(807, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filtro por nome";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Location = new System.Drawing.Point(703, 50);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 533);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.tdBtnCSV);
            this.Controls.Add(this.rdbtnXML);
            this.Controls.Add(this.rdBtnSQL);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbllControle);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mercado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem produtoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoMenuItem1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label lbllControle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.RadioButton rdBtnSQL;
        private System.Windows.Forms.RadioButton rdbtnXML;
        private System.Windows.Forms.RadioButton tdBtnCSV;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpar;
    }
}

