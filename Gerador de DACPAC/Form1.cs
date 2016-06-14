using System;
//using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
//using System.IO;
using System.Configuration; //1.5
using System.Xml; //1.5
//using System.Threading.Tasks;
//using System.Threading;


namespace Gerador_de_DACPAC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToolTip Dica = new ToolTip();
            Dica.AutoPopDelay = 5000;
            Dica.InitialDelay = 1000;
            Dica.ReshowDelay = 500;
            Dica.ShowAlways = true;
            Dica.SetToolTip(YMD, "Adiciona AAAAMMDD ao final do arquivo extraido");
            Dica.SetToolTip(Permissoes, "Adiciona as permissões de Objetos ao DACPAC");
            Dica.SetToolTip(AbrirDiretorio, "Após a geração abrir a pasta");
            Dica.SetToolTip(LocalSqlPackage, "Clique 2x para localizar o SqlPackage.exe");
            Dica.SetToolTip(MultiExtrator, "Habilitar para extração 1...1 (máquinas lentas)");
            #pragma warning disable CS0618 // Type or member is obsolete
            string UltimoLocalSqlPackage = ConfigurationSettings.AppSettings["UltimoLocalSqlPackage"]; //1.5
            #pragma warning restore CS0618 // Type or member is obsolete
            LocalizarSqlPackage.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Microsoft SQL Server\\110\\DAC\\bin\\SqlPackage.exe" + "\""; //1.5

            if (UltimoLocalSqlPackage == "") //1.5
            {
                LocalSqlPackage.Text = "\"" + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Microsoft SQL Server\\110\\DAC\\bin\\SqlPackage.exe" + "\""; //1.5
            }
            else
            {
                LocalSqlPackage.Text = UltimoLocalSqlPackage; //1.5
            }
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                //MessageBox.Show("You pressed the F1 key");
                System.Diagnostics.Process.Start("https://leka.com.br/2015/11/13/gerar-dacpac-versao-c/");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
            XmlDocument XmlDoc = new XmlDocument(); //1.5
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile); //1.5
            XmlNode appSettingsNode = XmlDoc.SelectSingleNode("configuration/appSettings"); //1.5
            foreach (XmlNode childNode in appSettingsNode) //1.5
            {
                if (childNode.Attributes["key"].Value == "UltimoLocalSqlPackage") //1.5
                    childNode.Attributes["value"].Value = LocalSqlPackage.Text; //1.5
            }
            XmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config"); //1.5
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile); //1.5
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
                SqlConnection Conexao = new SqlConnection("server=" + ServidorDB.Text + ";Initial Catalog=master;Trusted_Connection=yes;connection timeout=5");
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
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
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
                catch (Exception)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show("Erro ao conectar Servidor SQL: " +ServidorDB.Text, "Erro ao conectar Servidor SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Conexao.Close();
                    return;
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
            Destino.Text = (@DestinoDialogo.SelectedPath);
            //@Destino.Text = ("\"" + DestinoDialogo.SelectedPath + "\"");
            //Destino.Text = ("\"" + DestinoDialogo.SelectedPath + "\"");
        }

        private void extrair_Click(object sender, EventArgs e)
        {
            if (Destino.Text == "")
            {
                MessageBox.Show("Informe o caminho para extração", "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Destino.Text.Contains(" "))
            {
                MessageBox.Show("O Caminho selecionado possui espaço. Selecionar outro local.", "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("SqlPackage não localizado, clique 2x na caixa de texto e localize-o", "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (YMD.Checked)
            {
                //string DataGerador = DateTime.Now.ToString("yyyyMMdd");
                DataGerador = "_"+DateTime.Now.ToString("yyyyMMdd");
            }
            else
            {
                //string DataGerador = null;
                DataGerador = null;
            }
            if (Permissoes.Checked)
            {
                GetPerms = "/p:IgnorePermissions=False";
            }
            foreach (Object BaseSelecionada in BasesDACPAC.SelectedItems)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    string Run = (LocalSqlPackage.Text + " /a:Extract "+ GetPerms +" /ssn:" + ServidorDB.Text + " /sdn:" + BaseSelecionada + " /tf:" + @Destino.Text + "\\" + BaseSelecionada + DataGerador + ".dacpac");
                    //MessageBox.Show(Run, "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //System.Diagnostics.Process.Start(@Run);
                    Process exec = new Process();
                    exec.StartInfo.FileName = "cmd.exe";
                    exec.StartInfo.Arguments = "/c "+@Run;
                    exec.StartInfo.RedirectStandardOutput = false;
                    exec.StartInfo.UseShellExecute = false;
                    exec.StartInfo.CreateNoWindow = false;
                    exec.Start();
                    if (MultiExtrator.Checked)
                    {
                        exec.WaitForExit();
                    }
                }
                catch (Exception falha)
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                    MessageBox.Show(falha.Message, "Extrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (AbrirDiretorio.Checked)
            {
                Process.Start(@Destino.Text);
            }
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
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

        public string DataGerador { get; set; }


        public string GetPerms { get; set; }
    }
}
