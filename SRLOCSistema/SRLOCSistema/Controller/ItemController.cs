using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRLOCSistema.Dto;
using SRLOCSistema.Model;

namespace SRLOCSistema.Controller
{
	public class ItemController
	{
		public void CadastrarItem(Item item)
		{
			var dbContext = new DbContext();
			try
			{
				var query = new StringBuilder();

				query.AppendLine($"INSERT INTO ITENS ");
				query.AppendLine($"(NOME ,LARGURA ,COMPRIMENTO ,LARGURAESPACAMENTO ,COMPRIMENTOESPACAMENTO, DATACRIACAO)");
				query.AppendLine($"VALUES");
				query.AppendLine($"('{item.Nome}', '{item.Largura}', '{item.Comprimento}', '{item.LarguraEspacamento}', '{item.ComprimentoEspacamento}', '{DateTime.Now:s}')");

				dbContext.ExecuteQuery(query.ToString());
			}
			catch
			{
				throw;
			}
		}

		public void AtualizarItem(Item item)
		{
			var dbContext = new DbContext();
			try
			{
				var query = new StringBuilder();

				query.AppendLine($"UPDATE ITENS SET ");
				query.AppendLine($"NOME = '{item.Nome}',");
				query.AppendLine($"LARGURA = '{item.Largura}',");
				query.AppendLine($"COMPRIMENTO = '{item.Comprimento}',");
				query.AppendLine($"LARGURAESPACAMENTO = '{item.LarguraEspacamento}',");
				query.AppendLine($"COMPRIMENTOESPACAMENTO = '{item.ComprimentoEspacamento}'");
				query.AppendLine($"WHERE ID = {item.Id}");

				dbContext.ExecuteQuery(query.ToString());
			}
			catch
			{
				throw;
			}
		}

		public void ExcluirItem(int id)
		{
			var dbContext = new DbContext();
			try
			{
				var query = $"DELETE FROM ITENS WHERE ID = {id}";

				dbContext.ExecuteQuery(query);
			}
			catch
			{
				throw;
			}
		}

		public Item ObterItem(int id)
		{
			Item retorno = null;
			
			var dbContext = new DbContext();
			try
			{
				var query = $"SELECT * FROM ITENS WHERE ID = {id}";

				var dt = dbContext.ExecuteSelect(query);

				var lista = TransformarDataTable(dt);

				retorno = lista.FirstOrDefault();
			}
			catch
			{
				throw;
			}

			return retorno;
		}

		public List<Item> ObterListaItens()
		{
			List<Item> retorno = new List<Item>();
			
			var dbContext = new DbContext();
			try
			{
				var dt = ObterItens();

				retorno = TransformarDataTable(dt);
			}
			catch
			{
				throw;
			}

			return retorno;
		}

		public DataTable ObterItens()
		{
			DataTable retorno = new DataTable();

			var dbContext = new DbContext();
			try
			{
				var query = "SELECT * FROM ITENS";

				retorno = dbContext.ExecuteSelect(query);
			}
			catch
			{
				throw;
			}

			return retorno;
		}

		public List<Item> TransformarDataTable(DataTable dt)
		{
			var lista = (from rw in dt.AsEnumerable()
						 select new Item()
						 {
							 Id = Convert.ToInt32(rw["ID"]),
							 Nome = Convert.ToString(rw["NOME"]),
							 Largura = Convert.ToDouble(rw["LARGURA"]),
							 Comprimento = Convert.ToDouble(rw["COMPRIMENTO"]),
							 LarguraEspacamento = Convert.ToDouble(rw["LARGURAESPACAMENTO"]),
							 //ComprimentoEspacamento = Convert.ToDouble(rw["COMPRIMENTOESPACAMENTO"])
						 }).ToList();

			return lista;
		}
	}
}
