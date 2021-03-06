﻿namespace CountLines
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.tbIgnoreList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRootDir = new System.Windows.Forms.TextBox();
            this.btnRootDir = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTotalFiles = new System.Windows.Forms.Label();
            this.lbTotalLines = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbExtensions = new System.Windows.Forms.TextBox();
            this.tbFoundFiles = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnChooseIgnoreFile = new System.Windows.Forms.Button();
            this.tbIgnoreFileConfig = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbAllLines = new System.Windows.Forms.RadioButton();
            this.rbIgnoreEmptyLines = new System.Windows.Forms.RadioButton();
            this.rbIgnoreEmptyOrWhitespaceLines = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.numIgnoreRules = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Extensions (without dot, comma separated):";
            // 
            // tbIgnoreList
            // 
            this.tbIgnoreList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbIgnoreList.Location = new System.Drawing.Point(11, 155);
            this.tbIgnoreList.Multiline = true;
            this.tbIgnoreList.Name = "tbIgnoreList";
            this.tbIgnoreList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbIgnoreList.Size = new System.Drawing.Size(526, 181);
            this.tbIgnoreList.TabIndex = 2;
            this.tbIgnoreList.Text = resources.GetString("tbIgnoreList.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ignore List:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Root/Project Path:";
            // 
            // tbRootDir
            // 
            this.tbRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootDir.Location = new System.Drawing.Point(11, 29);
            this.tbRootDir.Name = "tbRootDir";
            this.tbRootDir.Size = new System.Drawing.Size(484, 20);
            this.tbRootDir.TabIndex = 5;
            // 
            // btnRootDir
            // 
            this.btnRootDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRootDir.Location = new System.Drawing.Point(501, 29);
            this.btnRootDir.Name = "btnRootDir";
            this.btnRootDir.Size = new System.Drawing.Size(36, 20);
            this.btnRootDir.TabIndex = 6;
            this.btnRootDir.Text = "...";
            this.toolTip1.SetToolTip(this.btnRootDir, "Take a file, the containting dir will be selected");
            this.btnRootDir.UseVisualStyleBackColor = true;
            this.btnRootDir.Click += new System.EventHandler(this.btnRootDir_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 456);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(175, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progBar
            // 
            this.progBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBar.Location = new System.Drawing.Point(11, 342);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(526, 23);
            this.progBar.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total Files:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numIgnoreRules);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbInfo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbTotalFiles);
            this.groupBox1.Controls.Add(this.lbTotalLines);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(11, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 81);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(70, 63);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(13, 13);
            this.lbInfo.TabIndex = 15;
            this.lbInfo.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Info:";
            // 
            // lbTotalFiles
            // 
            this.lbTotalFiles.AutoSize = true;
            this.lbTotalFiles.Location = new System.Drawing.Point(70, 21);
            this.lbTotalFiles.Name = "lbTotalFiles";
            this.lbTotalFiles.Size = new System.Drawing.Size(25, 13);
            this.lbTotalFiles.TabIndex = 13;
            this.lbTotalFiles.Text = "000";
            // 
            // lbTotalLines
            // 
            this.lbTotalLines.AutoSize = true;
            this.lbTotalLines.Location = new System.Drawing.Point(70, 42);
            this.lbTotalLines.Name = "lbTotalLines";
            this.lbTotalLines.Size = new System.Drawing.Size(25, 13);
            this.lbTotalLines.TabIndex = 12;
            this.lbTotalLines.Text = "000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total Lines:";
            // 
            // tbExtensions
            // 
            this.tbExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExtensions.Location = new System.Drawing.Point(12, 73);
            this.tbExtensions.Name = "tbExtensions";
            this.tbExtensions.Size = new System.Drawing.Size(525, 20);
            this.tbExtensions.TabIndex = 13;
            // 
            // tbFoundFiles
            // 
            this.tbFoundFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFoundFiles.Location = new System.Drawing.Point(11, 496);
            this.tbFoundFiles.Multiline = true;
            this.tbFoundFiles.Name = "tbFoundFiles";
            this.tbFoundFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFoundFiles.Size = new System.Drawing.Size(526, 52);
            this.tbFoundFiles.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Found Files:";
            // 
            // btnChooseIgnoreFile
            // 
            this.btnChooseIgnoreFile.Location = new System.Drawing.Point(501, 97);
            this.btnChooseIgnoreFile.Name = "btnChooseIgnoreFile";
            this.btnChooseIgnoreFile.Size = new System.Drawing.Size(36, 20);
            this.btnChooseIgnoreFile.TabIndex = 17;
            this.btnChooseIgnoreFile.Text = "...";
            this.btnChooseIgnoreFile.UseVisualStyleBackColor = true;
            this.btnChooseIgnoreFile.Click += new System.EventHandler(this.btnChooseIgnoreFile_Click);
            // 
            // tbIgnoreFileConfig
            // 
            this.tbIgnoreFileConfig.Location = new System.Drawing.Point(75, 97);
            this.tbIgnoreFileConfig.Name = "tbIgnoreFileConfig";
            this.tbIgnoreFileConfig.Size = new System.Drawing.Size(420, 20);
            this.tbIgnoreFileConfig.TabIndex = 18;
            this.toolTip1.SetToolTip(this.tbIgnoreFileConfig, resources.GetString("tbIgnoreFileConfig.ToolTip"));
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ignore file:";
            // 
            // rbAllLines
            // 
            this.rbAllLines.AutoSize = true;
            this.rbAllLines.Checked = true;
            this.rbAllLines.Location = new System.Drawing.Point(75, 123);
            this.rbAllLines.Name = "rbAllLines";
            this.rbAllLines.Size = new System.Drawing.Size(59, 17);
            this.rbAllLines.TabIndex = 20;
            this.rbAllLines.TabStop = true;
            this.rbAllLines.Text = "all lines";
            this.rbAllLines.UseVisualStyleBackColor = true;
            // 
            // rbIgnoreEmptyLines
            // 
            this.rbIgnoreEmptyLines.AutoSize = true;
            this.rbIgnoreEmptyLines.Location = new System.Drawing.Point(140, 123);
            this.rbIgnoreEmptyLines.Name = "rbIgnoreEmptyLines";
            this.rbIgnoreEmptyLines.Size = new System.Drawing.Size(109, 17);
            this.rbIgnoreEmptyLines.TabIndex = 21;
            this.rbIgnoreEmptyLines.Text = "ignore empty lines";
            this.rbIgnoreEmptyLines.UseVisualStyleBackColor = true;
            // 
            // rbIgnoreEmptyOrWhitespaceLines
            // 
            this.rbIgnoreEmptyOrWhitespaceLines.AutoSize = true;
            this.rbIgnoreEmptyOrWhitespaceLines.Location = new System.Drawing.Point(255, 123);
            this.rbIgnoreEmptyOrWhitespaceLines.Name = "rbIgnoreEmptyOrWhitespaceLines";
            this.rbIgnoreEmptyOrWhitespaceLines.Size = new System.Drawing.Size(200, 17);
            this.rbIgnoreEmptyOrWhitespaceLines.TabIndex = 22;
            this.rbIgnoreEmptyOrWhitespaceLines.Text = "ignore empty or only whitespace lines";
            this.rbIgnoreEmptyOrWhitespaceLines.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Ignore Rules:";
            // 
            // numIgnoreRules
            // 
            this.numIgnoreRules.AutoSize = true;
            this.numIgnoreRules.Location = new System.Drawing.Point(359, 21);
            this.numIgnoreRules.Name = "numIgnoreRules";
            this.numIgnoreRules.Size = new System.Drawing.Size(13, 13);
            this.numIgnoreRules.TabIndex = 17;
            this.numIgnoreRules.Text = "--";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 560);
            this.Controls.Add(this.rbIgnoreEmptyOrWhitespaceLines);
            this.Controls.Add(this.rbIgnoreEmptyLines);
            this.Controls.Add(this.rbAllLines);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbIgnoreFileConfig);
            this.Controls.Add(this.btnChooseIgnoreFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbFoundFiles);
            this.Controls.Add(this.tbExtensions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRootDir);
            this.Controls.Add(this.tbRootDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIgnoreList);
            this.Controls.Add(this.label1);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "CountLines";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIgnoreList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRootDir;
        private System.Windows.Forms.Button btnRootDir;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTotalFiles;
        private System.Windows.Forms.Label lbTotalLines;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbExtensions;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbFoundFiles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnChooseIgnoreFile;
        private System.Windows.Forms.TextBox tbIgnoreFileConfig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbAllLines;
        private System.Windows.Forms.RadioButton rbIgnoreEmptyLines;
        private System.Windows.Forms.RadioButton rbIgnoreEmptyOrWhitespaceLines;
        private System.Windows.Forms.Label numIgnoreRules;
        private System.Windows.Forms.Label label9;
    }
}

