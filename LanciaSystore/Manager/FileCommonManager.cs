using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace LanciaSystore.Manager;

internal class FileCommonManager
{
	public static string DirectoryCommon { get; set; }
	public static List<string> FileCommonList { get; set; } = new List<string>();
	public string DataSource { get; set; }
	public string Database { get; set; }
	private List<string> _FunzioniAbilitate { get; set; } = new List<string>();
	private List<string> _DefaultButton = new List<string>();
	public FileCommonManager(string datasource, string database, string directoryCommon)
	{
		DataSource = datasource;
		Database = database;


		DirectoryCommon = directoryCommon;
		leggiFunzioniAbilitate();


		_DefaultButton.Add("BarBtnPredFilters");
		_DefaultButton.Add("BarBtnPredGroups");
		_DefaultButton.Add("BarBtnExit");
		_DefaultButton.Add("BarBtnRefresh");
		_DefaultButton.Add("BarBtnConferma");
	}

	private void leggiFunzioniAbilitate()
	{
		using TestConnessione test = new TestConnessione(DataSource);
		if (test.Connessione.State == System.Data.ConnectionState.Closed)
			test.Connessione.Open();


		using var sqlcomm = new SqlCommand("use " + Database + " ; select fun_funzion from cfg_funzion where fun_abi=1 ", test.Connessione);

		sqlcomm.CommandType = System.Data.CommandType.Text;
		using var sqlReader = sqlcomm.ExecuteReader();
		while (sqlReader.Read())
		{
			_FunzioniAbilitate.Add(sqlReader[0].ToString());
		}


	}

	public async Task<int> ManageCommonFile()
	{
		FileCommonList.Clear();
		_listGlobal.Clear();

		foreach (var file in Directory.GetFiles(DirectoryCommon, "*.xml"))
		{
			FileCommonList.Add(file);
		}


		var list = new List<string>();
		var globalButton = "_Core.App.GlobalButton.xml";
		await ReadGlobalButton(Directory.GetFiles(DirectoryCommon, globalButton).First());

		list.AddRange(Directory.GetFiles(DirectoryCommon, "_Core.App.Ribbon.xml"));
		var ribbon = list.First();
		var ribbonData = await ReadRibbon(ribbon, true);


		await ReadAmbiente(ribbonData);


		return 0;
	}

