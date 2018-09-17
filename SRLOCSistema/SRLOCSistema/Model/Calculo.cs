using SRLOCSistema.Model.Enum;
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
		public Comodo Comodo { get; set; }
		public Item Item { get; set; }
		public int QuantidadeX { get; set; }
		public int QuantidadeY { get; set; }
		public int QuantidadeItens { get; set; }
		public List<Recorte> Recortes { get; set; }

		public void EfetuarCalculo(Item item, Comodo comodo)
		{
			Item = item;
			Comodo = comodo;

			var quantidadeX = comodo.Comprimento / item.Comprimento;
			var quantidadeY = comodo.Largura / item.Largura;
			var quantidadeItens = quantidadeX * quantidadeY;

			if (item.TipoCalculo == TipoCalculo.Area)
			{
				Recortes = ObterRecortes();
			}
		}

		public List<Recorte> ObterRecortes()
		{
			var retorno = new List<Recorte>();

			var sobraX = Comodo.Comprimento - (Item.Comprimento * QuantidadeX);
			var sobraY = Comodo.Largura - (Item.Largura * QuantidadeY);

			// validando necessidade de recorte
			if (sobraX == 0 && sobraY == 0)
			{
				return retorno;
			}

			// Obtendo condições de recorte
			// encaixar o item na horizontal

			// encaixar o item na vertical

			// encaixar o item na vertical e horizontal

			// Obtendo melhor condição:

			// Removendo canto sobreposto
			if (sobraX == 0)
			{

			}
			else if (sobraY == 0)
			{

			}

			return retorno;
		}
	}

	public class Recorte
	{
		public int TamanhoX { get; set; }
		public int TamanhoY { get; set; }
		public Posicao Posicao { get; set; }
	}
}
