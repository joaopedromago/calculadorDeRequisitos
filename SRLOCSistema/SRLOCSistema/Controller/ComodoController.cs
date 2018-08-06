
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
	public class ComodoController
	{

		public void CadastrarComodo(Comodo Comodo)
		{
			var dbContext = new DbContext();
			try
			{
				var query = new StringBuilder();

				query.AppendLine($"INSERT INTO COMODOS ");
				query.AppendLine($"(NOME ,LARGURA ,COMPRIMENTO, DATACRIACAO)");
				query.AppendLine($"VALUES");
				query.AppendLine($"('{Comodo.Nome}', '{Comodo.Largura}', '{Comodo.Comprimento}', '{DateTime.Now:s}')");

				dbContext.ExecuteQuery(query.ToString());
			}
			catch
			{
				throw;
			}
		}

		public void AtualizarComodo(Comodo Comodo)
		{
			var dbContext = new DbContext();
			try
			{
				var query = new StringBuilder();

				query.AppendLine($"UPDATE COMODOS SET ");
				query.AppendLine($"NOME = '{Comodo.Nome}',");
				query.AppendLine($"LARGURA = '{Comodo.Largura}',");
				query.AppendLine($"COMPRIMENTO = '{Comodo.Comprimento}'");
				query.AppendLine($"WHERE ID = {Comodo.Id}");

				dbContext.ExecuteQuery(query.ToString());
			}
			catch
			{
				throw;
			}
		}

		public void ExcluirComodo(int id)
		{
			var dbContext = new DbContext();
			try
			{
				var query = $"DELETE FROM COMODOS WHERE ID = {id}";

				dbContext.ExecuteQuery(query);
			}
			catch
			{
				throw;
			}
		}

		public Comodo ObterComodo(int id)
		{
			Comodo retorno = null;

			var dbContext = new DbContext();
			try
			{
				var query = $"SELECT * FROM COMODOS WHERE ID = {id}";

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

		public List<Comodo> ObterListaComodos()
		{
			List<Comodo> retorno = new List<Comodo>();

			var dbContext = new DbContext();
			try
			{
				var dt = ObterComodos();

				retorno = TransformarDataTable(dt);
			}
			catch
			{
				throw;
			}

			return retorno;
		}

		public DataTable ObterComodos()
		{
			DataTable retorno = new DataTable();

			var dbContext = new DbContext();
			try
			{
				var query = "SELECT * FROM COMODOS";

				retorno = dbContext.ExecuteSelect(query);
			}
			catch
			{
				throw;
			}

			return retorno;
		}

		public List<Comodo> TransformarDataTable(DataTable dt)
		{
			var lista = (from rw in dt.AsEnumerable()
						 select new Comodo()
						 {
							 Id = Convert.ToInt32(rw["ID"]),
							 Nome = Convert.ToString(rw["NOME"]),
							 Largura = Convert.ToDouble(rw["LARGURA"]),
							 Comprimento = Convert.ToDouble(rw["COMPRIMENTO"])
						 }).ToList();

			return lista;
		}
	}
}
