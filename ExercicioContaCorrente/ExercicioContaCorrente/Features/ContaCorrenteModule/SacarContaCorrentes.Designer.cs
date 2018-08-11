namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    partial class SacarContaCorrentes
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbWithdrawValue = new System.Windows.Forms.Label();
            this.txtWithdrawValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(153, 93);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(64, 93);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lbWithdrawValue
            // 
            this.lbWithdrawValue.AutoSize = true;
            this.lbWithdrawValue.Location = new System.Drawing.Point(61, 53);
            this.lbWithdrawValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWithdrawValue.Name = "lbWithdrawValue";
            this.lbWithdrawValue.Size = new System.Drawing.Size(34, 13);
            this.lbWithdrawValue.TabIndex = 13;
            this.lbWithdrawValue.Text = "Valor:";
            // 
            // txtWithdrawValue
            // 
            this.txtWithdrawValue.Location = new System.Drawing.Point(104, 49);
            this.txtWithdrawValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtWithdrawValue.Name = "txtWithdrawValue";
            this.txtWithdrawValue.Size = new System.Drawing.Size(120, 20);
            this.txtWithdrawValue.TabIndex = 12;
            // 
            // SacarContaCorrentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 170);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbWithdrawValue);
            this.Controls.Add(this.txtWithdrawValue);
            this.Name = "SacarContaCorrentes";
            this.Text = "SacarContaCorrentecs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbWithdrawValue;
        private System.Windows.Forms.TextBox txtWithdrawValue;
    }
}