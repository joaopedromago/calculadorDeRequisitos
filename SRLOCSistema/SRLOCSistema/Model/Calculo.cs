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
		public string Texto { get; set; }

		public void EfetuarCalculo(List<Item> itens, List<Comodo> comodos, bool porMilimetros)
		{
			try
			{
				ValoresPorComodo = new List<ValorPorComodo>();

				foreach (var comodo in comodos)
				{
					// obtendo normal
					var valores1 = ObterValoresPorComodoEItens(itens, comodo);

					// obtendo invertido
					comodo.InverterComprimentoLargura();
					var valores2 = ObterValoresPorComodoEItens(itens, comodo);
					comodo.InverterComprimentoLargura(); // voltando ao normal

					var valores = ObterMelhorOpcaoValoresPorComodo(valores1, valores2);

					ValoresPorComodo.AddRange(valores);
				}

				MontarTexto(itens, comodos, porMilimetros);
			}
			catch
			{
				throw;
			}
		}

		public List<ValorPorComodo> ObterValoresPorComodoEItens(List<Item> itens, Comodo comodo)
		{
			var retorno = new List<ValorPorComodo>();

			foreach (var item in itens)
			{
				var valorPorComodo = new ValorPorComodo();
				valorPorComodo.EfetuarCalculo(item, comodo);
				retorno.Add(valorPorComodo);
			}

			return retorno;
		}

		public void MontarTexto(List<Item> itens, List<Comodo> comodos, bool porMilimetros)
		{
			var texto = new StringBuilder();

			foreach (var comodo in comodos)
			{
				texto.AppendLine("Comodo: " + comodo.Nome + " (" + (porMilimetros ? comodo.Comprimento : comodo.Comprimento / 1000) + "x" + (porMilimetros ? comodo.Largura : comodo.Largura / 1000) + ")");

				foreach (var item in itens)
				{
					var valorComodo = ValoresPorComodo.FirstOrDefault(x => x.Comodo == comodo && x.Item == item);

					if (valorComodo == null)
					{
						return;
					}

					texto.AppendLine("Item: " + item.Nome);

					texto.AppendLine("Quantidade total de " + item.Nome + " inteiros: " + valorComodo.QuantidadeItens + " (" + valorComodo.QuantidadeY + "x" + valorComodo.QuantidadeX + ")");

					if (item.TipoCalculo == TipoCalculo.Area || item.TipoCalculo == TipoCalculo.SentidoUnico)
					{
						texto.AppendLine(ObterTextoRecortes("Recortes da parte superior: ", Posicao.Comprimento, valorComodo, porMilimetros, item.TipoCalculo));
						texto.AppendLine(ObterTextoRecortes("Recortes do lado: ", Posicao.Largura, valorComodo, porMilimetros, item.TipoCalculo));
					}
					//else
					//{
					//	texto.AppendLine("Quantidade total de " + item.Nome + " inteiros: " + valorComodo.QuantidadeItens + " de " + (porMilimetros ? (valorComodo.InfoAdicional + "mm") : (valorComodo.InfoAdicional / 1000) + "m"));
					//}
					texto.AppendLine("");
				}
				texto.AppendLine("");
			}

			Texto = texto.ToString();
		}

		public string ObterTextoRecortes(string padrao, Posicao posicao, ValorPorComodo valorComodo, bool porMilimetros, TipoCalculo tipoCalculo)
		{
			var retorno = padrao;

			var recortes = new List<Recorte>();

			recortes.AddRange(valorComodo.Recortes.Where(x => x.Posicao == posicao));

			if (recortes.Count == 0)
			{
				return "";
			}

			var recortesPrincipal = recortes.Where(x => x.TipoRecorte == TipoRecorte.CortePrincipal).ToList();
			var recortesComplementares = recortes.Where(x => x.TipoRecorte == TipoRecorte.CorteComplementar).ToList();

			if (tipoCalculo == TipoCalculo.SentidoUnico)
			{
				if (recortesComplementares.Count > 0 && recortesPrincipal.Count > 0)
				{
					recortesPrincipal.Add(recortesPrincipal.FirstOrDefault());
				}

				recortesComplementares = new List<Recorte>();
			}

			if (recortesPrincipal.Count > 0)
			{
				var recortePrincipal = recortesPrincipal.FirstOrDefault();

				retorno += recortesPrincipal.Count + " peças: " + (porMilimetros ? recortePrincipal.TamanhoX : recortePrincipal.TamanhoX / 1000) + "x" + (porMilimetros ? recortePrincipal.TamanhoY : recortePrincipal.TamanhoY / 1000);
				if (recortesComplementares.Count > 0)
				{
					var recorteComplementar = recortesComplementares.FirstOrDefault();

					retorno += " + complementar: " + (porMilimetros ? recorteComplementar.TamanhoX : recorteComplementar.TamanhoX / 1000) + "x" + (porMilimetros ? recorteComplementar.TamanhoY : recorteComplementar.TamanhoY / 1000);
				}
			}
			else if (recortesComplementares.Count > 0)
			{
				var recorteComplementar = recortesComplementares.FirstOrDefault();

				retorno += recortesComplementares.Count + " peças: " + (porMilimetros ? recorteComplementar.TamanhoX : recorteComplementar.TamanhoX / 1000) + "x" + (porMilimetros ? recorteComplementar.TamanhoY : recorteComplementar.TamanhoY / 1000);
			}

			return retorno;
		}

		public List<ValorPorComodo> ObterMelhorOpcaoValoresPorComodo(List<ValorPorComodo> v1, List<ValorPorComodo> v2)
		{
			var retorno = v1;

			if (retorno?.Sum(x => x.Recortes?.Count ?? 0) < v2?.Sum(x => x.Recortes?.Count ?? 0))
			{
				retorno = v2;
			}

			return retorno;
		}
	}

	public class ValorPorComodo
	{
		public Comodo Comodo { get; set; }
		public Item Item { get; set; }
		public int QuantidadeX { get; set; }
		public int QuantidadeY { get; set; }
		public int QuantidadeItens { get; set; }
		public double InfoAdicional { get; set; }
		public List<Recorte> Recortes { get; set; }

		public void EfetuarCalculo(Item item, Comodo comodo)
		{
			try
			{
				if (item.ObterComprimento() == 0 || item.ObterLargura() == 0)
				{
					return;
				}

				Item = item;
				Comodo = comodo;

				QuantidadeX = (int)comodo.Comprimento / (int)item.ObterComprimento();
				QuantidadeY = (int)comodo.Largura / (int)item.ObterLargura();
				var restoX = comodo.Comprimento - (QuantidadeX * item.ObterComprimento());
				var restoY = comodo.Largura - (QuantidadeY * item.ObterLargura());

				if (item.TipoCalculo == TipoCalculo.Quantidade)
				{
					if ((item.Comprimento / 2) <= restoX)
					{
						QuantidadeX++;
					}
					if ((item.Largura / 2) <= restoY)
					{
						QuantidadeY++;
					}
				}
				else if (item.TipoCalculo == TipoCalculo.SentidoUnico)
				{
					bool comprimentoMenor = item.Comprimento < item.Largura;

					if ((item.Comprimento / 2) <= restoX && comprimentoMenor)
					{
						QuantidadeX++;
					}
					if ((item.Largura / 2) <= restoY && !comprimentoMenor)
					{
						QuantidadeY++;
					}

					if (comprimentoMenor)
					{
						Recortes = ObterRecortes().Where(x => x.Posicao == Posicao.Largura).ToList();//.Where(x => x.ObterMaiorTamanho() != item.ObterMaiorLado()).ToList();
					}
					else
					{
						Recortes = ObterRecortes().Where(x => x.Posicao == Posicao.Comprimento).ToList();//.Where(x => x.ObterMaiorTamanho() != item.ObterMaiorLado()).ToList();
					}
					// InfoAdicional = QuantidadeX > QuantidadeY ? comodo.Comprimento : comodo.Largura;
				}
				else if (item.TipoCalculo == TipoCalculo.Area)
				{
					Recortes = ObterRecortes();
				}

				QuantidadeItens = QuantidadeX * QuantidadeY;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Recorte> ObterRecortes()
		{
			var retorno = new List<Recorte>();

			var itensAreaVerL = new List<Recorte>();
			var itensAreaVerC = new List<Recorte>();
			var itensAreaMelhorOpcaoL = new List<Recorte>();
			var itensAreaMelhorOpcaoC = new List<Recorte>();

			var sobraX = Comodo.Comprimento - ((int)Item.ObterComprimento() * (int)QuantidadeX);
			var sobraY = Comodo.Largura - ((int)Item.ObterLargura() * (int)QuantidadeY);

			// validando necessidade de recorte
			if (sobraX == 0 && sobraY == 0)
			{
				return retorno;
			}

			// Obtendo condições de recorte
			var maiorLado = Item.ObterMaiorLado();
			var menorLado = Item.ObterMenorLado();
			// encaixar o item na horizontal
			var itensAreaHorL = ObterRecortesPorLado(maiorLado, menorLado, sobraX, Comodo.Largura, PosicaoItem.Horizontal, Posicao.Comprimento);
			var itensAreaHorC = ObterRecortesPorLado(maiorLado, menorLado, sobraY, Comodo.Comprimento, PosicaoItem.Horizontal, Posicao.Largura);
			// encaixar o item na vertical
			itensAreaVerL = ObterRecortesPorLado(menorLado, maiorLado, sobraX, Comodo.Largura, PosicaoItem.Vertical, Posicao.Comprimento);
			itensAreaVerC = ObterRecortesPorLado(menorLado, maiorLado, sobraY, Comodo.Comprimento, PosicaoItem.Vertical, Posicao.Largura);

			if (Item.TipoCalculo != TipoCalculo.SentidoUnico)
			{
				// Obtendo melhor condição:
				itensAreaMelhorOpcaoL = ObterMelhorRecortesPorComparacao(itensAreaHorL, itensAreaVerL);
				itensAreaMelhorOpcaoC = ObterMelhorRecortesPorComparacao(itensAreaHorC, itensAreaVerC);
			}
			else
			{
				var itemAreaHorL = itensAreaHorL.FirstOrDefault();
				var itemAreaHorC = itensAreaHorC.FirstOrDefault();

				var itemAreaVerL = itensAreaHorL.FirstOrDefault();
				var itemAreaVerC = itensAreaHorC.FirstOrDefault();

				if (itensAreaHorL.Any() && itensAreaVerL.Any())
				{
					itensAreaMelhorOpcaoL = itemAreaHorL?.ObterMaiorTamanho()
						!= Item.ObterMaiorLado() ? itensAreaHorL : itensAreaVerL;
				}
				else if (itensAreaHorL.Any())
				{
					itensAreaMelhorOpcaoL = itemAreaHorL?.ObterMaiorTamanho()
						!= Item.ObterMaiorLado() ? itensAreaHorL : new List<Recorte>();
				}
				else
				{
					itensAreaMelhorOpcaoL = itemAreaVerL?.ObterMaiorTamanho()
						!= Item.ObterMaiorLado() ? itensAreaVerL : new List<Recorte>();
				}

				if (itensAreaHorC.Any() && itensAreaVerC.Any())
				{
					itensAreaMelhorOpcaoC = itemAreaHorC?.ObterMaiorTamanho()
						!= Item.ObterMaiorLado() ? itensAreaHorC : itensAreaVerC;
				}
				else if (itensAreaHorC.Any())
				{
					itensAreaMelhorOpcaoC = itemAreaHorC?.ObterMaiorTamanho()
						!= Item.ObterMaiorLado() ? itensAreaHorC : new List<Recorte>();
				}
				else
				{
					itensAreaMelhorOpcaoC = itemAreaVerC?.ObterMaiorTamanho()
						!= Item.ObterMaiorLado() ? itensAreaVerC : new List<Recorte>();
				}
			}


			retorno.AddRange(itensAreaMelhorOpcaoL);
			retorno.AddRange(itensAreaMelhorOpcaoC);

			// Removendo canto sobreposto
			if (sobraX == 0)
			{

			}
			else if (sobraY == 0)
			{

			}

			return retorno;
		}

		public List<Recorte> ObterRecortesPorLado(double lado, double altura, double sobra, double comprimento, PosicaoItem posicaoItem, Posicao posicao)
		{
			var retorno = new List<Recorte>();

			if (sobra == 0)
			{
				return retorno;
			}

			var qtdLado = (int)comprimento / (int)lado;
			double restoLado = comprimento - (qtdLado * lado);

			var qtdAltura = (int)sobra / (int)altura;
			double restoAltura = sobra - (qtdAltura * altura);

			var valorAltura = qtdAltura > 0 ? altura : restoAltura;
			var valorLado = qtdLado > 0 ? lado : restoLado;

			if (qtdAltura == 0 && restoAltura > 0 && qtdLado == 0 && restoLado > 0)
			{
				var recorte = new Recorte(restoAltura, restoLado, posicaoItem, TipoRecorte.CortePrincipal, posicao);
				retorno.Add(recorte);

				return retorno;
			}
			else if (qtdAltura > 0 && qtdLado > 0)
			{
				for (int i = 0; i < qtdLado; i++)
				{
					for (int j = 0; j < qtdAltura; j++)
					{
						var recorte = new Recorte(valorAltura, valorLado, posicaoItem, TipoRecorte.CortePrincipal, posicao);
						retorno.Add(recorte);
					}
				}

				if (restoAltura > 0)
				{
					for (int j = 0; j < qtdAltura; j++)
					{
						var recorteComplementar = new Recorte(restoAltura, valorLado, posicaoItem, TipoRecorte.CorteComplementar, posicao);
						retorno.Add(recorteComplementar);
					}
				}
				if (restoLado > 0)
				{
					for (int j = 0; j < qtdLado; j++)
					{
						var recorteComplementar = new Recorte(valorAltura, restoLado, posicaoItem, TipoRecorte.CorteComplementar, posicao);
						retorno.Add(recorteComplementar);
					}
				}
			}
			else if (qtdAltura > 0 && qtdLado == 0)
			{
				for (int j = 0; j < qtdAltura; j++)
				{
					var recorte = new Recorte(valorAltura, valorLado, posicaoItem, TipoRecorte.CortePrincipal, posicao);
					retorno.Add(recorte);

					if (restoAltura > 0)
					{
						var recorteComplementar = new Recorte(restoAltura, valorLado, posicaoItem, TipoRecorte.CorteComplementar, posicao);
						retorno.Add(recorteComplementar);
					}
				}

			}
			else if (qtdAltura == 0 && qtdLado > 0)
			{
				for (int i = 0; i < qtdLado; i++)
				{
					var recorte = new Recorte(valorAltura, valorLado, posicaoItem, TipoRecorte.CortePrincipal, posicao);
					retorno.Add(recorte);

					if (restoLado > 0)
					{
						var recorteComplementar = new Recorte(valorAltura, restoLado, posicaoItem, TipoRecorte.CorteComplementar, posicao);
						retorno.Add(recorteComplementar);
					}
				}
			}

			return retorno;
		}

		public List<Recorte> ObterMelhorRecortesPorComparacao(List<Recorte> recortesA, List<Recorte> recortesB)
		{
			return recortesA.Count > recortesB.Count ? recortesB : recortesA;
		}
	}

	public class Recorte
	{
		public double TamanhoX { get; set; }
		public double TamanhoY { get; set; }
		public PosicaoItem PosicaoItem { get; set; }
		public TipoRecorte TipoRecorte { get; set; }
		public Posicao Posicao { get; set; }

		public Recorte(double tamanhoX, double tamanhoY, PosicaoItem posicaoItem, TipoRecorte tipoRecorte, Posicao posicao)
		{
			TamanhoX = tamanhoX;
			TamanhoY = tamanhoY;
			PosicaoItem = posicaoItem;
			TipoRecorte = tipoRecorte;
			Posicao = posicao;
		}

		public double ObterMaiorTamanho()
		{
			return TamanhoX > TamanhoY ? TamanhoX : TamanhoY;
		}
	}
}
