namespace Leitor_Txt
{
    partial class LoginUser
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
            validUserLogin = new TextBox();
            validUserPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnCriarUser = new Button();
            btnEntrar = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // validUserLogin
            // 
            validUserLogin.Location = new Point(34, 47);
            validUserLogin.Name = "validUserLogin";
            validUserLogin.Size = new Size(190, 23);
            validUserLogin.TabIndex = 0;
            // 
            // validUserPassword
            // 
            validUserPassword.Location = new Point(34, 90);
            validUserPassword.Name = "validUserPassword";
            validUserPassword.PasswordChar = '*';
            validUserPassword.Size = new Size(190, 23);
            validUserPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 29);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 2;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 73);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Senha";
            // 
            // btnCriarUser
            // 
            btnCriarUser.Location = new Point(68, 119);
            btnCriarUser.Name = "btnCriarUser";
            btnCriarUser.Size = new Size(75, 23);
            btnCriarUser.TabIndex = 4;
            btnCriarUser.Text = "Criar";
            btnCriarUser.UseVisualStyleBackColor = true;
            btnCriarUser.Click += btnCriarUser_Click;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(149, 119);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(75, 23);
            btnEntrar.TabIndex = 5;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // LoginUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 155);
            Controls.Add(btnEntrar);
            Controls.Add(btnCriarUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(validUserPassword);
            Controls.Add(validUserLogin);
            Name = "LoginUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginUser";
            FormClosing += LoginUser_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox validUserLogin;
        private TextBox validUserPassword;
        private Label label1;
        private Label label2;
        private Button btnCriarUser;
        private Button btnEntrar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}