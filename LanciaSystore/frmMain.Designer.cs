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
			button1 = new System.Windows.Forms.Button();
			txtDataSource = new System.Windows.Forms.TextBox();
			lstDatabase = new System.Windows.Forms.ListBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			lstMaster = new System.Windows.Forms.ListBox();
			btnAvvia = new System.Windows.Forms.Button();
			lstCommonFolder = new System.Windows.Forms.ListBox();
			label3 = new System.Windows.Forms.Label();
			cbodataSource = new System.Windows.Forms.ComboBox();
			btnAddMaster = new System.Windows.Forms.Button();
			btnDebug = new System.Windows.Forms.Button();
			btnDbUpdate = new System.Windows.Forms.Button();
			btnLeggiDbCombo = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			txtDirectory = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			button3 = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new System.Drawing.Point(297, 65);
			button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(101, 35);
			button1.TabIndex = 0;
			button1.Text = "LeggiDb";
			button1.UseVisualStyleBackColor = true;
			button1.Click += btnConnect_Click;
			// 
			// txtDataSource
			// 
			txtDataSource.Location = new System.Drawing.Point(32, 65);
			txtDataSource.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			txtDataSource.Name = "txtDataSource";
			txtDataSource.Size = new System.Drawing.Size(255, 27);
			txtDataSource.TabIndex = 1;
			// 
			// lstDatabase
			// 
			lstDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lstDatabase.FormattingEnabled = true;
			lstDatabase.HorizontalScrollbar = true;
			lstDatabase.ItemHeight = 20;
			lstDatabase.Location = new System.Drawing.Point(32, 131);
			lstDatabase.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			lstDatabase.Name = "lstDatabase";
			lstDatabase.Size = new System.Drawing.Size(343, 304);
			lstDatabase.TabIndex = 2;
			lstDatabase.SelectedIndexChanged += lstDatabase_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(32, 101);
			label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 20);
			label1.TabIndex = 3;
			label1.Text = "Database";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(437, 101);
			label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(54, 20);
			label2.TabIndex = 5;
			label2.Text = "Master";
			// 
			// lstMaster
			// 
			lstMaster.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lstMaster.FormattingEnabled = true;
			lstMaster.HorizontalScrollbar = true;
			lstMaster.ItemHeight = 20;
			lstMaster.Location = new System.Drawing.Point(437, 131);
			lstMaster.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			lstMaster.Name = "lstMaster";
			lstMaster.Size = new System.Drawing.Size(181, 304);
			lstMaster.TabIndex = 4;
			// 
			// btnAvvia
			// 
			btnAvvia.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnAvvia.Location = new System.Drawing.Point(975, 461);
			btnAvvia.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			btnAvvia.Name = "btnAvvia";
			btnAvvia.Size = new System.Drawing.Size(101, 37);
			btnAvvia.TabIndex = 6;
			btnAvvia.Text = "Avvia";
			btnAvvia.UseVisualStyleBackColor = true;
			btnAvvia.Click += btnAvvia_Click;
			// 
			// lstCommonFolder
			// 
			lstCommonFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			lstCommonFolder.FormattingEnabled = true;
			lstCommonFolder.HorizontalScrollbar = true;
			lstCommonFolder.ItemHeight = 20;
			lstCommonFolder.Location = new System.Drawing.Point(725, 131);
			lstCommonFolder.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			lstCommonFolder.Name = "lstCommonFolder";
			lstCommonFolder.Size = new System.Drawing.Size(229, 364);
			lstCommonFolder.TabIndex = 7;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(720, 107);
			label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(112, 20);
			label3.TabIndex = 8;
			label3.Text = "CommonFolder";
			// 
			// cbodataSource
			// 
			cbodataSource.FormattingEnabled = true;
			cbodataSource.Location = new System.Drawing.Point(407, 65);
			cbodataSource.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			cbodataSource.Name = "cbodataSource";
			cbodataSource.Size = new System.Drawing.Size(356, 28);
			cbodataSource.TabIndex = 9;
			// 
			// btnAddMaster
			// 
			btnAddMaster.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnAddMaster.Location = new System.Drawing.Point(637, 131);
			btnAddMaster.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			btnAddMaster.Name = "btnAddMaster";
			btnAddMaster.Size = new System.Drawing.Size(69, 121);
			btnAddMaster.TabIndex = 10;
			btnAddMaster.Text = "Add Master";
			btnAddMaster.UseVisualStyleBackColor = true;
			btnAddMaster.Click += addMaster_Click;
			// 
			// btnDebug
			// 
			btnDebug.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDebug.Location = new System.Drawing.Point(873, 13);
			btnDebug.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			btnDebug.Name = "btnDebug";
			btnDebug.Size = new System.Drawing.Size(201, 52);
			btnDebug.TabIndex = 11;
			btnDebug.Text = "Debug  = 1";
			btnDebug.UseVisualStyleBackColor = true;
			btnDebug.Click += btnDebug_Click;
			// 
			// btnDbUpdate
			// 
			btnDbUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDbUpdate.Location = new System.Drawing.Point(975, 131);
			btnDbUpdate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			btnDbUpdate.Name = "btnDbUpdate";
			btnDbUpdate.Size = new System.Drawing.Size(101, 37);
			btnDbUpdate.TabIndex = 12;
			btnDbUpdate.Text = "dbUpdate";
			btnDbUpdate.UseVisualStyleBackColor = true;
			btnDbUpdate.Click += btnDbUpdate_Click;
			// 
			// btnLeggiDbCombo
			// 
			btnLeggiDbCombo.Location = new System.Drawing.Point(765, 64);
			btnLeggiDbCombo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			btnLeggiDbCombo.Name = "btnLeggiDbCombo";
			btnLeggiDbCombo.Size = new System.Drawing.Size(101, 35);
			btnLeggiDbCombo.TabIndex = 13;
			btnLeggiDbCombo.Text = "LeggiDb";
			btnLeggiDbCombo.UseVisualStyleBackColor = true;
			btnLeggiDbCombo.Click += button2_Click;
			// 
			// button2
			// 
			button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button2.Location = new System.Drawing.Point(971, 179);
			button2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(101, 73);
			button2.TabIndex = 14;
			button2.Text = "Controlla file scompagnati";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click_1;
			// 
			// txtDirectory
			// 
			txtDirectory.Location = new System.Drawing.Point(123, 19);
			txtDirectory.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			txtDirectory.Name = "txtDirectory";
			txtDirectory.Size = new System.Drawing.Size(731, 27);
			txtDirectory.TabIndex = 15;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(32, 23);
			label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(73, 20);
			label4.TabIndex = 16;
			label4.Text = "Directory:";
			// 
			// button3
			// 
			button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			button3.Location = new System.Drawing.Point(971, 262);
			button3.Margin = new System.Windows.Forms.Padding(5);
			button3.Name = "button3";
			button3.Size = new System.Drawing.Size(101, 73);
			button3.TabIndex = 17;
			button3.Text = "Leggi file Common";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1087, 517);
			Controls.Add(button3);
			Controls.Add(label4);
			Controls.Add(txtDirectory);
			Controls.Add(button2);
			Controls.Add(btnLeggiDbCombo);
			Controls.Add(btnDbUpdate);
			Controls.Add(btnDebug);
			Controls.Add(btnAddMaster);
			Controls.Add(cbodataSource);
			Controls.Add(label3);
			Controls.Add(lstCommonFolder);
			Controls.Add(btnAvvia);
			Controls.Add(label2);
			Controls.Add(lstMaster);
			Controls.Add(label1);
			Controls.Add(lstDatabase);
			Controls.Add(txtDataSource);
			Controls.Add(button1);
			Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			Name = "frmMain";
			Text = "Systore Launcher";
			Load += frmMain_Load;
			ResumeLayout(false);
			PerformLayout();
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
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtDirectory;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button3;
	}
}

