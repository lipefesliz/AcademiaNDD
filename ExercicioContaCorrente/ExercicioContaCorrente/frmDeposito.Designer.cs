namespace ExercicioContaCorrente
{
    partial class frmDeposito
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
            this.btnWithdrawConfirm = new System.Windows.Forms.Button();
            this.lbWithdrawValue = new System.Windows.Forms.Label();
            this.txtWithdrawValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWithdrawConfirm
            // 
            this.btnWithdrawConfirm.Location = new System.Drawing.Point(53, 66);
            this.btnWithdrawConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnWithdrawConfirm.Name = "btnWithdrawConfirm";
            this.btnWithdrawConfirm.Size = new System.Drawing.Size(75, 19);
            this.btnWithdrawConfirm.TabIndex = 5;
            this.btnWithdrawConfirm.Text = "Confirmar";
            this.btnWithdrawConfirm.UseVisualStyleBackColor = true;
            this.btnWithdrawConfirm.Click += new System.EventHandler(this.btnWithdrawConfirm_Click);
            // 
            // lbWithdrawValue
            // 
            this.lbWithdrawValue.AutoSize = true;
            this.lbWithdrawValue.Location = new System.Drawing.Point(15, 29);
            this.lbWithdrawValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWithdrawValue.Name = "lbWithdrawValue";
            this.lbWithdrawValue.Size = new System.Drawing.Size(34, 13);
            this.lbWithdrawValue.TabIndex = 4;
            this.lbWithdrawValue.Text = "Valor:";
            // 
            // txtWithdrawValue
            // 
            this.txtWithdrawValue.Location = new System.Drawing.Point(53, 29);
            this.txtWithdrawValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtWithdrawValue.Name = "txtWithdrawValue";
            this.txtWithdrawValue.Size = new System.Drawing.Size(116, 20);
            this.txtWithdrawValue.TabIndex = 3;
            // 
            // frmDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 105);
            this.Controls.Add(this.btnWithdrawConfirm);
            this.Controls.Add(this.lbWithdrawValue);
            this.Controls.Add(this.txtWithdrawValue);
            this.Name = "frmDeposito";
            this.Text = "frmDeposito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWithdrawConfirm;
        private System.Windows.Forms.Label lbWithdrawValue;
        private System.Windows.Forms.TextBox txtWithdrawValue;
    }
}