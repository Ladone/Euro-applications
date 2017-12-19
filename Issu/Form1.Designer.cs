namespace Issu
{
    partial class IndexForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            this.rbStatus = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограміToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataFileLbl = new System.Windows.Forms.Label();
            this.tmplEuroAddLbl = new System.Windows.Forms.Label();
            this.loadExcellFileBtn = new System.Windows.Forms.Button();
            this.loadDocFileBtn = new System.Windows.Forms.Button();
            this.controllGb = new System.Windows.Forms.GroupBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.excellFileLoadStatusPb = new System.Windows.Forms.PictureBox();
            this.docLoadStatusPb = new System.Windows.Forms.PictureBox();
            this.clearStatusConsoleLbl = new System.Windows.Forms.LinkLabel();
            this.qualificationRb = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.disciplinesCountLbl = new System.Windows.Forms.Label();
            this.numberOfGraduatesLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trainingDirectionRb = new System.Windows.Forms.RichTextBox();
            this.processPb = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.percentStatusLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.controllGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excellFileLoadStatusPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLoadStatusPb)).BeginInit();
            this.SuspendLayout();
            // 
            // rbStatus
            // 
            resources.ApplyResources(this.rbStatus, "rbStatus");
            this.rbStatus.Name = "rbStatus";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограміToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.вихідToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            resources.ApplyResources(this.файлToolStripMenuItem, "файлToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            resources.ApplyResources(this.вихідToolStripMenuItem, "вихідToolStripMenuItem");
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // оПрограміToolStripMenuItem
            // 
            this.оПрограміToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авторToolStripMenuItem});
            this.оПрограміToolStripMenuItem.Name = "оПрограміToolStripMenuItem";
            resources.ApplyResources(this.оПрограміToolStripMenuItem, "оПрограміToolStripMenuItem");
            // 
            // авторToolStripMenuItem
            // 
            this.авторToolStripMenuItem.Name = "авторToolStripMenuItem";
            resources.ApplyResources(this.авторToolStripMenuItem, "авторToolStripMenuItem");
            this.авторToolStripMenuItem.Click += new System.EventHandler(this.авторToolStripMenuItem_Click);
            // 
            // dataFileLbl
            // 
            resources.ApplyResources(this.dataFileLbl, "dataFileLbl");
            this.dataFileLbl.Name = "dataFileLbl";
            // 
            // tmplEuroAddLbl
            // 
            resources.ApplyResources(this.tmplEuroAddLbl, "tmplEuroAddLbl");
            this.tmplEuroAddLbl.Name = "tmplEuroAddLbl";
            // 
            // loadExcellFileBtn
            // 
            resources.ApplyResources(this.loadExcellFileBtn, "loadExcellFileBtn");
            this.loadExcellFileBtn.Name = "loadExcellFileBtn";
            this.loadExcellFileBtn.UseVisualStyleBackColor = true;
            this.loadExcellFileBtn.Click += new System.EventHandler(this.loadExcellFileBtn_Click);
            // 
            // loadDocFileBtn
            // 
            resources.ApplyResources(this.loadDocFileBtn, "loadDocFileBtn");
            this.loadDocFileBtn.Name = "loadDocFileBtn";
            this.loadDocFileBtn.UseVisualStyleBackColor = true;
            this.loadDocFileBtn.Click += new System.EventHandler(this.loadDocFileBtn_Click);
            // 
            // controllGb
            // 
            this.controllGb.Controls.Add(this.generateBtn);
            this.controllGb.Controls.Add(this.loadDocFileBtn);
            this.controllGb.Controls.Add(this.excellFileLoadStatusPb);
            this.controllGb.Controls.Add(this.loadExcellFileBtn);
            this.controllGb.Controls.Add(this.dataFileLbl);
            this.controllGb.Controls.Add(this.tmplEuroAddLbl);
            this.controllGb.Controls.Add(this.docLoadStatusPb);
            resources.ApplyResources(this.controllGb, "controllGb");
            this.controllGb.Name = "controllGb";
            this.controllGb.TabStop = false;
            // 
            // generateBtn
            // 
            resources.ApplyResources(this.generateBtn, "generateBtn");
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // excellFileLoadStatusPb
            // 
            this.excellFileLoadStatusPb.Image = global::Issu.Properties.Resources.Off;
            resources.ApplyResources(this.excellFileLoadStatusPb, "excellFileLoadStatusPb");
            this.excellFileLoadStatusPb.Name = "excellFileLoadStatusPb";
            this.excellFileLoadStatusPb.TabStop = false;
            // 
            // docLoadStatusPb
            // 
            this.docLoadStatusPb.Image = global::Issu.Properties.Resources.Off;
            resources.ApplyResources(this.docLoadStatusPb, "docLoadStatusPb");
            this.docLoadStatusPb.Name = "docLoadStatusPb";
            this.docLoadStatusPb.TabStop = false;
            // 
            // clearStatusConsoleLbl
            // 
            this.clearStatusConsoleLbl.ActiveLinkColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.clearStatusConsoleLbl, "clearStatusConsoleLbl");
            this.clearStatusConsoleLbl.Name = "clearStatusConsoleLbl";
            this.clearStatusConsoleLbl.TabStop = true;
            this.clearStatusConsoleLbl.VisitedLinkColor = System.Drawing.Color.Blue;
            this.clearStatusConsoleLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearStatusConsoleLbl_LinkClicked);
            // 
            // qualificationRb
            // 
            this.qualificationRb.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.qualificationRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.qualificationRb.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.qualificationRb.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.qualificationRb, "qualificationRb");
            this.qualificationRb.Name = "qualificationRb";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // disciplinesCountLbl
            // 
            resources.ApplyResources(this.disciplinesCountLbl, "disciplinesCountLbl");
            this.disciplinesCountLbl.Name = "disciplinesCountLbl";
            // 
            // numberOfGraduatesLbl
            // 
            resources.ApplyResources(this.numberOfGraduatesLbl, "numberOfGraduatesLbl");
            this.numberOfGraduatesLbl.Name = "numberOfGraduatesLbl";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // trainingDirectionRb
            // 
            this.trainingDirectionRb.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.trainingDirectionRb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trainingDirectionRb.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.trainingDirectionRb, "trainingDirectionRb");
            this.trainingDirectionRb.Name = "trainingDirectionRb";
            // 
            // processPb
            // 
            resources.ApplyResources(this.processPb, "processPb");
            this.processPb.Name = "processPb";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // percentStatusLbl
            // 
            resources.ApplyResources(this.percentStatusLbl, "percentStatusLbl");
            this.percentStatusLbl.BackColor = System.Drawing.Color.Transparent;
            this.percentStatusLbl.Name = "percentStatusLbl";
            // 
            // IndexForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.percentStatusLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.processPb);
            this.Controls.Add(this.trainingDirectionRb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberOfGraduatesLbl);
            this.Controls.Add(this.disciplinesCountLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clearStatusConsoleLbl);
            this.Controls.Add(this.qualificationRb);
            this.Controls.Add(this.controllGb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IndexForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.controllGb.ResumeLayout(false);
            this.controllGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.excellFileLoadStatusPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLoadStatusPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограміToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.PictureBox excellFileLoadStatusPb;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Label dataFileLbl;
        private System.Windows.Forms.Label tmplEuroAddLbl;
        private System.Windows.Forms.PictureBox docLoadStatusPb;
        private System.Windows.Forms.Button loadExcellFileBtn;
        private System.Windows.Forms.Button loadDocFileBtn;
        private System.Windows.Forms.GroupBox controllGb;
        private System.Windows.Forms.LinkLabel clearStatusConsoleLbl;
        private System.Windows.Forms.RichTextBox qualificationRb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label disciplinesCountLbl;
        private System.Windows.Forms.Label numberOfGraduatesLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox trainingDirectionRb;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.ProgressBar processPb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label percentStatusLbl;
    }
}

