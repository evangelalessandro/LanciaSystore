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
			this.btnDebug = new System.Windows.Forms.Button();
			this.btnDbUpdate = new System.Windows.Forms.Button();
			this.btnLeggiDbCombo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(297, 27);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 0;
			this.button1.Text = "LeggiDb";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtDataSource
			// 
			this.txtDataSource.Location = new System.Drawing.Point(32, 27);
			this.txtDataSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDataSource.Name = "txtDataSource";
			this.txtDataSource.Size = new System.Drawing.Size(256, 22);
			this.txtDataSource.TabIndex = 1;
			// 
			// lstDatabase
			// 
			this.lstDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)));
			this.lstDatabase.FormattingEnabled = true;
			this.lstDatabase.HorizontalScrollbar = true;
			this.lstDatabase.ItemHeight = 16;
			this.lstDatabase.Location = new System.Drawing.Point(32, 105);
			this.lstDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.lstDatabase.Name = "lstDatabase";
			this.lstDatabase.Size = new System.Drawing.Size(343, 244);
			this.lstDatabase.TabIndex = 2;
			this.lstDatabase.SelectedIndexChanged += new System.EventHandler(this.lstDatabase_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 81);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Database";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(436, 81);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Master";
			// 
			// lstMaster
			// 
			this.lstMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lstMaster.FormattingEnabled = true;
			this.lstMaster.HorizontalScrollbar = true;
			this.lstMaster.ItemHeight = 16;
			this.lstMaster.Location = new System.Drawing.Point(436, 105);
			this.lstMaster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.lstMaster.Name = "lstMaster";
			this.lstMaster.Size = new System.Drawing.Size(181, 244);
			this.lstMaster.TabIndex = 4;
			// 
			// btnAvvia
			// 
			this.btnAvvia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAvvia.Location = new System.Drawing.Point(975, 369);
			this.btnAvvia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAvvia.Name = "btnAvvia";
			this.btnAvvia.Size = new System.Drawing.Size(100, 30);
			this.btnAvvia.TabIndex = 6;
			this.btnAvvia.Text = "Avvia";
			this.btnAvvia.UseVisualStyleBackColor = true;
			this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
			// 
			// lstCommonFolder
			// 
			this.lstCommonFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lstCommonFolder.FormattingEnabled = true;
			this.lstCommonFolder.HorizontalScrollbar = true;
			this.lstCommonFolder.ItemHeight = 16;
			this.lstCommonFolder.Location = new System.Drawing.Point(724, 105);
			this.lstCommonFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.lstCommonFolder.Name = "lstCommonFolder";
			this.lstCommonFolder.Size = new System.Drawing.Size(229, 292);
			this.lstCommonFolder.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(720, 85);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "CommonFolder";
			// 
			// cbodataSource
			// 
			this.cbodataSource.FormattingEnabled = true;
			this.cbodataSource.Location = new System.Drawing.Point(407, 27);
			this.cbodataSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cbodataSource.Name = "cbodataSource";
			this.cbodataSource.Size = new System.Drawing.Size(356, 24);
			this.cbodataSource.TabIndex = 9;
			// 
			// btnAddMaster
			// 
			this.btnAddMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddMaster.Location = new System.Drawing.Point(637, 105);
			this.btnAddMaster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAddMaster.Name = "btnAddMaster";
			this.btnAddMaster.Size = new System.Drawing.Size(69, 97);
			this.btnAddMaster.TabIndex = 10;
			this.btnAddMaster.Text = "Add Master";
			this.btnAddMaster.UseVisualStyleBackColor = true;
			this.btnAddMaster.Click += new System.EventHandler(this.addMaster_Click);
			// 
			// btnDebug
			// 
			this.btnDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDebug.Location = new System.Drawing.Point(873, 11);
			this.btnDebug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDebug.Name = "btnDebug";
			this.btnDebug.Size = new System.Drawing.Size(201, 42);
			this.btnDebug.TabIndex = 11;
			this.btnDebug.Text = "Debug  = 1";
			this.btnDebug.UseVisualStyleBackColor = true;
			this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
			// 
			// btnDbUpdate
			// 
			this.btnDbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDbUpdate.Location = new System.Drawing.Point(975, 105);
			this.btnDbUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDbUpdate.Name = "btnDbUpdate";
			this.btnDbUpdate.Size = new System.Drawing.Size(100, 30);
			this.btnDbUpdate.TabIndex = 12;
			this.btnDbUpdate.Text = "dbUpdate";
			this.btnDbUpdate.UseVisualStyleBackColor = true;
			this.btnDbUpdate.Click += new System.EventHandler(this.btnDbUpdate_Click);
			// 
			// btnLeggiDbCombo
			// 
			this.btnLeggiDbCombo.Location = new System.Drawing.Point(765, 26);
			this.btnLeggiDbCombo.Margin = new System.Windows.Forms.Padding(4);
			this.btnLeggiDbCombo.Name = "btnLeggiDbCombo";
			this.btnLeggiDbCombo.Size = new System.Drawing.Size(100, 28);
			this.btnLeggiDbCombo.TabIndex = 13;
			this.btnLeggiDbCombo.Text = "LeggiDb";
			this.btnLeggiDbCombo.UseVisualStyleBackColor = true;
			this.btnLeggiDbCombo.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1087, 414);
			this.Controls.Add(this.btnLeggiDbCombo);
			this.Controls.Add(this.btnDbUpdate);
			this.Controls.Add(this.btnDebug);
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
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "frmMain";
			this.Text = "Systore Launcher";
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
		private System.Windows.Forms.Button btnDebug;
		private System.Windows.Forms.Button btnDbUpdate;
		private System.Windows.Forms.Button btnLeggiDbCombo;
	}
}

