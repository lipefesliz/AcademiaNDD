namespace ExercicioContaCorrente.Features.ContaCorrenteModule
{
    partial class DepositarContaCorrente
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
            this.txtValorDeposito = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(202, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 39);
            this.button1.TabIndex = 19;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(83, 110);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 39);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lbWithdrawValue
            // 
            this.lbWithdrawValue.AutoSize = true;
            this.lbWithdrawValue.Location = new System.Drawing.Point(79, 61);
            this.lbWithdrawValue.Name = "lbWithdrawValue";
            this.lbWithdrawValue.Size = new System.Drawing.Size(45, 17);
            this.lbWithdrawValue.TabIndex = 17;
            this.lbWithdrawValue.Text = "Valor:";
            // 
            // txtValorDeposito
            // 
            this.txtValorDeposito.Location = new System.Drawing.Point(137, 56);
            this.txtValorDeposito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValorDeposito.Name = "txtValorDeposito";
            this.txtValorDeposito.Size = new System.Drawing.Size(159, 22);
            this.txtValorDeposito.TabIndex = 16;
            // 
            // DepositarContaCorrente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 209);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbWithdrawValue);
            this.Controls.Add(this.txtValorDeposito);
            this.Name = "DepositarContaCorrente";
            this.Text = "DepositarContaCorrente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbWithdrawValue;
        private System.Windows.Forms.TextBox txtValorDeposito;
    }
}