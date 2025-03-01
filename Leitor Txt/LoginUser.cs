using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Leitor_Txt
{
    public partial class LoginUser : Form
    {
        public LoginUser()
        {
            InitializeComponent();
            ConectarBancoDeDados();
        }

        private SQLiteConnection sqliteConnection;

        private void ConectarBancoDeDados()
        {
            string caminhoBanco = "Data Source=C:\\Users\\iorgu\\OneDrive\\Área de Trabalho\\DatabaseArquivoEdit.db;Version=3;";
            sqliteConnection = new SQLiteConnection(caminhoBanco);

            try
            {
                sqliteConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarLogin(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM TBUSER WHERE LOGIN = @LOGIN AND SENHA = @SENHA";

            
            if (sqliteConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("A conexão com o banco de dados não está aberta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            using (var cmd = new SQLiteCommand(query, sqliteConnection))
            {
                cmd.Parameters.AddWithValue("@LOGIN", username);
                cmd.Parameters.AddWithValue("@SENHA", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string username = validUserLogin.Text;
            string password = validUserPassword.Text;

            if (ValidarLogin(username, password))
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCriarUser_Click(object sender, EventArgs e)
        {
            string username = validUserLogin.Text;
            string password = validUserPassword.Text;

            
            if (sqliteConnection.State != ConnectionState.Open)
            {
                MessageBox.Show("A conexão com o banco de dados não está aberta. Tentando reconectar...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConectarBancoDeDados();
                if (sqliteConnection.State != ConnectionState.Open)
                {
                    return;
                }
            }

            
            string queryCheck = "SELECT COUNT(*) FROM TBUSER WHERE LOGIN = @LOGIN";
            using (var cmd = new SQLiteCommand(queryCheck, sqliteConnection))
            {
                cmd.Parameters.AddWithValue("@LOGIN", username);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Nome de usuário já existe. Tente outro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            
            string query = "INSERT INTO TBUSER (LOGIN, SENHA) VALUES (@LOGIN, @SENHA)";
            using (var cmd = new SQLiteCommand(query, sqliteConnection))
            {
                cmd.Parameters.AddWithValue("@LOGIN", username);
                cmd.Parameters.AddWithValue("@SENHA", password);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                
                Application.Exit();
            }
        }
    }

}
