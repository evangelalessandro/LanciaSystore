using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace LanciaSystore.Manager
{
	internal class ListSpFunctionManager
	{
		public List<SqlProcedureFunction> List { get; set; } = new();

		public ListSpFunctionManager(string database, string datasource)
		{


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

			foreach (DataRow item in _test.GetData(query))
			{
				List.Add(new SqlProcedureFunction(item["SPECIFIC_NAME"].ToString(), item["ROUTINE_DEFINITION"].ToString(), item["routine_type"].ToString()));
			}

		}

	}
}
