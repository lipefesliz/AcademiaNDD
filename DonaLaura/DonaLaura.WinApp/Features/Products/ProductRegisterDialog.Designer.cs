namespace DonaLaura.WinApp.Features.Products
{
    partial class ProductRegisterDialog
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
            this.lblFabrication = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.chbxIsAvailable = new System.Windows.Forms.CheckBox();
            this.lblIsAvailable = new System.Windows.Forms.Label();
            this.dtFabrication = new System.Windows.Forms.DateTimePicker();
            this.dtExpiration = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblFabrication
            // 
            this.lblFabrication.AutoSize = true;
            this.lblFabrication.Location = new System.Drawing.Point(30, 244);
            this.lblFabrication.Name = "lblFabrication";
            this.lblFabrication.Size = new System.Drawing.Size(128, 17);
            this.lblFabrication.TabIndex = 58;
            this.lblFabrication.Text = "Data de fabricação";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(166, 149);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(209, 22);
            this.txtSalePrice.TabIndex = 57;
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Location = new System.Drawing.Point(30, 154);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(108, 17);
            this.lblSalePrice.TabIndex = 56;
            this.lblSalePrice.Text = "Preço de venda";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(166, 110);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(209, 22);
            this.txtCostPrice.TabIndex = 55;
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Location = new System.Drawing.Point(30, 115);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(103, 17);
            this.lblCostPrice.TabIndex = 54;
            this.lblCostPrice.Text = "Preço de custo";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(219, 327);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 52;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(30, 35);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 17);
            this.lblId.TabIndex = 51;
            this.lblId.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.SystemColors.Info;
            this.txtId.Location = new System.Drawing.Point(166, 29);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(97, 23);
            this.txtId.TabIndex = 50;
            this.txtId.Text = "0";
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(166, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 22);
            this.txtName.TabIndex = 49;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 74);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 48;
            this.lblName.Text = "Nome";
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(30, 284);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(115, 17);
            this.lblExpiration.TabIndex = 60;
            this.lblExpiration.Text = "Data de validade";
            // 
            // chbxIsAvailable
            // 
            this.chbxIsAvailable.AutoSize = true;
            this.chbxIsAvailable.Location = new System.Drawing.Point(165, 196);
            this.chbxIsAvailable.Name = "chbxIsAvailable";
            this.chbxIsAvailable.Size = new System.Drawing.Size(53, 21);
            this.chbxIsAvailable.TabIndex = 62;
            this.chbxIsAvailable.Text = "Sim";
            this.chbxIsAvailable.UseVisualStyleBackColor = true;
            // 
            // lblIsAvailable
            // 
            this.lblIsAvailable.AutoSize = true;
            this.lblIsAvailable.Location = new System.Drawing.Point(30, 196);
            this.lblIsAvailable.Name = "lblIsAvailable";
            this.lblIsAvailable.Size = new System.Drawing.Size(91, 17);
            this.lblIsAvailable.TabIndex = 63;
            this.lblIsAvailable.Text = "Em estoque?";
            // 
            // dtFabrication
            // 
            this.dtFabrication.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFabrication.Location = new System.Drawing.Point(166, 239);
            this.dtFabrication.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtFabrication.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtFabrication.Name = "dtFabrication";
            this.dtFabrication.Size = new System.Drawing.Size(200, 22);
            this.dtFabrication.TabIndex = 64;
            // 
            // dtExpiration
            // 
            this.dtExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiration.Location = new System.Drawing.Point(165, 279);
            this.dtExpiration.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dtExpiration.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.dtExpiration.Name = "dtExpiration";
            this.dtExpiration.Size = new System.Drawing.Size(200, 22);
            this.dtExpiration.TabIndex = 65;
            // 
            // ProductRegisterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 372);
            this.Controls.Add(this.dtExpiration);
            this.Controls.Add(this.dtFabrication);
            this.Controls.Add(this.lblIsAvailable);
            this.Controls.Add(this.chbxIsAvailable);
            this.Controls.Add(this.lblExpiration);
            this.Controls.Add(this.lblFabrication);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.lblSalePrice);
            this.Controls.Add(this.txtCostPrice);
            this.Controls.Add(this.lblCostPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductRegisterDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de produtos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFabrication;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.CheckBox chbxIsAvailable;
        private System.Windows.Forms.Label lblIsAvailable;
        private System.Windows.Forms.DateTimePicker dtFabrication;
        private System.Windows.Forms.DateTimePicker dtExpiration;
    }
}