using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace LanciaSystore.Manager
{
	internal class SpTranslationGrabberManager
	{

		private List<SqlProcedureFunction> List { get; set; } = new();
		UIManager _manager;
		public SpTranslationGrabberManager(UIManager manager)
		{
			_manager = manager;
			var listSpFromDb = new ListSpFunctionManager(manager.SelectedDb, manager.SelectedDataSource);
			List = listSpFromDb.List.Where(a => a.Content.Contains("dbo.fn_td(", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("APS", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("L2_Display", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("ws_HDL", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("fn_SW", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("ws_Mop", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("SMM", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("SMX", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("ws_SW", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("SMS", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("_uti_", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Type.Contains("trigger", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("prq", StringComparison.InvariantCultureIgnoreCase)
			&& !a.Name.Contains("ws_Helper_", StringComparison.InvariantCultureIgnoreCase)

			).ToList();


		}
		private List<string> Finded { get; set; } = new();
		internal async Task<bool> Exec()
		{
			string pattern = @"(?<=dbo\.fn_td\(')[^']+(?='\))";

			Regex rgx = new Regex(pattern);

			foreach (var item in List)
			{

				foreach (Match match in Regex.Matches(item.Content, pattern))
				{
					//match.Value

					Finded.Add(match.Value);
				}
				//item.Content
			}
			var tot = Finded.Distinct().Where(a => !a.Contains("_DES")).ToList();

			TestConnessione _test = new TestConnessione(_manager.SelectedDataSource);

			var sqlText = " use " + _manager.SelectedDb + " select top 1 LAN_ITA from UTI_LINGUA where LAN_ITA=@messaggio " +
				"if @@rowcount=0" +
				" insert into UTI_LINGUA \r\n" +
				" (\r\n  LAN_TIPOLINGUA,LAN_ITA,LAN_TRA,LAN_TIME,LAN_DMOD,LAN_STACK\r\n)" +
				" values\r\n(N'简体中文',@messaggio,'',getdate(),getdate(),default);\r\n";




			foreach (var item in tot)
			{
				_ = await _test.ExecCommand(sqlText, new SqlParameter[]
					{ new System.Data.SqlClient.SqlParameter("@messaggio", item) });

			}

			return (true);

		}
	}
}
