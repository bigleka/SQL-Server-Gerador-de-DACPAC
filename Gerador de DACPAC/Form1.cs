using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Gerador_de_DACPAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void conectar_Click(object sender, EventArgs e)
        {
            if(ServidorDB.Text=="")
            {
                MessageBox.Show("Digite o nome do servidor SQL", "Servidor SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlConnection Conexao = new SqlConnection("server=" + ServidorDB.Text + ";Initial Catalog=master;Trusted_Connection=yes;connection timeout=3");
                try
                {
                    BasesDACPAC.Items.Clear();
                    Conexao.Open();
                    SqlDataReader LerDB = null;
                    SqlCommand ComandoDB = new SqlCommand("select name from sys.sysdatabases where dbid>4",Conexao);
                    LerDB = ComandoDB.ExecuteReader();
                    while(LerDB.Read())
                    {
                        BasesDACPAC.Items.Add(LerDB["name"].ToString());
                    }
                    Conexao.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao conectar Servidor SQL: " +ServidorDB.Text, "Erro ao conectar Servidor SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (!string.IsNullOrWhiteSpace(LocalSqlPackage.Text) && !System.IO.File.Exists(LocalSqlPackage.Text))
            {
                LocalSqlPackage.BackColor = Color.Aquamarine;
            }
            else
            {
                LocalSqlPackage.BackColor = Color.Red;
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            DestinoDialogo.ShowDialog();
            Destino.Text = (DestinoDialogo.SelectedPath);
            //Destino.Text = ("\"" + DestinoDialogo.SelectedPath + "\"");
        }

        private void extrair_Click(object sender, EventArgs e)
        {
            if (Destino.Text == "")
            {
                MessageBox.Show("Informe o caminho para extração", "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ServidorDB.Text == "")
            {
                MessageBox.Show("Informe Servidor SQL", "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (BasesDACPAC.SelectedItems.Count==0)
            {
                MessageBox.Show("Nenhuma base foi selecionada", "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!string.IsNullOrWhiteSpace(LocalSqlPackage.Text) && !System.IO.File.Exists(LocalSqlPackage.Text))
            {
                
            }
            else
            {
                //MessageBox.Show("SqlPackage não localizado, clique 2x na caixa de texto e localize-o", "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // return;
            }
            foreach(Object BaseSelecionada in BasesDACPAC.SelectedItems)
            {
                try
                {
                    string Run = LocalSqlPackage.Text + " /a:Extract /ssn:" + ServidorDB.Text + " /sdn:" + BaseSelecionada + " /tf:" + Destino.Text  + "\\" + BaseSelecionada + ".dacpac";
                    //MessageBox.Show(Run, "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //System.Diagnostics.Process.Start(@Run);
                    Process exec = new Process();
                    exec.StartInfo.FileName = "cmd.exe";
                    exec.StartInfo.Arguments = "/c "+@Run;
                    exec.StartInfo.RedirectStandardOutput = true;
                    exec.StartInfo.UseShellExecute = false;
                    exec.StartInfo.CreateNoWindow = false;
                    exec.Start();
                    exec.WaitForExit();
                }
                catch (Exception falha)
                {
                    MessageBox.Show(falha.Message, "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void LocalSqlPackage_DoubleClick(object sender, EventArgs e)
        {
            LocalizarSqlPackage.ShowDialog();
            LocalSqlPackage.Text = ("\"" + LocalizarSqlPackage.FileName + "\"");
            //LocalSqlPackage.Text = (LocalizarSqlPackage.FileName);
        }
    }
}