	private async Task<int> ReadAmbiente(Root ribbonData)
	{
		foreach (var page in ribbonData.Pages.Where(a => CheckFunction(a)))
		{
			foreach (var group in page.Groups.Where(a => CheckFunction(a)))
			{
				foreach (var item in group.Items.Where(a => CheckFunction(a)))
				{
					if (item.CommonFile.Length > 0)
					{
						await ReadEnviroment(item, page, group);
					}
					foreach (var itemSub in item.Items)
					{
						if (itemSub.CommonFile.Length > 0)
						{
							await ReadEnviroment(itemSub, page, group);
						}
					}

				}
			}
		}
		return 0;
	}
	int _ordine = 1;
	private int GetNextOrdine
	{
		get
		{
			_ordine++;
			return _ordine;
		}
	}
	private async Task<int> ReadEnviroment(RibbonLinkItem item, RibbonLinkPage page, RibbonLinkGroup group)
	{
		var itemsCommon = await ReadRibbon(item.CommonFile, false);
		var commonRef = item.CommonFile.Split(@"\").Last();

		using TestConnessione test = new TestConnessione(DataSource);
		if (test.Connessione.State == System.Data.ConnectionState.Closed)
			await test.Connessione.OpenAsync();



		using var sqlcomm = new SqlCommand("use " + Database + " ; Exec ws_L2_CUSTOM_IMPORT_FUNZIONI @pPagina,@pGruppo, @pAmbiente,@pGruppoAmbiente,@pFunzione,@pOrdine, @pAbi, @pCommonFile ,@pButtonName, @pGroupName ", test.Connessione);
		bool abi = true;
		sqlcomm.CommandType = System.Data.CommandType.Text;
		foreach (var groupAmbiente in itemsCommon.Pages.SelectMany(a => a.Groups))
		{

			foreach (var itemFunz in groupAmbiente.Items.Where(a => !_DefaultButton.Contains(a.Name)))
			{

				var funzName = itemFunz.Text;
				try
				{
					abi = CheckFunction(itemFunz) && CheckFunction(groupAmbiente);

					var glob = _listGlobal.Find(a => a.Name == itemFunz.Name);

					if (glob != null)
					{
						funzName = glob.Text;
						if (!CheckFunction(glob))
							abi = false;
					}
					sqlcomm.Parameters.Clear();

					if (itemFunz.Name.StartsWith("cb", StringComparison.OrdinalIgnoreCase))
						continue;
					if (itemFunz.Name.StartsWith("chk", StringComparison.OrdinalIgnoreCase))
						continue;
					if (itemFunz.Name.StartsWith("dt", StringComparison.OrdinalIgnoreCase))
						continue;
					if (itemFunz.Name.StartsWith("txt", StringComparison.OrdinalIgnoreCase))
						continue;
					if (itemFunz.Name.StartsWith("cmb", StringComparison.OrdinalIgnoreCase))
						continue;
					if (itemFunz.Name.StartsWith("hh", StringComparison.OrdinalIgnoreCase))
						continue;
					var parameters = new SqlParameter[]
						{

							new SqlParameter("@pPagina", page.Text),
							new SqlParameter("@pGruppo", group.Text!=null?group.Text:""),
							new SqlParameter("@pAmbiente", item.Text),
							new SqlParameter("@pGruppoAmbiente",  groupAmbiente.Text!=null?groupAmbiente.Text:""),
							new SqlParameter("@pFunzione", funzName),
							new SqlParameter("@pOrdine", GetNextOrdine),
							new SqlParameter("@pAbi",abi ),
							new SqlParameter("@pCommonFile",commonRef),
							new SqlParameter("@pButtonName",itemFunz.Name),
							new SqlParameter("@pGroupName",groupAmbiente.Name),

						};

					sqlcomm.Parameters.AddRange(parameters);
					await sqlcomm.ExecuteNonQueryAsync();

				}
				catch (Exception ex)
				{

				}

			}
		}
		return 0;
	}
	private bool CheckFunction(AccessLevelNameText item)
	{
		return (item.AppFunctions == null || _FunzioniAbilitate.Contains(item.AppFunctions)) && item.Visility != "AlwaysHide"

			&& item.UserRole != ",SYSADM,";
	}

	static List<RibbonGlobalLinkItem> _listGlobal = new List<RibbonGlobalLinkItem>();
	private static async Task<int> ReadGlobalButton(string globalButton)
	{
		try
		{

			_listGlobal.Clear();

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(globalButton);


			//}
			// Ottieni il nodo radice
			XmlNode rootElement = xmlDoc.DocumentElement;

			// Deserializza il contenuto XML nelle classi
			Root root = new Root();

			var ItemsLink = rootElement.SelectNodes("Buttons/i-i").Item(0).ChildNodes;



			for (int k = 0; k < ItemsLink.Count; k++)
			{
				XmlNode itemNode = ItemsLink[k];
				RibbonGlobalLinkItem item = new RibbonGlobalLinkItem();
				var nameNode = itemNode.SelectSingleNode("Name");

				item.Name = nameNode.Attributes["value"].Value;
				if (itemNode.SelectSingleNode("Text") != null && itemNode.SelectSingleNode("Text").Attributes["value"] != null)
					item.Text = itemNode.SelectSingleNode("Text").Attributes["value"].Value;
				else if (itemNode.SelectSingleNode("FullName") != null)
					item.Text = itemNode.SelectSingleNode("FullName").Attributes["value"].Value;
				else
				{

				}


				if (itemNode.SelectSingleNode("ActionClick/FormParam/InstanceFileName") != null)
					item.Link = itemNode.SelectSingleNode("ActionClick/FormParam/InstanceFileName").Attributes["value"].Value;

				if (item.Text == "Annulla Split Riga")
				{

				}

				if (item.Link == null)
				{

				}
				_listGlobal.Add(item);
				CheckAccessLevel(nameNode, item);
				CheckAccessLevel(itemNode, item);

			}
		}
		catch (Exception ex)
		{


		}
		return 0;
	}

	private async Task<Root> ReadRibbon(string file, bool assignRole)
	{
		// Deserializza il contenuto XML nelle classi
		Root root = new Root();
		try
		{


			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(file);

			// Ottieni il nodo radice
			XmlNode rootElement = xmlDoc.DocumentElement;



			var ItemsLink = rootElement.SelectNodes("Ribbon/Items/i-i").Item(0).ChildNodes;

			var pageNodes = rootElement.SelectNodes("Ribbon/RootLink/Pages/i-i").Item(0).ChildNodes;




			for (int i = 0; i < pageNodes.Count; i++)
			{
				XmlNode pageNode = pageNodes[i];
				RibbonLinkPage page = new RibbonLinkPage();
				root.Pages.Add(page);
				page.Text = pageNode.SelectSingleNode("Text").Attributes["value"].Value;

				CheckAccessLevel(pageNode, page);

				var groupNodes = pageNode.SelectNodes("Groups/i-i").Item(0).ChildNodes;


				for (int j = 0; j < groupNodes.Count; j++)
				{
					XmlNode groupNode = groupNodes[j];
					RibbonLinkGroup group = new RibbonLinkGroup();
					page.Groups.Add(group);
					var txt = groupNode.SelectSingleNode("Text");
					if (txt != null && txt.Attributes["value"] != null)
					{
						group.Text = txt.Attributes["value"].Value;
					}

					txt = groupNode.SelectSingleNode("Name");
					if (txt != null && txt.Attributes["value"] != null)
					{
						if (string.IsNullOrEmpty(group.Text))
						{
							group.Text = txt.Attributes["value"].Value;
						}
						group.Name = txt.Attributes["value"].Value;
					}

					CheckAccessLevel(groupNode, group);


					var itemNodes = groupNode.SelectNodes("ItemLinks/i-i").Item(0);
					if (itemNodes != null)
					{
						var itemNodesChildren = groupNode.SelectNodes("ItemLinks/i-i").Item(0).ChildNodes;


						for (int k = 0; k < itemNodesChildren.Count; k++)
						{
							XmlNode itemNode = itemNodesChildren[k];
							RibbonLinkItem item = GetItem(ItemsLink, itemNode);

							group.Items.Add(item);


							if (assignRole)
							{
								AssignRole(page, group, item, file);
							}
						}
					}


				}

			}
		}
		catch (Exception ex)
		{

#pragma warning disable CA1416 // Convalida compatibilità della piattaforma
#pragma warning disable CA1416 // Convalida compatibilità della piattaforma
#pragma warning disable CA1416 // Convalida compatibilità della piattaforma
			DialogResult dialogResult = MessageBox.Show("Errore nella lettura della ribbon principale", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
#pragma warning restore CA1416 // Convalida compatibilità della piattaforma
#pragma warning restore CA1416 // Convalida compatibilità della piattaforma
#pragma warning restore CA1416 // Convalida compatibilità della piattaforma
		}
		return root;
	}

	private async void AssignRole(RibbonLinkPage page, RibbonLinkGroup group, RibbonLinkItem item, string file)
	{
		using TestConnessione test = new TestConnessione(DataSource);
		if (test.Connessione.State == System.Data.ConnectionState.Closed)
			await test.Connessione.OpenAsync();



		using var sqlcomm = new SqlCommand("use " + Database + " ;   select FRY_RUOLO\r\nfrom DAT_RIBBON_SYSTORE \r\nwhere FRY_PAGINA=@pagina and FRY_GRUPPO=@gruppo and FRY_AMBIENTE=@ambiente ", test.Connessione);
		bool abi = true;
		sqlcomm.CommandType = System.Data.CommandType.Text;
		sqlcomm.Parameters.AddRange(
			new[] {
			new SqlParameter("@pagina", page.Text),
			new SqlParameter("@gruppo", group.Text),
			new SqlParameter("@ambiente", item.Text) });

		var ruolo = "";
		var read = sqlcomm.ExecuteReader();
		if (read != null)
		{
			while (read.Read())
			{
				ruolo = read.GetString(0);
			}
		};
		await read.DisposeAsync();
		if (ruolo == "")
		{
			return;
		}


		var txt = File.ReadAllLines(file);
		var txtIndex = new List<Tuple<string, int>>();
		var index = 0;
		foreach (var itemNode in txt)
		{
			index += 10;
			txtIndex.Add(new Tuple<string, int>(itemNode, index));

		}
		//
		////<AccessLevel>
		///<UserRoles value = ",SYSADM," type = "[S]" ></UserRoles>

		bool write = false;
		var listItem = txtIndex.Where(a => a.Item1.Contains("<Name value=\"" + item.Name + "\"")).OrderByDescending(a => a.Item2).FirstOrDefault();
		if (listItem != null)
		{
			var listBlocchi = txtIndex.Where(a => a.Item1.Contains(@"<i-i type=""[ACore]Core.Ribbon.RibbonItemButton"">")).OrderBy(a => a.Item2).ToList();
			var inizioBlocco = listBlocchi.Where(a => a.Item2 < listItem.Item2).OrderByDescending(a => a.Item2).FirstOrDefault();

			var fine = txtIndex.Where(a => a.Item2 > listItem.Item2).Where(a => a.Item1.Contains("</i-i>")).OrderBy(a => a.Item2).FirstOrDefault();

			var access = txtIndex.Where(a => a.Item2 > inizioBlocco.Item2 && a.Item2 < fine.Item2 && a.Item1.Contains("AccessLevel")).FirstOrDefault();


			if (access == null)
			{
				txtIndex.Add(new Tuple<string, int>("          <AccessLevel>", listItem.Item2 - 5));
				txtIndex.Add(new Tuple<string, int>("          <UserRoles value = \"," + ruolo + ",\" type = \"[S]\" />", listItem.Item2 - 4));
				txtIndex.Add(new Tuple<string, int>("          </AccessLevel>", listItem.Item2 - 3));
				write = true;
			}
			else
			{
				var userRole = txtIndex.Where(a => a.Item2 > inizioBlocco.Item2 && a.Item2 < fine.Item2 && a.Item1.Contains("UserRoles")).ToList();
				if (userRole.Count == 0)
				{

					txtIndex.Add(new Tuple<string, int>("          <UserRoles value = \"," + ruolo + ",\" type = \"[S]\" />", access.Item2 + 1));
					write = true;
				}
				else
				{
					write = true;
				}
			}




		}
		if (write)
			File.WriteAllLines(file, txtIndex.OrderBy(a => a.Item2).Select(a => a.Item1));

	}

	private static RibbonLinkItem GetItem(XmlNodeList ItemsLink, XmlNode itemNode)
	{
		RibbonLinkItem item = new RibbonLinkItem();
		var nameNode = itemNode.SelectSingleNode("Name");

		item.Name = nameNode.Attributes["value"].Value;
		XmlNode itemLinkNode = null;
		foreach (XmlNode itemLinkC in ItemsLink)
		{
			if (itemLinkC.SelectNodes("Name").Item(0).Attributes["value"].Value == item.Name)
			{
				itemLinkNode = itemLinkC;

				if (itemLinkC.SelectNodes("Text") != null && itemLinkC.SelectNodes("Text").Item(0) != null)
				{
					var txt = itemLinkC.SelectNodes("Text").Item(0).Attributes["value"];

					if (txt != null)
					{
						item.Text = txt.Value;
					}
				}
				if (itemLinkC.SelectSingleNode("ItemLinks/i-i") != null)
				{
					foreach (XmlNode itemSub in itemLinkC.SelectSingleNode("ItemLinks/i-i").ChildNodes)
					{
						item.Items.Add(GetItem(ItemsLink, itemSub));
					}
				}
				var listG = _listGlobal.Where(a => a.Name == item.Name).FirstOrDefault();
				if (listG != null)
				{
					item.Link = listG.Link;

					item.Text = listG.Text;
				}
				else if (itemLinkC.SelectSingleNode("ActionClick/FormParam/InstanceFileName") != null)
					item.Link = itemLinkC.SelectSingleNode("ActionClick/FormParam/InstanceFileName").Attributes["value"].Value;
				else if (item.Name.StartsWith("L2Base", StringComparison.InvariantCultureIgnoreCase))
				{
					var actClick = itemLinkC.SelectSingleNode("ActionClick/FormParam");
					if (actClick != null && actClick.OuterXml.Contains("TableToEdit value="))
					{
						item.Link = actClick.OuterXml.Split("TableToEdit value=").Last();
						item.Link = "_CORE.FrmEditTable." + item.Link.Split("\"").ToList()[1] + ".xml";
						//_CORE.FrmEditTable.BCKUP_UDC.xml
					}
					else if (actClick != null && actClick.OuterXml.Contains("type=\"[Sl]"))
					{
						item.Link = actClick.OuterXml.Split("type=\"[Sl]").Last();
						item.Link = item.Link.Split("Args").First().Split(".").Last().Replace("Args", "");
					}
					else
					{
						var content = item.Name.Split(".").Last();
						item.Link = content;// "_L2base.Frm{0}.xml".Replace("{0}", content);
					}

				}
				else
				{


				}
				break;
			}

		}

		CheckAccessLevel(itemNode, item);
		CheckAccessLevel(itemLinkNode, item);


		if (item.Visility == "AlwaysHide")
		{

		}
		else
		if (item.Link != null)
		{
			findCommonFile(item);
		}
		return item;
	}

	private static void findCommonFile(RibbonLinkItem item)
	{
		if (CheckCondition(item, "_L2base.Frm{0}.xml".Replace("{0}", item.Link)))
		{ return; }
		if (CheckCondition(item, item.Link))
		{ return; }

		if (item.Name == "L2BASE.EWM")
		{
			if (CheckCondition(item, "_Slsystoreewm.FrmSystoreEwmCfg.xml"))
				return;
		}
		if (CheckCondition(item, "{0}.xml".Replace("{0}", item.Link)))
			return;

		if (CheckCondition(item, "{0}.xml".Replace("{0}", item.Text.Replace(" ", ""))))
			return;


		if (CheckCondition(item, "_L2base.FrmGridBaseL2.{0}.xml".Replace("{0}", item.Text.Replace(" ", ""))))
			return;


		if (CheckCondition(item, "_L2base.Frm{0}.xml".Replace("{0}", item.Text.Replace(" ", ""))))
			return;



		if (item.CommonFile == "")
		{


		}

	}

	private static bool CheckCondition(RibbonLinkItem item, string endWith)
	{
		var items = FileCommonList.Where(a => a.EndsWith(endWith, StringComparison.InvariantCultureIgnoreCase)).ToList();
		if (items.Count == 1)
		{
			item.CommonFile = items.FirstOrDefault();
			return true;
		}
		return false;
	}

	private static async void CheckAccessLevel(XmlNode itemNode, AccessLevel item)
	{

		XmlNode checkResult = itemNode.SelectSingleNode("AccessLevel/CheckResultMode");
		if (checkResult != null)
		{
			item.Visility = checkResult.Attributes["value"].Value;
		}
		checkResult = itemNode.SelectSingleNode("AccessLevel/UserRoles");
		if (checkResult != null)
		{
			item.UserRole = checkResult.Attributes["value"].Value;
		}
		checkResult = itemNode.SelectSingleNode("AccessLevel/AppFunctions");
		if (checkResult != null)
		{
			item.AppFunctions = checkResult.Attributes["value"].Value;
		}


	}

	public class RibbonGlobalLinkItem : AccessLevelNameText
	{
		public string Link { get; set; }
	}
	public class RibbonLinkItem : AccessLevelNameText
	{
		public string Link { get; set; }
		public string CommonFile { get; set; } = "";
		public List<RibbonLinkItem> Items { get; set; } = new();
		public EnviromentSystore Enviroment { get; set; }
	}
	public class EnviromentSystore
	{
		public string FileCommon { get; set; }
		public List<FunzioniSystore> FunzioniSystore { get; set; }

	}
	public class FunzioniSystore : AccessLevelNameText
	{


	}

	public class RibbonLinkGroup : AccessLevelNameText
	{
		public List<RibbonLinkItem> Items { get; set; } = new();

	}

	public class RibbonLinkPage : AccessLevelNameText
	{
		public List<RibbonLinkGroup> Groups { get; set; } = new();


	}

	public class Root
	{
		public List<RibbonLinkPage> Pages { get; set; } = new();
	}

	public class AccessLevel
	{
		public string Visility { get; internal set; }
		public string UserRole { get; internal set; }
		public string AppFunctions { get; internal set; }
	}
	public class AccessLevelNameText : AccessLevel
	{
		public string Name { get; set; }
		public string Text { get; set; }

		public override string ToString()
		{
			if (Text.Length > 0)
			{
				return Text;
			}
			return Name;

		}
	}
}
