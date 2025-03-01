using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leitor_Txt
{
    public partial class Criar_Arquivocs : Form
    {
        public string NomeArquivo { get; private set; }

        public Criar_Arquivocs()
        {
            InitializeComponent();
        }

        private void btnCriarArquivo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameArquivo.Text))
            {
                MessageBox.Show("Digite um nome para o arquivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NomeArquivo = txtNameArquivo.Text.Trim() + ".txt";
            DialogResult = DialogResult.OK; 
            Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
