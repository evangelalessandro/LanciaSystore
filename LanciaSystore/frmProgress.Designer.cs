namespace LanciaSystore {
  partial class frmProgress {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label lblMessage;

    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent() {
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.lblMessage = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(12, 35);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(360, 23);
      this.progressBar1.TabIndex = 0;
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Location = new System.Drawing.Point(12, 9);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(50, 15);
      this.lblMessage.TabIndex = 1;
      this.lblMessage.Text = "Avvio...";
      // 
      // frmProgress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(384, 81);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.progressBar1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmProgress";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Progresso";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
