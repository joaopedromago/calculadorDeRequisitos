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

		public bool ValidarCampos(string nome, string largura, string comprimento, string larguraEspacamento, string comprimentoEspacamento, string tipoCalculo)
		{
			int auxInt;

			if (!int.TryParse(comprimentoEspacamento, out auxInt))
			{
				MessageBox.Show("Erro nos campos", "O campo tipoCalculo deve ser preenchido corretamente");
				return false;
			}

			if (auxInt < 1 || auxInt > 2)
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
	}
}
