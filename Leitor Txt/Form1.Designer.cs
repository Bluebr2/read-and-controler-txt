namespace Leitor_Txt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listArquivos = new ListBox();
            btnNovo = new Button();
            btnAbrir = new Button();
            btnSalvar = new Button();
            btnApagar = new Button();
            edtText = new TextBox();
            label1 = new Label();
            txtLog = new Label();
            SuspendLayout();
            // 
            // listArquivos
            // 
            listArquivos.FormattingEnabled = true;
            listArquivos.ItemHeight = 15;
            listArquivos.Location = new Point(12, 42);
            listArquivos.Name = "listArquivos";
            listArquivos.Size = new Size(318, 439);
            listArquivos.TabIndex = 0;
            listArquivos.SelectedIndexChanged += listArquivos_SelectedIndexChanged;
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.Yellow;
            btnNovo.Location = new Point(12, 13);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(93, 13);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(75, 23);
            btnAbrir.TabIndex = 2;
            btnAbrir.Text = "Abrir";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.LightGreen;
            btnSalvar.Location = new Point(174, 13);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 3;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnApagar
            // 
            btnApagar.BackColor = Color.LightCoral;
            btnApagar.Location = new Point(255, 13);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(75, 23);
            btnApagar.TabIndex = 4;
            btnApagar.Text = "Apagar";
            btnApagar.UseVisualStyleBackColor = false;
            btnApagar.Click += btnApagar_Click;
            // 
            // edtText
            // 
            edtText.Location = new Point(336, 42);
            edtText.Multiline = true;
            edtText.Name = "edtText";
            edtText.Size = new Size(754, 439);
            edtText.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(675, 24);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 6;
            label1.Text = "Dados do arquivo";
            // 
            // txtLog
            // 
            txtLog.AutoSize = true;
            txtLog.BackColor = Color.FloralWhite;
            txtLog.ImageAlign = ContentAlignment.BottomCenter;
            txtLog.Location = new Point(119, 484);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(87, 15);
            txtLog.TabIndex = 7;
            txtLog.Text = "Log de eventos";
            txtLog.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 534);
            Controls.Add(txtLog);
            Controls.Add(label1);
            Controls.Add(edtText);
            Controls.Add(btnApagar);
            Controls.Add(btnSalvar);
            Controls.Add(btnAbrir);
            Controls.Add(btnNovo);
            Controls.Add(listArquivos);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LEITOR TXT";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listArquivos;
        private Button btnNovo;
        private Button btnAbrir;
        private Button btnSalvar;
        private Button btnApagar;
        private TextBox edtText;
        private Label label1;
        private Label txtLog;
    }
}
