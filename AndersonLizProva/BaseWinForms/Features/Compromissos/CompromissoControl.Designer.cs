namespace AndersonLiz.Agenda.WinApp.Features.Compromissos
{
    partial class CompromissoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCompromissos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompromissos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompromissos
            // 
            this.dgvCompromissos.AllowUserToAddRows = false;
            this.dgvCompromissos.AllowUserToDeleteRows = false;
            this.dgvCompromissos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompromissos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompromissos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCompromissos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompromissos.Location = new System.Drawing.Point(0, 0);
            this.dgvCompromissos.MultiSelect = false;
            this.dgvCompromissos.Name = "dgvCompromissos";
            this.dgvCompromissos.ReadOnly = true;
            this.dgvCompromissos.RowTemplate.Height = 24;
            this.dgvCompromissos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompromissos.Size = new System.Drawing.Size(284, 245);
            this.dgvCompromissos.TabIndex = 0;
            // 
            // CompromissoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCompromissos);
            this.Name = "CompromissoControl";
            this.Size = new System.Drawing.Size(284, 245);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompromissos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompromissos;
    }
}
