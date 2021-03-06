﻿namespace Gerador_de_DACPAC
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.conectar = new System.Windows.Forms.Button();
            this.SaveAs = new System.Windows.Forms.Button();
            this.AbrirDiretorio = new System.Windows.Forms.CheckBox();
            this.extrair = new System.Windows.Forms.Button();
            this.fechar = new System.Windows.Forms.Button();
            this.ServidorDB = new System.Windows.Forms.TextBox();
            this.Destino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BasesDACPAC = new System.Windows.Forms.ListBox();
            this.DestinoDialogo = new System.Windows.Forms.FolderBrowserDialog();
            this.LocalizarSqlPackage = new System.Windows.Forms.OpenFileDialog();
            this.LocalSqlPackage = new System.Windows.Forms.TextBox();
            this.YMD = new System.Windows.Forms.CheckBox();
            this.Permissoes = new System.Windows.Forms.CheckBox();
            this.MultiExtrator = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(163, 29);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(66, 27);
            this.conectar.TabIndex = 0;
            this.conectar.Text = "Conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Location = new System.Drawing.Point(163, 77);
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(66, 27);
            this.SaveAs.TabIndex = 1;
            this.SaveAs.Text = "...";
            this.SaveAs.UseVisualStyleBackColor = true;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // AbrirDiretorio
            // 
            this.AbrirDiretorio.AutoSize = true;
            this.AbrirDiretorio.Checked = true;
            this.AbrirDiretorio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AbrirDiretorio.Location = new System.Drawing.Point(239, 82);
            this.AbrirDiretorio.Name = "AbrirDiretorio";
            this.AbrirDiretorio.Size = new System.Drawing.Size(15, 14);
            this.AbrirDiretorio.TabIndex = 2;
            this.AbrirDiretorio.UseVisualStyleBackColor = true;
            // 
            // extrair
            // 
            this.extrair.Location = new System.Drawing.Point(41, 243);
            this.extrair.Name = "extrair";
            this.extrair.Size = new System.Drawing.Size(60, 25);
            this.extrair.TabIndex = 4;
            this.extrair.Text = "Extrair";
            this.extrair.UseVisualStyleBackColor = true;
            this.extrair.Click += new System.EventHandler(this.extrair_Click);
            // 
            // fechar
            // 
            this.fechar.Location = new System.Drawing.Point(163, 243);
            this.fechar.Name = "fechar";
            this.fechar.Size = new System.Drawing.Size(56, 25);
            this.fechar.TabIndex = 5;
            this.fechar.Text = "Fechar";
            this.fechar.UseVisualStyleBackColor = true;
            this.fechar.Click += new System.EventHandler(this.fechar_Click);
            // 
            // ServidorDB
            // 
            this.ServidorDB.Location = new System.Drawing.Point(12, 33);
            this.ServidorDB.Name = "ServidorDB";
            this.ServidorDB.Size = new System.Drawing.Size(145, 20);
            this.ServidorDB.TabIndex = 6;
            this.ServidorDB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Destino
            // 
            this.Destino.Location = new System.Drawing.Point(12, 79);
            this.Destino.Name = "Destino";
            this.Destino.Size = new System.Drawing.Size(145, 20);
            this.Destino.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selecione a base que deseja extrair o DACPAC";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // BasesDACPAC
            // 
            this.BasesDACPAC.FormattingEnabled = true;
            this.BasesDACPAC.Location = new System.Drawing.Point(13, 138);
            this.BasesDACPAC.Name = "BasesDACPAC";
            this.BasesDACPAC.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.BasesDACPAC.Size = new System.Drawing.Size(241, 95);
            this.BasesDACPAC.Sorted = true;
            this.BasesDACPAC.TabIndex = 11;
            // 
            // DestinoDialogo
            // 
            this.DestinoDialogo.Description = "Utilizar diretório que NÃO contenha espaço no nome. Ex. \"Nova Pasta\"";
            // 
            // LocalSqlPackage
            // 
            this.LocalSqlPackage.Location = new System.Drawing.Point(179, 3);
            this.LocalSqlPackage.Name = "LocalSqlPackage";
            this.LocalSqlPackage.Size = new System.Drawing.Size(75, 20);
            this.LocalSqlPackage.TabIndex = 12;
            this.LocalSqlPackage.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.LocalSqlPackage.DoubleClick += new System.EventHandler(this.LocalSqlPackage_DoubleClick);
            // 
            // YMD
            // 
            this.YMD.AutoSize = true;
            this.YMD.Location = new System.Drawing.Point(116, 6);
            this.YMD.Name = "YMD";
            this.YMD.Size = new System.Drawing.Size(50, 17);
            this.YMD.TabIndex = 13;
            this.YMD.Text = "YMD";
            this.YMD.UseVisualStyleBackColor = true;
            // 
            // Permissoes
            // 
            this.Permissoes.AutoSize = true;
            this.Permissoes.Location = new System.Drawing.Point(62, 5);
            this.Permissoes.Name = "Permissoes";
            this.Permissoes.Size = new System.Drawing.Size(50, 17);
            this.Permissoes.TabIndex = 14;
            this.Permissoes.Text = "Perm";
            this.Permissoes.UseVisualStyleBackColor = true;
            // 
            // MultiExtrator
            // 
            this.MultiExtrator.AutoSize = true;
            this.MultiExtrator.Location = new System.Drawing.Point(239, 120);
            this.MultiExtrator.Name = "MultiExtrator";
            this.MultiExtrator.Size = new System.Drawing.Size(15, 14);
            this.MultiExtrator.TabIndex = 15;
            this.MultiExtrator.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 273);
            this.Controls.Add(this.MultiExtrator);
            this.Controls.Add(this.Permissoes);
            this.Controls.Add(this.YMD);
            this.Controls.Add(this.LocalSqlPackage);
            this.Controls.Add(this.BasesDACPAC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Destino);
            this.Controls.Add(this.ServidorDB);
            this.Controls.Add(this.fechar);
            this.Controls.Add(this.extrair);
            this.Controls.Add(this.AbrirDiretorio);
            this.Controls.Add(this.SaveAs);
            this.Controls.Add(this.conectar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de DACPAC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.Button SaveAs;
        private System.Windows.Forms.CheckBox AbrirDiretorio;
        private System.Windows.Forms.Button extrair;
        private System.Windows.Forms.Button fechar;
        private System.Windows.Forms.TextBox ServidorDB;
        private System.Windows.Forms.TextBox Destino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox BasesDACPAC;
        private System.Windows.Forms.FolderBrowserDialog DestinoDialogo;
        public System.Windows.Forms.OpenFileDialog LocalizarSqlPackage;
        private System.Windows.Forms.TextBox LocalSqlPackage;
        private System.Windows.Forms.CheckBox YMD;
        private System.Windows.Forms.CheckBox Permissoes;
        private System.Windows.Forms.CheckBox MultiExtrator;
    }
}

