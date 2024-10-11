using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanciaSystore.Manager
{
	internal class ManagePacchettoSvn
	{
		internal static void CreaPacchetto(string folder)
		{
			if (!Clipboard.ContainsText())
			{
				MessageBox.Show("Mancano dati nella clipboard ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			var list = Clipboard.GetText().Split(Environment.NewLine).ToList();


			FolderBrowserDialog v = new FolderBrowserDialog();
			v.Description = "Seleziona cartella destinazione";
			v.InitialDirectory = folder + @"\_Developers";
			if (v.ShowDialog() == DialogResult.OK)
			{
				var dirDest = v.SelectedPath;
				try
				{

					list = list.Where(a => a.Length > 0 && File.Exists(a)).ToList();
					if (list.Count == 0)
					{
						MessageBox.Show("Nella clip non ci sono dati validi ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					foreach (var item in list)
					{
						var predir = item.Replace(folder, "");

						var listFolder = (dirDest + predir).Split(@"\").ToList();
						listFolder.Remove(listFolder.Last());
						var onlyFolder = string.Join(@"\", listFolder);

						Directory.CreateDirectory(onlyFolder);
						File.Copy(item, dirDest + predir, true);
					}
					MessageBox.Show("Terminata copia !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}




		}
	}
}
