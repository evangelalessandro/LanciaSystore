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

namespace LanciaSystore.Data
{
	internal class ManageNewSp
	{
		private static List<SqlProcedureFunction> _LIST = new();
		internal static void CreateNewFileSp(string datasource, string database, string folder)
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
			foreach (DataRow item in tab.Rows)
			{
				_LIST.Add(new SqlProcedureFunction(item["SPECIFIC_NAME"].ToString(), item["ROUTINE_DEFINITION"].ToString(), item["routine_type"].ToString()));
			}
			folder = System.IO.Path.Combine(folder, "Database");
			var folders = Directory.GetDirectories(folder, "WS*");

			foreach (var folderDb in folders.Where(a => a.EndsWith(database)))
			{

				var files = Directory.GetFiles(folderDb, "*.sql", SearchOption.AllDirectories);
				foreach (var item in files.Where(a => !a.Contains(@"\CreazioneDatabase\") && !a.Contains(@"\Update\") && !a.Contains(@"\Percorsi\") && !a.Contains(@"\Path\")).ToList())
				{
					var file = item.Split(@"\").Last().Replace("dbo.", "").Replace(".sql", ""); ;
					var proc = _LIST.FirstOrDefault(a => a.Name.Equals(file, StringComparison.InvariantCultureIgnoreCase));
					if (proc != null)
					{
						proc.File = item;
					}
					else
					{

					}
				}

			}
			var listEmpty = _LIST.Where(a => a.File == "").ToList();
			if (listEmpty.Count > 0)
			{
				var folderDest = System.IO.Path.Combine(folder, database, "CustomAle");
				if (!Directory.Exists(folderDest))
				{
					Directory.CreateDirectory(folderDest);
				}


				foreach (var item in listEmpty)
				{
					File.WriteAllText(System.IO.Path.Combine(folderDest, "dbo." + item.Name + ".sql"), item.Content);
				}
				MessageBox.Show("Trovate  " + listEmpty.Count().ToString() + " sp, generati i nuovi file e messi in " + folderDest, "Info", MessageBoxButtons.OK, icon: MessageBoxIcon.Exclamation);
			}
			else
			{
				MessageBox.Show("Niente di nuovo ", "Info", MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			}

		}
	}
	internal class SqlProcedureFunction
	{


		public SqlProcedureFunction(string name, string body, string type)
		{
			this.Name = name;
			this.Content = body;
			this.Type = type;
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
