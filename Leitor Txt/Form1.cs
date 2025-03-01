using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite; 




namespace Leitor_Txt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var loginForm = new LoginUser();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
            }
            InitializeComponent();
            
            AtualizarListaArquivos();
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
                txtLog.Text = "Conexão com o banco de dados estabelecida.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarListaArquivos()
        {
            listArquivos.Items.Clear();
            arquivosMapeados.Clear();

            var arquivosBase = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.txt");

            foreach (var caminho in arquivosBase)
            {
                var nomeArquivo = Path.GetFileName(caminho);
                arquivosMapeados[nomeArquivo] = caminho;
                listArquivos.Items.Add(nomeArquivo); 
            }

            txtLog.Text = "Lista de arquivos atualizada.";
        }

        

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var novoForm = new Criar_Arquivocs())
            {
                if (novoForm.ShowDialog() == DialogResult.OK)
                {
                    var nomeArquivo = novoForm.NomeArquivo;
                    var caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);

                    if (File.Exists(caminho))
                    {
                        MessageBox.Show($"O arquivo '{nomeArquivo}' já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        File.Create(caminho).Close(); 
                        AtualizarListaArquivos();
                        txtLog.Text = $"Arquivo '{nomeArquivo}' criado.";
                    }
                }
            }

        }

        private Dictionary<string, string> arquivosMapeados = new Dictionary<string, string>();

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var caminho = openFileDialog.FileName;
                    var nomeArquivo = Path.GetFileName(caminho);

                    
                    if (arquivosMapeados.ContainsKey(nomeArquivo))
                    {
                        MessageBox.Show("O arquivo já está na lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    arquivosMapeados[nomeArquivo] = caminho;
                    listArquivos.Items.Add(nomeArquivo);
                    txtLog.Text = $"Arquivo '{nomeArquivo}' adicionado à lista.";
                }
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (listArquivos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um arquivo para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nomeArquivo = listArquivos.SelectedItem.ToString();

            if (arquivosMapeados.TryGetValue(nomeArquivo, out var caminho))
            {
                var confirmResult = MessageBox.Show("Deseja salvar as alterações?", "Confirmar Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        
                        File.WriteAllText(caminho, edtText.Text);

                        string dataModificada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string query = "INSERT INTO TBEDITARQUIVO (NOME_ARQUIVO, PATH, DATA_MOD) VALUES (@NOME_ARQUIVO, @PATH, @DATA_MOD)";
                        using (var cmd = new SQLiteCommand(query, sqliteConnection))
                        {
                            cmd.Parameters.AddWithValue("@NOME_ARQUIVO", nomeArquivo);
                            cmd.Parameters.AddWithValue("@PATH", caminho);
                            cmd.Parameters.AddWithValue("@DATA_MOD", dataModificada);

                            try
                            {
                                cmd.ExecuteNonQuery();

                                string query2 = "INSERT INTO TBLOG (TEXT_LOG, DATA_MOD_LOG) VALUES (@TEXT_LOG, @DATA_MOD_LOG)";
                                using (var cmd2 = new SQLiteCommand(query2, sqliteConnection))
                                {
                                    cmd2.Parameters.AddWithValue("@TEXT_LOG", $"Arquivo '{nomeArquivo}' salvo no banco de dados.");
                                    cmd2.Parameters.AddWithValue("@DATA_MOD_LOG", dataModificada);

                                    try
                                    {
                                        cmd2.ExecuteNonQuery();
                                        txtLog.Text = $"Arquivo '{nomeArquivo}' salvo no banco de dados.";
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Erro ao inserir dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                txtLog.Text = $"Arquivo '{nomeArquivo}' salvo no banco de dados.";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao inserir dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("O caminho do arquivo não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (listArquivos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um arquivo para apagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var arquivoSelecionado = listArquivos.SelectedItem.ToString();

            var confirmResult = MessageBox.Show("Deseja remover este arquivo da lista?", "Confirmar Apagar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                listArquivos.Items.Remove(arquivoSelecionado);
                arquivosMapeados.Remove(arquivoSelecionado);
                txtLog.Text = $"Arquivo '{arquivoSelecionado}' removido da lista.";
            }

        }

        private void listArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listArquivos.SelectedItem != null)
            {
                var nomeArquivo = listArquivos.SelectedItem.ToString();

                if (arquivosMapeados.TryGetValue(nomeArquivo, out var caminho))
                {
                    if (File.Exists(caminho))
                    {
                        edtText.Text = File.ReadAllText(caminho);
                        txtLog.Text = $"Arquivo '{nomeArquivo}' aberto.";
                    }
                    else
                    {
                        MessageBox.Show("O arquivo não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
