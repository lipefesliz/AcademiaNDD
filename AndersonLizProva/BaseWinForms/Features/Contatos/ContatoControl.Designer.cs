namespace AndersonLiz.Agenda.WinApp.Features.Contatos
{
    partial class ContatoControl
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
            this.listContatos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listContatos
            // 
            this.listContatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listContatos.FormattingEnabled = true;
            this.listContatos.ItemHeight = 16;
            this.listContatos.Location = new System.Drawing.Point(0, 0);
            this.listContatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listContatos.Name = "listContatos";
            this.listContatos.Size = new System.Drawing.Size(284, 245);
            this.listContatos.TabIndex = 1;
            // 
            // ContatoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listContatos);
            this.Name = "ContatoControl";
            this.Size = new System.Drawing.Size(284, 245);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listContatos;
    }
}
