using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRLOCSistema.Model
{
	public class Calculo
	{
		public List<ValorPorComodo> ValoresPorComodo { get; set; }

		public void EfetuarCalculo(List<Item> itens, List<Comodo> comodos)
		{
			ValoresPorComodo = new List<ValorPorComodo>();

			foreach (var comodo in comodos)
			{
				foreach (var item in itens)
				{
					var valorPorComodo = new ValorPorComodo();

					valorPorComodo.EfetuarCalculo(item, comodo);

					ValoresPorComodo.Add(valorPorComodo);
				}
			}
		}
	}

	public class ValorPorComodo
	{
		public string Comodo { get; set; }
		public string Item { get; set; }
		public int QuantidadeX { get; set; }
		public int QuantidadeY { get; set; }
		public double RecortesX { get; set; }
		public double RecortesY { get; set; }

		public void EfetuarCalculo(Item item, Comodo comodo)
		{

		}
	}
}
