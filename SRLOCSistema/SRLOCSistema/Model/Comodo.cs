using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRLOCSistema.Model
{
	public class Comodo : BaseModel
	{
		public string Nome { get; set; }
		public double Largura { get; set; }
		public double Comprimento { get; set; }

		public bool ValidarCampos(string nome, string largura, string comprimento)
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

			Nome = nome;
			Largura = double.Parse(largura);
			Comprimento = double.Parse(comprimento);

			return true;
		}
	}
}
