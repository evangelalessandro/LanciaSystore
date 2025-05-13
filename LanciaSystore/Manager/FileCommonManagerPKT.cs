using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace LanciaSystore.Manager;

internal class FileCommonManagerPKT {
	public static List<string> FileCommonList { get; set; } = new List<string>();
	private UIManager _manager { get; set; }


	public FileCommonManagerPKT(UIManager manager) {
		_manager = manager;
	}



	public async Task<int> Exec() {
		FileCommonList.Clear();

		foreach (var file in Directory.GetFiles(Path.Combine(_manager.DirectoryProgettoCorrente, _manager.SelectedCommon), "*PKT*.xml")) {
			FileCommonList.Add(File.ReadAllText(file));
		}

		string sregex = @"(?<par>[{][T]{1}(?<key>[\w \s\S][^}]*)[}])";
		RegexOptions options = ((System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | System.Text.RegularExpressions.RegexOptions.Multiline)
		  | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

		Regex reg = new Regex(sregex, options);

		List<string> listMessage = new List<string>();

		foreach (var item in FileCommonList) {


			foreach (Match match in reg.Matches(item)) {
				//match.Value

				listMessage.Add(match.Value.Remove(0, 2).Replace("}", ""));
			}


		}

		listMessage = listMessage.Distinct().ToList();

		foreach (var item in listMessage) {
			Debug.Print(item);
		}



		return 0;
	}

}
