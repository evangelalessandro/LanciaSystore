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
			btnControllaFileScompagnati = new System.Windows.Forms.Button();
			txtDirectory = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			btnLeggiFileCommon = new System.Windows.Forms.Button();
			btnRemove = new System.Windows.Forms.Button();
			btnSearchTraslation = new System.Windows.Forms.Button();
			btnTraduzioniPkt = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new System.Drawing.Point(260, 49);
			button1.Margin = new System.Windows.Forms.Padding(4);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(88, 26);
			button1.TabIndex = 0;
			button1.Text = "LeggiDb";
			button1.UseVisualStyleBackColor = true;
			button1.Click += btnConnect_Click;
			// 
			// txtDataSource
			// 
			txtDataSource.Location = new System.Drawing.Point(28, 49);
			txtDataSource.Margin = new System.Windows.Forms.Padding(4);
			txtDataSource.Name = "txtDataSource";
			txtDataSource.Size = new System.Drawing.Size(224, 23);
			txtDataSource.TabIndex = 1;
			// 
			// lstDatabase
			// 
			lstDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lstDatabase.FormattingEnabled = true;
			lstDatabase.HorizontalScrollbar = true;
			lstDatabase.ItemHeight = 15;
			lstDatabase.Location = new System.Drawing.Point(28, 98);
			lstDatabase.Margin = new System.Windows.Forms.Padding(4);
			lstDatabase.Name = "lstDatabase";
			lstDatabase.Size = new System.Drawing.Size(301, 229);
			lstDatabase.TabIndex = 2;
			lstDatabase.SelectedIndexChanged += lstDatabase_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(28, 76);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(55, 15);
			label1.TabIndex = 3;
			label1.Text = "Database";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(382, 76);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(43, 15);
			label2.TabIndex = 5;
			label2.Text = "Master";
			// 
			// lstMaster
			// 
			lstMaster.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lstMaster.FormattingEnabled = true;
			lstMaster.HorizontalScrollbar = true;
			lstMaster.ItemHeight = 15;
			lstMaster.Location = new System.Drawing.Point(382, 98);
			lstMaster.Margin = new System.Windows.Forms.Padding(4);
			lstMaster.Name = "lstMaster";
			lstMaster.Size = new System.Drawing.Size(206, 229);
			lstMaster.TabIndex = 4;
			// 
			// btnAvvia
			// 
			btnAvvia.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			btnAvvia.Location = new System.Drawing.Point(899, 354);
			btnAvvia.Margin = new System.Windows.Forms.Padding(4);
			btnAvvia.Name = "btnAvvia";
			btnAvvia.Size = new System.Drawing.Size(88, 28);
			btnAvvia.TabIndex = 6;
			btnAvvia.Text = "Avvia";
			btnAvvia.UseVisualStyleBackColor = true;
			btnAvvia.Click += btnAvvia_Click;
			// 
			// lstCommonFolder
			// 
			lstCommonFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			lstCommonFolder.FormattingEnabled = true;
			lstCommonFolder.HorizontalScrollbar = true;
			lstCommonFolder.ItemHeight = 15;
			lstCommonFolder.Location = new System.Drawing.Point(681, 98);
			lstCommonFolder.Margin = new System.Windows.Forms.Padding(4);
			lstCommonFolder.Name = "lstCommonFolder";
			lstCommonFolder.Size = new System.Drawing.Size(201, 259);
			lstCommonFolder.TabIndex = 7;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(677, 80);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(91, 15);
			label3.TabIndex = 8;
			label3.Text = "CommonFolder";
			// 
			// cbodataSource
			// 
			cbodataSource.FormattingEnabled = true;
			cbodataSource.Location = new System.Drawing.Point(356, 49);
			cbodataSource.Margin = new System.Windows.Forms.Padding(4);
			cbodataSource.Name = "cbodataSource";
			cbodataSource.Size = new System.Drawing.Size(312, 23);
			cbodataSource.TabIndex = 9;
			// 
			// btnAddMaster
			// 
			btnAddMaster.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnAddMaster.Location = new System.Drawing.Point(604, 98);
			btnAddMaster.Margin = new System.Windows.Forms.Padding(4);
			btnAddMaster.Name = "btnAddMaster";
			btnAddMaster.Size = new System.Drawing.Size(60, 91);
			btnAddMaster.TabIndex = 10;
			btnAddMaster.Text = "Add Master";
			btnAddMaster.UseVisualStyleBackColor = true;
			btnAddMaster.Click += addMaster_Click;
			// 
			// btnDebug
			// 
			btnDebug.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDebug.Location = new System.Drawing.Point(811, 10);
			btnDebug.Margin = new System.Windows.Forms.Padding(4);
			btnDebug.Name = "btnDebug";
			btnDebug.Size = new System.Drawing.Size(176, 30);
			btnDebug.TabIndex = 11;
			btnDebug.Text = "Debug  = 1";
			btnDebug.UseVisualStyleBackColor = true;
			btnDebug.Click += btnDebug_Click;
			// 
			// btnDbUpdate
			// 
			btnDbUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDbUpdate.Location = new System.Drawing.Point(900, 98);
			btnDbUpdate.Margin = new System.Windows.Forms.Padding(4);
			btnDbUpdate.Name = "btnDbUpdate";
			btnDbUpdate.Size = new System.Drawing.Size(88, 28);
			btnDbUpdate.TabIndex = 12;
			btnDbUpdate.Text = "dbUpdate";
			btnDbUpdate.UseVisualStyleBackColor = true;
			btnDbUpdate.Click += btnDbUpdate_Click;
			// 
			// btnLeggiDbCombo
			// 
			btnLeggiDbCombo.Location = new System.Drawing.Point(669, 48);
			btnLeggiDbCombo.Margin = new System.Windows.Forms.Padding(4);
			btnLeggiDbCombo.Name = "btnLeggiDbCombo";
			btnLeggiDbCombo.Size = new System.Drawing.Size(88, 26);
			btnLeggiDbCombo.TabIndex = 13;
			btnLeggiDbCombo.Text = "LeggiDb";
			btnLeggiDbCombo.UseVisualStyleBackColor = true;
			btnLeggiDbCombo.Click += btnLeggiDbCombo_Click;
			// 
			// btnControllaFileScompagnati
			// 
			btnControllaFileScompagnati.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnControllaFileScompagnati.Location = new System.Drawing.Point(897, 134);
			btnControllaFileScompagnati.Margin = new System.Windows.Forms.Padding(4);
			btnControllaFileScompagnati.Name = "btnControllaFileScompagnati";
			btnControllaFileScompagnati.Size = new System.Drawing.Size(88, 55);
			btnControllaFileScompagnati.TabIndex = 14;
			btnControllaFileScompagnati.Text = "Controlla file scompagnati";
			btnControllaFileScompagnati.UseVisualStyleBackColor = true;
			btnControllaFileScompagnati.Click += btnControllaFileScompagnati_Click;
			// 
			// txtDirectory
			// 
			txtDirectory.Location = new System.Drawing.Point(108, 14);
			txtDirectory.Margin = new System.Windows.Forms.Padding(4);
			txtDirectory.Name = "txtDirectory";
			txtDirectory.Size = new System.Drawing.Size(640, 23);
			txtDirectory.TabIndex = 15;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(28, 17);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(58, 15);
			label4.TabIndex = 16;
			label4.Text = "Directory:";
			// 
			// btnLeggiFileCommon
			// 
			btnLeggiFileCommon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnLeggiFileCommon.Location = new System.Drawing.Point(897, 196);
			btnLeggiFileCommon.Margin = new System.Windows.Forms.Padding(4);
			btnLeggiFileCommon.Name = "btnLeggiFileCommon";
			btnLeggiFileCommon.Size = new System.Drawing.Size(88, 55);
			btnLeggiFileCommon.TabIndex = 17;
			btnLeggiFileCommon.Text = "Leggi file Common";
			btnLeggiFileCommon.UseVisualStyleBackColor = true;
			btnLeggiFileCommon.Click += btnLeggiFileCommon_Click;
			// 
			// btnRemove
			// 
			btnRemove.Location = new System.Drawing.Point(760, 48);
			btnRemove.Margin = new System.Windows.Forms.Padding(4);
			btnRemove.Name = "btnRemove";
			btnRemove.Size = new System.Drawing.Size(87, 27);
			btnRemove.TabIndex = 18;
			btnRemove.Text = "Rimuovi";
			btnRemove.UseVisualStyleBackColor = true;
			btnRemove.Click += btnRemove_Click;
			// 
			// btnSearchTraslation
			// 
			btnSearchTraslation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnSearchTraslation.Location = new System.Drawing.Point(897, 259);
			btnSearchTraslation.Margin = new System.Windows.Forms.Padding(4);
			btnSearchTraslation.Name = "btnSearchTraslation";
			btnSearchTraslation.Size = new System.Drawing.Size(88, 41);
			btnSearchTraslation.TabIndex = 19;
			btnSearchTraslation.Text = "Cerca traduzioni";
			btnSearchTraslation.UseVisualStyleBackColor = true;
			btnSearchTraslation.Click += btnSearchTraslation_Click;
			// 
			// btnTraduzioniPkt
			// 
			btnTraduzioniPkt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnTraduzioniPkt.Location = new System.Drawing.Point(897, 308);
			btnTraduzioniPkt.Margin = new System.Windows.Forms.Padding(4);
			btnTraduzioniPkt.Name = "btnTraduzioniPkt";
			btnTraduzioniPkt.Size = new System.Drawing.Size(88, 41);
			btnTraduzioniPkt.TabIndex = 20;
			btnTraduzioniPkt.Text = "Cerca traduzioni pkt";
			btnTraduzioniPkt.UseVisualStyleBackColor = true;
			btnTraduzioniPkt.Click += btnTraduzioniPkt_Click;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(998, 395);
			Controls.Add(btnTraduzioniPkt);
			Controls.Add(btnSearchTraslation);
			Controls.Add(btnRemove);
			Controls.Add(btnLeggiFileCommon);
			Controls.Add(label4);
			Controls.Add(txtDirectory);
			Controls.Add(btnControllaFileScompagnati);
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
			Margin = new System.Windows.Forms.Padding(4);
			Name = "frmMain";
			Text = "Systore Launcher";
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
		private System.Windows.Forms.Button btnControllaFileScompagnati;
		private System.Windows.Forms.TextBox txtDirectory;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnLeggiFileCommon;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnSearchTraslation;
		private System.Windows.Forms.Button btnTraduzioniPkt;
	}
}

