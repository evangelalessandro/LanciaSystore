using System;
using System.Windows.Forms;

namespace LanciaSystore {
  public partial class frmProgress : Form {
    public frmProgress() {
      InitializeComponent();
    }

    public void UpdateProgress(int percentage, string message) {
      if (InvokeRequired) {
        Invoke(new Action(() => UpdateProgress(percentage, message)));
        return;
      }

      progressBar1.Value = percentage;
      lblMessage.Text = message;
			Application.DoEvents();
    }
  }
}
