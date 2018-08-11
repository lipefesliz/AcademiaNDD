namespace ExercicioContaCorrente
{
    partial class frmCheckingAccount
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
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbBalance = new System.Windows.Forms.Label();
            this.lbEspecial = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.cbIsSpecial = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(13, 14);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(62, 17);
            this.lbNumber.TabIndex = 0;
            this.lbNumber.Text = "Numero:";
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Location = new System.Drawing.Point(13, 58);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(48, 17);
            this.lbBalance.TabIndex = 1;
            this.lbBalance.Text = "Saldo:";
            // 
            // lbEspecial
            // 
            this.lbEspecial.AutoSize = true;
            this.lbEspecial.Location = new System.Drawing.Point(9, 95);
            this.lbEspecial.Name = "lbEspecial";
            this.lbEspecial.Size = new System.Drawing.Size(65, 17);
            this.lbEspecial.TabIndex = 3;
            this.lbEspecial.Text = "Especial:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(83, 14);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(184, 22);
            this.txtNumber.TabIndex = 4;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(83, 55);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(184, 22);
            this.txtBalance.TabIndex = 5;
            // 
            // cbIsSpecial
            // 
            this.cbIsSpecial.AutoSize = true;
            this.cbIsSpecial.Location = new System.Drawing.Point(85, 95);
            this.cbIsSpecial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIsSpecial.Name = "cbIsSpecial";
            this.cbIsSpecial.Size = new System.Drawing.Size(18, 17);
            this.cbIsSpecial.TabIndex = 7;
            this.cbIsSpecial.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(193, 124);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCheckingAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 165);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbIsSpecial);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lbEspecial);
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.lbNumber);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCheckingAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conta Corrente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.Label lbEspecial;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.CheckBox cbIsSpecial;
        private System.Windows.Forms.Button btnSave;
    }
}