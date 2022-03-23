namespace LanciaSystore
{
    partial class frmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.lstDatabase = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstMaster = new System.Windows.Forms.ListBox();
            this.btnAvvia = new System.Windows.Forms.Button();
            this.lstCommonFolder = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbodataSource = new System.Windows.Forms.ComboBox();
            this.btnAddMaster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "LeggiDb";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtDataSource
            // 
            this.txtDataSource.Location = new System.Drawing.Point(24, 22);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(193, 20);
            this.txtDataSource.TabIndex = 1;
            // 
            // lstDatabase
            // 
            this.lstDatabase.FormattingEnabled = true;
            this.lstDatabase.HorizontalScrollbar = true;
            this.lstDatabase.Location = new System.Drawing.Point(24, 85);
            this.lstDatabase.Name = "lstDatabase";
            this.lstDatabase.Size = new System.Drawing.Size(258, 238);
            this.lstDatabase.TabIndex = 2;
            this.lstDatabase.SelectedIndexChanged += new System.EventHandler(this.lstDatabase_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Master";
            // 
            // lstMaster
            // 
            this.lstMaster.FormattingEnabled = true;
            this.lstMaster.HorizontalScrollbar = true;
            this.lstMaster.Location = new System.Drawing.Point(327, 85);
            this.lstMaster.Name = "lstMaster";
            this.lstMaster.Size = new System.Drawing.Size(238, 238);
            this.lstMaster.TabIndex = 4;
            // 
            // btnAvvia
            // 
            this.btnAvvia.Location = new System.Drawing.Point(825, 300);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(75, 23);
            this.btnAvvia.TabIndex = 6;
            this.btnAvvia.Text = "Avvia";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            // 
            // lstCommonFolder
            // 
            this.lstCommonFolder.FormattingEnabled = true;
            this.lstCommonFolder.HorizontalScrollbar = true;
            this.lstCommonFolder.Location = new System.Drawing.Point(637, 85);
            this.lstCommonFolder.Name = "lstCommonFolder";
            this.lstCommonFolder.Size = new System.Drawing.Size(173, 238);
            this.lstCommonFolder.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CommonFolder";
            // 
            // cbodataSource
            // 
            this.cbodataSource.FormattingEnabled = true;
            this.cbodataSource.Location = new System.Drawing.Point(330, 22);
            this.cbodataSource.Name = "cbodataSource";
            this.cbodataSource.Size = new System.Drawing.Size(268, 21);
            this.cbodataSource.TabIndex = 9;
            // 
            // btnAddMaster
            // 
            this.btnAddMaster.Location = new System.Drawing.Point(579, 85);
            this.btnAddMaster.Name = "btnAddMaster";
            this.btnAddMaster.Size = new System.Drawing.Size(52, 79);
            this.btnAddMaster.TabIndex = 10;
            this.btnAddMaster.Text = "Add Master";
            this.btnAddMaster.UseVisualStyleBackColor = true;
            this.btnAddMaster.Click += new System.EventHandler(this.addMaster_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 342);
            this.Controls.Add(this.btnAddMaster);
            this.Controls.Add(this.cbodataSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstCommonFolder);
            this.Controls.Add(this.btnAvvia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstMaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDatabase);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.ListBox lstDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstMaster;
        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.ListBox lstCommonFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbodataSource;
        private System.Windows.Forms.Button btnAddMaster;
    }
}

