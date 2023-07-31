using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Metadata.Ecma335;
using System.Text.Unicode;
using System.Drawing;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace LanciaSystore.Manager
{
	internal class NewSpManager
	{
		private static List<SqlProcedureFunction> _LIST = new();
		internal static async Task CreateNewFileSp(UIManager manager)
		{
			await CreateNewFileSp(manager.SelectedDataSource, manager.SelectedDb, manager.Directory);

			return;
		}

		private static async Task CreateNewFileSp(string datasource, string database, string folder)
		{
			_LIST.Clear();
			string query = "  USE  " + database + " select SPECIFIC_NAME,'' as TableRef,ROUTINE_BODY,ROUTINE_DEFINITION,routine_type " +
						"  from information_schema.routines                                                " +
						" where routine_type in ('PROCEDURE', 'FUNCTION') and SPECIFIC_SCHEMA = 'dbo'	   " +
						" union																			   " +
						" select trg.name as trigger_name,												   " +
						"    schema_name(tab.schema_id) + '.' + tab.name as [table],					   " +
						"   																			   " +
						"    'SQL' as Body,																   " +
						"    																			   " +
						"    object_definition(trg.object_id) as [definition],							   " +
						"																				   " +
						"	case when trg.[type] = 'TA' then 'Assembly (CLR) trigger'					   " +
						"																				   " +
						"		when trg.[type] = 'TR' then 'SQL trigger'								   " +
						"																				   " +
						"		else '' end as [type]													   " +
						"from sys.triggers trg															   " +
						"																				   " +
						"	left																		   " +
						"join sys.objects tab															   " +
						"																				   " +
						"		on trg.parent_id = tab.object_id										   " +
						"where trg.[type] = 'TR'														   ";



			TestConnessione _test = new TestConnessione(datasource);
			DataTable tab = new DataTable();

			using (SqlDataAdapter comm = new SqlDataAdapter(query, _test.Connessione))
			{
				// Adapter fill table function
				comm.Fill(tab);
			}
			_LIST.Clear();
			foreach (DataRow item in tab.Rows.AsParallel())
			{
				_LIST.Add(new SqlProcedureFunction(item["SPECIFIC_NAME"].ToString(), item["ROUTINE_DEFINITION"].ToString(), item["routine_type"].ToString()));
			}
			folder = Path.Combine(folder, "Database");
			var folders = Directory.GetDirectories(folder, "WS*");

			foreach (var folderDb in folders.Where(a => a.EndsWith(database)))
			{

				var files = Directory.GetFiles(folderDb, "*.sql", SearchOption.AllDirectories);


				await foreach (var item in files.Where(a => !a.Contains(@"\CreazioneDatabase\") && !a.Contains(@"\Update\") && !a.Contains(@"\Percorsi\") && !a.Contains(@"\Path\")).ToAsyncEnumerable())
				{
					var file = item.Split(@"\").Last().Replace("dbo.", "").Replace(".sql", ""); ;
					var proc = _LIST.FirstOrDefault(a => a.Name.Equals(file, StringComparison.InvariantCultureIgnoreCase));
					if (proc != null)
					{
						proc.File = item;
						try
						{
							File.SetAttributes(item, FileAttributes.Normal);
							//var cont = System.IO.File.ReadAllText(item);
							//bool removerBoom = true;
							//if (!GetFileEncodingUTF8(item) || removerBoom)
							//{

							//	var contTowrite = cont;

							//	System.IO.File.WriteAllText(item, contTowrite, new UTF8Encoding(false));
							//}
						}
						catch (Exception)
						{

						}

					}
					else
					{

					}
				}

			}
			var listEmpty = await _LIST.Where(a => a.File == "").ToAsyncEnumerable().ToListAsync();
			if (listEmpty.Count > 0)
			{
				var folderDest = Path.Combine(folder, database, "CustomAle");
				if (!Directory.Exists(folderDest))
				{
					Directory.CreateDirectory(folderDest);
				}


				foreach (var item in listEmpty)
				{
					File.WriteAllText(Path.Combine(folderDest, "dbo." + item.Name + ".sql"), item.Content, new UTF8Encoding());
				}
				MessageBox.Show("Trovate  " + listEmpty.Count().ToString() + " sp, generati i nuovi file e messi in " + folderDest, "Info", MessageBoxButtons.OK, icon: MessageBoxIcon.Exclamation);
			}
			else
			{
				MessageBox.Show("Niente di nuovo ", "Info", MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			}

		}
		//private static string RemoveBom(string text)
		//{
		//	text = Regex.Replace(text, @"^\xEF\xBB\xBF\", string.Empty);
		//	return text;
		//}
		public static bool GetFileEncodingUTF8(string srcFile)
		{
			// *** Use Default of Encoding.Default (Ansi CodePage)
			Encoding enc = Encoding.Default;

			// *** Detect byte order mark if any - otherwise assume default
			byte[] buffer = new byte[10];
			FileStream file = new FileStream(srcFile, FileMode.Open);
			file.Read(buffer, 0, 10);
			file.Close();

			if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
				return true;
			return false;
		}

	}
	internal class SqlProcedureFunction
	{


		public SqlProcedureFunction(string name, string body, string type)
		{
			Name = name;
			Content = body;
			Type = type;
		}

		public string Name { get; set; } = "";
		public string Content { get; set; } = "";
		public string Type { get; set; } = "";
		public string File { get; set; } = "";

		public override string ToString()
		{
			return Name + " " + Type;
		}

	}
}
