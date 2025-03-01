namespace Leitor_Txt
{
    partial class Criar_Arquivocs
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
            txtNameArquivo = new TextBox();
            label1 = new Label();
            btnCriarArquivo = new Button();
            btnFechar = new Button();
            SuspendLayout();
            // 
            // txtNameArquivo
            // 
            txtNameArquivo.Location = new Point(12, 49);
            txtNameArquivo.Name = "txtNameArquivo";
            txtNameArquivo.Size = new Size(295, 23);
            txtNameArquivo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 1;
            label1.Text = "Insira o nome do arquivo";
            // 
            // btnCriarArquivo
            // 
            btnCriarArquivo.Location = new Point(232, 78);
            btnCriarArquivo.Name = "btnCriarArquivo";
            btnCriarArquivo.Size = new Size(75, 23);
            btnCriarArquivo.TabIndex = 2;
            btnCriarArquivo.Text = "Criar";
            btnCriarArquivo.UseVisualStyleBackColor = true;
            btnCriarArquivo.Click += btnCriarArquivo_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(151, 78);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(75, 23);
            btnFechar.TabIndex = 3;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // Criar_Arquivocs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 115);
            Controls.Add(btnFechar);
            Controls.Add(btnCriarArquivo);
            Controls.Add(label1);
            Controls.Add(txtNameArquivo);
            Name = "Criar_Arquivocs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Criar_Arquivos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNameArquivo;
        private Label label1;
        private Button btnCriarArquivo;
        private Button btnFechar;
    }
}