using SRLOCSistema.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRLOCSistema.Model
{
	public class Item : BaseModel
	{
		public string Nome { get; set; }
		public double Largura { get; set; }
		public double Comprimento { get; set; }
		public double LarguraEspacamento { get; set; }
		public double ComprimentoEspacamento { get; set; }
		public TipoCalculo TipoCalculo { get; set; }

		public void InverterComprimentoLargura()
		{
			double aux1, aux2;
			aux1 = Largura;
			aux2 = LarguraEspacamento;
			Largura = Comprimento;
			LarguraEspacamento = ComprimentoEspacamento;
			Comprimento = aux1;
			ComprimentoEspacamento = aux2;
		}

		public double ObterLargura()
		{
			return Largura + LarguraEspacamento;
		}

		public double ObterComprimento()
		{
			return Comprimento + ComprimentoEspacamento;
		}
		
		public bool ValidarCampos(string nome, string largura, string comprimento, string larguraEspacamento, string comprimentoEspacamento, string tipoCalculo)
		{
			int auxInt;

			if (string.IsNullOrEmpty(nome))
			{
				MessageBox.Show("Erro nos campos", "O campo nome deve ser preenchido corretamente");
				return false;
			}

			if (!int.TryParse(comprimento, out auxInt))
			{
				MessageBox.Show("Erro nos campos", "O campo comprimento deve ser preenchido corretamente");
				return false;
			}

			if (!int.TryParse(largura, out auxInt))
			{
				MessageBox.Show("Erro nos campos", "O campo largura deve ser preenchido corretamente");
				return false;
			}

			if (!int.TryParse(comprimentoEspacamento, out auxInt))
			{
				MessageBox.Show("Erro nos campos", "O campo comprimento espaçamento deve ser preenchido corretamente");
				return false;
			}

			if (!int.TryParse(larguraEspacamento, out auxInt))
			{
				MessageBox.Show("Erro nos campos", "O campo largura espaçamento deve ser preenchido corretamente");
				return false;
			}

			if (!int.TryParse(tipoCalculo, out auxInt))
			{
				MessageBox.Show("Erro nos campos", "O campo Tipo Calculo deve ser preenchido corretamente");
				return false;
			}

			if (auxInt < 0 || auxInt > 2)
			{
				MessageBox.Show("Erro nos campos", "O campo tipoCalculo deve ser preenchido corretamente");
				return false;
			}

			var tipoCalculoValidado = (TipoCalculo)auxInt;

			return ValidarCampos(nome, largura, comprimento, larguraEspacamento, comprimentoEspacamento, tipoCalculoValidado);
		}

		public bool ValidarCampos(string nome, string largura, string comprimento, string larguraEspacamento, string comprimentoEspacamento, TipoCalculo tipoCalculo)
		{
			if (string.IsNullOrEmpty(nome))
			{
				MessageBox.Show("Erro nos campos", "O campo nome deve ser preenchido");
				return false;
			}

			double auxDouble;

			if (!double.TryParse(largura, out auxDouble))
			{
				MessageBox.Show("Erro nos campos", "O campo largura deve ser preenchido corretamente");
				return false;
			}
			if (!double.TryParse(comprimento, out auxDouble))
			{
				MessageBox.Show("Erro nos campos", "O campo comprimento deve ser preenchido corretamente");
				return false;
			}
			if (!double.TryParse(larguraEspacamento, out auxDouble))
			{
				MessageBox.Show("Erro nos campos", "O campo largura espaçamento deve ser preenchido corretamente");
				return false;
			}
			if (!double.TryParse(comprimentoEspacamento, out auxDouble))
			{
				MessageBox.Show("Erro nos campos", "O campo comprimento espaçamento deve ser preenchido corretamente");
				return false;
			}

			Nome = nome;
			Largura = double.Parse(largura);
			Comprimento = double.Parse(comprimento);
			LarguraEspacamento = double.Parse(larguraEspacamento);
			ComprimentoEspacamento = double.Parse(comprimentoEspacamento);
			TipoCalculo = tipoCalculo;

			return true;
		}

		public double ObterMenorLado()
		{
			return Largura > Comprimento ? Comprimento : Largura;
		}

		public double ObterMaiorLado()
		{
			return Largura > Comprimento ? Largura : Comprimento;
		}
	}
}
