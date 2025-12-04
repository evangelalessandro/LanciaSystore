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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
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
			txtDirectory = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			btnLeggiFileCommon = new System.Windows.Forms.Button();
			btnRemove = new System.Windows.Forms.Button();
			btnSearchTraslation = new System.Windows.Forms.Button();
			btnTraduzioniPkt = new System.Windows.Forms.Button();
			btnPacchettoSvn = new System.Windows.Forms.Button();
			btnCartella = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
			button1.Location = new System.Drawing.Point(334, 64);
			button1.Margin = new System.Windows.Forms.Padding(5);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(129, 62);
			button1.TabIndex = 0;
			button1.Text = "LeggiDb";
			button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			button1.UseVisualStyleBackColor = true;
			button1.Click += btnConnect_Click;
			// 
			// txtDataSource
			// 
			txtDataSource.Location = new System.Drawing.Point(32, 82);
			txtDataSource.Margin = new System.Windows.Forms.Padding(5);
			txtDataSource.Name = "txtDataSource";
			txtDataSource.Size = new System.Drawing.Size(292, 27);
			txtDataSource.TabIndex = 1;
			// 
			// lstDatabase
			// 
			lstDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			lstDatabase.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
			lstDatabase.FormattingEnabled = true;
			lstDatabase.HorizontalScrollbar = true;
			lstDatabase.Location = new System.Drawing.Point(32, 168);
			lstDatabase.Margin = new System.Windows.Forms.Padding(5);
			lstDatabase.Name = "lstDatabase";
			lstDatabase.Size = new System.Drawing.Size(343, 562);
			lstDatabase.TabIndex = 2;
			lstDatabase.SelectedIndexChanged += lstDatabase_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(32, 138);
			label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(72, 20);
			label1.TabIndex = 3;
			label1.Text = "Database";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(437, 138);
			label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(54, 20);
			label2.TabIndex = 5;
			label2.Text = "Master";
			// 
			// lstMaster
			// 
			lstMaster.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			lstMaster.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
			lstMaster.FormattingEnabled = true;
			lstMaster.HorizontalScrollbar = true;
			lstMaster.Location = new System.Drawing.Point(437, 168);
			lstMaster.Margin = new System.Windows.Forms.Padding(5);
			lstMaster.Name = "lstMaster";
			lstMaster.Size = new System.Drawing.Size(569, 562);
			lstMaster.TabIndex = 4;
			// 
			// btnAvvia
			// 
			btnAvvia.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnAvvia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
			btnAvvia.Image = (System.Drawing.Image)resources.GetObject("btnAvvia.Image");
			btnAvvia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnAvvia.Location = new System.Drawing.Point(1331, 650);
			btnAvvia.Margin = new System.Windows.Forms.Padding(5);
			btnAvvia.Name = "btnAvvia";
			btnAvvia.Size = new System.Drawing.Size(196, 80);
			btnAvvia.TabIndex = 6;
			btnAvvia.Text = "AVVIA SYSTORE";
			btnAvvia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnAvvia.UseVisualStyleBackColor = true;
			btnAvvia.Click += btnAvvia_Click;
			// 
			// lstCommonFolder
			// 
			lstCommonFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			lstCommonFolder.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
			lstCommonFolder.FormattingEnabled = true;
			lstCommonFolder.HorizontalScrollbar = true;
			lstCommonFolder.Location = new System.Drawing.Point(1095, 168);
			lstCommonFolder.Margin = new System.Windows.Forms.Padding(5);
			lstCommonFolder.Name = "lstCommonFolder";
			lstCommonFolder.Size = new System.Drawing.Size(229, 562);
			lstCommonFolder.TabIndex = 7;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(1095, 143);
			label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(112, 20);
			label3.TabIndex = 8;
			label3.Text = "CommonFolder";
			// 
			// cbodataSource
			// 
			cbodataSource.FormattingEnabled = true;
			cbodataSource.Location = new System.Drawing.Point(475, 83);
			cbodataSource.Margin = new System.Windows.Forms.Padding(5);
			cbodataSource.Name = "cbodataSource";
			cbodataSource.Size = new System.Drawing.Size(356, 28);
			cbodataSource.TabIndex = 9;
			// 
			// btnAddMaster
			// 
			btnAddMaster.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnAddMaster.Location = new System.Drawing.Point(1016, 168);
			btnAddMaster.Margin = new System.Windows.Forms.Padding(5);
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
			btnDebug.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnDebug.Location = new System.Drawing.Point(1331, 13);
			btnDebug.Margin = new System.Windows.Forms.Padding(5);
			btnDebug.Name = "btnDebug";
			btnDebug.Size = new System.Drawing.Size(201, 68);
			btnDebug.TabIndex = 11;
			btnDebug.Text = "Debug  = 1";
			btnDebug.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnDebug.UseVisualStyleBackColor = true;
			btnDebug.Click += btnDebug_Click;
			// 
			// btnDbUpdate
			// 
			btnDbUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnDbUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
			btnDbUpdate.Image = (System.Drawing.Image)resources.GetObject("btnDbUpdate.Image");
			btnDbUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnDbUpdate.Location = new System.Drawing.Point(1331, 168);
			btnDbUpdate.Margin = new System.Windows.Forms.Padding(5);
			btnDbUpdate.Name = "btnDbUpdate";
			btnDbUpdate.Size = new System.Drawing.Size(196, 63);
			btnDbUpdate.TabIndex = 12;
			btnDbUpdate.Text = "DB UPDATE";
			btnDbUpdate.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			btnDbUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnDbUpdate.UseVisualStyleBackColor = true;
			btnDbUpdate.Click += btnDbUpdate_Click;
			// 
			// btnLeggiDbCombo
			// 
			btnLeggiDbCombo.Image = (System.Drawing.Image)resources.GetObject("btnLeggiDbCombo.Image");
			btnLeggiDbCombo.Location = new System.Drawing.Point(841, 64);
			btnLeggiDbCombo.Margin = new System.Windows.Forms.Padding(5);
			btnLeggiDbCombo.Name = "btnLeggiDbCombo";
			btnLeggiDbCombo.Size = new System.Drawing.Size(140, 63);
			btnLeggiDbCombo.TabIndex = 13;
			btnLeggiDbCombo.Text = "LeggiDb";
			btnLeggiDbCombo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnLeggiDbCombo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnLeggiDbCombo.UseVisualStyleBackColor = true;
			btnLeggiDbCombo.Click += btnLeggiDbCombo_Click;
			// 
			// btnControllaFileScompagnati
			// 
			btnControllaFileScompagnati.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnControllaFileScompagnati.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
			btnControllaFileScompagnati.Image = (System.Drawing.Image)resources.GetObject("btnControllaFileScompagnati.Image");
			btnControllaFileScompagnati.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnControllaFileScompagnati.Location = new System.Drawing.Point(1331, 251);
			btnControllaFileScompagnati.Margin = new System.Windows.Forms.Padding(5);
			btnControllaFileScompagnati.Name = "btnControllaFileScompagnati";
			btnControllaFileScompagnati.Size = new System.Drawing.Size(196, 89);
			btnControllaFileScompagnati.TabIndex = 14;
			btnControllaFileScompagnati.Text = "Controlla file \r\nscompagnati";
			btnControllaFileScompagnati.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnControllaFileScompagnati.UseVisualStyleBackColor = true;
			btnControllaFileScompagnati.Click += btnControllaFileScompagnati_Click;
			// 
			// txtDirectory
			// 
			txtDirectory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			txtDirectory.Location = new System.Drawing.Point(123, 19);
			txtDirectory.Margin = new System.Windows.Forms.Padding(5);
			txtDirectory.Name = "txtDirectory";
			txtDirectory.Size = new System.Drawing.Size(731, 28);
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
			// btnLeggiFileCommon
			// 
			btnLeggiFileCommon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnLeggiFileCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
			btnLeggiFileCommon.Location = new System.Drawing.Point(1331, 350);
			btnLeggiFileCommon.Margin = new System.Windows.Forms.Padding(5);
			btnLeggiFileCommon.Name = "btnLeggiFileCommon";
			btnLeggiFileCommon.Size = new System.Drawing.Size(196, 46);
			btnLeggiFileCommon.TabIndex = 17;
			btnLeggiFileCommon.Text = "Leggi file Common";
			btnLeggiFileCommon.UseVisualStyleBackColor = true;
			btnLeggiFileCommon.Click += btnLeggiFileCommon_Click;
			// 
			// btnRemove
			// 
			btnRemove.Image = (System.Drawing.Image)resources.GetObject("btnRemove.Image");
			btnRemove.Location = new System.Drawing.Point(991, 65);
			btnRemove.Margin = new System.Windows.Forms.Padding(5);
			btnRemove.Name = "btnRemove";
			btnRemove.Size = new System.Drawing.Size(147, 62);
			btnRemove.TabIndex = 18;
			btnRemove.Text = "Rimuovi";
			btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnRemove.UseVisualStyleBackColor = true;
			btnRemove.Click += btnRemove_Click;
			// 
			// btnSearchTraslation
			// 
			btnSearchTraslation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnSearchTraslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
			btnSearchTraslation.Location = new System.Drawing.Point(1331, 406);
			btnSearchTraslation.Margin = new System.Windows.Forms.Padding(5);
			btnSearchTraslation.Name = "btnSearchTraslation";
			btnSearchTraslation.Size = new System.Drawing.Size(198, 40);
			btnSearchTraslation.TabIndex = 19;
			btnSearchTraslation.Text = "Cerca traduzioni";
			btnSearchTraslation.UseVisualStyleBackColor = true;
			btnSearchTraslation.Click += btnSearchTraslation_Click;
			// 
			// btnTraduzioniPkt
			// 
			btnTraduzioniPkt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnTraduzioniPkt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
			btnTraduzioniPkt.Location = new System.Drawing.Point(1331, 456);
			btnTraduzioniPkt.Margin = new System.Windows.Forms.Padding(5);
			btnTraduzioniPkt.Name = "btnTraduzioniPkt";
			btnTraduzioniPkt.Size = new System.Drawing.Size(196, 44);
			btnTraduzioniPkt.TabIndex = 20;
			btnTraduzioniPkt.Text = "Cerca traduzioni pkt";
			btnTraduzioniPkt.UseVisualStyleBackColor = true;
			btnTraduzioniPkt.Click += btnTraduzioniPkt_Click;
			// 
			// btnPacchettoSvn
			// 
			btnPacchettoSvn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnPacchettoSvn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
			btnPacchettoSvn.Image = (System.Drawing.Image)resources.GetObject("btnPacchettoSvn.Image");
			btnPacchettoSvn.Location = new System.Drawing.Point(1331, 510);
			btnPacchettoSvn.Margin = new System.Windows.Forms.Padding(5);
			btnPacchettoSvn.Name = "btnPacchettoSvn";
			btnPacchettoSvn.Size = new System.Drawing.Size(198, 116);
			btnPacchettoSvn.TabIndex = 21;
			btnPacchettoSvn.Text = "Fai copia in cartella destinazione della lista file svn";
			btnPacchettoSvn.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			btnPacchettoSvn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnPacchettoSvn.UseVisualStyleBackColor = true;
			// 
			// btnCartella
			// 
			btnCartella.Location = new System.Drawing.Point(864, 13);
			btnCartella.Margin = new System.Windows.Forms.Padding(5);
			btnCartella.Name = "btnCartella";
			btnCartella.Size = new System.Drawing.Size(154, 42);
			btnCartella.TabIndex = 22;
			btnCartella.Text = "Leggi cartella";
			btnCartella.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnCartella.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			btnCartella.UseVisualStyleBackColor = true;
			btnCartella.Click += btnCartella_Click;
			// 
			// frmMain
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1545, 781);
			Controls.Add(btnCartella);
			Controls.Add(btnPacchettoSvn);
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
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(5);
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
		private System.Windows.Forms.ComboBox txtDirectory;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnLeggiFileCommon;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnSearchTraslation;
		private System.Windows.Forms.Button btnTraduzioniPkt;
		private System.Windows.Forms.Button btnPacchettoSvn;
		private System.Windows.Forms.Button btnCartella;
	}
}

