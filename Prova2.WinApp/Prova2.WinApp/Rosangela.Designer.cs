namespace Prova2.WinApp
{
    partial class Rosangela
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabRosangela = new System.Windows.Forms.TabControl();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.cbIsAvailable = new System.Windows.Forms.CheckBox();
            this.lbIsAvailable = new System.Windows.Forms.Label();
            this.dtpDatePublication = new System.Windows.Forms.DateTimePicker();
            this.lbData = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.lbVolume = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.lbAutor = new System.Windows.Forms.Label();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.lbTheme = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tabList = new System.Windows.Forms.TabPage();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lbReturnDate = new System.Windows.Forms.Label();
            this.btnTax = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.lbOrders = new System.Windows.Forms.ListBox();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.btnClearOrders = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lbBook = new System.Windows.Forms.Label();
            this.cmbBooks = new System.Windows.Forms.ComboBox();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.btnReportOrder = new System.Windows.Forms.Button();
            this.tabRosangela.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.tabList.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabRosangela
            // 
            this.tabRosangela.Controls.Add(this.tabRegister);
            this.tabRosangela.Controls.Add(this.tabList);
            this.tabRosangela.Controls.Add(this.tabPage3);
            this.tabRosangela.Location = new System.Drawing.Point(13, 13);
            this.tabRosangela.Name = "tabRosangela";
            this.tabRosangela.SelectedIndex = 0;
            this.tabRosangela.Size = new System.Drawing.Size(380, 267);
            this.tabRosangela.TabIndex = 0;
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.btnClear);
            this.tabRegister.Controls.Add(this.btnCancel);
            this.tabRegister.Controls.Add(this.btnSave);
            this.tabRegister.Controls.Add(this.txtId);
            this.tabRegister.Controls.Add(this.lbId);
            this.tabRegister.Controls.Add(this.cbIsAvailable);
            this.tabRegister.Controls.Add(this.lbIsAvailable);
            this.tabRegister.Controls.Add(this.dtpDatePublication);
            this.tabRegister.Controls.Add(this.lbData);
            this.tabRegister.Controls.Add(this.txtVolume);
            this.tabRegister.Controls.Add(this.lbVolume);
            this.tabRegister.Controls.Add(this.txtAutor);
            this.tabRegister.Controls.Add(this.lbAutor);
            this.tabRegister.Controls.Add(this.txtTheme);
            this.tabRegister.Controls.Add(this.lbTheme);
            this.tabRegister.Controls.Add(this.txtTitle);
            this.tabRegister.Controls.Add(this.lbTitle);
            this.tabRegister.Location = new System.Drawing.Point(4, 22);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegister.Size = new System.Drawing.Size(372, 241);
            this.tabRegister.TabIndex = 0;
            this.tabRegister.Text = "Cadastro";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(93, 212);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(26, 212);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DimGray;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtId.Location = new System.Drawing.Point(133, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(42, 20);
            this.txtId.TabIndex = 25;
            this.txtId.Text = "0";
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(20, 5);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(19, 13);
            this.lbId.TabIndex = 24;
            this.lbId.Text = "Id:";
            // 
            // cbIsAvailable
            // 
            this.cbIsAvailable.AutoSize = true;
            this.cbIsAvailable.Location = new System.Drawing.Point(133, 178);
            this.cbIsAvailable.Name = "cbIsAvailable";
            this.cbIsAvailable.Size = new System.Drawing.Size(15, 14);
            this.cbIsAvailable.TabIndex = 23;
            this.cbIsAvailable.UseVisualStyleBackColor = true;
            // 
            // lbIsAvailable
            // 
            this.lbIsAvailable.AutoSize = true;
            this.lbIsAvailable.Location = new System.Drawing.Point(20, 178);
            this.lbIsAvailable.Name = "lbIsAvailable";
            this.lbIsAvailable.Size = new System.Drawing.Size(64, 13);
            this.lbIsAvailable.TabIndex = 22;
            this.lbIsAvailable.Text = "Disponível?";
            // 
            // dtpDatePublication
            // 
            this.dtpDatePublication.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatePublication.Location = new System.Drawing.Point(133, 149);
            this.dtpDatePublication.Name = "dtpDatePublication";
            this.dtpDatePublication.Size = new System.Drawing.Size(129, 20);
            this.dtpDatePublication.TabIndex = 21;
            this.dtpDatePublication.Value = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(17, 149);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(86, 13);
            this.lbData.TabIndex = 20;
            this.lbData.Text = "Data Publicação";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(133, 122);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(216, 20);
            this.txtVolume.TabIndex = 19;
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(17, 118);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(42, 13);
            this.lbVolume.TabIndex = 18;
            this.lbVolume.Text = "Volume";
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(133, 91);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(216, 20);
            this.txtAutor.TabIndex = 17;
            // 
            // lbAutor
            // 
            this.lbAutor.AutoSize = true;
            this.lbAutor.Location = new System.Drawing.Point(17, 86);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(32, 13);
            this.lbAutor.TabIndex = 16;
            this.lbAutor.Text = "Autor";
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(133, 58);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(216, 20);
            this.txtTheme.TabIndex = 15;
            // 
            // lbTheme
            // 
            this.lbTheme.AutoSize = true;
            this.lbTheme.Location = new System.Drawing.Point(17, 53);
            this.lbTheme.Name = "lbTheme";
            this.lbTheme.Size = new System.Drawing.Size(34, 13);
            this.lbTheme.TabIndex = 14;
            this.lbTheme.Text = "Tema";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(133, 26);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(216, 20);
            this.txtTitle.TabIndex = 13;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(17, 28);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(35, 13);
            this.lbTitle.TabIndex = 12;
            this.lbTitle.Text = "Título";
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.btnReport);
            this.tabList.Controls.Add(this.btnDelete);
            this.tabList.Controls.Add(this.btnEdit);
            this.tabList.Controls.Add(this.lbBooks);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(372, 241);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "Listar";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(44, 7);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Relatório";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(235, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(141, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lbBooks
            // 
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.Location = new System.Drawing.Point(11, 36);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(355, 199);
            this.lbBooks.TabIndex = 3;
            this.lbBooks.SelectedIndexChanged += new System.EventHandler(this.lbBooks_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnReportOrder);
            this.tabPage3.Controls.Add(this.dtpReturnDate);
            this.tabPage3.Controls.Add(this.lbReturnDate);
            this.tabPage3.Controls.Add(this.btnTax);
            this.tabPage3.Controls.Add(this.btnDeleteOrder);
            this.tabPage3.Controls.Add(this.btnEditOrder);
            this.tabPage3.Controls.Add(this.lbOrders);
            this.tabPage3.Controls.Add(this.lbCustomer);
            this.tabPage3.Controls.Add(this.btnClearOrders);
            this.tabPage3.Controls.Add(this.txtCustomer);
            this.tabPage3.Controls.Add(this.lbBook);
            this.tabPage3.Controls.Add(this.cmbBooks);
            this.tabPage3.Controls.Add(this.btnSaveOrder);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(372, 241);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Emprestimo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(111, 71);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(133, 20);
            this.dtpReturnDate.TabIndex = 26;
            this.dtpReturnDate.Value = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            // 
            // lbReturnDate
            // 
            this.lbReturnDate.AutoSize = true;
            this.lbReturnDate.Location = new System.Drawing.Point(19, 78);
            this.lbReturnDate.Name = "lbReturnDate";
            this.lbReturnDate.Size = new System.Drawing.Size(85, 13);
            this.lbReturnDate.TabIndex = 25;
            this.lbReturnDate.Text = "Data Devolução";
            // 
            // btnTax
            // 
            this.btnTax.Enabled = false;
            this.btnTax.Location = new System.Drawing.Point(313, 212);
            this.btnTax.Name = "btnTax";
            this.btnTax.Size = new System.Drawing.Size(53, 23);
            this.btnTax.TabIndex = 24;
            this.btnTax.Text = "Multa";
            this.btnTax.UseVisualStyleBackColor = true;
            this.btnTax.Click += new System.EventHandler(this.btnTax_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Enabled = false;
            this.btnDeleteOrder.Location = new System.Drawing.Point(313, 180);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(53, 23);
            this.btnDeleteOrder.TabIndex = 23;
            this.btnDeleteOrder.Text = "Excluir";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Enabled = false;
            this.btnEditOrder.Location = new System.Drawing.Point(313, 148);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(53, 23);
            this.btnEditOrder.TabIndex = 22;
            this.btnEditOrder.Text = "Editar";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // lbOrders
            // 
            this.lbOrders.FormattingEnabled = true;
            this.lbOrders.Location = new System.Drawing.Point(6, 140);
            this.lbOrders.Name = "lbOrders";
            this.lbOrders.Size = new System.Drawing.Size(301, 95);
            this.lbOrders.TabIndex = 21;
            this.lbOrders.SelectedIndexChanged += new System.EventHandler(this.lbOrders_SelectedIndexChanged);
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(19, 21);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(39, 13);
            this.lbCustomer.TabIndex = 20;
            this.lbCustomer.Text = "Cliente";
            // 
            // btnClearOrders
            // 
            this.btnClearOrders.Location = new System.Drawing.Point(151, 111);
            this.btnClearOrders.Name = "btnClearOrders";
            this.btnClearOrders.Size = new System.Drawing.Size(75, 23);
            this.btnClearOrders.TabIndex = 19;
            this.btnClearOrders.Text = "Limpar";
            this.btnClearOrders.UseVisualStyleBackColor = true;
            this.btnClearOrders.Click += new System.EventHandler(this.btnClearOrders_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(111, 14);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(196, 20);
            this.txtCustomer.TabIndex = 16;
            // 
            // lbBook
            // 
            this.lbBook.AutoSize = true;
            this.lbBook.Location = new System.Drawing.Point(19, 49);
            this.lbBook.Name = "lbBook";
            this.lbBook.Size = new System.Drawing.Size(33, 13);
            this.lbBook.TabIndex = 15;
            this.lbBook.Text = "Livro:";
            // 
            // cmbBooks
            // 
            this.cmbBooks.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new System.Drawing.Point(111, 41);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(196, 21);
            this.cmbBooks.TabIndex = 14;
            this.cmbBooks.SelectedIndexChanged += new System.EventHandler(this.cmbBooks_SelectedIndexChanged);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Location = new System.Drawing.Point(232, 111);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSaveOrder.TabIndex = 12;
            this.btnSaveOrder.Text = "Salvar";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // btnReportOrder
            // 
            this.btnReportOrder.Location = new System.Drawing.Point(70, 111);
            this.btnReportOrder.Name = "btnReportOrder";
            this.btnReportOrder.Size = new System.Drawing.Size(75, 23);
            this.btnReportOrder.TabIndex = 27;
            this.btnReportOrder.Text = "Relatório";
            this.btnReportOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportOrder.Click += new System.EventHandler(this.btnReportOrder_Click);
            // 
            // Rosangela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 292);
            this.Controls.Add(this.tabRosangela);
            this.Name = "Rosangela";
            this.Text = "Form1";
            this.tabRosangela.ResumeLayout(false);
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.tabList.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabRosangela;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.CheckBox cbIsAvailable;
        private System.Windows.Forms.Label lbIsAvailable;
        private System.Windows.Forms.DateTimePicker dtpDatePublication;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label lbAutor;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.Label lbTheme;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.Button btnClearOrders;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lbBook;
        private System.Windows.Forms.ComboBox cmbBooks;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.Button btnTax;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.ListBox lbOrders;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lbReturnDate;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnReportOrder;
    }
}

